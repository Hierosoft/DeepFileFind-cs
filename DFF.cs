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
		public ListView resultsListView = null;
		public static readonly int COLUMNFLAG_IGNORE = -2;
		public bool enable = true;
		public bool finished = false;

		public static bool newline_detected_as_space_enable=false;
		public static readonly string datetime_sortable_format_string = "yyyy-MM-dd HH:mm";
		#region cache
		private string options_name_string_tolower = null;
		#endregion cache
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
		
		public bool get_is_match(FileInfo this_info, bool filenames_prefiltered_enable) {
			bool result = false;
            if (this_info != null) {
                try {
                    if (
						!this_info.Name.EndsWith (":")
						&& !this_info.Name.StartsWith ("Singleton")
                        && !this_info.Name.EndsWith ("Socket")
                       ) {
                        Console.WriteLine ("get_is_match(FileInfo,bool) '" + this_info.Name + "'...");
                        if (filenames_prefiltered_enable || string.IsNullOrEmpty (options.name_string) || (options.case_sensitive_enable ? this_info.Name.Contains (options.name_string) : this_info.Name.ToLower ().Contains (options_name_string_tolower))) {
                            //below is ok since time was manipulated if !options.endbefore_time_enable
                            //Console.WriteLine("file: "+this_info.LastWriteTime.ToUniversalTime().ToString(DFF.datetime_sortable_format_string));
                            //Console.WriteLine("endbefore: "+options.modified_endbefore_datetime_utc.ToUniversalTime().ToString(DFF.datetime_sortable_format_string));
                            //Console.WriteLine();
                            if (!options.modified_endbefore_date_enable || (this_info.LastWriteTime.ToUniversalTime () < options.modified_endbefore_datetime_utc.ToUniversalTime ())) {
                                if (!options.modified_start_date_enable || (this_info.LastWriteTime.ToUniversalTime () >= options.modified_start_datetime_utc.ToUniversalTime ())) {
                                    if (!options.min_size_enable || (this_info.Length >= options.min_size)) {
                                        if (!options.max_size_enable || (this_info.Length <= options.max_size)) {
                                            if (string.IsNullOrEmpty (options.content_string) || get_file_contains (this_info, options.content_string)) {
                                                result = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        Console.WriteLine ("...done get_is_match(FileInfo,bool)");
                    } else Console.Error.WriteLine ("get_is_match(FileInfo,bool): non-file-like name skipped");
                } catch (IOException ioEx) {
                    //ignore since probably a permission issue
                } catch {
                    //Console.Error.WriteLine ("Could not finish get_is_match: " + exn.ToString ());
                    Console.Error.WriteLine ("Could not finish get_is_match(FileInfo,bool).");
                }
            } else Console.Error.WriteLine ("get_is_match(FileInfo,bool):null");
			return result;
		}
		public bool get_is_match(DirectoryInfo this_info) {
			bool result = false;
            if (this_info != null) {
                Console.WriteLine ("get_is_match(DirectoryInfo) '" + this_info.Name + "'...");
                if (string.IsNullOrEmpty (options.name_string) || (options.case_sensitive_enable ? this_info.Name.Contains (options.name_string) : this_info.Name.ToLower ().Contains (options_name_string_tolower))) {
                    //below is ok since time was manipulated if !options.endbefore_time_enable
                    if (!options.modified_endbefore_date_enable || (this_info.LastWriteTime.ToFileTimeUtc () < options.modified_endbefore_datetime_utc.ToFileTimeUtc ())) {
                        if (!options.modified_start_date_enable || (this_info.LastWriteTime.ToFileTimeUtc () >= options.modified_start_datetime_utc.ToFileTimeUtc ())) {
                            result = true;
                        }
                    }
                }
            } else Console.Error.WriteLine ("get_is_match(DirectoryInfo):null");
			return result;
		}
		private bool get_is_folder_searchable(DirectoryInfo this_di, bool device_allow_enable)
		{
			bool result = false;
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
			finished = false;
			options.DumpToDebug();
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
			
			if (resultsListView!=null) resultsListView.Items.Clear();
			else results = new ArrayList();
			options_name_string_tolower = (options.name_string!=null) ? options.name_string.ToLower() : null;
			Console.Error.WriteLine("  Searching in "+options.start_directoryinfos.Count+" DirectoryInfo(s)");
			foreach (DirectoryInfo major_di in options.start_directoryinfos) {
				if (!enable) break;
                //NOTE: user-entered Locations are considered depth 0;
                Console.Error.WriteLine("    - "+major_di.FullName);
                ExecuteSearchRecursively(major_di, 0);
			}
			finished = true;
			if (options.statusTextBox!=null) {
				if (enable) {
					options.statusTextBox.Text="Finished {";
					if (options.modified_start_date_enable) options.statusTextBox.Text+=" ModStarting:"+options.modified_start_datetime_utc.ToString(DFF.datetime_sortable_format_string)+";";
					if (options.modified_endbefore_date_enable) options.statusTextBox.Text+=" ModBefore:"+options.modified_endbefore_datetime_utc.ToString(DFF.datetime_sortable_format_string)+";";
					options.statusTextBox.Text+="}";
				}
				else options.statusTextBox.Text="Cancelled";
			}
		}

		private void ExecuteSearchRecursively(DirectoryInfo major_di, int depth) {
            if (major_di!=null) {
				if (get_is_folder_searchable(major_di, true)) {
	                Console.WriteLine ("(depth=" + depth.ToString () + ") Searching in " + major_di.Name);
	                //crashes if on different thread:
	                if (options.statusTextBox != null) options.statusTextBox.Text = major_di.FullName;
	                Application.DoEvents ();
	                //Console.Error.WriteLine(major_di.FullName);
	                if (resultsListView != null) {
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
	
	                try {
	                    if (string.IsNullOrEmpty(this.options.name_string)) this.options.name_string = "*"; //prevents ContainsAny crash on next line
	                    bool filenames_prefiltered_enable = ContainsAny (this.options.name_string, wildcards);
	                    FileInfo [] major_di_files = filenames_prefiltered_enable ? major_di.GetFiles (this.options.name_string) : major_di.GetFiles ();
	                    //if (major_di_files!=null) {
	                    //	if (major_di_files.Length<=1) Console.Error.WriteLine(major_di_files.Length.ToString()+" file(s) in "+major_di.FullName);
	                    //}
	                    //else Console.Error.WriteLine("Could not list files in "+major_di.FullName);
	                    foreach (FileInfo this_fi in major_di_files) {
	                        if (!enable) break;
	                        try {
	                            if (get_is_match(this_fi, filenames_prefiltered_enable)) {
	                                if (resultsListView != null) {
	                                    string [] fields = new String [resultsListView.Columns.Count];
	                                    if (COLUMN_PATH >= 0) fields [COLUMN_PATH] = this_fi.FullName;
	                                    if (COLUMN_NAME >= 0) fields [COLUMN_NAME] = this_fi.Name;
	                                    if (COLUMN_MODIFIED >= 0) fields [COLUMN_MODIFIED] = this_fi.LastWriteTime.ToString (DFF.datetime_sortable_format_string);
	                                    if (COLUMN_CREATED >= 0) fields [COLUMN_CREATED] = this_fi.CreationTime.ToString (DFF.datetime_sortable_format_string);
	                                    if (COLUMN_EXTENSION >= 0) fields [COLUMN_EXTENSION] = this_fi.Extension;
	                                    resultsListView.Items.Add (new ListViewItem (fields));
	                                    Application.DoEvents ();
	                                }
	                                if (results != null) results.Add (this_fi.FullName);
	                            }
	                            //else Console.Error.WriteLine(this_fi.FullName+" does not match");
	                        } catch (Exception exn) {
	                            Console.Error.WriteLine ("Could not finish accessing file '" + this_fi.FullName + "': " + exn.ToString ());
	                        }
	                    }
	                    if (enable) {
	                        foreach (DirectoryInfo this_di in major_di.GetDirectories ()) {
	                            if (!enable) break;
	                            try {
	                                if (options.include_folders_as_results_enable) {
	                                    if (get_is_match (this_di)) {
	                                        if (resultsListView != null) {
	                                            string [] fields = new String [resultsListView.Columns.Count];
	                                            if (COLUMN_PATH >= 0) fields [COLUMN_PATH] = this_di.FullName;
	                                            if (COLUMN_NAME >= 0) fields [COLUMN_NAME] = this_di.Name;
	                                            if (COLUMN_MODIFIED >= 0) fields [COLUMN_MODIFIED] = this_di.LastWriteTime.ToString (DFF.datetime_sortable_format_string);
	                                            if (COLUMN_CREATED >= 0) fields [COLUMN_CREATED] = this_di.CreationTime.ToString (DFF.datetime_sortable_format_string);
	                                            if (COLUMN_EXTENSION >= 0) fields [COLUMN_EXTENSION] = "<Folder>";
	                                            resultsListView.Items.Add (new ListViewItem (fields));
	                                            Application.DoEvents ();
	                                        }
	                                        if (results != null) results.Add (this_di.FullName);
	                                    }
	                                }
	                                if (this.non_directory_paths == null || Array.IndexOf (this.non_directory_paths, this_di.FullName) <= -1) {
	                                    if (get_is_folder_searchable(this_di,false)) {
	                                        ExecuteSearchRecursively(this_di, depth+1);
	                                    }
	                                }
	                            } catch (Exception exn) {
	                                Console.Error.WriteLine ("Could not finish accessing subdirectory '" + this_di.FullName + "': " + exn.ToString ());
	                            }
	                        }
	                    }
	                } catch (Exception exn) {
	                    Console.Error.WriteLine ("Could not finish accessing folder '" + major_di.FullName + "': " + exn.ToString ());
	                }
				}
			 	else Console.Error.WriteLine("get_is_folder_searchable is false for " + major_di.FullName);
            }//end if get_is_folder_searchable
            else Console.Error.WriteLine("Null for " + major_di.FullName);
		}//end ExecuteSearchRecursively
		

	}//end class
}//end namespace
