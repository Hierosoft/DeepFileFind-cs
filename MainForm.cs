﻿/*
 * Created by SharpDevelop.
 * User: jgustafson
 * Date: 3/23/2017
 * Time: 4:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;
using System.Globalization;
using System.Diagnostics;
//using System.Diagnostics; //System.Diagnostics.Debug.WriteLine etc
	
namespace DeepFileFind
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private static string thisprogram_name = "DeepFileFind";
		private static string thisprogram_name_and_version = "DeepFileFind";
		private static string folders_thisprogram_name = "DeepFileFind";
		private DFF dff = null;
		private Thread this_thread = null;
		public static string date_format_string = "yyyy-MM-dd";
		public static string datetime_format_string = "yyyy-MM-dd hh:mm tt";
		//see also DFF.datetime_sortable_format_string
		public static string appdata_thisprogram_path = null;
		private static string recent_folders_list_name = "recent_folders.txt";
		public static string recent_folders_list_path = null;
		private static string settings_name = "settings.yml";
		public static string startup_path = null;
		public static string settings_path = null;
		public int RESULT_NAME_COLUMN_INDEX = -1;
		public int RESULT_MODIFIED_COLUMN_INDEX = -1;
		public int RESULT_CREATED_COLUMN_INDEX = -1;
		public int RESULT_PATH_COLUMN_INDEX = -1;
		public int RESULT_EXTENSION_COLUMN_INDEX = -1;
		public Dictionary<string, string> settings = new Dictionary<string, string>();
		public ListViewColumnSorter lvwColumnSorter;
		public bool version_then_exit = false;
		public bool contentCBUpdating = true;  // true until done loading settings
		public Color highlightColor = Color.Yellow;
		public Color defaultColor = Color.Black;  // set to *invalid (black)* until later
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.defaultColor = this.statusTextBox.BackColor;
			Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			thisprogram_name_and_version = thisprogram_name + " " + version;
			this.Text = thisprogram_name_and_version;
			appdata_thisprogram_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), folders_thisprogram_name);
			if (!Directory.Exists(appdata_thisprogram_path)) Directory.CreateDirectory(appdata_thisprogram_path);
			recent_folders_list_path = Path.Combine(appdata_thisprogram_path, recent_folders_list_name);
			settings_path = Path.Combine(appdata_thisprogram_path, settings_name);
			//loaded on MainFormLoad
			this.lvwColumnSorter = new ListViewColumnSorter();
			this.resultsListView.ListViewItemSorter = this.lvwColumnSorter;
			// ^ It still flickers without this.
			SetDoubleBuffered(this.resultsListView, true);
			this.contentCBUpdating = false;  // true again when loading settings
			this.updateDatePickers();
		}

	    /// <summary>
	    /// Sets the double buffered property of a list view to the specified value
	    /// (Based on <https://stackoverflow.com/a/42389596/4541104>).
	    /// </summary>
	    /// <param name="listView">The List view</param>
	    /// <param name="doubleBuffered">Double Buffered or not</param>
	    public static void SetDoubleBuffered(System.Windows.Forms.ListView listView, bool doubleBuffered)
	    {
	        listView
	            .GetType()
	            .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
	            .SetValue(listView, doubleBuffered, null);
	    }
		
		public void setSearchAvailability(bool enable) {
			findButton.Enabled=enable;
			findButton.Visible=enable;
			cancelButton.Enabled=!enable;
			cancelButton.Visible=!enable;
			nameTextBox.Enabled=enable;
			foldersCheckBox.Enabled=enable;
			recursiveCheckBox.Enabled=enable;
			locationComboBox.Enabled=enable;
			contentCheckBox.Enabled=enable;
			contentTextBox.Enabled=enable;
			modifiedStartDateCheckBox.Enabled=enable;
			modifiedEndBeforeDateCheckBox.Enabled=enable;
			minSizeCheckBox.Enabled=enable;
			maxSizeCheckBox.Enabled=enable;
			minSizeTextBox.Enabled=enable;
			maxSizeTextBox.Enabled=enable;
			search_inside_hidden_files_enableCB.Enabled=enable;
			follow_system_folders_enableCB.Enabled=enable;
			follow_folder_symlinks_enableCB.Enabled=enable;
			follow_temporary_folders_enableCB.Enabled=enable;
			follow_dot_folders_enableCB.Enabled=enable;
			follow_hidden_folders_enableCB.Enabled=enable;
			
		}

		
		public void updateDatePickers() {
			if (modifiedStartTimeCheckBox.Checked) modifiedStartDTPicker.CustomFormat = datetime_format_string;
			else modifiedStartDTPicker.CustomFormat = date_format_string;
			if (modifiedEndBeforeTimeCheckBox.Checked) modifiedEndBeforeDTPicker.CustomFormat = datetime_format_string;
			else modifiedEndBeforeDTPicker.CustomFormat = date_format_string;
			
			if (modifiedStartDateCheckBox.Checked) {
				modifiedStartDTPicker.Enabled=true;
				modifiedStartTimeCheckBox.Enabled=true;
			}
			else {
				modifiedStartDTPicker.Enabled=false;
				modifiedStartTimeCheckBox.Enabled=false;
			}
			if (modifiedEndBeforeDateCheckBox.Checked) {
				modifiedEndBeforeDTPicker.Enabled=true;
				modifiedEndBeforeTimeCheckBox.Enabled=true;
			}
			else {
				modifiedEndBeforeDTPicker.Enabled=false;
				modifiedEndBeforeTimeCheckBox.Enabled=false;
			}
		    if (contentCheckBox.Checked)
		    {
		        contentTextBox.Enabled = true;
		        foldersCheckBox.Font = new Font(foldersCheckBox.Font, FontStyle.Strikeout); // Set font style to normal
		    }
		    else
		    {
		        contentTextBox.Enabled = false;
		        foldersCheckBox.Font = new Font(foldersCheckBox.Font, FontStyle.Regular); // Set font style to strikethrough
		    }
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			if (version_then_exit) {
				string[] parts = this.Text.Split();
				if (parts.Length > 1) {
					Console.WriteLine(parts[1]);
					Application.Exit();
				}
				else {
					MessageBox.Show("--version couldn't be shown because"
					                + " there is no version in the MainForm title"
					                + " (this.Text=\""+this.Text+"\".", "Error");
				}
			}

			updateDatePickers();
			if (File.Exists(recent_folders_list_path)) {
				StreamReader ins = new StreamReader(recent_folders_list_path);
				string line;
				while ( (line=ins.ReadLine()) != null ) {
					line = line.Trim();
					if (!String.IsNullOrEmpty(line)) {
						locationComboBox.Items.Add(line);
					}
				}
				ins.Close();
			}
			string userprofile_path=Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			try {
				DirectoryInfo personalDI = new DirectoryInfo(userprofile_path);
				if (personalDI.Name.ToLower()=="documents") {
					userprofile_path=personalDI.Parent.FullName;
				}
			}
			catch {} //don't care
			if (locationComboBox.Text.Trim()=="") {
				if (locationComboBox.Items.Count>0) {
					locationComboBox.Text=locationComboBox.Items[0].ToString();
				}
				else locationComboBox.Text=userprofile_path;
			}
			//try {
				//string try_path="\\\\FCAFILES\\student";
				//if (Directory.Exists(try_path)) locationComboBox.Text=try_path;
			//}
			//catch {} //don't care
			LoadSettings();
			GenerateColumns();

			if (startup_path!=null) {
				if (startup_path.Length>=2 && startup_path.StartsWith("\"") && startup_path.EndsWith("\"")) {
					startup_path = startup_path.Substring(1, startup_path.Length-2);
				}
				locationComboBox.Text = startup_path;
			}
			if (!hasLocation(locationComboBox.Text)) locationComboBox.Items.Add(locationComboBox.Text);
			
		}
		void LoadSettings() {
			this.contentCBUpdating = true;
			if (File.Exists(settings_path)) {
				StreamReader ins = new StreamReader(settings_path);
				string line;
				while ( (line=ins.ReadLine()) != null ) {
					line = line.Trim();
					if (!String.IsNullOrEmpty(line)) {
						string ao = ":"; //assignment operator
						int ao_index = line.IndexOf(ao);
						if (ao_index>0) {
							string name = line.Substring(0,ao_index).Trim();
							string val = null;
							if (ao_index+1<line.Length) val = line.Substring(ao_index+1);
							settings[name] = val;
						}
					}
				}
				ins.Close();
			}
			if (settings.ContainsKey("modified_start_time_enable")) modifiedStartTimeCheckBox.Checked = (settings["modified_start_time_enable"]=="true"?true:false);
			else modifiedStartTimeCheckBox.Checked = false;
			if (settings.ContainsKey("modified_start_date_enable")) modifiedStartDateCheckBox.Checked = (settings["modified_start_date_enable"]=="true"?true:false);
			else modifiedStartDateCheckBox.Checked = false;
			modifiedStartDTPicker.CustomFormat = modifiedStartTimeCheckBox.Checked ? datetime_format_string : date_format_string;
			if (settings.ContainsKey("modified_start_datetime_utc")) {
				try {
					DateTime tmp_datetime = DateTime.ParseExact(settings["modified_start_datetime_utc"], datetime_format_string+" UTC", CultureInfo.InvariantCulture);
					tmp_datetime = tmp_datetime.ToLocalTime();//TimeZoneInfo.ConvertTimeToUtc(tmp_datetime, TimeZoneInfo.Utc); //NOTE: DateTimeKind does NOT work
					if (settings.ContainsKey("modified_start_datetime_utc")) modifiedStartDTPicker.Value = DateTime.Parse( tmp_datetime.ToString(modifiedStartDTPicker.CustomFormat) );
				}
				catch {
					try {
						DateTime tmp_datetime = DateTime.Parse(settings["modified_start_datetime_utc"]);
						tmp_datetime = tmp_datetime.ToLocalTime();
						//if (settings.ContainsKey("modified_start_datetime_utc")) modifiedStartDTPicker.Value = DateTime.Parse( DateTime.ParseExact(settings["modified_start_datetime_utc"],date_format_string,CultureInfo.InvariantCulture).ToString(modifiedStartDTPicker.CustomFormat) );
						modifiedStartDTPicker.Value = DateTime.Parse( tmp_datetime.ToString(modifiedStartDTPicker.CustomFormat) );
					}
					catch (Exception exn) {
						statusTextBox.Text = "Could not finish interpreting date " + settings["modified_start_datetime_utc"];
						Console.Error.WriteLine(exn.ToString());
					}
				}
			}
			modifiedStartDTPicker.Enabled = modifiedStartDateCheckBox.Checked;

			if (settings.ContainsKey("modified_endbefore_time_enable")) modifiedEndBeforeTimeCheckBox.Checked = (settings["modified_endbefore_time_enable"]=="true"?true:false);
			else modifiedEndBeforeTimeCheckBox.Checked = false;
			if (settings.ContainsKey("modified_endbefore_date_enable")) modifiedEndBeforeDateCheckBox.Checked = (settings["modified_endbefore_date_enable"]=="true"?true:false);
			else modifiedEndBeforeDateCheckBox.Checked = false;
			modifiedEndBeforeDTPicker.CustomFormat = modifiedEndBeforeTimeCheckBox.Checked ? datetime_format_string : date_format_string;
			if (settings.ContainsKey("modified_endbefore_datetime_utc")) {
				try {
					DateTime tmp_datetime = DateTime.ParseExact(settings["modified_endbefore_datetime_utc"], datetime_format_string+" UTC", CultureInfo.InvariantCulture);
					//if (tmp_datetime.Kind != DateTimeKind.Utc) MessageBox.Show("Date Did not load as UTC");
					tmp_datetime = tmp_datetime.ToLocalTime();//TimeZoneInfo.ConvertTimeToUtc(utc_datetime, TimeZoneInfo.Utc);
					modifiedEndBeforeDTPicker.Value = DateTime.Parse( tmp_datetime.ToString(modifiedEndBeforeDTPicker.CustomFormat) );
				}
				catch {
					//if (settings.ContainsKey("modified_endbefore_datetime_utc")) modifiedEndBeforeDTPicker.Value = DateTime.Parse( DateTime.ParseExact(settings["modified_endbefore_datetime_utc"],date_format_string,CultureInfo.InvariantCulture).ToString(modifiedEndBeforeDTPicker.CustomFormat) );
					try {
						DateTime tmp_datetime = DateTime.Parse(settings["modified_endbefore_datetime_utc"]);
						tmp_datetime = tmp_datetime.ToLocalTime();
						if (settings.ContainsKey("modified_endbefore_datetime_utc")) modifiedEndBeforeDTPicker.Value = DateTime.Parse( tmp_datetime.ToString(modifiedEndBeforeDTPicker.CustomFormat) );
					}
					catch (Exception exn) {
						statusTextBox.Text = "Could not finish interpreting date " + settings["modified_endbefore_datetime_utc"];
						Console.Error.WriteLine(exn.ToString());
					}
				}
			}
			modifiedEndBeforeDTPicker.Enabled = modifiedEndBeforeDateCheckBox.Checked;
			
			if (settings.ContainsKey("include_folders_as_results_enable")) foldersCheckBox.Checked = (settings["include_folders_as_results_enable"]=="true"?true:false);
			else modifiedEndBeforeDateCheckBox.Checked = false;
			if (settings.ContainsKey("recursive_enable")) recursiveCheckBox.Checked = (settings["recursive_enable"]=="true"?true:false);
			else recursiveCheckBox.Checked = true;
			if (settings.ContainsKey("content_enable")) contentCheckBox.Checked = (settings["content_enable"]=="true")?true:false;
			else contentCheckBox.Checked = false;
			if (settings.ContainsKey("name")) nameTextBox.Text = settings["name"];
			if (settings.ContainsKey("content_string")) contentTextBox.Text = settings["content_string"];
			if (settings.ContainsKey("min_size_enable")) minSizeCheckBox.Checked = (settings["min_size_enable"]=="true"?true:false);
			if (settings.ContainsKey("max_size_enable")) maxSizeCheckBox.Checked = (settings["max_size_enable"]=="true"?true:false);
			if (settings.ContainsKey("min_size")) minSizeTextBox.Text = settings["min_size"];
			if (settings.ContainsKey("max_size")) maxSizeTextBox.Text = settings["max_size"];
			if (settings.ContainsKey("exclude_names")) excludeTextBox.Text = settings["exclude_names"];
			if (!settings.ContainsKey("follow_dot_folders_enable")) settings["follow_dot_folders_enable"] = "true"; //true by default
			if (!settings.ContainsKey("follow_hidden_folders_enable")) settings["follow_hidden_folders_enable"] = "true"; //true by default

			if (settings.ContainsKey("follow_folder_symlinks_enable")) follow_folder_symlinks_enableCB.Checked = (settings["follow_folder_symlinks_enable"]=="true"?true:false);
			if (settings.ContainsKey("search_inside_hidden_files_enable")) search_inside_hidden_files_enableCB.Checked = (settings["search_inside_hidden_files_enable"]=="true"?true:false);
			if (settings.ContainsKey("follow_dot_folders_enable")) follow_dot_folders_enableCB.Checked = (settings["follow_dot_folders_enable"]=="true"?true:false);
			if (settings.ContainsKey("follow_hidden_folders_enable")) follow_hidden_folders_enableCB.Checked = (settings["follow_hidden_folders_enable"]=="true"?true:false);
			if (settings.ContainsKey("follow_system_folders_enable")) follow_system_folders_enableCB.Checked = (settings["follow_system_folders_enable"]=="true"?true:false);
			if (settings.ContainsKey("follow_temporary_folders_enable")) follow_temporary_folders_enableCB.Checked = (settings["follow_temporary_folders_enable"]=="true"?true:false);
			contentTextBox.Enabled = contentCheckBox.Checked;
			contentTextBox.Enabled = contentCheckBox.Checked;
			this.contentCBUpdating = false;
		}
		
		void GenerateColumns() {
			resultsListView.Columns.Add("Path", "Path", (int)((double)this.Width*.35+.5));
			RESULT_PATH_COLUMN_INDEX = resultsListView.Columns.Count-1;
			resultsListView.Columns.Add("Extension", "Extension", (int)((double)this.Width*.08+.5));
			RESULT_EXTENSION_COLUMN_INDEX = resultsListView.Columns.Count-1;
			resultsListView.Columns.Add("Modified", "Modified", (int)((double)this.Width*.16+.5));
			RESULT_MODIFIED_COLUMN_INDEX = resultsListView.Columns.Count-1;
			resultsListView.Columns.Add("Created", "Created", (int)((double)this.Width*.16+.5));
			RESULT_CREATED_COLUMN_INDEX = resultsListView.Columns.Count-1;
			resultsListView.Columns.Add("Name", "Name", (int)((double)this.Width*.1+.5));
			RESULT_NAME_COLUMN_INDEX = resultsListView.Columns.Count-1;
		}
		
		void StartDateCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			updateDatePickers();
		}
		
		void EndbeforeDateCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			updateDatePickers();
		}
		
		void StartTimeCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			updateDatePickers();
		}
		
		void EndbeforeTimeCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			updateDatePickers();
		}
		
		void FindToolStripMenuItemClick(object sender, EventArgs e)
		{
			ExecuteSearch();
		}
		void FindButtonClick(object sender, EventArgs e)
		{
			ExecuteSearch();
		}
		public void CancelSearch() {
			cancelButton.Enabled=false;
			cancelButton.Visible=false;
			if (dff!=null) {
				if (this_thread != null) {
					statusTextBox.Text="waiting for previous thread to stop...";
					dff.enable = false;
					Application.DoEvents();
					while (this_thread.IsAlive) {
						Thread.Sleep(100);
						Application.DoEvents();
					}
					statusTextBox.Text="";
					Application.DoEvents();
					/*
					if (this.this_thread != null) {
						if (this.this_thread.IsAlive) {
							this.this_thread.Abort();
						}
					}
					*/
					
				}
				else {
					statusTextBox.Text="waiting for previous operation to stop...";
					dff.enable = false;
					Application.DoEvents();
					//while (!dff.finished) {
					//	Thread.Sleep(100);
					//	Application.DoEvents();
					//}
					//statusTextBox.Text="";
				}
			}
			setSearchAvailability(true);
		}
		public bool hasLocation(string needle) {
			bool result=false;
			foreach (string s in locationComboBox.Items) {
				if (s==needle) {
					result=true;
					break;
				}
			}
			return result;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="size_string">either a number of bytes, or a number ending with G, GB, M, MB, K, or KB (capitalization does not matter).</param>
		/// <returns>A plain number (if could be parsed) otherwize returns the value of the original parameter</returns>
		public static string get_byte_count_string(string size_string) {
			long i;
			if (!string.IsNullOrEmpty(size_string)) {
				if (size_string.ToLower().EndsWith("gb") || size_string.ToLower().EndsWith("g")) {
					int cut_len = 2;
					if (size_string.ToLower().EndsWith("g")) cut_len=1;
					decimal d;
					if (decimal.TryParse(size_string.Substring(0,size_string.Length-cut_len).Trim(), out d)) {
						i = (long)decimal.Ceiling(d*1024.0M*1024.0M*1024.0M);
						size_string = i.ToString();
					}
				}
				else if (size_string.ToLower().EndsWith("mb") || size_string.ToLower().EndsWith("m")) {
					int cut_len = 2;
					if (size_string.ToLower().EndsWith("m")) cut_len=1;
					decimal d;
					if (decimal.TryParse(size_string.Substring(0,size_string.Length-cut_len).Trim(), out d)) {
						i = (long)decimal.Ceiling(d*1024.0M*1024.0M);
						size_string = i.ToString();
					}
				}
				else if (size_string.ToLower().EndsWith("kb") || size_string.ToLower().EndsWith("k")) {
					int cut_len = 2;
					if (size_string.ToLower().EndsWith("k")) cut_len=1;
					decimal d;
					if (decimal.TryParse(size_string.Substring(0,size_string.Length-cut_len).Trim(), out d)) {
						i = (long)decimal.Ceiling(d*1024.0M);
						size_string = i.ToString();
					}
				}
			}
			return size_string;
		}
		public void SaveSettings() {
			statusTextBox.Text="Saving settings...";
			Application.DoEvents();
			StreamWriter outs = new StreamWriter(recent_folders_list_path);
			ArrayList uniqueAL = new ArrayList();
			outs.WriteLine(locationComboBox.Text);
			uniqueAL.Add(locationComboBox.Text);
			foreach (string line in locationComboBox.Items) {
				if (!uniqueAL.Contains(line)) {
					outs.WriteLine(line);
					uniqueAL.Add(line);
				}
			}
			outs.Close();
			
			outs = new StreamWriter(settings_path);
			settings["modified_start_date_enable"] = modifiedStartDateCheckBox.Checked?"true":"false";
			settings["modified_start_time_enable"] = modifiedStartTimeCheckBox.Checked?"true":"false";
			settings["modified_start_datetime_utc"] = modifiedStartDTPicker.Value.ToUniversalTime().ToString(datetime_format_string+" UTC");
			settings["modified_endbefore_date_enable"] = modifiedEndBeforeDateCheckBox.Checked?"true":"false";
			settings["modified_endbefore_time_enable"] = modifiedEndBeforeTimeCheckBox.Checked?"true":"false";
			settings["modified_endbefore_datetime_utc"] = modifiedEndBeforeDTPicker.Value.ToUniversalTime().ToString(datetime_format_string+" UTC");
			settings["include_folders_as_results_enable"] = foldersCheckBox.Checked?"true":"false";
			settings["content_enable"] = contentCheckBox.Checked?"true":"false";
			settings["recursive_enable"] = recursiveCheckBox.Checked?"true":"false";
			settings["content_string"] = contentTextBox.Text;
			settings["exclude_names"] = excludeTextBox.Text;
			settings["name"] = nameTextBox.Text;
			settings["min_size_enable"] = minSizeCheckBox.Checked?"true":"false";
			settings["max_size_enable"] = maxSizeCheckBox.Checked?"true":"false";
			settings["min_size"] = minSizeTextBox.Text;
			settings["max_size"] = maxSizeTextBox.Text;
			settings["follow_folder_symlinks_enable"] = follow_folder_symlinks_enableCB.Checked?"true":"false";
			settings["search_inside_hidden_files_enable"] = search_inside_hidden_files_enableCB.Checked?"true":"false";
			settings["follow_dot_folders_enable"] = follow_dot_folders_enableCB.Checked?"true":"false";
			settings["follow_hidden_folders_enable"] = follow_hidden_folders_enableCB.Checked?"true":"false";
			settings["follow_system_folders_enable"] = follow_system_folders_enableCB.Checked?"true":"false";
			settings["follow_temporary_folders_enable"] = follow_temporary_folders_enableCB.Checked?"true":"false";
			foreach(KeyValuePair<string, string> entry in settings) {
				outs.WriteLine(entry.Key+":"+entry.Value);
			}
			outs.Close();
			
			statusTextBox.Text="";
			
		}
		public void ExecuteSearch() {
			SaveSettings();
			//MessageBox.Show(new String (System.IO.Path.InvalidPathChars));
			if ( nameTextBox.Text.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0) { //Path.InvalidPathChars is obsoleted by Microsoft //if (!nameTextBox.Text.Contains("*") && !nameTextBox.Text.Contains("?") && )
				MessageBox.Show("Usage of these characters is not implemented. Please enter all or part of a valid filename.");
				return;
			}
			if (!hasLocation(locationComboBox.Text)) locationComboBox.Items.Add(locationComboBox.Text);
			//findButton.Enabled=false;
			//findButton.Visible=false;
			//cancelButton.Visible=true;
			//cancelButton.Enabled=true;
			setSearchAvailability(false);
			if (this_thread!=null) {
				dff.enable = false;
				statusTextBox.Text="waiting for previous operation to stop...";
				Application.DoEvents();
				while (this_thread.IsAlive) Thread.Sleep(1);
				statusTextBox.Text="";
				Application.DoEvents();
			}
			dff = new DFF();
			dff.options = new DFFSearchOptions();
			locationComboBox.Text = locationComboBox.Text.Trim();
			if (locationComboBox.Text.Length < 1) {
				MessageBox.Show("Search directory must be specified");
				return;
			}
            string[] location_strings = null;
            try {
                if (Directory.Exists(locationComboBox.Text)) {
                    //in case is one path but includes path separator (such as ":" in gvfs paths on GNU OS)
                    location_strings = new string[] {locationComboBox.Text};
                }
            }
            catch (Exception exn) {
                MessageBox.Show("ERROR: could not finish checking gvfs path due to " + exn.ToString(), "DeepFileFind");
            }
            if (location_strings==null) location_strings = locationComboBox.Text.Split(Path.PathSeparator);
			
			bool folders_all_ok_enable = true;
			ArrayList bad_paths = new ArrayList();
			foreach (string original_location_string in location_strings) {
				string location_string = original_location_string;
				Console.Error.WriteLine("Searching in location_string:"+location_string);
				if (Path.DirectorySeparatorChar=='\\'&&location_string.EndsWith(":")) location_string+="\\"; //otherwise directory info will be current working directory instead!
				DirectoryInfo this_di = new DirectoryInfo(location_string);
				if (this_di.Exists) {
					Console.Error.WriteLine("  adding as "+this_di.FullName);
					dff.options.start_directoryinfos.Add(this_di);
				}
				else {
					folders_all_ok_enable=false;
					Console.Error.WriteLine("  does not exist so adding as bad path.");
					bad_paths.Add(location_string);
				}
			}

			if (!folders_all_ok_enable) {
				string bad_paths_string = "";
				foreach (string bad_path in bad_paths) {
					bad_paths_string += ((bad_paths_string=="")?"":"; ") + bad_path;
				}
				MessageBox.Show("Cannot search due to nonexistant directory(ies): "+bad_paths_string);
				return;
			}
			dff.options.modified_start_date_enable=modifiedStartDateCheckBox.Checked;
			dff.options.modified_start_time_enable=modifiedStartTimeCheckBox.Checked;
			dff.options.min_size_enable=minSizeCheckBox.Checked;
			dff.options.max_size_enable=maxSizeCheckBox.Checked;
			string[] sarr = excludeTextBox.Text.Trim().Split(',');
			dff.options.never_use_names.Clear();
			for (int nun_i=0; nun_i<sarr.Length; nun_i++) {
				string nun = sarr[nun_i].Trim();
				if (nun.Length>1 && nun[0]=='"' && nun[nun.Length-1]=='"') {
					nun = nun.Substring(1, nun.Length-2);
				}
				else if (nun.Length>1 && nun[0]=='\'' && nun[nun.Length-1]=='\'') {
					nun = nun.Substring(1, nun.Length-2);
				}
				if (nun.Length>0) {
					dff.options.never_use_names.Add(nun);
					Console.Error.WriteLine("Excluding '" + nun + "'");
				}
			}
			
			dff.options.follow_folder_symlinks_enable=follow_folder_symlinks_enableCB.Checked;
			dff.options.search_inside_hidden_files_enable=search_inside_hidden_files_enableCB.Checked;
			dff.options.follow_dot_folders_enable=follow_dot_folders_enableCB.Checked;
			dff.options.follow_hidden_folders_enable=follow_hidden_folders_enableCB.Checked;
			dff.options.follow_system_folders_enable=follow_system_folders_enableCB.Checked;
			dff.options.follow_temporary_folders_enable=follow_temporary_folders_enableCB.Checked;
			long i;
			string min_size_byte_count_string = get_byte_count_string(minSizeTextBox.Text.Trim());
			minSizeLabel.Text="bytes: "+min_size_byte_count_string;
			string max_size_byte_count_string = get_byte_count_string(maxSizeTextBox.Text.Trim());
			if (long.TryParse(min_size_byte_count_string, out i)) dff.options.min_size=i;
			if (long.TryParse(max_size_byte_count_string, out i)) dff.options.max_size=i;
			if (modifiedStartDateCheckBox.Checked) {
				dff.options.modified_start_datetime_utc=modifiedStartDTPicker.Value; //DateTime.FromFileTimeUtc(modifiedStartDTPicker.Value.ToFileTimeUtc());
			}
			dff.options.modified_endbefore_date_enable=modifiedEndBeforeDateCheckBox.Checked;
			dff.options.modified_endbefore_time_enable=modifiedEndBeforeTimeCheckBox.Checked;
			if (modifiedEndBeforeDateCheckBox.Checked) {
				dff.options.modified_endbefore_datetime_utc=modifiedEndBeforeDTPicker.Value; //DateTime.FromFileTimeUtc(modifiedEndBeforeDTPicker.Value.ToFileTimeUtc());
			}
			//NOTE: time is set to 0,0,0 during ExecuteSearch if time is not enabled
			
			if (!string.IsNullOrEmpty(nameTextBox.Text.Trim())) dff.options.name_string=nameTextBox.Text;
			//else already null since new object, so do nothing
			if (contentCheckBox.Checked && !string.IsNullOrEmpty(contentTextBox.Text.Trim())) dff.options.content_string=contentTextBox.Text;
			//else already null since new object, so do nothing
			dff.options.include_folders_as_results_enable=foldersCheckBox.Checked && !contentCheckBox.Checked;
			dff.options.recursive_enable=recursiveCheckBox.Checked;
			dff.SetListView(this.resultsListView);
			dff.options.SetStatusTextBox(this.statusTextBox);
			bool queued = false;
			if (dff.options.min_size_enable && dff.options.max_size_enable && dff.options.max_size<dff.options.min_size) {
				statusTextBox.Text="WARNING: max is less than min (nothing to find)";
			}
			else if (dff.options.modified_endbefore_date_enable && dff.options.modified_start_date_enable && dff.options.modified_endbefore_datetime_utc <= dff.options.modified_start_datetime_utc) {
				statusTextBox.Text="WARNING: \"endbefore\" is less than or equal to start date (nothing to find)";
				statusTextBox.BackColor = this.highlightColor;  // reverts to defaultColor on next change
				// using System.Media;
				// SystemSounds.Hand.Play();
				System.Media.SystemSounds.Asterisk.Play();
			}
			else {
				if (dff.options.threading_enable) {
					this_thread = new Thread(dff.ExecuteSearch);
					this_thread.Start();
					statusTextBox.Text="Searching (1 thread)...";
					Console.Error.WriteLine(statusTextBox.Text);
					Application.DoEvents();
					timer1.Enabled=true;
					timer1.Start();
					queued = true;
				}
				else {
					statusTextBox.Text="Searching...";
					Console.Error.WriteLine(statusTextBox.Text);
					dff.ExecuteSearch();
					//findButton.Visible=true;
					//findButton.Enabled=true;
					//cancelButton.Visible=false;
					//cancelButton.Enabled=false;
				}
			}
			//while (this_thread.IsAlive) Thread.Sleep(1);
			//foreach (FileInfo this_fi in results) {
			//	string[] fields = new String[resultsListView.Columns.Count];
			//	for (int i=0; i<this_item.Length; i++) fields[i]="";
			//	fields[RESULT_CREATED_COLUMN_INDEX] = 
			//	resultsListView.Items.Add(new ListViewItem(fields));
			//}
			if (!queued)
				setSearchAvailability(true);
		}
		
		void ContentCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			updateDatePickers();
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			CancelSearch();
			SaveSettings();
		}
		
		void CancelButtonClick(object sender, EventArgs e)
		{
			CancelSearch();
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			if (!dff.enable || dff.finished) {
				timer1.Enabled=false;
				timer1.Stop();
				statusTextBox.Text="Finished.";
				Application.DoEvents();
				//cancelButton.Enabled=false;
				//cancelButton.Visible=false;
				//findButton.Enabled=true;
				//findButton.Visible=true;
				setSearchAvailability(true);
			}
		}
		
		/// <summary>
		/// works with .NET versions before Core as per
		/// <https://stackoverflow.com/a/5117005>.
		/// To detect Windows on .NET 5+, you can do
		/// OperatingSystem.IsWindows() as per
		/// <https://stackoverflow.com/a/72815578>.
		/// "The first versions of the framework (1.0 and 1.1) didn't
		/// include any PlatformID value for Unix, so Mono used the value 128.
		/// The newer framework 2.0 added Unix to the PlatformID enum but,
		/// sadly, with a different value: 4 and newer versions of .NET
		/// distinguished between Unix and macOS, introducing yet another
		/// value 6 for macOS.
		/// </summary>
		public static bool IsWindows
		{
		    get
		    {
		        int p = (int)Environment.OSVersion.Platform;
		        bool IsLinux = (p == 4) || (p == 128); // 128 for old Mono on Linux
		        bool IsMacOS = (p == 6);
		        return !IsLinux && !IsMacOS;
		    }
		}
		
		void ResultsListViewDoubleClick(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in resultsListView.SelectedItems) {
				string path = lvi.SubItems[RESULT_PATH_COLUMN_INDEX].Text;
				// if (IsWindows) {
				if (false) {
					// as per <https://stackoverflow.com/a/54275102>
					// Process.Start("explorer", "\"" + path + "\"");
					// ^ fails with "Application not found",
					//   even if run using Start, Run & pasting path to py file!
				}
				else {
					ProcessStartInfo psi = new ProcessStartInfo(path);
					try {
						// System.Diagnostics.Process.Start(path);
						// ^ Still causes "Application not found"
						//   so try:
						if (Array.Exists(psi.Verbs, element => element == "open")) {
							psi.Verb = "open";
							// There *still* can be a condition where it causes
							// "Application not found" :( where Windows' default
							// program no longer exists (and, in this case,
							// Windows 10 will not provide the "Always use"
							// checkbox :( so it is stuck that way without
							// registry editing.							
						}
						
						// psi.Arguments = "\"" + path + "\"";
						Process.Start(psi);
					}
					catch(Exception exn) {
						string verbs = string.Join(", ", psi.Verbs);
						MessageBox.Show("Your OS' default program for the file type"
						                + " seems to no longer exist. Due to a bug in Windows,"
						                + " this makes the \"Always use\" checkbox not appear"
						                + " so you must edit the registry to fix this :("
						                + " or right-click the file in Explorer,"
						                + " then \"Open With\""
						                + " then \"Choose another app\", and make sure."
						                + " \"Always use this app to open...\" is checked before continuing."
						                + "\n\nVerbs="+verbs+"\n"+"Verb="+psi.Verb+"\n"+exn.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						/*
						if (Array.Exists(psi.Verbs, element => element == "editwithidle")) {
							psi.Verb = "editwithidle";
							// There *still* can be a condition where it causes
							// "Application not found" :( where Windows' default
							// program no longer exists (and, in this case,
							// Windows 10 will not provide the "Always use"
							// checkbox :( so it is stuck that way without
							// registry editing.
							Process.Start(psi);
							// ^ causes "System.ComponentModel.Win32Exception: No application is associated with the specified file for this operation"
						} else if (Array.Exists(psi.Verbs, element => element == "Edit with IDLE")) {
							psi.Verb = "Edit with IDLE";
							// There *still* can be a condition where it causes
							// "Application not found" :( where Windows' default
							// program no longer exists (and, in this case,
							// Windows 10 will not provide the "Always use"
							// checkbox :( so it is stuck that way without
							// registry editing.
							Process.Start(psi);
							// ^ causes "System.ComponentModel.Win32Exception: No application is associated with the specified file for this operation"
						}
						*/
					}
				}
			}
		}
		
		void OpenContainingFolderTSMIClick(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in resultsListView.SelectedItems) {
				FileInfo this_fi = new FileInfo(lvi.SubItems[RESULT_PATH_COLUMN_INDEX].Text);
				System.Diagnostics.Process.Start(this_fi.Directory.FullName);
			}
		}
		
		void OpenTSMIClick(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in resultsListView.SelectedItems) {
				System.Diagnostics.Process.Start(lvi.SubItems[RESULT_PATH_COLUMN_INDEX].Text);
			}
		}
		void CopyFilePathTSMIClick(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in resultsListView.SelectedItems) {
				//FileInfo this_fi = new FileInfo(lvi.SubItems[RESULT_PATH_COLUMN_INDEX].Text);
				Clipboard.SetText(lvi.SubItems[RESULT_PATH_COLUMN_INDEX].Text);
				break;
			}
		}
		
		void ResultsListViewItemDrag_BROKEN_KEEPS_CURSOR_X_FOREVER(object sender, ItemDragEventArgs e)
		{
			if (this.resultsListView.SelectedItems.Count>0) {
				string[] files = new String[this.resultsListView.SelectedItems.Count];
				int index=0;
				foreach (ListViewItem thisLVI in this.resultsListView.SelectedItems) {
					files[index] = thisLVI.SubItems[resultsListView.Columns.IndexOfKey("Path")].ToString();
					index++;
				}
				DataObject dataObject = new DataObject(DataFormats.FileDrop, files);
				DoDragDrop(dataObject, DragDropEffects.Copy);
				Application.DoEvents();
			}			
		}
		
		void ResultsListViewDragDrop_BROKEN_FREEZES(object sender, DragEventArgs e)
		{
		    if (!e.Data.GetDataPresent(DataFormats.FileDrop)) 
		    {
		        return;
		    }
		
		    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
		    foreach (string file in files)
		    {
		        //string dest = homeFolder + "\\" + Path.GetFileName(file);
		        bool isFolder = Directory.Exists(file);
		        bool isFile = File.Exists(file);
		        if (!isFolder && !isFile)
		        // Ignore if it doesn't exist
		            continue;
		
		        try
		        {
		            switch(e.Effect)
		            {
		                case DragDropEffects.Copy:
		                    //if(isFile)
		                    // TODO: Need to handle folders
		                        //File.Copy(file, dest, false);
		                    break;
		                case DragDropEffects.Move:
		                    //if (isFile)
		                        //File.Move(file, dest);
		                    break;
		                case DragDropEffects.Link:
		                // TODO: Need to handle links
		                    break;
		            }
		        }
		        catch(IOException ex)
		        {
		            MessageBox.Show(this, "Failed to perform the" + 
		              " specified operation:\n\n" + ex.Message, 
		              "File operation failed", MessageBoxButtons.OK, 
		              MessageBoxIcon.Stop);
		        }
		    }
		}
		
		
		void ResultsListViewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.C && e.Control) {
				if (resultsListView.SelectedItems.Count>0) {
					//string[] files = new String[this.resultsListView.SelectedItems.Count];
					//int index=0;
					string paths = "";
					foreach (ListViewItem thisLVI in this.resultsListView.SelectedItems) {
						string this_path = thisLVI.SubItems[resultsListView.Columns.IndexOfKey("Path")].Text;
						if (paths.Length > 0) paths += Environment.NewLine;
						paths += this_path;
						// Clipboard.SetText(this_path);
						// break;
						//files[index] = this_path;
						//index++;
					}
					Clipboard.SetText(paths);
				}
				else Clipboard.SetText("");
			}
		}
		
		
		
		void NameTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) {
				ExecuteSearch();
			}
			
		}
		
		void ContentTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) {
				ExecuteSearch();
			}
			
		}
		
		void ResultsListViewColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Determine if clicked column is already the column that is being sorted.
			if ( e.Column == lvwColumnSorter.SortColumn )
			{
			// Reverse the current sort direction for this column.
				if (lvwColumnSorter.Order == SortOrder.Ascending)
				{
					lvwColumnSorter.Order = SortOrder.Descending;
				}
				else
				{
					lvwColumnSorter.Order = SortOrder.Ascending;
				}
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				lvwColumnSorter.SortColumn = e.Column;
				lvwColumnSorter.Order = SortOrder.Ascending;
			}
			
			// Perform the sort with these new sort options.
			this.resultsListView.Sort();
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("This program is released under the terms of the GNU General Public Licence version 3.0. \n\nAll source code for the original project is available at: https://github.com/Hierosoft/DeepFileFind",thisprogram_name_and_version);
		}
		
		void DeleteResultsToolStripMenuItemClick(object sender, EventArgs e)
		{
			DialogResult dr = DialogResult.Yes;
			dr = MessageBox.Show("This will really delete the files, not just in this program. Everywhere! Are you REALLY sure?","DeepFileFind", MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes) {
				for (int i=this.resultsListView.Items.Count-1; i>=0; i--) {
					ListViewItem item = resultsListView.Items[i];
					try {
						if (File.Exists(item.SubItems[RESULT_PATH_COLUMN_INDEX].Text)) {
							File.Delete(item.SubItems[RESULT_PATH_COLUMN_INDEX].Text);
							resultsListView.Items.RemoveAt(i);
						}
						else {
							if (Directory.Exists(item.SubItems[RESULT_PATH_COLUMN_INDEX].Text)) Console.Error.WriteLine("      purposely skipping delete since is a directory: "+item.SubItems[RESULT_PATH_COLUMN_INDEX].Text);
							else Console.Error.WriteLine("      purposely skipping delete since doesn't exist: "+item.SubItems[RESULT_PATH_COLUMN_INDEX].Text);
						}
					}
					catch (Exception exn) {
						Console.Error.WriteLine("      Could not finish deleting file '"+item.SubItems[RESULT_PATH_COLUMN_INDEX].Text+"':"+exn.ToString());
					}
				}
			}
		}
		
		void SaveResultsToolStripMenuItemClick(object sender, EventArgs e)
		{
			DialogResult dr = saveFileDialog.ShowDialog();
			if (dr == DialogResult.OK) {
				if (saveFileDialog.FilterIndex==0&&!saveFileDialog.FileName.ToLower().EndsWith(".txt"))
					saveFileDialog.FileName += ".txt";
				StreamWriter outs = new StreamWriter(saveFileDialog.FileName);
				for (int i=this.resultsListView.Items.Count-1; i>=0; i--) {
					outs.WriteLine(this.resultsListView.Items[i].SubItems[RESULT_PATH_COLUMN_INDEX].Text);
				}
				outs.Close();
			}
			else statusTextBox.Text = "You cancelled saving.";
		}
		
		void SaveFileDialogFileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void ContentTextBoxTextChanged(object sender, EventArgs e)
		{
			if (!this.contentCBUpdating) {
				if (contentTextBox.Text.Length > 0) {
					contentCheckBox.Checked = true;
				}
				else {
					contentCheckBox.Checked = false;
				}
			}
		}
		/// <summary>
		/// Allow dragging a file to another program (Set the content).
		/// See <https://social.msdn.microsoft.com/Forums/windows/en-US
		/// /60f3ef88-ff7d-4846-b28f-3c97dcef7583
		/// /c-dragdrop-to-desktopexplorer?forum=winforms>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ResultsListViewMouseDown(object sender, MouseEventArgs e)
		{
			string[] files = new string[this.resultsListView.SelectedItems.Count];
			int index = 0;
			foreach (ListViewItem thisLVI in this.resultsListView.SelectedItems) {
				files[index] = thisLVI.SubItems[resultsListView.Columns.IndexOfKey("Path")].Text;
				index++;
			}
			
      		this.DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy); 
		}
		void StatusTextBoxTextChanged(object sender, EventArgs e)
		{
			if (defaultColor == Color.Black) {
				if (this.statusTextBox.BackColor != highlightColor)
					defaultColor = this.statusTextBox.BackColor; // set the default
			}
			else
				this.statusTextBox.BackColor = defaultColor;
		}
		/*
		/// <summary>
		/// This handler is required when the ListView VirtualMode is true.
		/// Set VirtualListSize = 1000000000.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ResultsListViewRetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
		{
			// See https://www.codeproject.com/Articles/42229/Virtual-Mode-ListView
			ListViewItem lvi = new ListViewItem(); 	// create a listviewitem object
			lvi.Text = nt.MakeText(e.ItemIndex); 		// assign the text to the item
			ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem(); // subitem
			NumberFormatInfo nfi = new CultureInfo("de-DE").NumberFormat;
			nfi.NumberDecimalDigits = 0;
			lvsi.Text = e.ItemIndex.ToString("n", nfi); 	// the subitem text
			lvi.SubItems.Add(lvsi); 			// assign subitem to item
			
			e.Item = lvi; 		// assign item to event argument's item-property
		}
		
		*/

	}
}
