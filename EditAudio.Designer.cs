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
            this.lbArtist = new System.Windows.Forms.Label();
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lbLyrics = new System.Windows.Forms.Label();
            this.txtLyrics = new System.Windows.Forms.TextBox();
            this.lbGenre = new System.Windows.Forms.Label();
            this.cbGenre = new System.Windows.Forms.ComboBox();
            this.chkNoSearch = new System.Windows.Forms.CheckBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbArtist
            // 
            this.lbArtist.AutoSize = true;
            this.lbArtist.Location = new System.Drawing.Point(0, 0);
            this.lbArtist.Name = "lbArtist";
            this.lbArtist.Size = new System.Drawing.Size(74, 13);
            this.lbArtist.TabIndex = 0;
            this.lbArtist.Text = "Исполнитель";
            // 
            // txtArtist
            // 
            this.txtArtist.Location = new System.Drawing.Point(8, 8);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(100, 20);
            this.txtArtist.TabIndex = 1;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(16, 16);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(57, 13);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "Название";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(24, 24);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(100, 20);
            this.txtTitle.TabIndex = 3;
            // 
            // lbLyrics
            // 
            this.lbLyrics.AutoSize = true;
            this.lbLyrics.Location = new System.Drawing.Point(32, 32);
            this.lbLyrics.Name = "lbLyrics";
            this.lbLyrics.Size = new System.Drawing.Size(76, 13);
            this.lbLyrics.TabIndex = 4;
            this.lbLyrics.Text = "Текст песьни";
            // 
            // txtLyrics
            // 
            this.txtLyrics.Location = new System.Drawing.Point(40, 40);
            this.txtLyrics.Multiline = true;
            this.txtLyrics.Name = "txtLyrics";
            this.txtLyrics.Size = new System.Drawing.Size(100, 20);
            this.txtLyrics.TabIndex = 5;
            this.txtLyrics.WordWrap = false;
            // 
            // lbGenre
            // 
            this.lbGenre.AutoSize = true;
            this.lbGenre.Location = new System.Drawing.Point(48, 48);
            this.lbGenre.Name = "lbGenre";
            this.lbGenre.Size = new System.Drawing.Size(30, 13);
            this.lbGenre.TabIndex = 6;
            this.lbGenre.Text = "Жар";
            // 
            // cbGenre
            // 
            this.cbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenre.FormattingEnabled = true;
            this.cbGenre.Location = new System.Drawing.Point(56, 56);
            this.cbGenre.Name = "cbGenre";
            this.cbGenre.Size = new System.Drawing.Size(121, 21);
            this.cbGenre.TabIndex = 7;
            // 
            // chkNoSearch
            // 
            this.chkNoSearch.AutoSize = true;
            this.chkNoSearch.Location = new System.Drawing.Point(64, 64);
            this.chkNoSearch.Name = "chkNoSearch";
            this.chkNoSearch.Size = new System.Drawing.Size(140, 17);
            this.chkNoSearch.TabIndex = 8;
            this.chkNoSearch.Text = "Не выдавать в поиске";
            this.chkNoSearch.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEdit.Location = new System.Drawing.Point(72, 72);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Отредактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_ClickAsync);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(80, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
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
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.chkNoSearch);
            this.Controls.Add(this.cbGenre);
            this.Controls.Add(this.lbGenre);
            this.Controls.Add(this.txtLyrics);
            this.Controls.Add(this.lbLyrics);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.txtArtist);
            this.Controls.Add(this.lbArtist);
            this.Name = "EditAudio";
            this.Text = "Редактирование аудио";
            this.Load += new System.EventHandler(this.EditAudio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbArtist;
        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lbLyrics;
        private System.Windows.Forms.TextBox txtLyrics;
        private System.Windows.Forms.Label lbGenre;
        private System.Windows.Forms.ComboBox cbGenre;
        private System.Windows.Forms.CheckBox chkNoSearch;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
    }
}