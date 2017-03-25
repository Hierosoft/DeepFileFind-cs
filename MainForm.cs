/*
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

namespace DeepFileFind
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private DFF dff = null;
		private Thread this_thread = null;
		public static string date_format_string = "yyyy-MM-dd";
		public static string datetime_format_string = "yyyy-MM-dd hh:mm tt";
		//see also DFF.datetime_sortable_format_string
		private static string folders_thisprogram_name = "DeepFileFind";
		public static string appdata_thisprogram_path = null;
		private static string recent_folders_list_name = "recent_folders.txt";
		public static string recent_folders_list_path = null;
		private static string settings_name = "settings.yml";
		public static string settings_path = null;
		public int RESULT_NAME_COLUMN_INDEX = -1;
		public int RESULT_MODIFIED_COLUMN_INDEX = -1;
		public int RESULT_CREATED_COLUMN_INDEX = -1;
		public int RESULT_PATH_COLUMN_INDEX = -1;
		public int RESULT_EXTENSION_COLUMN_INDEX = -1;
		public Dictionary<string, string> settings = new Dictionary<string, string>();
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//TODO: discontinue this program and make Miracle File Search in qt?
			appdata_thisprogram_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), folders_thisprogram_name);
			if (!Directory.Exists(appdata_thisprogram_path)) Directory.CreateDirectory(appdata_thisprogram_path);
			recent_folders_list_path = Path.Combine(appdata_thisprogram_path, recent_folders_list_name);
			settings_path = Path.Combine(appdata_thisprogram_path, settings_name);
			//loaded on MainFormLoad
		}
		
		public void setSearchAvailability(bool enable) {
			findButton.Enabled=enable;
			findButton.Visible=enable;
			cancelButton.Enabled=!enable;
			cancelButton.Visible=!enable;
			nameTextBox.Enabled=enable;
			locationComboBox.Enabled=enable;
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
			if (contentCheckBox.Checked) contentTextBox.Enabled=true;
			else contentTextBox.Enabled=false;
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			updateDatePickers();
			if (locationComboBox.Text.Trim()=="") {
				locationComboBox.Text=Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			}
			try {
				string try_path="\\\\FCAFILES\\student";
				if (Directory.Exists(try_path)) locationComboBox.Text=try_path;
			}
			catch {} //don't care
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
			if (settings.ContainsKey("modified_start_datetime")) modifiedStartDTPicker.Value = DateTime.Parse( DateTime.Parse(settings["modified_start_datetime"]).ToString(modifiedStartDTPicker.CustomFormat) );
			modifiedStartDTPicker.Enabled = modifiedStartDateCheckBox.Checked;

			if (settings.ContainsKey("modified_endbefore_time_enable")) modifiedEndBeforeTimeCheckBox.Checked = (settings["modified_endbefore_time_enable"]=="true"?true:false);
			else modifiedEndBeforeTimeCheckBox.Checked = false;
			if (settings.ContainsKey("modified_endbefore_date_enable")) modifiedEndBeforeDateCheckBox.Checked = (settings["modified_endbefore_date_enable"]=="true"?true:false);
			else modifiedEndBeforeDateCheckBox.Checked = false;
			modifiedEndBeforeDTPicker.CustomFormat = modifiedEndBeforeTimeCheckBox.Checked ? datetime_format_string : date_format_string;
			if (settings.ContainsKey("modified_endbefore_datetime")) modifiedEndBeforeDTPicker.Value = DateTime.Parse( DateTime.Parse(settings["modified_endbefore_datetime"]).ToString(modifiedEndBeforeDTPicker.CustomFormat) );
			modifiedEndBeforeDTPicker.Enabled = modifiedEndBeforeDateCheckBox.Checked;
			
			if (settings.ContainsKey("include_folders_as_results_enable")) foldersCheckBox.Checked = (settings["include_folders_as_results_enable"]=="true"?true:false);
			else modifiedEndBeforeDateCheckBox.Checked = false;
			if (settings.ContainsKey("recursive_enable")) recursiveCheckBox.Checked = (settings["recursive_enable"]=="true"?true:false);
			else recursiveCheckBox.Checked = true;
			if (settings.ContainsKey("content_enable")) contentCheckBox.Checked = (settings["content_enable"]=="true"?true:false);
			else contentCheckBox.Checked = false;
			contentTextBox.Enabled = contentCheckBox.Checked;
						
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
			
			if (!hasLocation(locationComboBox.Text)) locationComboBox.Items.Add(locationComboBox.Text);
		}//end MainFormLoad
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
				if (this_thread!=null) {
					statusTextBox.Text="waiting for previous thread to stop...";
					dff.enable = false;
					Application.DoEvents();
					while (this_thread.IsAlive) {
						Thread.Sleep(100);
						Application.DoEvents();
					}
					statusTextBox.Text="";
					Application.DoEvents();
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
		public void ExecuteSearch() {
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
			if (locationComboBox.Text.Length>0) {
				string[] location_strings = locationComboBox.Text.Split(Path.PathSeparator);
				
				bool folders_all_ok_enable = true;
				ArrayList bad_paths = new ArrayList();
				foreach (string location_string in location_strings) {
					DirectoryInfo this_di = new DirectoryInfo(location_string);
					if (this_di.Exists) {
						dff.options.start_directoryinfos.Add(this_di);
					}
					else {
						folders_all_ok_enable=false;
						bad_paths.Add(location_string);
					}
				}
				
				if (folders_all_ok_enable) {
					dff.options.modified_start_date_enable=modifiedStartDateCheckBox.Checked;
					dff.options.modified_start_time_enable=modifiedStartTimeCheckBox.Checked;
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
					if (contentCheckBox.Checked && !string.IsNullOrEmpty(contentTextBox.Text.Trim())) dff.options.content_string=contentTextBox.Text;
					dff.options.include_folders_as_results_enable=foldersCheckBox.Checked;
					dff.options.recursive_enable=recursiveCheckBox.Checked;
					dff.resultsListView = this.resultsListView;
					dff.options.statusTextBox = this.statusTextBox;
					if (dff.options.threading_enable) {
						this_thread = new Thread(dff.ExecuteSearch);
						this_thread.Start();
						statusTextBox.Text="Searching (1 thread)...";
						Application.DoEvents();
						timer1.Enabled=true;
						timer1.Start();
					}
					else {
						statusTextBox.Text="Searching...";
						dff.ExecuteSearch();
						//findButton.Visible=true;
						//findButton.Enabled=true;
						//cancelButton.Visible=false;
						//cancelButton.Enabled=false;
						setSearchAvailability(true);
					}
					//while (this_thread.IsAlive) Thread.Sleep(1);
					//foreach (FileInfo this_fi in results) {
					//	string[] fields = new String[resultsListView.Columns.Count];
					//	for (int i=0; i<this_item.Length; i++) fields[i]="";
					//	fields[RESULT_CREATED_COLUMN_INDEX] = 
					//	resultsListView.Items.Add(new ListViewItem(fields));
					//}
				}
				else {
					string bad_paths_string = "";
					foreach (string bad_path in bad_paths) {
						bad_paths_string += ((bad_paths_string=="")?"":"; ") + bad_path;
					}
					MessageBox.Show("Cannot search due to nonexistant directory(ies): "+bad_paths_string);
				}
			}
			else {
				MessageBox.Show("Search directory must be specified");
			}
		}
		
		void ContentCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			updateDatePickers();
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			statusTextBox.Text="Saving settings...";
			Application.DoEvents();
			StreamWriter outs = new StreamWriter(recent_folders_list_path);
			foreach (string line in locationComboBox.Items) {
				outs.WriteLine(line);
			}
			outs.Close();
			
			outs = new StreamWriter(settings_path);
			settings["modified_start_date_enable"] = modifiedStartDateCheckBox.Checked?"true":"false";
			settings["modified_start_time_enable"] = modifiedStartTimeCheckBox.Checked?"true":"false";
			settings["modified_start_datetime_utc"] = modifiedStartDTPicker.Value.ToUniversalTime().ToString(modifiedStartDTPicker.CustomFormat);
			settings["modified_endbefore_date_enable"] = modifiedEndBeforeDateCheckBox.Checked?"true":"false";
			settings["modified_endbefore_time_enable"] = modifiedEndBeforeTimeCheckBox.Checked?"true":"false";
			settings["modified_endbefore_datetime_utc"] = modifiedEndBeforeDTPicker.Value.ToUniversalTime().ToString(modifiedEndBeforeDTPicker.CustomFormat);
			settings["include_folders_as_results_enable"] = foldersCheckBox.Checked?"true":"false";
			settings["content_enable"] = contentCheckBox.Checked?"true":"false";
			settings["recursive_enable"] = recursiveCheckBox.Checked?"true":"false";
			foreach(KeyValuePair<string, string> entry in settings) {
				outs.WriteLine(entry.Key+":"+entry.Value);
			}
			outs.Close();
			
			statusTextBox.Text="";
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
		
		void ResultsListViewDoubleClick(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in resultsListView.SelectedItems) {
				System.Diagnostics.Process.Start(lvi.SubItems[RESULT_PATH_COLUMN_INDEX].Text);
			}
		}
		
		void OpenContainingFolderToolStripMenuItemClick(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in resultsListView.SelectedItems) {
				FileInfo this_fi = new FileInfo(lvi.SubItems[RESULT_PATH_COLUMN_INDEX].Text);
				System.Diagnostics.Process.Start(this_fi.Directory.FullName);
			}
		}
		
		void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in resultsListView.SelectedItems) {
				System.Diagnostics.Process.Start(lvi.SubItems[RESULT_PATH_COLUMN_INDEX].Text);
			}
		}
	}
}
