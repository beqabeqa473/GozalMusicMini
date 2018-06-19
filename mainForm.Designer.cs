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
            this.lbSections = new System.Windows.Forms.Label();
            this.tvSections = new System.Windows.Forms.TreeView();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnPopular = new System.Windows.Forms.Button();
            this.lbAudios = new System.Windows.Forms.Label();
            this.lvAudios = new System.Windows.Forms.ListView();
            this.cmAudios = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmAudiosPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAudiosDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAudiosAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAudiosEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAudiosDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAudiosRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.lbVolume = new System.Windows.Forms.Label();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.lbSeek = new System.Windows.Forms.Label();
            this.tbSeek = new System.Windows.Forms.TrackBar();
            this.tmSeek = new System.Windows.Forms.Timer(this.components);
            this.lbDevices = new System.Windows.Forms.Label();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmTrayExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mbMain = new System.Windows.Forms.MenuStrip();
            this.mbFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mbFileProxy = new System.Windows.Forms.ToolStripMenuItem();
            this.mbFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mbHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mbHelpDocumentation = new System.Windows.Forms.ToolStripMenuItem();
            this.mbHelpReportIssue = new System.Windows.Forms.ToolStripMenuItem();
            this.mbHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.cmSections = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmSectionsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmSectionsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmSectionsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAudios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSeek)).BeginInit();
            this.cmTray.SuspendLayout();
            this.mbMain.SuspendLayout();
            this.cmSections.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSections
            // 
            this.lbSections.AutoSize = true;
            this.lbSections.Location = new System.Drawing.Point(0, 0);
            this.lbSections.Name = "lbSections";
            this.lbSections.Size = new System.Drawing.Size(52, 13);
            this.lbSections.TabIndex = 0;
            this.lbSections.Text = "Разделы";
            // 
            // tvSections
            // 
            this.tvSections.Location = new System.Drawing.Point(8, 8);
            this.tvSections.Name = "tvSections";
            this.tvSections.Size = new System.Drawing.Size(121, 97);
            this.tvSections.TabIndex = 1;
            this.tvSections.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvSections_AfterSelect);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(16, 16);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(104, 13);
            this.lbSearch.TabIndex = 2;
            this.lbSearch.Text = "Поисковый запрос";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(24, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown_1Async);
            // 
            // btnPopular
            // 
            this.btnPopular.Enabled = false;
            this.btnPopular.Location = new System.Drawing.Point(32, 32);
            this.btnPopular.Name = "btnPopular";
            this.btnPopular.Size = new System.Drawing.Size(75, 23);
            this.btnPopular.TabIndex = 4;
            this.btnPopular.Text = "Показать популярные";
            this.btnPopular.UseVisualStyleBackColor = true;
            this.btnPopular.Click += new System.EventHandler(this.BtnPopular_ClickAsync);
            // 
            // lbAudios
            // 
            this.lbAudios.AutoSize = true;
            this.lbAudios.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAudios.Location = new System.Drawing.Point(40, 40);
            this.lbAudios.Name = "lbAudios";
            this.lbAudios.Size = new System.Drawing.Size(76, 13);
            this.lbAudios.TabIndex = 5;
            this.lbAudios.Text = "Список аудио";
            // 
            // lvAudios
            // 
            this.lvAudios.CheckBoxes = true;
            this.lvAudios.ContextMenuStrip = this.cmAudios;
            this.lvAudios.LabelWrap = false;
            this.lvAudios.Location = new System.Drawing.Point(48, 48);
            this.lvAudios.MultiSelect = false;
            this.lvAudios.Name = "lvAudios";
            this.lvAudios.Size = new System.Drawing.Size(121, 97);
            this.lvAudios.TabIndex = 6;
            this.lvAudios.UseCompatibleStateImageBehavior = false;
            this.lvAudios.View = System.Windows.Forms.View.Details;
            this.lvAudios.SelectedIndexChanged += new System.EventHandler(this.LvAudios_SelectedIndexChanged);
            this.lvAudios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvAudios_KeyDown);
            this.lvAudios.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvAudios_MouseDoubleClick);
            // 
            // cmAudios
            // 
            this.cmAudios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmAudiosPlay,
            this.cmAudiosDownload,
            this.cmAudiosAdd,
            this.cmAudiosEdit,
            this.cmAudiosDelete,
            this.cmAudiosRestore});
            this.cmAudios.Name = "cmAudios";
            this.cmAudios.Size = new System.Drawing.Size(190, 136);
            // 
            // cmAudiosPlay
            // 
            this.cmAudiosPlay.Name = "cmAudiosPlay";
            this.cmAudiosPlay.Size = new System.Drawing.Size(189, 22);
            this.cmAudiosPlay.Text = "Играть";
            this.cmAudiosPlay.Click += new System.EventHandler(this.Play_Click);
            // 
            // cmAudiosDownload
            // 
            this.cmAudiosDownload.Name = "cmAudiosDownload";
            this.cmAudiosDownload.Size = new System.Drawing.Size(189, 22);
            this.cmAudiosDownload.Text = "Скачать";
            this.cmAudiosDownload.Click += new System.EventHandler(this.cmAudiosDownload_ClickAsync);
            // 
            // cmAudiosAdd
            // 
            this.cmAudiosAdd.Name = "cmAudiosAdd";
            this.cmAudiosAdd.Size = new System.Drawing.Size(189, 22);
            this.cmAudiosAdd.Text = "Добавить аудио";
            this.cmAudiosAdd.Click += new System.EventHandler(this.Add_ClickAsync);
            // 
            // cmAudiosEdit
            // 
            this.cmAudiosEdit.Name = "cmAudiosEdit";
            this.cmAudiosEdit.Size = new System.Drawing.Size(189, 22);
            this.cmAudiosEdit.Text = "Редактировать аудио";
            this.cmAudiosEdit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // cmAudiosDelete
            // 
            this.cmAudiosDelete.Name = "cmAudiosDelete";
            this.cmAudiosDelete.Size = new System.Drawing.Size(189, 22);
            this.cmAudiosDelete.Text = "Удалить аудио";
            this.cmAudiosDelete.Click += new System.EventHandler(this.Delete_ClickAsync);
            // 
            // cmAudiosRestore
            // 
            this.cmAudiosRestore.Name = "cmAudiosRestore";
            this.cmAudiosRestore.Size = new System.Drawing.Size(189, 22);
            this.cmAudiosRestore.Text = "Востановить аудио";
            this.cmAudiosRestore.Visible = false;
            this.cmAudiosRestore.Click += new System.EventHandler(this.cmAudiosRestore_ClickAsync);
            // 
            // lbVolume
            // 
            this.lbVolume.AutoSize = true;
            this.lbVolume.Location = new System.Drawing.Point(56, 56);
            this.lbVolume.Name = "lbVolume";
            this.lbVolume.Size = new System.Drawing.Size(62, 13);
            this.lbVolume.TabIndex = 7;
            this.lbVolume.Text = "Громкость";
            // 
            // tbVolume
            // 
            this.tbVolume.Location = new System.Drawing.Point(64, 64);
            this.tbVolume.Maximum = 100;
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(104, 45);
            this.tbVolume.TabIndex = 8;
            this.tbVolume.Value = 50;
            this.tbVolume.Scroll += new System.EventHandler(this.TbVolume_Scroll);
            this.tbVolume.ValueChanged += new System.EventHandler(this.TbVolume_ValueChanged);
            // 
            // lbSeek
            // 
            this.lbSeek.AutoSize = true;
            this.lbSeek.Location = new System.Drawing.Point(72, 72);
            this.lbSeek.Name = "lbSeek";
            this.lbSeek.Size = new System.Drawing.Size(64, 13);
            this.lbSeek.TabIndex = 9;
            this.lbSeek.Text = "Перемотка";
            // 
            // tbSeek
            // 
            this.tbSeek.Location = new System.Drawing.Point(80, 80);
            this.tbSeek.Maximum = 100;
            this.tbSeek.Name = "tbSeek";
            this.tbSeek.Size = new System.Drawing.Size(104, 45);
            this.tbSeek.TabIndex = 10;
            this.tbSeek.Scroll += new System.EventHandler(this.TbSeek_Scroll);
            // 
            // tmSeek
            // 
            this.tmSeek.Enabled = true;
            this.tmSeek.Interval = 500;
            this.tmSeek.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // lbDevices
            // 
            this.lbDevices.AutoSize = true;
            this.lbDevices.Location = new System.Drawing.Point(0, 0);
            this.lbDevices.Name = "lbDevices";
            this.lbDevices.Size = new System.Drawing.Size(108, 13);
            this.lbDevices.TabIndex = 11;
            this.lbDevices.Text = "Устройство вывода";
            // 
            // cbDevices
            // 
            this.cbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(8, 8);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(121, 21);
            this.cbDevices.TabIndex = 12;
            this.cbDevices.SelectedIndexChanged += new System.EventHandler(this.CbDevices_SelectedIndexChanged);
            // 
            // pbDownload
            // 
            this.pbDownload.Location = new System.Drawing.Point(0, 0);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(100, 23);
            this.pbDownload.TabIndex = 13;
            // 
            // niTray
            // 
            this.niTray.ContextMenuStrip = this.cmTray;
            this.niTray.Icon = ((System.Drawing.Icon)(resources.GetObject("niTray.Icon")));
            this.niTray.Text = "GozalMusicMini";
            this.niTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            // 
            // cmTray
            // 
            this.cmTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmTrayExit});
            this.cmTray.Name = "cmTray";
            this.cmTray.Size = new System.Drawing.Size(109, 26);
            // 
            // cmTrayExit
            // 
            this.cmTrayExit.Name = "cmTrayExit";
            this.cmTrayExit.Size = new System.Drawing.Size(108, 22);
            this.cmTrayExit.Text = "Выход";
            this.cmTrayExit.Click += new System.EventHandler(this.MbFileExit_Click);
            // 
            // mbMain
            // 
            this.mbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbFile,
            this.mbHelp});
            this.mbMain.Location = new System.Drawing.Point(0, 0);
            this.mbMain.Name = "mbMain";
            this.mbMain.Size = new System.Drawing.Size(563, 24);
            this.mbMain.TabIndex = 14;
            this.mbMain.Text = "menuStrip1";
            // 
            // mbFile
            // 
            this.mbFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbFileProxy,
            this.mbFileExit});
            this.mbFile.Name = "mbFile";
            this.mbFile.Size = new System.Drawing.Size(48, 20);
            this.mbFile.Text = "Файл";
            // 
            // mbFileProxy
            // 
            this.mbFileProxy.Name = "mbFileProxy";
            this.mbFileProxy.Size = new System.Drawing.Size(194, 22);
            this.mbFileProxy.Text = "Использовать прокси";
            this.mbFileProxy.Click += new System.EventHandler(this.mbFileProxy_Click);
            // 
            // mbFileExit
            // 
            this.mbFileExit.Name = "mbFileExit";
            this.mbFileExit.Size = new System.Drawing.Size(194, 22);
            this.mbFileExit.Text = "Выход";
            this.mbFileExit.Click += new System.EventHandler(this.MbFileExit_Click);
            // 
            // mbHelp
            // 
            this.mbHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbHelpDocumentation,
            this.mbHelpReportIssue,
            this.mbHelpAbout});
            this.mbHelp.Name = "mbHelp";
            this.mbHelp.Size = new System.Drawing.Size(65, 20);
            this.mbHelp.Text = "Справка";
            // 
            // mbHelpDocumentation
            // 
            this.mbHelpDocumentation.Name = "mbHelpDocumentation";
            this.mbHelpDocumentation.Size = new System.Drawing.Size(196, 22);
            this.mbHelpDocumentation.Text = "Документация";
            // 
            // mbHelpReportIssue
            // 
            this.mbHelpReportIssue.Name = "mbHelpReportIssue";
            this.mbHelpReportIssue.Size = new System.Drawing.Size(196, 22);
            this.mbHelpReportIssue.Text = "Сообщить об ошибке";
            this.mbHelpReportIssue.Click += new System.EventHandler(this.ReportIssue_Click);
            // 
            // mbHelpAbout
            // 
            this.mbHelpAbout.Name = "mbHelpAbout";
            this.mbHelpAbout.Size = new System.Drawing.Size(196, 22);
            this.mbHelpAbout.Text = "О программе";
            // 
            // cmSections
            // 
            this.cmSections.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmSectionsAdd,
            this.cmSectionsEdit,
            this.cmSectionsDelete});
            this.cmSections.Name = "cmSections";
            this.cmSections.Size = new System.Drawing.Size(200, 92);
            // 
            // cmSectionsAdd
            // 
            this.cmSectionsAdd.Name = "cmSectionsAdd";
            this.cmSectionsAdd.Size = new System.Drawing.Size(199, 22);
            this.cmSectionsAdd.Text = "Добавить альбом";
            this.cmSectionsAdd.Click += new System.EventHandler(this.AddAlbum_Click);
            // 
            // cmSectionsEdit
            // 
            this.cmSectionsEdit.Name = "cmSectionsEdit";
            this.cmSectionsEdit.Size = new System.Drawing.Size(199, 22);
            this.cmSectionsEdit.Text = "Редактировать альбом";
            this.cmSectionsEdit.Click += new System.EventHandler(this.EditAlbum_Click);
            // 
            // cmSectionsDelete
            // 
            this.cmSectionsDelete.Name = "cmSectionsDelete";
            this.cmSectionsDelete.Size = new System.Drawing.Size(199, 22);
            this.cmSectionsDelete.Text = "Удалить альбом";
            this.cmSectionsDelete.Click += new System.EventHandler(this.DeleteAlbum_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 482);
            this.Controls.Add(this.pbDownload);
            this.Controls.Add(this.cbDevices);
            this.Controls.Add(this.lbDevices);
            this.Controls.Add(this.tbSeek);
            this.Controls.Add(this.lbSeek);
            this.Controls.Add(this.tbVolume);
            this.Controls.Add(this.lbVolume);
            this.Controls.Add(this.lvAudios);
            this.Controls.Add(this.lbAudios);
            this.Controls.Add(this.btnPopular);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.tvSections);
            this.Controls.Add(this.lbSections);
            this.Controls.Add(this.mbMain);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "gozal_music";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_LoadAsync);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.cmAudios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSeek)).EndInit();
            this.cmTray.ResumeLayout(false);
            this.mbMain.ResumeLayout(false);
            this.mbMain.PerformLayout();
            this.cmSections.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Label lbSections;
        private System.Windows.Forms.TreeView tvSections;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnPopular;
        private System.Windows.Forms.Label lbAudios;
        private System.Windows.Forms.ListView lvAudios;
        private System.Windows.Forms.ContextMenuStrip cmAudios;
        private System.Windows.Forms.ToolStripMenuItem cmAudiosPlay;
        private System.Windows.Forms.ToolStripMenuItem cmAudiosAdd;
        private System.Windows.Forms.ToolStripMenuItem cmAudiosEdit;
        private System.Windows.Forms.ToolStripMenuItem cmAudiosDelete;
        private System.Windows.Forms.Label lbVolume;
        private System.Windows.Forms.TrackBar tbVolume;
        private System.Windows.Forms.Label lbSeek;
        private System.Windows.Forms.TrackBar tbSeek;
        private System.Windows.Forms.Timer tmSeek;
        private System.Windows.Forms.Label lbDevices;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.ProgressBar pbDownload;
        private System.Windows.Forms.NotifyIcon niTray;
        private System.Windows.Forms.ContextMenuStrip cmTray;
        private System.Windows.Forms.ToolStripMenuItem cmTrayExit;
        private System.Windows.Forms.MenuStrip mbMain;
        private System.Windows.Forms.ToolStripMenuItem mbFile;
        private System.Windows.Forms.ToolStripMenuItem mbFileExit;
        private System.Windows.Forms.ToolStripMenuItem mbHelp;
        private System.Windows.Forms.ToolStripMenuItem mbHelpDocumentation;
        private System.Windows.Forms.ToolStripMenuItem mbHelpReportIssue;
        private System.Windows.Forms.ToolStripMenuItem mbHelpAbout;
        private System.Windows.Forms.ContextMenuStrip cmSections;
        private System.Windows.Forms.ToolStripMenuItem cmSectionsAdd;
        private System.Windows.Forms.ToolStripMenuItem cmSectionsEdit;
        private System.Windows.Forms.ToolStripMenuItem cmSectionsDelete;
        private System.Windows.Forms.ToolStripMenuItem mbFileProxy;
        private System.Windows.Forms.ToolStripMenuItem cmAudiosRestore;
        private System.Windows.Forms.ToolStripMenuItem cmAudiosDownload;
    }
}

