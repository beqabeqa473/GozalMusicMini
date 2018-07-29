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
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.mbMain = new System.Windows.Forms.MenuStrip();
            this.mbFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mbFileProxy = new System.Windows.Forms.ToolStripMenuItem();
            this.mbFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mbHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mbHelpDocumentation = new System.Windows.Forms.ToolStripMenuItem();
            this.mbHelpReportIssue = new System.Windows.Forms.ToolStripMenuItem();
            this.mbHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cmAudiosRecomsAudio = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAudiosRecomsOwner = new System.Windows.Forms.ToolStripMenuItem();
            this.lbVolume = new System.Windows.Forms.Label();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.lbSeek = new System.Windows.Forms.Label();
            this.tbSeek = new System.Windows.Forms.TrackBar();
            this.lbDevices = new System.Windows.Forms.Label();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.lbDownload = new System.Windows.Forms.Label();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.cmSections = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmSectionsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmSectionsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmSectionsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tmSeek = new System.Windows.Forms.Timer(this.components);
            this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmTrayExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tblMain.SuspendLayout();
            this.mbMain.SuspendLayout();
            this.cmAudios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSeek)).BeginInit();
            this.cmSections.SuspendLayout();
            this.cmTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 4;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tblMain.Controls.Add(this.mbMain, 0, 0);
            this.tblMain.Controls.Add(this.lbSections, 0, 1);
            this.tblMain.Controls.Add(this.tvSections, 0, 2);
            this.tblMain.Controls.Add(this.lbSearch, 1, 1);
            this.tblMain.Controls.Add(this.txtSearch, 1, 2);
            this.tblMain.Controls.Add(this.btnPopular, 1, 2);
            this.tblMain.Controls.Add(this.lbAudios, 0, 3);
            this.tblMain.Controls.Add(this.lvAudios, 1, 3);
            this.tblMain.Controls.Add(this.lbVolume, 0, 5);
            this.tblMain.Controls.Add(this.tbVolume, 0, 6);
            this.tblMain.Controls.Add(this.lbSeek, 1, 5);
            this.tblMain.Controls.Add(this.tbSeek, 1, 6);
            this.tblMain.Controls.Add(this.lbDevices, 2, 5);
            this.tblMain.Controls.Add(this.cbDevices, 2, 6);
            this.tblMain.Controls.Add(this.lbDownload, 3, 5);
            this.tblMain.Controls.Add(this.pbDownload, 3, 6);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 7;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.Size = new System.Drawing.Size(563, 482);
            this.tblMain.TabIndex = 0;
            // 
            // mbMain
            // 
            this.tblMain.SetColumnSpan(this.mbMain, 4);
            this.mbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbFile,
            this.mbHelp});
            this.mbMain.Location = new System.Drawing.Point(0, 0);
            this.mbMain.Name = "mbMain";
            this.mbMain.Size = new System.Drawing.Size(563, 191);
            this.mbMain.TabIndex = 0;
            this.mbMain.Text = "Главное меню";
            // 
            // mbFile
            // 
            this.mbFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbFileProxy,
            this.mbFileExit});
            this.mbFile.Name = "mbFile";
            this.mbFile.Size = new System.Drawing.Size(48, 187);
            this.mbFile.Text = "Файл";
            // 
            // mbFileProxy
            // 
            this.mbFileProxy.CheckOnClick = true;
            this.mbFileProxy.Name = "mbFileProxy";
            this.mbFileProxy.Size = new System.Drawing.Size(183, 22);
            this.mbFileProxy.Text = "Использовать proxy";
            this.mbFileProxy.Click += new System.EventHandler(this.mbFileProxy_Click);
            // 
            // mbFileExit
            // 
            this.mbFileExit.Name = "mbFileExit";
            this.mbFileExit.Size = new System.Drawing.Size(183, 22);
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
            this.mbHelp.Size = new System.Drawing.Size(65, 187);
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
            // lbSections
            // 
            this.lbSections.AutoSize = true;
            this.lbSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSections.Location = new System.Drawing.Point(3, 191);
            this.lbSections.Name = "lbSections";
            this.lbSections.Size = new System.Drawing.Size(255, 191);
            this.lbSections.TabIndex = 1;
            this.lbSections.Text = "Разделы";
            // 
            // tvSections
            // 
            this.tvSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSections.Location = new System.Drawing.Point(3, 385);
            this.tvSections.Name = "tvSections";
            this.tvSections.Size = new System.Drawing.Size(255, 14);
            this.tvSections.TabIndex = 2;
            this.tvSections.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvSections_AfterSelectAsync);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSearch.Location = new System.Drawing.Point(264, 191);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(255, 191);
            this.lbSearch.TabIndex = 3;
            this.lbSearch.Text = "Поисковый запрос";
            this.lbSearch.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(525, 385);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(14, 20);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.Visible = false;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown_1Async);
            // 
            // btnPopular
            // 
            this.btnPopular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPopular.Location = new System.Drawing.Point(264, 385);
            this.btnPopular.Name = "btnPopular";
            this.btnPopular.Size = new System.Drawing.Size(255, 14);
            this.btnPopular.TabIndex = 5;
            this.btnPopular.Text = "Показать популярные аудиозаписи";
            this.btnPopular.UseVisualStyleBackColor = true;
            this.btnPopular.Visible = false;
            this.btnPopular.Click += new System.EventHandler(this.BtnPopular_ClickAsync);
            // 
            // lbAudios
            // 
            this.lbAudios.AutoSize = true;
            this.lbAudios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAudios.Location = new System.Drawing.Point(3, 402);
            this.lbAudios.Name = "lbAudios";
            this.lbAudios.Size = new System.Drawing.Size(255, 20);
            this.lbAudios.TabIndex = 6;
            this.lbAudios.Text = "Список аудио";
            // 
            // lvAudios
            // 
            this.lvAudios.CheckBoxes = true;
            this.tblMain.SetColumnSpan(this.lvAudios, 4);
            this.lvAudios.ContextMenuStrip = this.cmAudios;
            this.lvAudios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAudios.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvAudios.HideSelection = false;
            this.lvAudios.Location = new System.Drawing.Point(3, 425);
            this.lvAudios.MultiSelect = false;
            this.lvAudios.Name = "lvAudios";
            this.lvAudios.Size = new System.Drawing.Size(557, 14);
            this.lvAudios.TabIndex = 7;
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
            this.cmAudiosRestore,
            this.cmAudiosRecomsAudio,
            this.cmAudiosRecomsOwner});
            this.cmAudios.Name = "cmAudios";
            this.cmAudios.Size = new System.Drawing.Size(350, 180);
            // 
            // cmAudiosPlay
            // 
            this.cmAudiosPlay.Name = "cmAudiosPlay";
            this.cmAudiosPlay.Size = new System.Drawing.Size(349, 22);
            this.cmAudiosPlay.Text = "Играть";
            this.cmAudiosPlay.Click += new System.EventHandler(this.Play_Click);
            // 
            // cmAudiosDownload
            // 
            this.cmAudiosDownload.Name = "cmAudiosDownload";
            this.cmAudiosDownload.Size = new System.Drawing.Size(349, 22);
            this.cmAudiosDownload.Text = "Скачать";
            this.cmAudiosDownload.Click += new System.EventHandler(this.cmAudiosDownload_ClickAsync);
            // 
            // cmAudiosAdd
            // 
            this.cmAudiosAdd.Name = "cmAudiosAdd";
            this.cmAudiosAdd.Size = new System.Drawing.Size(349, 22);
            this.cmAudiosAdd.Text = "Добавить аудио запись";
            this.cmAudiosAdd.Click += new System.EventHandler(this.Add_ClickAsync);
            // 
            // cmAudiosEdit
            // 
            this.cmAudiosEdit.Name = "cmAudiosEdit";
            this.cmAudiosEdit.Size = new System.Drawing.Size(349, 22);
            this.cmAudiosEdit.Text = "Редактировать аудио запись";
            this.cmAudiosEdit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // cmAudiosDelete
            // 
            this.cmAudiosDelete.Name = "cmAudiosDelete";
            this.cmAudiosDelete.Size = new System.Drawing.Size(349, 22);
            this.cmAudiosDelete.Text = "Удалить аудио запись";
            this.cmAudiosDelete.Click += new System.EventHandler(this.Delete_ClickAsync);
            // 
            // cmAudiosRestore
            // 
            this.cmAudiosRestore.Name = "cmAudiosRestore";
            this.cmAudiosRestore.Size = new System.Drawing.Size(349, 22);
            this.cmAudiosRestore.Text = "Востановить аудио запись";
            this.cmAudiosRestore.Click += new System.EventHandler(this.cmAudiosRestore_ClickAsync);
            // 
            // cmAudiosRecomsAudio
            // 
            this.cmAudiosRecomsAudio.Name = "cmAudiosRecomsAudio";
            this.cmAudiosRecomsAudio.Size = new System.Drawing.Size(349, 22);
            this.cmAudiosRecomsAudio.Text = "Рекомендации на основе текущей аудио записи";
            this.cmAudiosRecomsAudio.Click += new System.EventHandler(this.cmAudiosRecomsAudio_ClickAsync);
            // 
            // cmAudiosRecomsOwner
            // 
            this.cmAudiosRecomsOwner.Name = "cmAudiosRecomsOwner";
            this.cmAudiosRecomsOwner.Size = new System.Drawing.Size(349, 22);
            this.cmAudiosRecomsOwner.Text = "Рекомендации на основе владельца аудио записи";
            this.cmAudiosRecomsOwner.Click += new System.EventHandler(this.cmAudiosRecomsOwner_ClickAsync);
            // 
            // lbVolume
            // 
            this.lbVolume.AutoSize = true;
            this.lbVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbVolume.Location = new System.Drawing.Point(3, 442);
            this.lbVolume.Name = "lbVolume";
            this.lbVolume.Size = new System.Drawing.Size(255, 20);
            this.lbVolume.TabIndex = 8;
            this.lbVolume.Text = "Громкость";
            // 
            // tbVolume
            // 
            this.tbVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbVolume.Location = new System.Drawing.Point(3, 465);
            this.tbVolume.Maximum = 100;
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(255, 14);
            this.tbVolume.TabIndex = 9;
            this.tbVolume.Value = 50;
            this.tbVolume.Scroll += new System.EventHandler(this.TbVolume_Scroll);
            this.tbVolume.ValueChanged += new System.EventHandler(this.TbVolume_ValueChanged);
            // 
            // lbSeek
            // 
            this.lbSeek.AutoSize = true;
            this.lbSeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSeek.Location = new System.Drawing.Point(264, 442);
            this.lbSeek.Name = "lbSeek";
            this.lbSeek.Size = new System.Drawing.Size(255, 20);
            this.lbSeek.TabIndex = 10;
            this.lbSeek.Text = "Перемотка";
            // 
            // tbSeek
            // 
            this.tbSeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSeek.Location = new System.Drawing.Point(264, 465);
            this.tbSeek.Maximum = 100;
            this.tbSeek.Name = "tbSeek";
            this.tbSeek.Size = new System.Drawing.Size(255, 14);
            this.tbSeek.TabIndex = 11;
            this.tbSeek.Scroll += new System.EventHandler(this.TbSeek_Scroll);
            // 
            // lbDevices
            // 
            this.lbDevices.AutoSize = true;
            this.lbDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDevices.Location = new System.Drawing.Point(525, 442);
            this.lbDevices.Name = "lbDevices";
            this.lbDevices.Size = new System.Drawing.Size(14, 20);
            this.lbDevices.TabIndex = 12;
            this.lbDevices.Text = "Устройства вывода";
            // 
            // cbDevices
            // 
            this.cbDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(525, 465);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(14, 21);
            this.cbDevices.TabIndex = 13;
            this.cbDevices.SelectedIndexChanged += new System.EventHandler(this.CbDevices_SelectedIndexChanged);
            // 
            // lbDownload
            // 
            this.lbDownload.AutoSize = true;
            this.lbDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDownload.Location = new System.Drawing.Point(545, 442);
            this.lbDownload.Name = "lbDownload";
            this.lbDownload.Size = new System.Drawing.Size(15, 20);
            this.lbDownload.TabIndex = 14;
            this.lbDownload.Text = "Ход выполнения";
            // 
            // pbDownload
            // 
            this.pbDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDownload.Location = new System.Drawing.Point(545, 465);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(15, 14);
            this.pbDownload.TabIndex = 15;
            // 
            // cmSections
            // 
            this.cmSections.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmSectionsAdd,
            this.cmSectionsEdit,
            this.cmSectionsDelete});
            this.cmSections.Name = "cmSections";
            this.cmSections.Size = new System.Drawing.Size(200, 70);
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
            // tmSeek
            // 
            this.tmSeek.Enabled = true;
            this.tmSeek.Interval = 500;
            this.tmSeek.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // niTray
            // 
            this.niTray.Icon = ((System.Drawing.Icon)(resources.GetObject("niTray.Icon")));
            this.niTray.Text = "Gozal Music Mini";
            this.niTray.Visible = true;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 482);
            this.Controls.Add(this.tblMain);
            this.KeyPreview = true;
            this.MainMenuStrip = this.mbMain;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "gozal_music";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_LoadAsync);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.mbMain.ResumeLayout(false);
            this.mbMain.PerformLayout();
            this.cmAudios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSeek)).EndInit();
            this.cmSections.ResumeLayout(false);
            this.cmTray.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.MenuStrip mbMain;
        private System.Windows.Forms.ToolStripMenuItem mbFile;
        private System.Windows.Forms.ToolStripMenuItem mbHelp;
        private System.Windows.Forms.ToolStripMenuItem mbFileProxy;
        private System.Windows.Forms.ToolStripMenuItem mbFileExit;
        private System.Windows.Forms.ToolStripMenuItem mbHelpDocumentation;
        private System.Windows.Forms.ToolStripMenuItem mbHelpReportIssue;
        private System.Windows.Forms.ToolStripMenuItem mbHelpAbout;
        private System.Windows.Forms.Label lbSections;
        private System.Windows.Forms.TreeView tvSections;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ContextMenuStrip cmSections;
        private System.Windows.Forms.ToolStripMenuItem cmSectionsAdd;
        private System.Windows.Forms.ToolStripMenuItem cmSectionsEdit;
        private System.Windows.Forms.ToolStripMenuItem cmSectionsDelete;
        private System.Windows.Forms.Button btnPopular;
        private System.Windows.Forms.Label lbAudios;
        private System.Windows.Forms.ListView lvAudios;
        private System.Windows.Forms.ContextMenuStrip cmAudios;
        private System.Windows.Forms.ToolStripMenuItem cmAudiosPlay;
        private System.Windows.Forms.ToolStripMenuItem cmAudiosDownload;
        private System.Windows.Forms.ToolStripMenuItem cmAudiosAdd;
        private System.Windows.Forms.ToolStripMenuItem cmAudiosEdit;
        private System.Windows.Forms.ToolStripMenuItem cmAudiosDelete;
        private System.Windows.Forms.ToolStripMenuItem cmAudiosRestore;
        private System.Windows.Forms.ToolStripMenuItem cmAudiosRecomsAudio;
        private System.Windows.Forms.ToolStripMenuItem cmAudiosRecomsOwner;
        private System.Windows.Forms.Label lbVolume;
        private System.Windows.Forms.TrackBar tbVolume;
        private System.Windows.Forms.Label lbSeek;
        private System.Windows.Forms.TrackBar tbSeek;
        private System.Windows.Forms.Label lbDevices;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.Label lbDownload;
        private System.Windows.Forms.ProgressBar pbDownload;
        private System.Windows.Forms.Timer tmSeek;
        private System.Windows.Forms.NotifyIcon niTray;
        private System.Windows.Forms.ContextMenuStrip cmTray;
        private System.Windows.Forms.ToolStripMenuItem cmTrayExit;
    }
}

