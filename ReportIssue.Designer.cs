namespace GozalMusicMini
{
    partial class ReportIssue
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.titleTxt = new System.Windows.Forms.TextBox();
            this.lbComment = new System.Windows.Forms.Label();
            this.commentTxt = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(102, 13);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Заголовок ошибки";
            // 
            // titleTxt
            // 
            this.titleTxt.Location = new System.Drawing.Point(8, 8);
            this.titleTxt.Name = "titleTxt";
            this.titleTxt.Size = new System.Drawing.Size(100, 20);
            this.titleTxt.TabIndex = 1;
            // 
            // lbComment
            // 
            this.lbComment.AutoSize = true;
            this.lbComment.Location = new System.Drawing.Point(0, 0);
            this.lbComment.Name = "lbComment";
            this.lbComment.Size = new System.Drawing.Size(37, 13);
            this.lbComment.TabIndex = 2;
            this.lbComment.Text = "Текст";
            // 
            // commentTxt
            // 
            this.commentTxt.AcceptsReturn = true;
            this.commentTxt.Location = new System.Drawing.Point(8, 8);
            this.commentTxt.Multiline = true;
            this.commentTxt.Name = "commentTxt";
            this.commentTxt.Size = new System.Drawing.Size(100, 20);
            this.commentTxt.TabIndex = 3;
            this.commentTxt.WordWrap = false;
            this.commentTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commentTxt_KeyDown);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(8, 8);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "Отправить";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_ClickAsync);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(16, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReportIssue
            // 
            this.AcceptButton = this.btnReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(772, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.commentTxt);
            this.Controls.Add(this.lbComment);
            this.Controls.Add(this.titleTxt);
            this.Controls.Add(this.lbTitle);
            this.Name = "ReportIssue";
            this.Text = "Сообщить об ошибке";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TextBox titleTxt;
        private System.Windows.Forms.Label lbComment;
        private System.Windows.Forms.TextBox commentTxt;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClose;
    }
}