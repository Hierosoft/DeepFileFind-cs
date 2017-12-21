/*
 * Created by SharpDevelop.
 * User: jgustafson
 * Date: 3/23/2017
 * Time: 5:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
//using System.Diagnostics; //System.Diagnostics.Debug.WriteLine etc

namespace DeepFileFind
{
	/// <summary>
	/// Description of DFFSearchOptions.
	/// </summary>
	public class DFFSearchOptions
	{
		/// <summary>
		/// MUST be UTC
		/// </summary>
		public DateTime modified_start_datetime_utc = DateTime.MinValue;
		/// <summary>
		/// MUST be UTC
		/// </summary>
		public DateTime modified_endbefore_datetime_utc = DateTime.MaxValue;
		public bool modified_start_date_enable = false;
		public bool modified_endbefore_date_enable = false;
		public bool modified_start_time_enable = false;
		public bool modified_endbefore_time_enable = false;
		public ArrayList start_directoryinfos = null;
        public ArrayList never_use_names = null;
		public string name_string = null;
		public string content_string = null;
		public bool recursive_enable = true;
		public bool include_folders_as_results_enable = true;
		public bool case_sensitive_enable = false;
		public bool threading_enable = false;
		public bool min_size_enable = false;
		public bool max_size_enable = false;
		public long min_size = 0;
		public long max_size = long.MaxValue;
		public System.Windows.Forms.TextBox statusTextBox = null;
		
        public bool follow_folder_symlinks_enable = false;
		public bool search_inside_hidden_files_enable = false;
		public bool follow_dot_folders_enable = true;
        public bool follow_hidden_folders_enable = true;
		public bool follow_system_folders_enable = false;
		public bool follow_temporary_folders_enable = false;
		
		public DFFSearchOptions()
		{
			start_directoryinfos = new ArrayList();
            never_use_names = new ArrayList();
            never_use_names.Add(".cache");
            never_use_names.Add("Trash");
		}
		
		public void DumpToDebug() {
			Console.Error.WriteLine("Dumping options:");
			
			foreach (string s in Dump()) {
				Console.Error.WriteLine(s);
			}
			Console.Error.WriteLine("");
		}
		public ArrayList Dump() {
			ArrayList results = new ArrayList();
			//NOTE: these MUST match the values from MainFormLoad in order for all settings to save and load
			results.Add("start_date_enable = "+(modified_start_date_enable?"true":"false"));
			results.Add("start_time_enable = "+(modified_start_time_enable?"true":"false"));
			results.Add("start_datetime_utc = "+modified_start_datetime_utc.ToUniversalTime().ToString(DFF.datetime_sortable_format_string));
			results.Add("endbefore_date_enable = "+(modified_endbefore_date_enable?"true":"false"));
			results.Add("endbefore_time_enable = "+(modified_endbefore_time_enable?"true":"false"));
			results.Add("endbefore_datetime_utc = "+modified_endbefore_datetime_utc.ToUniversalTime().ToString(DFF.datetime_sortable_format_string));
			results.Add("recursive_enable = "+(recursive_enable?"true":"false"));
			results.Add("include_folders_as_results_enable = "+(include_folders_as_results_enable?"true":"false"));
			results.Add("case_sensitive_enable = "+(case_sensitive_enable?"true":"false"));
			results.Add("min_size_enable = "+(min_size_enable?"true":"false"));
			results.Add("max_size_enable = "+(max_size_enable?"true":"false"));
			results.Add("min_size = "+min_size.ToString());
			results.Add("max_size = "+max_size.ToString());
			string line = "start_directoryinfos = ";
			foreach (DirectoryInfo di in start_directoryinfos) {
				line += di.FullName+";";
			}
			results.Add(line);
			results.Add("name_string = "+(name_string!=null?"\""+name_string+"\"":"null"));
			results.Add("content_string = "+(content_string!=null?"\""+content_string+"\"":"null"));
			
			return results;
		}
	}
	
}
