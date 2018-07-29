using System.Windows.Forms;

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
            this.tblReportIssue = new System.Windows.Forms.TableLayoutPanel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.titleTxt = new System.Windows.Forms.TextBox();
            this.lbComment = new System.Windows.Forms.Label();
            this.commentTxt = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tblReportIssue.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblReportIssue
            // 
            this.tblReportIssue.ColumnCount = 2;
            this.tblReportIssue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblReportIssue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblReportIssue.Controls.Add(this.lbTitle, 0, 0);
            this.tblReportIssue.Controls.Add(this.titleTxt, 0, 1);
            this.tblReportIssue.Controls.Add(this.lbComment, 1, 0);
            this.tblReportIssue.Controls.Add(this.commentTxt, 1, 1);
            this.tblReportIssue.Controls.Add(this.btnReport, 0, 2);
            this.tblReportIssue.Controls.Add(this.btnClose, 1, 2);
            this.tblReportIssue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblReportIssue.Location = new System.Drawing.Point(0, 0);
            this.tblReportIssue.Name = "tblReportIssue";
            this.tblReportIssue.RowCount = 3;
            this.tblReportIssue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblReportIssue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblReportIssue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblReportIssue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblReportIssue.Size = new System.Drawing.Size(772, 450);
            this.tblReportIssue.TabIndex = 0;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Location = new System.Drawing.Point(3, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(380, 215);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Заголовок ошибки";
            // 
            // titleTxt
            // 
            this.titleTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleTxt.Location = new System.Drawing.Point(3, 218);
            this.titleTxt.Name = "titleTxt";
            this.titleTxt.Size = new System.Drawing.Size(380, 20);
            this.titleTxt.TabIndex = 1;
            // 
            // lbComment
            // 
            this.lbComment.AutoSize = true;
            this.lbComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbComment.Location = new System.Drawing.Point(389, 0);
            this.lbComment.Name = "lbComment";
            this.lbComment.Size = new System.Drawing.Size(380, 215);
            this.lbComment.TabIndex = 2;
            this.lbComment.Text = "Текст";
            // 
            // commentTxt
            // 
            this.commentTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commentTxt.Location = new System.Drawing.Point(389, 218);
            this.commentTxt.Multiline = true;
            this.commentTxt.Name = "commentTxt";
            this.commentTxt.Size = new System.Drawing.Size(380, 209);
            this.commentTxt.TabIndex = 3;
            this.commentTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commentTxt_KeyDown);
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReport.Location = new System.Drawing.Point(3, 433);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(380, 14);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "Отправить";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_ClickAsync);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point(389, 433);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(380, 14);
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
            this.ControlBox = false;
            this.Controls.Add(this.tblReportIssue);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportIssue";
            this.Text = "Сообщить об ошибке";
            this.tblReportIssue.ResumeLayout(false);
            this.tblReportIssue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tblReportIssue;
        private Label lbTitle;
        private TextBox titleTxt;
        private Label lbComment;
        private TextBox commentTxt;
        private Button btnReport;
        private Button btnClose;
    }
}