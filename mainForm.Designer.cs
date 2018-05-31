namespace GozalMusicMini
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.Play = new System.Windows.Forms.MenuItem();
            this.Add = new System.Windows.Forms.MenuItem();
            this.Edit = new System.Windows.Forms.MenuItem();
            this.Delete = new System.Windows.Forms.MenuItem();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.menu1 = new System.Windows.Forms.MainMenu(this.components);
            this.File = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.Help = new System.Windows.Forms.MenuItem();
            this.Documentation = new System.Windows.Forms.MenuItem();
            this.Changelog = new System.Windows.Forms.MenuItem();
            this.About = new System.Windows.Forms.MenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconContextMenu = new System.Windows.Forms.ContextMenu();
            this.trayExit = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.Name = "treeView1";
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelectAsync);
            // 
            // listView1
            // 
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.CheckBoxes = true;
            this.listView1.ContextMenu = this.contextMenu1;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListView1_KeyDownAsync);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseDoubleClick);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Play,
            this.Add,
            this.Edit,
            this.Delete});
            // 
            // Play
            // 
            this.Play.Index = 0;
            resources.ApplyResources(this.Play, "Play");
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // Add
            // 
            this.Add.Index = 1;
            resources.ApplyResources(this.Add, "Add");
            this.Add.Click += new System.EventHandler(this.Add_ClickAsync);
            // 
            // Edit
            // 
            this.Edit.Index = 2;
            resources.ApplyResources(this.Edit, "Edit");
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Delete
            // 
            this.Delete.Index = 3;
            resources.ApplyResources(this.Delete, "Delete");
            this.Delete.Click += new System.EventHandler(this.Delete_ClickAsync);
            // 
            // trackBar1
            // 
            resources.ApplyResources(this.trackBar1, "trackBar1");
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll_1);
            this.trackBar1.ValueChanged += new System.EventHandler(this.TrackBar1_ValueChanged);
            // 
            // trackBar2
            // 
            resources.ApplyResources(this.trackBar2, "trackBar2");
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Scroll += new System.EventHandler(this.TrackBar2_Scroll);
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown_1Async);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_ClickAsync);
            // 
            // menu1
            // 
            this.menu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.File,
            this.Help});
            // 
            // File
            // 
            this.File.Index = 0;
            this.File.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.exitMenuItem});
            resources.ApplyResources(this.File, "File");
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Index = 0;
            resources.ApplyResources(this.exitMenuItem, "exitMenuItem");
            this.exitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // Help
            // 
            this.Help.Index = 1;
            this.Help.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Documentation,
            this.Changelog,
            this.About});
            resources.ApplyResources(this.Help, "Help");
            // 
            // Documentation
            // 
            this.Documentation.Index = 0;
            resources.ApplyResources(this.Documentation, "Documentation");
            // 
            // Changelog
            // 
            this.Changelog.Index = 1;
            resources.ApplyResources(this.Changelog, "Changelog");
            // 
            // About
            // 
            this.About.Index = 2;
            resources.ApplyResources(this.About, "About");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenu = this.trayIconContextMenu;
            resources.ApplyResources(this.trayIcon, "trayIcon");
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            // 
            // trayIconContextMenu
            // 
            this.trayIconContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.trayExit});
            // 
            // trayExit
            // 
            this.trayExit.Index = 0;
            resources.ApplyResources(this.trayExit, "trayExit");
            this.trayExit.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.treeView1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Menu = this.menu1;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_LoadAsync);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem Play;
        private System.Windows.Forms.MenuItem Add;
        private System.Windows.Forms.MenuItem Edit;
        private System.Windows.Forms.MenuItem Delete;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MainMenu menu1;
        private System.Windows.Forms.MenuItem File;
        private System.Windows.Forms.MenuItem Help;
        private System.Windows.Forms.MenuItem Documentation;
        private System.Windows.Forms.MenuItem Changelog;
        private System.Windows.Forms.MenuItem About;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuItem exitMenuItem;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenu trayIconContextMenu;
        private System.Windows.Forms.MenuItem trayExit;
    }
}

