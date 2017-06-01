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
			this.maxSizeLabel = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resultsListView = new System.Windows.Forms.ListView();
			this.resultContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openContainingFolderTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.copyFilePathTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.statusTextBox = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel8.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			this.tableLayoutPanel7.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.resultContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
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
			this.splitContainer1.Size = new System.Drawing.Size(979, 663);
			this.splitContainer1.SplitterDistance = 354;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
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
			this.tableLayoutPanel1.Controls.Add(this.maxSizeLabel, 0, 15);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 17;
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
			this.tableLayoutPanel1.Size = new System.Drawing.Size(354, 638);
			this.tableLayoutPanel1.TabIndex = 0;
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
			this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 399);
			this.tableLayoutPanel8.Name = "tableLayoutPanel8";
			this.tableLayoutPanel8.RowCount = 1;
			this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel8.Size = new System.Drawing.Size(348, 35);
			this.tableLayoutPanel8.TabIndex = 110;
			// 
			// minSizeTextBox
			// 
			this.minSizeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.minSizeTextBox.Location = new System.Drawing.Point(143, 4);
			this.minSizeTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.minSizeTextBox.Name = "minSizeTextBox";
			this.minSizeTextBox.Size = new System.Drawing.Size(201, 27);
			this.minSizeTextBox.TabIndex = 15;
			// 
			// minSizeCheckBox
			// 
			this.minSizeCheckBox.AutoSize = true;
			this.minSizeCheckBox.Location = new System.Drawing.Point(4, 4);
			this.minSizeCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.minSizeCheckBox.Name = "minSizeCheckBox";
			this.minSizeCheckBox.Size = new System.Drawing.Size(118, 23);
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
			this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 327);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 1;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(348, 31);
			this.tableLayoutPanel5.TabIndex = 90;
			// 
			// modifiedEndBeforeDateCheckBox
			// 
			this.modifiedEndBeforeDateCheckBox.AutoSize = true;
			this.modifiedEndBeforeDateCheckBox.Location = new System.Drawing.Point(4, 4);
			this.modifiedEndBeforeDateCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.modifiedEndBeforeDateCheckBox.Name = "modifiedEndBeforeDateCheckBox";
			this.modifiedEndBeforeDateCheckBox.Size = new System.Drawing.Size(132, 23);
			this.modifiedEndBeforeDateCheckBox.TabIndex = 11;
			this.modifiedEndBeforeDateCheckBox.Text = "Modified Before";
			this.modifiedEndBeforeDateCheckBox.UseVisualStyleBackColor = true;
			this.modifiedEndBeforeDateCheckBox.CheckedChanged += new System.EventHandler(this.EndbeforeDateCheckBoxCheckedChanged);
			// 
			// modifiedEndBeforeTimeCheckBox
			// 
			this.modifiedEndBeforeTimeCheckBox.AutoSize = true;
			this.modifiedEndBeforeTimeCheckBox.Enabled = false;
			this.modifiedEndBeforeTimeCheckBox.Location = new System.Drawing.Point(178, 4);
			this.modifiedEndBeforeTimeCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.modifiedEndBeforeTimeCheckBox.Name = "modifiedEndBeforeTimeCheckBox";
			this.modifiedEndBeforeTimeCheckBox.Size = new System.Drawing.Size(113, 23);
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
			this.modifiedEndBeforeDTPicker.Location = new System.Drawing.Point(4, 365);
			this.modifiedEndBeforeDTPicker.Margin = new System.Windows.Forms.Padding(4);
			this.modifiedEndBeforeDTPicker.Name = "modifiedEndBeforeDTPicker";
			this.modifiedEndBeforeDTPicker.Size = new System.Drawing.Size(346, 27);
			this.modifiedEndBeforeDTPicker.TabIndex = 100;
			this.modifiedEndBeforeDTPicker.Value = new System.DateTime(2017, 6, 10, 0, 0, 0, 0);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(13, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = " ";
			// 
			// contentTextBox
			// 
			this.contentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contentTextBox.Location = new System.Drawing.Point(4, 221);
			this.contentTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.contentTextBox.Name = "contentTextBox";
			this.contentTextBox.Size = new System.Drawing.Size(346, 27);
			this.contentTextBox.TabIndex = 60;
			this.contentTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContentTextBoxKeyDown);
			// 
			// contentCheckBox
			// 
			this.contentCheckBox.AutoSize = true;
			this.contentCheckBox.Location = new System.Drawing.Point(4, 190);
			this.contentCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.contentCheckBox.Name = "contentCheckBox";
			this.contentCheckBox.Size = new System.Drawing.Size(79, 23);
			this.contentCheckBox.TabIndex = 50;
			this.contentCheckBox.Text = "Content";
			this.contentCheckBox.UseVisualStyleBackColor = true;
			this.contentCheckBox.CheckedChanged += new System.EventHandler(this.ContentCheckBoxCheckedChanged);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.findButton, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.nameTextBox, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.cancelButton, 2, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 22);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(348, 37);
			this.tableLayoutPanel2.TabIndex = 10;
			// 
			// findButton
			// 
			this.findButton.AutoSize = true;
			this.findButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.findButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.findButton.Location = new System.Drawing.Point(225, 4);
			this.findButton.Margin = new System.Windows.Forms.Padding(4);
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
			this.nameTextBox.Location = new System.Drawing.Point(4, 5);
			this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(213, 27);
			this.nameTextBox.TabIndex = 0;
			this.nameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameTextBoxKeyDown);
			// 
			// cancelButton
			// 
			this.cancelButton.AutoSize = true;
			this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cancelButton.Enabled = false;
			this.cancelButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelButton.Location = new System.Drawing.Point(281, 4);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
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
			this.modifiedStartDTPicker.Location = new System.Drawing.Point(4, 293);
			this.modifiedStartDTPicker.Margin = new System.Windows.Forms.Padding(4);
			this.modifiedStartDTPicker.Name = "modifiedStartDTPicker";
			this.modifiedStartDTPicker.Size = new System.Drawing.Size(346, 27);
			this.modifiedStartDTPicker.TabIndex = 80;
			this.modifiedStartDTPicker.Value = new System.DateTime(2017, 4, 10, 0, 0, 0, 0);
			// 
			// locationComboBox
			// 
			this.locationComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.locationComboBox.FormattingEnabled = true;
			this.locationComboBox.Location = new System.Drawing.Point(4, 120);
			this.locationComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.locationComboBox.Name = "locationComboBox";
			this.locationComboBox.Size = new System.Drawing.Size(346, 27);
			this.locationComboBox.TabIndex = 30;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 97);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(243, 19);
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
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 154);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(348, 29);
			this.tableLayoutPanel3.TabIndex = 40;
			this.tableLayoutPanel3.TabStop = true;
			// 
			// recursiveCheckBox
			// 
			this.recursiveCheckBox.AutoSize = true;
			this.recursiveCheckBox.Checked = true;
			this.recursiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.recursiveCheckBox.Location = new System.Drawing.Point(72, 3);
			this.recursiveCheckBox.Name = "recursiveCheckBox";
			this.recursiveCheckBox.Size = new System.Drawing.Size(149, 23);
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
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 255);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(348, 31);
			this.tableLayoutPanel4.TabIndex = 70;
			// 
			// modifiedStartTimeCheckBox
			// 
			this.modifiedStartTimeCheckBox.AutoSize = true;
			this.modifiedStartTimeCheckBox.Enabled = false;
			this.modifiedStartTimeCheckBox.Location = new System.Drawing.Point(178, 4);
			this.modifiedStartTimeCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.modifiedStartTimeCheckBox.Name = "modifiedStartTimeCheckBox";
			this.modifiedStartTimeCheckBox.Size = new System.Drawing.Size(113, 23);
			this.modifiedStartTimeCheckBox.TabIndex = 9;
			this.modifiedStartTimeCheckBox.Text = "Specific Time";
			this.modifiedStartTimeCheckBox.UseVisualStyleBackColor = true;
			this.modifiedStartTimeCheckBox.CheckedChanged += new System.EventHandler(this.StartTimeCheckBoxCheckedChanged);
			// 
			// modifiedStartDateCheckBox
			// 
			this.modifiedStartDateCheckBox.AutoSize = true;
			this.modifiedStartDateCheckBox.Location = new System.Drawing.Point(4, 4);
			this.modifiedStartDateCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.modifiedStartDateCheckBox.Name = "modifiedStartDateCheckBox";
			this.modifiedStartDateCheckBox.Size = new System.Drawing.Size(138, 23);
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
			this.tableLayoutPanel6.Controls.Add(this.foldersCheckBox, 1, 0);
			this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 65);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(348, 29);
			this.tableLayoutPanel6.TabIndex = 20;
			// 
			// foldersCheckBox
			// 
			this.foldersCheckBox.AutoSize = true;
			this.foldersCheckBox.Checked = true;
			this.foldersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.foldersCheckBox.Location = new System.Drawing.Point(72, 3);
			this.foldersCheckBox.Name = "foldersCheckBox";
			this.foldersCheckBox.Size = new System.Drawing.Size(191, 23);
			this.foldersCheckBox.TabIndex = 3;
			this.foldersCheckBox.Text = "Include folders as results";
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
			this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 459);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 1;
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel7.Size = new System.Drawing.Size(348, 35);
			this.tableLayoutPanel7.TabIndex = 120;
			// 
			// maxSizeTextBox
			// 
			this.maxSizeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.maxSizeTextBox.Location = new System.Drawing.Point(143, 4);
			this.maxSizeTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.maxSizeTextBox.Name = "maxSizeTextBox";
			this.maxSizeTextBox.Size = new System.Drawing.Size(201, 27);
			this.maxSizeTextBox.TabIndex = 17;
			// 
			// maxSizeCheckBox
			// 
			this.maxSizeCheckBox.AutoSize = true;
			this.maxSizeCheckBox.Location = new System.Drawing.Point(4, 4);
			this.maxSizeCheckBox.Margin = new System.Windows.Forms.Padding(4);
			this.maxSizeCheckBox.Name = "maxSizeCheckBox";
			this.maxSizeCheckBox.Size = new System.Drawing.Size(121, 23);
			this.maxSizeCheckBox.TabIndex = 16;
			this.maxSizeCheckBox.Text = "Maximum Size";
			this.maxSizeCheckBox.UseVisualStyleBackColor = true;
			// 
			// minSizeLabel
			// 
			this.minSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.minSizeLabel.AutoSize = true;
			this.minSizeLabel.Location = new System.Drawing.Point(351, 437);
			this.minSizeLabel.Name = "minSizeLabel";
			this.minSizeLabel.Size = new System.Drawing.Size(0, 19);
			this.minSizeLabel.TabIndex = 19;
			// 
			// maxSizeLabel
			// 
			this.maxSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.maxSizeLabel.AutoSize = true;
			this.maxSizeLabel.Location = new System.Drawing.Point(351, 497);
			this.maxSizeLabel.Name = "maxSizeLabel";
			this.maxSizeLabel.Size = new System.Drawing.Size(0, 19);
			this.maxSizeLabel.TabIndex = 20;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.editToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
			this.menuStrip1.Size = new System.Drawing.Size(354, 25);
			this.menuStrip1.TabIndex = 101;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.findToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 19);
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
			// resultsListView
			// 
			this.resultsListView.ContextMenuStrip = this.resultContextMenuStrip;
			this.resultsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultsListView.FullRowSelect = true;
			this.resultsListView.Location = new System.Drawing.Point(0, 0);
			this.resultsListView.Margin = new System.Windows.Forms.Padding(4);
			this.resultsListView.MultiSelect = false;
			this.resultsListView.Name = "resultsListView";
			this.resultsListView.Size = new System.Drawing.Size(620, 663);
			this.resultsListView.TabIndex = 100;
			this.resultsListView.UseCompatibleStateImageBehavior = false;
			this.resultsListView.View = System.Windows.Forms.View.Details;
			this.resultsListView.DoubleClick += new System.EventHandler(this.ResultsListViewDoubleClick);
			this.resultsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ResultsListViewColumnClick);
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
			this.statusTextBox.Location = new System.Drawing.Point(0, 663);
			this.statusTextBox.Name = "statusTextBox";
			this.statusTextBox.ReadOnly = true;
			this.statusTextBox.Size = new System.Drawing.Size(979, 27);
			this.statusTextBox.TabIndex = 200;
			this.statusTextBox.TabStop = false;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(979, 690);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusTextBox);
			this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.Text = "DeepFileFind";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
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
			this.tableLayoutPanel6.ResumeLayout(false);
			this.tableLayoutPanel6.PerformLayout();
			this.tableLayoutPanel7.ResumeLayout(false);
			this.tableLayoutPanel7.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.resultContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyFilePathTSMI;
		private System.Windows.Forms.ToolStripMenuItem openContainingFolderTSMI;
		private System.Windows.Forms.Label maxSizeLabel;
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
		
		void ResultContextMenuStripOpening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		}
	}
}
