/*
 * Created by SharpDevelop.
 * User: jgustafson
 * Date: 3/23/2017
 * Time: 6:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.Security.AccessControl; //for FileSystemAccessRule in mscorlib as per http://docs.go-mono.com/index.aspx?link=T%3ASystem.Security.AccessControl.FileSystemAccessRule
//using Mono.Unix;
//using System.Diagnostics; //System.Diagnostics.Debug.WriteLine etc

namespace DeepFileFind
{
	/// <summary>
	/// Description of DFF.
	/// </summary>
	public class DFF
	{
		public DFF()
		{
            if (Path.DirectorySeparatorChar=='/')
                non_directory_paths = new string []{"/dev", "/proc", "/sys", "/boot", "/run/udev"};
		}
        public string[] non_directory_paths = null;
		public static readonly char[] wildcards = new Char[] {'*','?'};
		public int COLUMN_PATH = -1;
		public int COLUMN_NAME = -1;
		public int COLUMN_MODIFIED = -1;
		public int COLUMN_CREATED = -1;
		public int COLUMN_EXTENSION = -1;
		public ArrayList results = null;
		public DFFSearchOptions options = null;
		private ListView resultsListView = null;
		private int ColumnCount = -1;
		public static readonly int COLUMNFLAG_IGNORE = -2;
		public bool enable = true;
		public bool finished = false;

		public static bool newline_detected_as_space_enable=false;
		public static readonly string datetime_sortable_format_string = "yyyy-MM-dd HH:mm";
		public long refreshTick = 0;
		public long refreshDelay = 10000;
		#region cache
		private string options_name_string_tolower = null;
		#endregion cache

		/// <summary>
		/// Set the list view if any. This must be called on the same thread
		/// as the ListView and the column names must already be set.
		/// </summary>
		/// <param name="box"></param>
		public void SetListView(ListView box) {
			resultsListView = box;
			ColumnCount = resultsListView.Columns.Count;
            if (COLUMN_PATH < 0 && COLUMN_PATH != COLUMNFLAG_IGNORE) {
                COLUMN_PATH = resultsListView.Columns.IndexOfKey ("Path");
                if (COLUMN_PATH < 0) COLUMN_PATH = COLUMNFLAG_IGNORE;
            }
            if (COLUMN_NAME < 0 && COLUMN_NAME != COLUMNFLAG_IGNORE) {
                COLUMN_NAME = resultsListView.Columns.IndexOfKey ("Name");
                if (COLUMN_NAME < 0) COLUMN_NAME = COLUMNFLAG_IGNORE;
            }
            if (COLUMN_MODIFIED < 0 && COLUMN_MODIFIED != COLUMNFLAG_IGNORE) {
                COLUMN_MODIFIED = resultsListView.Columns.IndexOfKey ("Modified");
                if (COLUMN_MODIFIED < 0) COLUMN_MODIFIED = COLUMNFLAG_IGNORE;
            }
            if (COLUMN_CREATED < 0 && COLUMN_CREATED != COLUMNFLAG_IGNORE) {
                COLUMN_CREATED = resultsListView.Columns.IndexOfKey ("Created");
                if (COLUMN_CREATED < 0) COLUMN_CREATED = COLUMNFLAG_IGNORE;
            }
            if (COLUMN_EXTENSION < 0 && COLUMN_EXTENSION != COLUMNFLAG_IGNORE) {
                COLUMN_EXTENSION = resultsListView.Columns.IndexOfKey ("Extension");
                if (COLUMN_EXTENSION < 0) COLUMN_EXTENSION = COLUMNFLAG_IGNORE;
            }
		}

		private static void ClearListView(ListView box) {
			// - tried <https://www.codeproject.com/questions/1073539/control-richtextbox-accessed-from-a-thread-other-t>
			
		    if (box.InvokeRequired)
	        {
		    	// System.Windows.Forms.MethodInvoker
		    	box.Invoke((MethodInvoker)(() => box.Items.Clear()));
	        }
	        else
	        {
	        	box.Items.Clear();
	        }
		}
		private void ClearList() {
			if (this.resultsListView != null) {
				ClearListView(this.resultsListView);
			}
		}
		private static void AddListViewItem(ListView box, ListViewItem item) {
			// - tried <https://www.codeproject.com/questions/1073539/control-richtextbox-accessed-from-a-thread-other-t>
			
		    if (box.InvokeRequired)
	        {
		    	// System.Windows.Forms.MethodInvoker
		    	box.Invoke((MethodInvoker)(() => box.Items.Add(item)));
	        }
	        else
	        {
	        	box.Items.Add(item);
	        }
		}
		public void AddItem(ListViewItem item) {
			if (this.resultsListView != null) {
				AddListViewItem(this.resultsListView, item);
			}
			else {
				// Console.Error.WriteLine();
			}
		}
		public static long NowMS() {
			return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
		}
		public static string get_indent(int depth, string tab) {
			string result = "";
			if (depth < 1) return "";
			for (int i=0; i<depth; i++) {
				result += tab;
			}
			return result;
		}
		public bool get_is_content_searchable(string path)
		{
			//see also etc/deprecated_cs.md for other ideas 
			bool result = true;
            try {
                //for another way (ioctl from libc, see also etc/FileProvider.cs
                FileAttributes attributes = File.GetAttributes(path);
                if ((attributes & FileAttributes.Device) == FileAttributes.Device) result = false;
                //else if ((attributes & FileAttributes.Archive)==FileAttributes.Archive) result = false;
                //else if ((attributes & FileAttributes.Compressed) == FileAttributes.Compressed) result = false; //just OS-level compression so its ok
				else if ((attributes & FileAttributes.Directory) == FileAttributes.Directory) result = false;
				//else if ((attributes & FileAttributes.Encrypted) == FileAttributes.Encrypted) result = false; //ok since I can probably try
				//else if ((attributes & FileAttributes.IntegrityStream) == FileAttributes.IntegrityStream) result = false;
				//else if ((attributes & FileAttributes.System) == FileAttributes.System) result = false;
                //else if ((attributes & FileAttributes.Temporary) == FileAttributes.Temporary) result = false;
				else if ((attributes & FileAttributes.Offline) == FileAttributes.Offline) result = false;
				if (!options.search_inside_hidden_files_enable && ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)) result = false;
			} catch { 
                result = false;
            }
            return result;
		}//end get_is_content_searchable
		public static bool ContainsAny(string Haystack, char[] Needles) {
			bool result=false;
			//char[] HaystackChars=Haystack.ToCharArray();
			for (int i=0; i<Needles.Length; i++) {
				for (int j=0; j<Haystack.Length; j++) {
					if (Haystack[j]==Needles[i]) {
						result=true;
						break;
					}
				}
				if (result) break;
			}
			return result;
		}
		
		public static bool get_file_contains(FileInfo this_info, string content_string) {
			bool result=false;
			StreamReader ins = null;
			string content_string_Substring=null;
			if (!string.IsNullOrEmpty(content_string)) {
				if (content_string.EndsWith(" ")) {
					content_string_Substring=content_string.Substring(0,content_string.Length-1);
				}
				try {
					ins = new StreamReader(this_info.FullName);
					string line;
					while ( (line=ins.ReadLine()) != null ) {
						//check if line contains it OR endswith substring (allows counting a newline as a space)
						if (  line.Contains(content_string)  ||  (newline_detected_as_space_enable&&(content_string_Substring!=null)&&line.Length>1&&line.Substring(0,line.Length-1).EndsWith(content_string_Substring))  ) {
							result=true;
							break;
						}
					}
					ins.Close();
				}
				catch (Exception exn) {
                    Console.Error.WriteLine ("Could not finish get_file_contains {filename:'" + this_info.FullName);
					//commented for debug only: Console.Error.WriteLine("Could not finish get_file_contains {filename:'"+this_info.FullName+"'}: "+exn.ToString());
					try {
						if (ins!=null) ins.Close();
					}
					catch {} //don't care
				}
			}
			return result;
		}
		
		public bool is_like(string haystack, string filter) {
			bool result = false;
			if (string.IsNullOrEmpty(filter)) {
				/*
				if (filter == null)
					Debug.WriteLine("  true any is_like(\""+haystack+"\", null)");
				else
					Debug.WriteLine("  true any is_like(\""+haystack+"\", \""+filter+"\")");
				*/
				return true;
			}
			if (filter == "*") {
				// Debug.WriteLine("  true any is_like(\""+haystack+"\", \""+filter+"\")");
				return true;
			}
			if (!options.case_sensitive_enable) {
				haystack = haystack.ToLower();
				filter = filter.ToLower();
			}
			if (filter.StartsWith("*") && filter.EndsWith("*")) {
				// Debug.WriteLine("  true is_like *filter* (\""+haystack+"\", \""+filter+"\")");
				return haystack.Contains(filter.Substring(1, filter.Length-2));
			}
			else if (filter.EndsWith("*")) {
				// Debug.WriteLine("  true startswith is_like(\""+haystack+"\", \""+filter+"\")");
				return haystack.StartsWith(filter.Substring(0, filter.Length-1));
			}
			else if (filter.StartsWith("*")) {
				// Debug.WriteLine("  true endswith is_like(\""+haystack+"\", \""+filter+"\")");
				return haystack.EndsWith(filter.Substring(1));
			}
			//else if (!filter.StartsWith("*") && !filter.EndsWith("*")) {
			// Debug.WriteLine("  "+(haystack.Contains(filter)?"true":"false")+" Contains is_like(\""+haystack+"\", \""+filter+"\")");
			return haystack.Contains(filter);
			//}
		}
		
		public bool get_is_match(FileInfo this_info, bool filenames_prefiltered_enable) {
			bool result = false;
            if (this_info == null) {
				string msg = "get_is_match(FileInfo,bool):null";
				Console.Error.WriteLine(msg);
				 Debug.WriteLine(msg);
				return false;
			}
            if (
				this_info.Name.EndsWith(":")
				|| this_info.Name.StartsWith("Singleton")
                || this_info.Name.EndsWith("Socket")
               ) {
                Debug.WriteLine("get_is_match(FileInfo,bool): non-file-like name skipped");
                return false;
			}
			
            try {
				// Debug.WriteLine("get_is_match(FileInfo,"+(filenames_prefiltered_enable?"true":"false")+") '" + this_info.Name + "'...");
                if (options_name_string_tolower==null&&options.name_string!=null) {
                	options_name_string_tolower=options.name_string.ToLower();
                    //;throw new ApplicationException("options_name_string_tolower was null but options.name_string was not (this should never happen)");
				}
                
				if (!filenames_prefiltered_enable) {
					if (!is_like(this_info.Name, options.name_string))
                		return false;
					else {
						/*
						if (options.name_string != null)
							Debug.WriteLine("  name matches \""+options.name_string+"\"");
						else
							Debug.WriteLine("  name matches null");
						*/
					}
				}
                // Comparisons below are ok since time was manipulated if !options.endbefore_time_enable
                if (options.modified_endbefore_date_enable && (this_info.LastWriteTime.ToUniversalTime () >= options.modified_endbefore_datetime_utc.ToUniversalTime()))
                    return false;
                if (options.modified_start_date_enable && (this_info.LastWriteTime.ToUniversalTime () < options.modified_start_datetime_utc.ToUniversalTime ()))
                    return false;
                if (options.min_size_enable && (this_info.Length < options.min_size))
                	return false;
                if (options.max_size_enable && (this_info.Length > options.max_size))
                	return false;
				if (string.IsNullOrEmpty(options.content_string) || (get_is_content_searchable(this_info.FullName)&&get_file_contains(this_info, options.content_string))) {
                	// It has to be a searchable file if content_string is used, and content_string must be found inside.
                	/*
                	if (!string.IsNullOrEmpty(options.content_string))
                		Debug.WriteLine("  content matches \""+options.content_string+"\"");
                		*/
                    result = true;
                }

            } catch (IOException ioEx) {
                //ignore since probably a permission issue
                Debug.WriteLine("  Error: get_is_match failed with IOException on "+this_info.Name+":"+ioEx.ToString());
			} catch (Exception exn) {
                //Console.Error.WriteLine ("Could not finish get_is_match: " + exn.ToString ());
                Console.Error.WriteLine ("Could not finish get_is_match(FileInfo,bool):"+exn.ToString());
                Debug.WriteLine("  Error: get_is_match failed with Exception on "+this_info.Name+":"+exn.ToString());
            }
			// Debug.WriteLine("  "+(result?"true":"false")+"...done get_is_match(FileInfo,bool)");
			return result;
		}
		public bool get_is_match(DirectoryInfo this_info) {
			bool result = false;
			if (this_info == null) {
				Console.Error.WriteLine ("get_is_match(DirectoryInfo=null):");
				Debug.WriteLine("get_is_match(DirectoryInfo=null):");
			}
            //Console.Error.WriteLine("get_is_match(DirectoryInfo) '" + this_info.Name + "'...");
            //Console.Error.WriteLine("  options.name_string:" + options.name_string);
            //Console.Error.WriteLine("  options_name_string_tolower: " + options_name_string_tolower);
            if (is_like(this_info.Name, options.name_string)) {
                //below is ok since time was manipulated if !options.endbefore_time_enable
                if (!options.modified_endbefore_date_enable || (this_info.LastWriteTime.ToFileTimeUtc () < options.modified_endbefore_datetime_utc.ToFileTimeUtc ())) {
                    if (!options.modified_start_date_enable || (this_info.LastWriteTime.ToFileTimeUtc () >= options.modified_start_datetime_utc.ToFileTimeUtc ())) {
                        result = true;
                    }
                	else {
                		// Debug.WriteLine("not after start date:");
                	}
                }
                else {
                	// Debug.WriteLine("not before end date:");
                }
            }
            else {
                // Debug.WriteLine("not like "+options.name_string+":");
            }
			return result;
		}
        public static bool ContainsI(ArrayList haystack, string needle) {
            bool result = false;
            if (haystack!=null) {
                needle = needle.ToLower();
                foreach (string s in haystack) {
                    if (s.ToLower()==needle) {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
		private bool get_is_folder_searchable(DirectoryInfo this_di, bool device_allow_enable)
		{
			bool result = false;
            if (options.never_use_names==null || !ContainsI(options.never_use_names, this_di.Name)) {
    			FileAttributes attributes = FileAttributes.Normal;
    			if (this_di != null) {
    				try {
                        if (
                            !this_di.Name.EndsWith (":")
                            &&!this_di.Name.StartsWith("Singleton")
    						&& !this_di.Name.EndsWith ("Socket")
    					   ) {
                            Console.WriteLine ("get_is_folder_searchable:" + this_di.Name);
                            //if (!follow_folder_symlinks_enable
                            //							|| !follow_system_folders_enable
                            //							|| !follow_hidden_folders_enable
                            //							|| !follow_temporary_folders_enable
                            //						   )
                            attributes = File.GetAttributes(this_di.FullName);
                            if (options.recursive_enable
                                && (options.follow_folder_symlinks_enable || !((attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint))
                                && ((options.follow_system_folders_enable || device_allow_enable) || !((attributes & FileAttributes.System) == FileAttributes.System))
                                && (options.follow_hidden_folders_enable || !((attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
                                && (options.follow_temporary_folders_enable || !((attributes & FileAttributes.Temporary) == FileAttributes.Temporary))
                                && (device_allow_enable || !((attributes & FileAttributes.Device) == FileAttributes.Device))
                                && (options.follow_dot_folders_enable || !this_di.Name.StartsWith ("."))
                                && !((attributes & FileAttributes.Offline) == FileAttributes.Offline)
                               ) {
                                result = true;
                            }
                            else {
                            	if ((attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint) Console.Error.WriteLine("    not searchable since ReparsePoint: "+this_di.FullName);
                            	else if ((attributes & FileAttributes.System) == FileAttributes.System) Console.Error.WriteLine("    not searchable since System: "+this_di.FullName);
                            	else if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden) Console.Error.WriteLine("    not searchable since Hidden: "+this_di.FullName);
                            	else if ((attributes & FileAttributes.Temporary) == FileAttributes.Temporary) Console.Error.WriteLine("    not searchable since Temporary: "+this_di.FullName);
                            	else if ((attributes & FileAttributes.Offline) == FileAttributes.Offline) Console.Error.WriteLine("    not searchable since Offline: "+this_di.FullName);
                            	else if ((attributes & FileAttributes.Device) == FileAttributes.Device) Console.Error.WriteLine("    not searchable since Device: "+this_di.FullName);
                            	else Console.Error.WriteLine("    not searchable for unknown reason (this should never happen)");
                            }
                        }
    					else {
                            Console.Error.WriteLine("Skipped non-folderlike name: " + this_di.Name);
                        }
    				}
    				catch {
    					Console.Error.WriteLine("Could not finish get_is_folder_searchable " + this_di.FullName);
    					//ignore since probably a privelege issue or non-folder specified
    				}
    			}
    			else Console.Error.WriteLine("get_is_folder_searchable:null");
            }
			return result;
		}
		/// <summary>
		/// Uses keys in columns of listview (always case sensitively): Path, Modified, Created, Name, Extension; otherwise you must set the static COLUMN_ indices manually (set each COLUMN_ index to COLUMNFLAG_IGNORE to avoid searching through column keys for columns you don't want to use).
		/// The calling program is responsible for warning the user of nonsensical values, such as max_size less than min_size or dates that are unusable for same reason.
		/// </summary>
		/// <param name="results">If not null, is filled with result paths (usually null if resultsListView is present)</param>
		/// <param name="options"></param>
		/// <param name="resultsListView"></param>
		/// <returns>If resultsListView is present, returns null. Otherwise, returns ArrayList containing strings (directory and file paths)</returns>
		public void ExecuteSearch() {
			this.refreshTick = 0;
			finished = false;
			options.DumpToDebug();
			string err = null;
			if (options.modified_endbefore_date_enable) {
				if (!options.modified_endbefore_time_enable) {
					options.modified_endbefore_datetime_utc = DateTime.FromFileTimeUtc((new DateTime(options.modified_endbefore_datetime_utc.Year, options.modified_endbefore_datetime_utc.Month, options.modified_endbefore_datetime_utc.Day, 0,0,0)).ToFileTimeUtc());
				}
			}
			if (options.modified_start_date_enable) {
				if (!options.modified_start_time_enable) {
					options.modified_start_datetime_utc = DateTime.FromFileTimeUtc((new DateTime(options.modified_start_datetime_utc.Year, options.modified_start_datetime_utc.Month, options.modified_start_datetime_utc.Day, 0,0,0)).ToFileTimeUtc());
				}
			}
			
			if (resultsListView!=null) this.ClearList();
			else results = new ArrayList();
			options_name_string_tolower = (options.name_string!=null) ? options.name_string.ToLower() : null;
			Console.Error.WriteLine("  Searching in "+options.start_directoryinfos.Count+" DirectoryInfo(s)");
			foreach (DirectoryInfo major_di in options.start_directoryinfos) {
				if (!enable) break;
                //NOTE: user-entered Locations are considered depth 0;
                Console.Error.WriteLine("    - "+major_di.FullName);
                string this_err = ExecuteSearchRecursively(major_di, 0);
                if (this_err!=null) {
                	if (err==null) err = "";
                	else err+="; ";
                	err += this_err;
                }
			}
			finished = true;
			if (enable) {
				string msg = "Finished {";
				if (err!=null) msg += " error:"+err+";";
				if (options.modified_start_date_enable) msg += " ModStarting:"+options.modified_start_datetime_utc.ToString(DFF.datetime_sortable_format_string)+";";
				if (options.modified_endbefore_date_enable) msg +=" ModBefore:"+options.modified_endbefore_datetime_utc.ToString(DFF.datetime_sortable_format_string)+";";
				msg += "}";
				options.SetStatus(msg);
			}
			else options.SetStatus("Cancelled");
		}
		

		private string ExecuteSearchRecursively(DirectoryInfo major_di, int depth) {
			string err = null;
            if (major_di!=null) {
                if (depth == 0 || get_is_folder_searchable(major_di, true)) {
	                Console.WriteLine ("(depth=" + depth.ToString () + ") Searching in " + major_di.Name);
	                //crashes if on different thread:
	                options.SetStatus(major_di.FullName);
	                if (DFF.NowMS() - refreshTick > refreshDelay) {
	                	Application.DoEvents();
	                	refreshTick = DFF.NowMS();
	                }
	                //Console.Error.WriteLine(major_di.FullName);
					string participle="preparing to check for matches in '"+major_di.FullName+"'";
                    if (string.IsNullOrEmpty(this.options.name_string)) this.options.name_string = "*"; //prevents ContainsAny crash on next line
                    bool filenames_prefiltered_enable = ContainsAny(this.options.name_string, wildcards);
                    FileInfo [] major_di_files = null;  // new FileInfo[] {};
                    try {
                    	major_di_files = filenames_prefiltered_enable ? major_di.GetFiles(this.options.name_string) : major_di.GetFiles ();
                    }
                    catch (System.UnauthorizedAccessException exn) {
                    	err = "UnauthorizedAccessException:\""+major_di.FullName+"\"";
                    	return err; // Stop trying to traverse files (or subdirectories further down)
                    }
                    //if (major_di_files!=null) {
                    //	if (major_di_files.Length<=1) Console.Error.WriteLine(major_di_files.Length.ToString()+" file(s) in "+major_di.FullName);
                    //}
                    //else Console.Error.WriteLine("Could not list files in "+major_di.FullName);
                    participle="checking for matches in '"+major_di.FullName+"'";
                    foreach (FileInfo this_fi in major_di_files) {
                        if (!enable) break;
                        participle="checking for match '"+this_fi.FullName+"'";
                        try {
                            if (get_is_match(this_fi, filenames_prefiltered_enable)) {
                                if (resultsListView != null) {
                        			//participle="creating fields array '"+this_fi.FullName+"'";
                                    string [] fields = new String [this.ColumnCount];
                                    //participle="setting path '"+this_fi.FullName+"'";
                                    if (COLUMN_PATH >= 0) fields [COLUMN_PATH] = this_fi.FullName;
                                    if (COLUMN_NAME >= 0) fields [COLUMN_NAME] = this_fi.Name;
                                    if (COLUMN_MODIFIED >= 0) fields [COLUMN_MODIFIED] = this_fi.LastWriteTime.ToString (DFF.datetime_sortable_format_string);
                                    if (COLUMN_CREATED >= 0) fields [COLUMN_CREATED] = this_fi.CreationTime.ToString (DFF.datetime_sortable_format_string);
                                    if (COLUMN_EXTENSION >= 0) fields [COLUMN_EXTENSION] = this_fi.Extension;
                                    participle="adding fields for "+((fields!=null)?("'"+this_fi.Name+"'"):("null"));
                                    this.AddItem(new ListViewItem(fields));
					                if (DFF.NowMS() - refreshTick > refreshDelay) {
					                	Application.DoEvents();
					                	refreshTick = DFF.NowMS();
					                }
                                }
                        		if (results != null) {
                        			participle="adding results";
                        			results.Add(this_fi.FullName);
                        		}
                            }
                            //else Console.Error.WriteLine(this_fi.FullName+" does not match");
                        } catch (Exception exn) {
                            Console.Error.WriteLine("Could not finish accessing file while "+participle+" in ExecuteSearchRecursively '" + this_fi.FullName + "': " + exn.ToString ());
                        }
                    }
                    if (enable) {
                    	participle = "getting directory list for '"+major_di.FullName+"'";
                        foreach (DirectoryInfo this_di in major_di.GetDirectories ()) {
                    		participle = "preparing to check (under major directory) in directory '"+this_di.FullName+"'";
                    		// Debug.WriteLine(participle);
                            if (!enable) break;
                            try {
                                if (options.include_folders_as_results_enable) {
                            		participle = "checking for match (under major directory)";
                                    if (get_is_match(this_di)) {
                                        if (resultsListView != null) {
                            				participle = "creating fields array";
                                            string [] fields = new String [this.ColumnCount];
                                            if (COLUMN_PATH >= 0) fields [COLUMN_PATH] = this_di.FullName;
                                            if (COLUMN_NAME >= 0) fields [COLUMN_NAME] = this_di.Name;
                                            participle = "converting modified date to string";
                                            if (COLUMN_MODIFIED >= 0) fields [COLUMN_MODIFIED] = this_di.LastWriteTime.ToString(DFF.datetime_sortable_format_string);
                                            participle = "converting created date to string";
                                            if (COLUMN_CREATED >= 0) fields [COLUMN_CREATED] = this_di.CreationTime.ToString(DFF.datetime_sortable_format_string);
                                            if (COLUMN_EXTENSION >= 0) fields [COLUMN_EXTENSION] = "<Folder>";
                                            participle = "creating ListViewItem";
                                            this.AddItem(new ListViewItem(fields));
							                if (DFF.NowMS() - refreshTick > refreshDelay) {
							                	Application.DoEvents();
							                	refreshTick = DFF.NowMS();
							                }
                                        }
                            			if (results != null) {
                            				participle = "adding result";
                            				results.Add(this_di.FullName);
                            			}
                            			participle = "done checking for match (under major directory)";
                                    }
                                }
                                if (this.non_directory_paths == null || Array.IndexOf (this.non_directory_paths, this_di.FullName) <= -1) {
                                    if (get_is_folder_searchable(this_di, false)) {
                            			/*
                            			if (get_is_match(this_di)) {
                            				Debug.WriteLine(get_indent(depth, "  ")+"++ "+this_di.Name);
                            				// Add folders, not just directories, if not matching content.
                            				participle = "adding a folder result";
                            				if (this_di==null)
                            					Debug.WriteLine("ERROR: this_di is null");
                            				if (results != null) {
                            					results.Add(this_di.FullName);
                            				}
                            			}
                            			else {
                            				Debug.WriteLine(get_indent(depth, "  ")+"+ "+this_di.Name);
                            			}
                            			*/
                            			// ^ already done in the previous case if include_folders_as_results_enable
                                        string subResult = ExecuteSearchRecursively(this_di, depth+1);
                                        if (subResult != null) {
                                        	if (err == null) err = subResult;
                                        	else err += ". " + subResult;
                                        }
                                        
                                        // Debug.WriteLine shows in the SharpDevelop "Output" panel.
                                        // - but only in Debug configuration!
                                    }
                            		else {
                                        Debug.WriteLine(get_indent(depth, "  ")+"- (not searchable)"+this_di.Name);
                            		}
                                }
                        		else {
                                    Debug.WriteLine(get_indent(depth, "  ")+"- (non-directory)"+this_di.Name);
                        		}
                            } catch (Exception exn) {
                            	if (depth==0) err = exn.ToString();
                            	string msg = "Could not finish accessing subdirectory while "+participle+" in ExecuteSearchRecursively '" + this_di.FullName + "': " + exn.ToString ();
                                Debug.WriteLine(get_indent(depth, "  ")+"- ("+exn.ToString()+")"+this_di.Name);
                            	if (err == null) err = msg;
                            	else err += ". " + msg;
                                Console.Error.WriteLine(msg);
                            }
                        }
                    }
                    else {
                    	Debug.WriteLine("- (enable==false) " + major_di.FullName);
                    }
                    /*
	                } catch (Exception exn) {
						Debug.WriteLine("- ("+exn.ToString()+") " + major_di.FullName);
	                	if (depth==0) err = exn.ToString();
	                	string msg = "Could not finish accessing folder '" + major_di.FullName + "': " + exn.ToString ();
                    	if (err == null) err = msg;
                    	else err += ". " + msg;
	                    Console.Error.WriteLine(msg);
	                }
	                */
				}
				else {
					string msg = "get_is_folder_searchable is false for " + major_di.FullName;
					Debug.WriteLine(msg);
                    //if (depth==0) err = "not a normal folder: '" + major_di.FullName + "'";
                	if (err == null) err = msg;
                	else err += ". " + msg;
					Console.Error.WriteLine(msg);
				}
            }//end if get_is_folder_searchable
			else {
				if (depth==0) err = "null path";
				Console.Error.WriteLine("Null for " + major_di.FullName);
			}
			return err;
		}//end ExecuteSearchRecursively
	}//end class
}//end namespace
