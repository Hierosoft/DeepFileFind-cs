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

namespace DeepFileFind
{
	/// <summary>
	/// Description of DFF.
	/// </summary>
	public class DFF
	{
		public DFF()
		{
		}
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
		public static readonly string datetime_sortable_format_string = "yyyy-MM-dd HH:mm";
		#region cache
		private string options_name_string_tolower = null;
		#endregion cache
		
		public bool get_is_match(FileInfo this_info) {
			bool result = false;
			if (   string.IsNullOrEmpty(options.name_string)   ||   ( options.case_sensitive_enable ? this_info.Name.Contains(options.name_string) : this_info.Name.ToLower().Contains(options_name_string_tolower) )   ) {
				//below is ok since time was manipulated if !options.endbefore_time_enable
				Console.WriteLine("file: "+this_info.LastWriteTime.ToUniversalTime().ToString(DFF.datetime_sortable_format_string));
				Console.WriteLine("endbefore: "+options.modified_endbefore_datetime_utc.ToUniversalTime().ToString(DFF.datetime_sortable_format_string));
				Console.WriteLine();
				if (   !options.modified_endbefore_date_enable   ||   (  this_info.LastWriteTime.ToUniversalTime() < options.modified_endbefore_datetime_utc.ToUniversalTime() )   ) {
					if (   !options.modified_start_date_enable  ||   (  this_info.LastWriteTime.ToUniversalTime() >= options.modified_start_datetime_utc.ToUniversalTime() )   ) {
						result = true;
					}
				}
			}
			return result;
		}
		public bool get_is_match(DirectoryInfo this_info) {
			bool result = false;
			if (   string.IsNullOrEmpty(options.name_string)   ||   ( options.case_sensitive_enable ? this_info.Name.Contains(options.name_string) : this_info.Name.ToLower().Contains(options_name_string_tolower) )   ) {
				//below is ok since time was manipulated if !options.endbefore_time_enable
				if (   !options.modified_endbefore_date_enable   ||   (  this_info.LastWriteTime.ToFileTimeUtc() < options.modified_endbefore_datetime_utc.ToFileTimeUtc() )   ) {
					if (   !options.modified_start_date_enable  ||   (  this_info.LastWriteTime.ToFileTimeUtc() >= options.modified_start_datetime_utc.ToFileTimeUtc() )   ) {
						result = true;
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Uses keys in columns of listview (always case sensitively): Path, Modified, Created, Name, Extension; otherwise you must set the static COLUMN_ indices manually (set each COLUMN_ index to COLUMNFLAG_IGNORE to avoid searching through column keys for columns you don't want to use).
		/// </summary>
		/// <param name="results">If not null, is filled with result paths (usually null if resultsListView is present)</param>
		/// <param name="options"></param>
		/// <param name="resultsListView"></param>
		/// <returns>If resultsListView is present, returns null. Otherwise, returns ArrayList containing strings (directory and file paths)</returns>
		public void ExecuteSearch() {
			finished = false;
			options.DumpToConsole();
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
			foreach (DirectoryInfo major_di in options.start_directoryinfos) {
				if (!enable) break;
				ExecuteSearchRecursively(major_di);
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
		
		private void ExecuteSearchRecursively(DirectoryInfo major_di) {
			//crashes if on different thread:
			if (options.statusTextBox!=null) options.statusTextBox.Text=major_di.FullName;
			Application.DoEvents();
			//Console.Error.WriteLine(major_di.FullName);
			if (resultsListView!=null) {
				if (COLUMN_PATH<0 && COLUMN_PATH!=COLUMNFLAG_IGNORE) {
					COLUMN_PATH=resultsListView.Columns.IndexOfKey("Path");
					if (COLUMN_PATH<0) COLUMN_PATH=COLUMNFLAG_IGNORE;
				}
				if (COLUMN_NAME<0 && COLUMN_NAME!=COLUMNFLAG_IGNORE) {
					COLUMN_NAME=resultsListView.Columns.IndexOfKey("Name");
					if (COLUMN_NAME<0) COLUMN_NAME=COLUMNFLAG_IGNORE;
				}
				if (COLUMN_MODIFIED<0 && COLUMN_MODIFIED!=COLUMNFLAG_IGNORE) {
					COLUMN_MODIFIED=resultsListView.Columns.IndexOfKey("Modified");
					if (COLUMN_MODIFIED<0) COLUMN_MODIFIED=COLUMNFLAG_IGNORE;
				}
				if (COLUMN_CREATED<0 && COLUMN_CREATED!=COLUMNFLAG_IGNORE) {
					COLUMN_CREATED=resultsListView.Columns.IndexOfKey("Created");
					if (COLUMN_CREATED<0) COLUMN_CREATED=COLUMNFLAG_IGNORE;
				}
				if (COLUMN_EXTENSION<0 && COLUMN_EXTENSION!=COLUMNFLAG_IGNORE) {
					COLUMN_EXTENSION=resultsListView.Columns.IndexOfKey("Extension");
					if (COLUMN_EXTENSION<0) COLUMN_EXTENSION=COLUMNFLAG_IGNORE;
				}
			}
		
			try {
				
				foreach (FileInfo this_fi in major_di.GetFiles()) {
					if (!enable) break;
					try {
						if (get_is_match(this_fi)) {
							if (resultsListView!=null) {
								string[] fields = new String[resultsListView.Columns.Count];
								if (COLUMN_PATH>=0) fields[COLUMN_PATH]=this_fi.FullName;
								if (COLUMN_NAME>=0) fields[COLUMN_NAME]=this_fi.Name;
								if (COLUMN_MODIFIED>=0) fields[COLUMN_MODIFIED]=this_fi.LastWriteTime.ToString(DFF.datetime_sortable_format_string);
								if (COLUMN_CREATED>=0) fields[COLUMN_CREATED]=this_fi.CreationTime.ToString(DFF.datetime_sortable_format_string);
								if (COLUMN_EXTENSION>=0) fields[COLUMN_EXTENSION]=this_fi.Extension;
								resultsListView.Items.Add(new ListViewItem(fields));
								Application.DoEvents();
							}
							if (results!=null) results.Add(this_fi.FullName);
						}
					}
					catch (Exception exn) {
						Console.Error.WriteLine("Could not finish accessing file '"+this_fi.FullName+"': "+exn.ToString());
					}
				}
				if (enable) {
					foreach (DirectoryInfo this_di in major_di.GetDirectories()) {
						if (!enable) break;
						try {
							if (options.include_folders_as_results_enable) {
								if (get_is_match(this_di)) {
									if (resultsListView!=null) {
										string[] fields = new String[resultsListView.Columns.Count];
										if (COLUMN_PATH>=0) fields[COLUMN_PATH]=this_di.FullName;
										if (COLUMN_NAME>=0) fields[COLUMN_NAME]=this_di.Name;
										if (COLUMN_MODIFIED>=0) fields[COLUMN_MODIFIED]=this_di.LastWriteTime.ToString(DFF.datetime_sortable_format_string);
										if (COLUMN_CREATED>=0) fields[COLUMN_CREATED]=this_di.CreationTime.ToString(DFF.datetime_sortable_format_string);
										if (COLUMN_EXTENSION>=0) fields[COLUMN_EXTENSION]="<Folder>";
										resultsListView.Items.Add(new ListViewItem(fields));
										Application.DoEvents();
									}
									if (results!=null) results.Add(this_di.FullName);
								}
							}
							if (options.recursive_enable) ExecuteSearchRecursively(this_di);
						}
						catch (Exception exn) {
							Console.Error.WriteLine("Could not finish accessing subdirectory '"+this_di.FullName+"': "+exn.ToString());
						}
					}
				}
			}
			catch (Exception exn) {
				Console.Error.WriteLine("Could not finish accessing folder '"+major_di.FullName+"': "+exn.ToString());
			}
		}
		

	}
}
