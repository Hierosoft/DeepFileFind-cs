/*
 * Created by SharpDevelop.
 * User: jgustafson
 * Date: 3/23/2017
 * Time: 4:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DeepFileFind
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.excludeTextBox = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
			this.minSizeTextBox = new System.Windows.Forms.TextBox();
			this.minSizeCheckBox = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.modifiedEndBeforeDateCheckBox = new System.Windows.Forms.CheckBox();
			this.modifiedEndBeforeTimeCheckBox = new System.Windows.Forms.CheckBox();
			this.modifiedEndBeforeDTPicker = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.contentTextBox = new System.Windows.Forms.TextBox();
			this.contentCheckBox = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.findButton = new System.Windows.Forms.Button();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.modifiedStartDTPicker = new System.Windows.Forms.DateTimePicker();
			this.locationComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.recursiveCheckBox = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.modifiedStartTimeCheckBox = new System.Windows.Forms.CheckBox();
			this.modifiedStartDateCheckBox = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.foldersCheckBox = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
			this.maxSizeTextBox = new System.Windows.Forms.TextBox();
			this.maxSizeCheckBox = new System.Windows.Forms.CheckBox();
			this.minSizeLabel = new System.Windows.Forms.Label();
			this.follow_temporary_folders_enableCB = new System.Windows.Forms.CheckBox();
			this.follow_system_folders_enableCB = new System.Windows.Forms.CheckBox();
			this.follow_dot_folders_enableCB = new System.Windows.Forms.CheckBox();
			this.search_inside_hidden_files_enableCB = new System.Windows.Forms.CheckBox();
			this.follow_hidden_folders_enableCB = new System.Windows.Forms.CheckBox();
			this.follow_folder_symlinks_enableCB = new System.Windows.Forms.CheckBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resultsListView = new System.Windows.Forms.ListView();
			this.resultContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openContainingFolderTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.copyFilePathTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.statusTextBox = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel9.SuspendLayout();
			this.tableLayoutPanel8.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel7.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.resultContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
			this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.resultsListView);
			this.splitContainer1.Size = new System.Drawing.Size(857, 606);
			this.splitContainer1.SplitterDistance = 341;
			this.splitContainer1.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel9, 0, 15);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 0, 12);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 10);
			this.tableLayoutPanel1.Controls.Add(this.modifiedEndBeforeDTPicker, 0, 11);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.contentTextBox, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.contentCheckBox, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.modifiedStartDTPicker, 0, 9);
			this.tableLayoutPanel1.Controls.Add(this.locationComboBox, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 8);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 0, 14);
			this.tableLayoutPanel1.Controls.Add(this.minSizeLabel, 0, 13);
			this.tableLayoutPanel1.Controls.Add(this.follow_temporary_folders_enableCB, 0, 21);
			this.tableLayoutPanel1.Controls.Add(this.follow_system_folders_enableCB, 0, 20);
			this.tableLayoutPanel1.Controls.Add(this.follow_dot_folders_enableCB, 0, 19);
			this.tableLayoutPanel1.Controls.Add(this.search_inside_hidden_files_enableCB, 0, 18);
			this.tableLayoutPanel1.Controls.Add(this.follow_hidden_folders_enableCB, 0, 17);
			this.tableLayoutPanel1.Controls.Add(this.follow_folder_symlinks_enableCB, 0, 16);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 23;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(341, 582);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel9
			// 
			this.tableLayoutPanel9.AutoSize = true;
			this.tableLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel9.ColumnCount = 2;
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel9.Controls.Add(this.label3, 0, 0);
			this.tableLayoutPanel9.Controls.Add(this.excludeTextBox, 1, 0);
			this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 382);
			this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel9.Name = "tableLayoutPanel9";
			this.tableLayoutPanel9.RowCount = 1;
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel9.Size = new System.Drawing.Size(305, 27);
			this.tableLayoutPanel9.TabIndex = 412;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.Location = new System.Drawing.Point(3, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 18);
			this.label3.TabIndex = 0;
			this.label3.Text = "Exclude list";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// excludeTextBox
			// 
			this.excludeTextBox.Location = new System.Drawing.Point(91, 2);
			this.excludeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.excludeTextBox.Name = "excludeTextBox";
			this.excludeTextBox.Size = new System.Drawing.Size(211, 23);
			this.excludeTextBox.TabIndex = 1;
			this.excludeTextBox.Text = ".cache, Trash, .git";
			// 
			// tableLayoutPanel8
			// 
			this.tableLayoutPanel8.AutoSize = true;
			this.tableLayoutPanel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel8.ColumnCount = 2;
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tableLayoutPanel8.Controls.Add(this.minSizeTextBox, 0, 0);
			this.tableLayoutPanel8.Controls.Add(this.minSizeCheckBox, 0, 0);
			this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 301);
			this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel8.Name = "tableLayoutPanel8";
			this.tableLayoutPanel8.RowCount = 1;
			this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel8.Size = new System.Drawing.Size(335, 29);
			this.tableLayoutPanel8.TabIndex = 110;
			// 
			// minSizeTextBox
			// 
			this.minSizeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.minSizeTextBox.Location = new System.Drawing.Point(138, 3);
			this.minSizeTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.minSizeTextBox.Name = "minSizeTextBox";
			this.minSizeTextBox.Size = new System.Drawing.Size(193, 23);
			this.minSizeTextBox.TabIndex = 15;
			// 
			// minSizeCheckBox
			// 
			this.minSizeCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.minSizeCheckBox.AutoSize = true;
			this.minSizeCheckBox.Location = new System.Drawing.Point(4, 5);
			this.minSizeCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.minSizeCheckBox.Name = "minSizeCheckBox";
			this.minSizeCheckBox.Size = new System.Drawing.Size(103, 19);
			this.minSizeCheckBox.TabIndex = 14;
			this.minSizeCheckBox.Text = "Minimum Size";
			this.minSizeCheckBox.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.AutoSize = true;
			this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel5.ColumnCount = 2;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.Controls.Add(this.modifiedEndBeforeDateCheckBox, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.modifiedEndBeforeTimeCheckBox, 1, 0);
			this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 243);
			this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 1;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(335, 25);
			this.tableLayoutPanel5.TabIndex = 90;
			// 
			// modifiedEndBeforeDateCheckBox
			// 
			this.modifiedEndBeforeDateCheckBox.AutoSize = true;
			this.modifiedEndBeforeDateCheckBox.Location = new System.Drawing.Point(4, 3);
			this.modifiedEndBeforeDateCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.modifiedEndBeforeDateCheckBox.Name = "modifiedEndBeforeDateCheckBox";
			this.modifiedEndBeforeDateCheckBox.Size = new System.Drawing.Size(113, 19);
			this.modifiedEndBeforeDateCheckBox.TabIndex = 11;
			this.modifiedEndBeforeDateCheckBox.Text = "Modified Before";
			this.modifiedEndBeforeDateCheckBox.UseVisualStyleBackColor = true;
			this.modifiedEndBeforeDateCheckBox.CheckedChanged += new System.EventHandler(this.EndbeforeDateCheckBoxCheckedChanged);
			// 
			// modifiedEndBeforeTimeCheckBox
			// 
			this.modifiedEndBeforeTimeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.modifiedEndBeforeTimeCheckBox.AutoSize = true;
			this.modifiedEndBeforeTimeCheckBox.Enabled = false;
			this.modifiedEndBeforeTimeCheckBox.Location = new System.Drawing.Point(171, 3);
			this.modifiedEndBeforeTimeCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.modifiedEndBeforeTimeCheckBox.Name = "modifiedEndBeforeTimeCheckBox";
			this.modifiedEndBeforeTimeCheckBox.Size = new System.Drawing.Size(97, 19);
			this.modifiedEndBeforeTimeCheckBox.TabIndex = 12;
			this.modifiedEndBeforeTimeCheckBox.Text = "Specific Time";
			this.modifiedEndBeforeTimeCheckBox.UseVisualStyleBackColor = true;
			this.modifiedEndBeforeTimeCheckBox.CheckedChanged += new System.EventHandler(this.EndbeforeTimeCheckBoxCheckedChanged);
			// 
			// modifiedEndBeforeDTPicker
			// 
			this.modifiedEndBeforeDTPicker.CustomFormat = "yyyy-MM-dd hh:mm tt";
			this.modifiedEndBeforeDTPicker.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modifiedEndBeforeDTPicker.Enabled = false;
			this.modifiedEndBeforeDTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.modifiedEndBeforeDTPicker.Location = new System.Drawing.Point(4, 273);
			this.modifiedEndBeforeDTPicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.modifiedEndBeforeDTPicker.Name = "modifiedEndBeforeDTPicker";
			this.modifiedEndBeforeDTPicker.Size = new System.Drawing.Size(333, 23);
			this.modifiedEndBeforeDTPicker.TabIndex = 100;
			this.modifiedEndBeforeDTPicker.Value = new System.DateTime(2017, 6, 10, 0, 0, 0, 0);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(10, 15);
			this.label2.TabIndex = 0;
			this.label2.Text = " ";
			// 
			// contentTextBox
			// 
			this.contentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contentTextBox.Location = new System.Drawing.Point(4, 157);
			this.contentTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.contentTextBox.Name = "contentTextBox";
			this.contentTextBox.Size = new System.Drawing.Size(333, 23);
			this.contentTextBox.TabIndex = 60;
			this.contentTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContentTextBoxKeyDown);
			// 
			// contentCheckBox
			// 
			this.contentCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.contentCheckBox.AutoSize = true;
			this.contentCheckBox.Location = new System.Drawing.Point(4, 132);
			this.contentCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.contentCheckBox.Name = "contentCheckBox";
			this.contentCheckBox.Size = new System.Drawing.Size(68, 19);
			this.contentCheckBox.TabIndex = 50;
			this.contentCheckBox.Text = "Content";
			this.contentCheckBox.UseVisualStyleBackColor = true;
			this.contentCheckBox.CheckedChanged += new System.EventHandler(this.ContentCheckBoxCheckedChanged);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.foldersCheckBox, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.findButton, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.nameTextBox, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.cancelButton, 3, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(335, 35);
			this.tableLayoutPanel2.TabIndex = 10;
			// 
			// findButton
			// 
			this.findButton.AutoSize = true;
			this.findButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.findButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.findButton.Location = new System.Drawing.Point(212, 3);
			this.findButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.findButton.Name = "findButton";
			this.findButton.Size = new System.Drawing.Size(48, 29);
			this.findButton.TabIndex = 1;
			this.findButton.Text = "Find";
			this.findButton.UseVisualStyleBackColor = true;
			this.findButton.Click += new System.EventHandler(this.FindButtonClick);
			// 
			// nameTextBox
			// 
			this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nameTextBox.Location = new System.Drawing.Point(4, 6);
			this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(93, 23);
			this.nameTextBox.TabIndex = 0;
			this.nameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameTextBoxKeyDown);
			// 
			// cancelButton
			// 
			this.cancelButton.AutoSize = true;
			this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cancelButton.Enabled = false;
			this.cancelButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelButton.Location = new System.Drawing.Point(268, 3);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(63, 29);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Visible = false;
			this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// modifiedStartDTPicker
			// 
			this.modifiedStartDTPicker.CustomFormat = "yyyy-MM-dd hh:mm tt";
			this.modifiedStartDTPicker.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modifiedStartDTPicker.Enabled = false;
			this.modifiedStartDTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.modifiedStartDTPicker.Location = new System.Drawing.Point(4, 215);
			this.modifiedStartDTPicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.modifiedStartDTPicker.Name = "modifiedStartDTPicker";
			this.modifiedStartDTPicker.Size = new System.Drawing.Size(333, 23);
			this.modifiedStartDTPicker.TabIndex = 80;
			this.modifiedStartDTPicker.Value = new System.DateTime(2017, 4, 10, 0, 0, 0, 0);
			// 
			// locationComboBox
			// 
			this.locationComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.locationComboBox.FormattingEnabled = true;
			this.locationComboBox.Location = new System.Drawing.Point(4, 76);
			this.locationComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.locationComboBox.Name = "locationComboBox";
			this.locationComboBox.Size = new System.Drawing.Size(333, 23);
			this.locationComboBox.TabIndex = 30;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 58);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(204, 15);
			this.label1.TabIndex = 410;
			this.label1.Text = "Location(s) separated by semicolon:";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanel3.Controls.Add(this.recursiveCheckBox, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 104);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(335, 23);
			this.tableLayoutPanel3.TabIndex = 40;
			this.tableLayoutPanel3.TabStop = true;
			// 
			// recursiveCheckBox
			// 
			this.recursiveCheckBox.AutoSize = true;
			this.recursiveCheckBox.Checked = true;
			this.recursiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.recursiveCheckBox.Location = new System.Drawing.Point(70, 2);
			this.recursiveCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.recursiveCheckBox.Name = "recursiveCheckBox";
			this.recursiveCheckBox.Size = new System.Drawing.Size(129, 19);
			this.recursiveCheckBox.TabIndex = 5;
			this.recursiveCheckBox.Text = "Search Recursively";
			this.recursiveCheckBox.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.AutoSize = true;
			this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Controls.Add(this.modifiedStartTimeCheckBox, 1, 0);
			this.tableLayoutPanel4.Controls.Add(this.modifiedStartDateCheckBox, 0, 0);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 185);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(335, 25);
			this.tableLayoutPanel4.TabIndex = 70;
			// 
			// modifiedStartTimeCheckBox
			// 
			this.modifiedStartTimeCheckBox.AutoSize = true;
			this.modifiedStartTimeCheckBox.Enabled = false;
			this.modifiedStartTimeCheckBox.Location = new System.Drawing.Point(171, 3);
			this.modifiedStartTimeCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.modifiedStartTimeCheckBox.Name = "modifiedStartTimeCheckBox";
			this.modifiedStartTimeCheckBox.Size = new System.Drawing.Size(97, 19);
			this.modifiedStartTimeCheckBox.TabIndex = 9;
			this.modifiedStartTimeCheckBox.Text = "Specific Time";
			this.modifiedStartTimeCheckBox.UseVisualStyleBackColor = true;
			this.modifiedStartTimeCheckBox.CheckedChanged += new System.EventHandler(this.StartTimeCheckBoxCheckedChanged);
			// 
			// modifiedStartDateCheckBox
			// 
			this.modifiedStartDateCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.modifiedStartDateCheckBox.AutoSize = true;
			this.modifiedStartDateCheckBox.Location = new System.Drawing.Point(4, 3);
			this.modifiedStartDateCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.modifiedStartDateCheckBox.Name = "modifiedStartDateCheckBox";
			this.modifiedStartDateCheckBox.Size = new System.Drawing.Size(120, 19);
			this.modifiedStartDateCheckBox.TabIndex = 8;
			this.modifiedStartDateCheckBox.Text = "Earliest Modified";
			this.modifiedStartDateCheckBox.UseVisualStyleBackColor = true;
			this.modifiedStartDateCheckBox.CheckedChanged += new System.EventHandler(this.StartDateCheckBoxCheckedChanged);
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.AutoSize = true;
			this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel6.ColumnCount = 2;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 56);
			this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(335, 1);
			this.tableLayoutPanel6.TabIndex = 20;
			// 
			// foldersCheckBox
			// 
			this.foldersCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.foldersCheckBox.AutoSize = true;
			this.foldersCheckBox.Checked = true;
			this.foldersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.foldersCheckBox.Location = new System.Drawing.Point(104, 8);
			this.foldersCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.foldersCheckBox.Name = "foldersCheckBox";
			this.foldersCheckBox.Size = new System.Drawing.Size(101, 19);
			this.foldersCheckBox.TabIndex = 3;
			this.foldersCheckBox.Text = "Folder Names";
			this.foldersCheckBox.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel7
			// 
			this.tableLayoutPanel7.AutoSize = true;
			this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel7.ColumnCount = 2;
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tableLayoutPanel7.Controls.Add(this.maxSizeTextBox, 0, 0);
			this.tableLayoutPanel7.Controls.Add(this.maxSizeCheckBox, 0, 0);
			this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 349);
			this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 1;
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel7.Size = new System.Drawing.Size(308, 29);
			this.tableLayoutPanel7.TabIndex = 120;
			// 
			// maxSizeTextBox
			// 
			this.maxSizeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.maxSizeTextBox.Location = new System.Drawing.Point(127, 3);
			this.maxSizeTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.maxSizeTextBox.Name = "maxSizeTextBox";
			this.maxSizeTextBox.Size = new System.Drawing.Size(177, 23);
			this.maxSizeTextBox.TabIndex = 17;
			// 
			// maxSizeCheckBox
			// 
			this.maxSizeCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.maxSizeCheckBox.AutoSize = true;
			this.maxSizeCheckBox.Location = new System.Drawing.Point(4, 5);
			this.maxSizeCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.maxSizeCheckBox.Name = "maxSizeCheckBox";
			this.maxSizeCheckBox.Size = new System.Drawing.Size(105, 19);
			this.maxSizeCheckBox.TabIndex = 16;
			this.maxSizeCheckBox.Text = "Maximum Size";
			this.maxSizeCheckBox.UseVisualStyleBackColor = true;
			// 
			// minSizeLabel
			// 
			this.minSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.minSizeLabel.AutoSize = true;
			this.minSizeLabel.Location = new System.Drawing.Point(46, 332);
			this.minSizeLabel.Name = "minSizeLabel";
			this.minSizeLabel.Size = new System.Drawing.Size(292, 15);
			this.minSizeLabel.TabIndex = 19;
			this.minSizeLabel.Text = "(number is byte count, unless ends in KB, MB, or GB)";
			// 
			// follow_temporary_folders_enableCB
			// 
			this.follow_temporary_folders_enableCB.AutoSize = true;
			this.follow_temporary_folders_enableCB.Location = new System.Drawing.Point(4, 539);
			this.follow_temporary_folders_enableCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.follow_temporary_folders_enableCB.Name = "follow_temporary_folders_enableCB";
			this.follow_temporary_folders_enableCB.Size = new System.Drawing.Size(165, 19);
			this.follow_temporary_folders_enableCB.TabIndex = 411;
			this.follow_temporary_folders_enableCB.Text = "Search temporary folders";
			this.follow_temporary_folders_enableCB.UseVisualStyleBackColor = true;
			// 
			// follow_system_folders_enableCB
			// 
			this.follow_system_folders_enableCB.AutoSize = true;
			this.follow_system_folders_enableCB.Location = new System.Drawing.Point(4, 514);
			this.follow_system_folders_enableCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.follow_system_folders_enableCB.Name = "follow_system_folders_enableCB";
			this.follow_system_folders_enableCB.Size = new System.Drawing.Size(146, 19);
			this.follow_system_folders_enableCB.TabIndex = 411;
			this.follow_system_folders_enableCB.Text = "Search system folders";
			this.follow_system_folders_enableCB.UseVisualStyleBackColor = true;
			// 
			// follow_dot_folders_enableCB
			// 
			this.follow_dot_folders_enableCB.AutoSize = true;
			this.follow_dot_folders_enableCB.Location = new System.Drawing.Point(4, 489);
			this.follow_dot_folders_enableCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.follow_dot_folders_enableCB.Name = "follow_dot_folders_enableCB";
			this.follow_dot_folders_enableCB.Size = new System.Drawing.Size(261, 19);
			this.follow_dot_folders_enableCB.TabIndex = 411;
			this.follow_dot_folders_enableCB.Text = "Search \".*\" folders (cross-platform hidden)";
			this.follow_dot_folders_enableCB.UseVisualStyleBackColor = true;
			// 
			// search_inside_hidden_files_enableCB
			// 
			this.search_inside_hidden_files_enableCB.AutoSize = true;
			this.search_inside_hidden_files_enableCB.Location = new System.Drawing.Point(4, 464);
			this.search_inside_hidden_files_enableCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.search_inside_hidden_files_enableCB.Name = "search_inside_hidden_files_enableCB";
			this.search_inside_hidden_files_enableCB.Size = new System.Drawing.Size(130, 19);
			this.search_inside_hidden_files_enableCB.TabIndex = 411;
			this.search_inside_hidden_files_enableCB.Text = "Search hidden files";
			this.search_inside_hidden_files_enableCB.UseVisualStyleBackColor = true;
			// 
			// follow_hidden_folders_enableCB
			// 
			this.follow_hidden_folders_enableCB.AutoSize = true;
			this.follow_hidden_folders_enableCB.Location = new System.Drawing.Point(4, 439);
			this.follow_hidden_folders_enableCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.follow_hidden_folders_enableCB.Name = "follow_hidden_folders_enableCB";
			this.follow_hidden_folders_enableCB.Size = new System.Drawing.Size(146, 19);
			this.follow_hidden_folders_enableCB.TabIndex = 411;
			this.follow_hidden_folders_enableCB.Text = "Search hidden folders";
			this.follow_hidden_folders_enableCB.UseVisualStyleBackColor = true;
			// 
			// follow_folder_symlinks_enableCB
			// 
			this.follow_folder_symlinks_enableCB.AutoSize = true;
			this.follow_folder_symlinks_enableCB.Location = new System.Drawing.Point(4, 414);
			this.follow_folder_symlinks_enableCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.follow_folder_symlinks_enableCB.Name = "follow_folder_symlinks_enableCB";
			this.follow_folder_symlinks_enableCB.Size = new System.Drawing.Size(260, 19);
			this.follow_folder_symlinks_enableCB.TabIndex = 411;
			this.follow_folder_symlinks_enableCB.Text = "Follow folder symlinks (not recommended)";
			this.follow_folder_symlinks_enableCB.UseVisualStyleBackColor = true;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.editToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(341, 24);
			this.menuStrip1.TabIndex = 101;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.deleteResultsToolStripMenuItem,
									this.saveResultsToolStripMenuItem,
									this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// deleteResultsToolStripMenuItem
			// 
			this.deleteResultsToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed;
			this.deleteResultsToolStripMenuItem.Name = "deleteResultsToolStripMenuItem";
			this.deleteResultsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.deleteResultsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
			this.deleteResultsToolStripMenuItem.Text = "Delete All Files Listed";
			this.deleteResultsToolStripMenuItem.Click += new System.EventHandler(this.DeleteResultsToolStripMenuItemClick);
			// 
			// saveResultsToolStripMenuItem
			// 
			this.saveResultsToolStripMenuItem.Name = "saveResultsToolStripMenuItem";
			this.saveResultsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveResultsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
			this.saveResultsToolStripMenuItem.Text = "&Save List";
			this.saveResultsToolStripMenuItem.Click += new System.EventHandler(this.SaveResultsToolStripMenuItemClick);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.findToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// findToolStripMenuItem
			// 
			this.findToolStripMenuItem.Name = "findToolStripMenuItem";
			this.findToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.findToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.findToolStripMenuItem.Text = "Find";
			this.findToolStripMenuItem.Click += new System.EventHandler(this.FindToolStripMenuItemClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// resultsListView
			// 
			this.resultsListView.ContextMenuStrip = this.resultContextMenuStrip;
			this.resultsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultsListView.FullRowSelect = true;
			this.resultsListView.Location = new System.Drawing.Point(0, 0);
			this.resultsListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.resultsListView.MultiSelect = false;
			this.resultsListView.Name = "resultsListView";
			this.resultsListView.Size = new System.Drawing.Size(512, 606);
			this.resultsListView.TabIndex = 100;
			this.resultsListView.UseCompatibleStateImageBehavior = false;
			this.resultsListView.View = System.Windows.Forms.View.Details;
			this.resultsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ResultsListViewColumnClick);
			this.resultsListView.DoubleClick += new System.EventHandler(this.ResultsListViewDoubleClick);
			this.resultsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ResultsListViewKeyDown);
			// 
			// resultContextMenuStrip
			// 
			this.resultContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.openToolStripMenuItem,
									this.openContainingFolderTSMI,
									this.copyFilePathTSMI});
			this.resultContextMenuStrip.Name = "contextMenuStrip1";
			this.resultContextMenuStrip.Size = new System.Drawing.Size(202, 70);
			this.resultContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ResultContextMenuStripOpening);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenTSMIClick);
			// 
			// openContainingFolderTSMI
			// 
			this.openContainingFolderTSMI.Name = "openContainingFolderTSMI";
			this.openContainingFolderTSMI.Size = new System.Drawing.Size(201, 22);
			this.openContainingFolderTSMI.Text = "Open Containing Folder";
			this.openContainingFolderTSMI.Click += new System.EventHandler(this.OpenContainingFolderTSMIClick);
			// 
			// copyFilePathTSMI
			// 
			this.copyFilePathTSMI.Name = "copyFilePathTSMI";
			this.copyFilePathTSMI.Size = new System.Drawing.Size(201, 22);
			this.copyFilePathTSMI.Text = "Copy Path";
			this.copyFilePathTSMI.Click += new System.EventHandler(this.CopyFilePathTSMIClick);
			// 
			// statusTextBox
			// 
			this.statusTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.statusTextBox.Location = new System.Drawing.Point(0, 606);
			this.statusTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.statusTextBox.Name = "statusTextBox";
			this.statusTextBox.ReadOnly = true;
			this.statusTextBox.Size = new System.Drawing.Size(857, 23);
			this.statusTextBox.TabIndex = 200;
			this.statusTextBox.TabStop = false;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "txt";
			this.saveFileDialog.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
			this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialogFileOk);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(857, 629);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusTextBox);
			this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "MainForm";
			this.Text = "DeepFileFind";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel9.ResumeLayout(false);
			this.tableLayoutPanel9.PerformLayout();
			this.tableLayoutPanel8.ResumeLayout(false);
			this.tableLayoutPanel8.PerformLayout();
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.tableLayoutPanel7.ResumeLayout(false);
			this.tableLayoutPanel7.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.resultContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox follow_system_folders_enableCB;
		private System.Windows.Forms.CheckBox follow_temporary_folders_enableCB;
		private System.Windows.Forms.CheckBox follow_hidden_folders_enableCB;
		private System.Windows.Forms.CheckBox follow_dot_folders_enableCB;
		private System.Windows.Forms.CheckBox search_inside_hidden_files_enableCB;
		private System.Windows.Forms.CheckBox follow_folder_symlinks_enableCB;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolStripMenuItem saveResultsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteResultsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyFilePathTSMI;
		private System.Windows.Forms.ToolStripMenuItem openContainingFolderTSMI;
		private System.Windows.Forms.Label minSizeLabel;
		private System.Windows.Forms.CheckBox maxSizeCheckBox;
		private System.Windows.Forms.TextBox maxSizeTextBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
		private System.Windows.Forms.CheckBox minSizeCheckBox;
		private System.Windows.Forms.TextBox minSizeTextBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
		private System.Windows.Forms.CheckBox recursiveCheckBox;
		private System.Windows.Forms.ContextMenuStrip resultContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TextBox statusTextBox;
		private System.Windows.Forms.CheckBox foldersCheckBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox contentTextBox;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Button findButton;
		private System.Windows.Forms.ComboBox locationComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox contentCheckBox;
		private System.Windows.Forms.DateTimePicker modifiedEndBeforeDTPicker;
		private System.Windows.Forms.DateTimePicker modifiedStartDTPicker;
		private System.Windows.Forms.CheckBox modifiedStartTimeCheckBox;
		private System.Windows.Forms.CheckBox modifiedEndBeforeTimeCheckBox;
		private System.Windows.Forms.CheckBox modifiedEndBeforeDateCheckBox;
		private System.Windows.Forms.CheckBox modifiedStartDateCheckBox;
		private System.Windows.Forms.ListView resultsListView;
		private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox excludeTextBox;
		
		void ResultContextMenuStripOpening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		}
	}
}
