using System.Windows.Forms;

namespace GozalMusicMini
{
    partial class EditAudio
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
            this.tblEditAudio = new System.Windows.Forms.TableLayoutPanel();
            this.lbArtist = new System.Windows.Forms.Label();
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lbLyrics = new System.Windows.Forms.Label();
            this.txtLyrics = new System.Windows.Forms.TextBox();
            this.lbGenre = new System.Windows.Forms.Label();
            this.cbGenre = new System.Windows.Forms.ComboBox();
            this.lbNoSearch = new System.Windows.Forms.Label();
            this.chkNoSearch = new System.Windows.Forms.CheckBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tblEditAudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblEditAudio
            // 
            this.tblEditAudio.ColumnCount = 5;
            this.tblEditAudio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblEditAudio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblEditAudio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblEditAudio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblEditAudio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblEditAudio.Controls.Add(this.lbArtist, 0, 0);
            this.tblEditAudio.Controls.Add(this.txtArtist, 0, 1);
            this.tblEditAudio.Controls.Add(this.lbTitle, 1, 0);
            this.tblEditAudio.Controls.Add(this.txtTitle, 1, 1);
            this.tblEditAudio.Controls.Add(this.lbLyrics, 2, 0);
            this.tblEditAudio.Controls.Add(this.txtLyrics, 2, 1);
            this.tblEditAudio.Controls.Add(this.lbGenre, 3, 0);
            this.tblEditAudio.Controls.Add(this.cbGenre, 3, 1);
            this.tblEditAudio.Controls.Add(this.lbNoSearch, 4, 0);
            this.tblEditAudio.Controls.Add(this.chkNoSearch, 4, 1);
            this.tblEditAudio.Controls.Add(this.btnEdit, 0, 2);
            this.tblEditAudio.Controls.Add(this.btnCancel, 1, 2);
            this.tblEditAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEditAudio.Location = new System.Drawing.Point(0, 0);
            this.tblEditAudio.Name = "tblEditAudio";
            this.tblEditAudio.RowCount = 3;
            this.tblEditAudio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblEditAudio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblEditAudio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblEditAudio.Size = new System.Drawing.Size(292, 273);
            this.tblEditAudio.TabIndex = 0;
            // 
            // lbArtist
            // 
            this.lbArtist.AutoSize = true;
            this.lbArtist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbArtist.Location = new System.Drawing.Point(3, 0);
            this.lbArtist.Name = "lbArtist";
            this.lbArtist.Size = new System.Drawing.Size(110, 126);
            this.lbArtist.TabIndex = 0;
            this.lbArtist.Text = "Исполнитель";
            // 
            // txtArtist
            // 
            this.txtArtist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtArtist.Location = new System.Drawing.Point(3, 129);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(110, 20);
            this.txtArtist.TabIndex = 1;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Location = new System.Drawing.Point(119, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(110, 126);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "Название";
            // 
            // txtTitle
            // 
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Location = new System.Drawing.Point(119, 129);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(110, 20);
            this.txtTitle.TabIndex = 3;
            // 
            // lbLyrics
            // 
            this.lbLyrics.AutoSize = true;
            this.lbLyrics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLyrics.Location = new System.Drawing.Point(235, 0);
            this.lbLyrics.Name = "lbLyrics";
            this.lbLyrics.Size = new System.Drawing.Size(14, 126);
            this.lbLyrics.TabIndex = 4;
            this.lbLyrics.Text = "Текст песьни";
            // 
            // txtLyrics
            // 
            this.txtLyrics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLyrics.Location = new System.Drawing.Point(235, 129);
            this.txtLyrics.Multiline = true;
            this.txtLyrics.Name = "txtLyrics";
            this.txtLyrics.Size = new System.Drawing.Size(14, 120);
            this.txtLyrics.TabIndex = 5;
            // 
            // lbGenre
            // 
            this.lbGenre.AutoSize = true;
            this.lbGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGenre.Location = new System.Drawing.Point(255, 0);
            this.lbGenre.Name = "lbGenre";
            this.lbGenre.Size = new System.Drawing.Size(14, 126);
            this.lbGenre.TabIndex = 6;
            this.lbGenre.Text = "Жанр";
            // 
            // cbGenre
            // 
            this.cbGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenre.FormattingEnabled = true;
            this.cbGenre.Location = new System.Drawing.Point(255, 129);
            this.cbGenre.Name = "cbGenre";
            this.cbGenre.Size = new System.Drawing.Size(14, 21);
            this.cbGenre.TabIndex = 7;
            // 
            // lbNoSearch
            // 
            this.lbNoSearch.AutoSize = true;
            this.lbNoSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNoSearch.Location = new System.Drawing.Point(275, 0);
            this.lbNoSearch.Name = "lbNoSearch";
            this.lbNoSearch.Size = new System.Drawing.Size(14, 126);
            this.lbNoSearch.TabIndex = 8;
            this.lbNoSearch.Text = "Не выдавать в поиске";
            // 
            // chkNoSearch
            // 
            this.chkNoSearch.AutoSize = true;
            this.chkNoSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkNoSearch.Location = new System.Drawing.Point(275, 129);
            this.chkNoSearch.Name = "chkNoSearch";
            this.chkNoSearch.Size = new System.Drawing.Size(14, 120);
            this.chkNoSearch.TabIndex = 9;
            this.chkNoSearch.Text = "Не выдавать в поиске";
            this.chkNoSearch.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Location = new System.Drawing.Point(3, 255);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 15);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_ClickAsync);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(119, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 15);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditAudio
            // 
            this.AcceptButton = this.btnEdit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.ControlBox = false;
            this.Controls.Add(this.tblEditAudio);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditAudio";
            this.Text = "Редактирование аудио";
            this.Load += new System.EventHandler(this.EditAudio_Load);
            this.tblEditAudio.ResumeLayout(false);
            this.tblEditAudio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tblEditAudio;
        private Label lbArtist;
        private TextBox txtArtist;
        private Label lbTitle;
        private TextBox txtTitle;
        private Label lbLyrics;
        private TextBox txtLyrics;
        private Label lbGenre;
        private ComboBox cbGenre;
        private Label lbNoSearch;
        private CheckBox chkNoSearch;
        private Button btnEdit;
        private Button btnCancel;
    }
}