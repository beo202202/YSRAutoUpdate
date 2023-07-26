namespace Devil2.ucPanel
{
    partial class ucPanel1
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lboxLog = new System.Windows.Forms.ListBox();
            this.lblPanel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lboxLog
            // 
            this.lboxLog.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lboxLog.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lboxLog.FormattingEnabled = true;
            this.lboxLog.ItemHeight = 12;
            this.lboxLog.Location = new System.Drawing.Point(5, 26);
            this.lboxLog.Name = "lboxLog";
            this.lboxLog.Size = new System.Drawing.Size(462, 376);
            this.lboxLog.TabIndex = 17;
            // 
            // lblPanel
            // 
            this.lblPanel.AutoSize = true;
            this.lblPanel.Location = new System.Drawing.Point(3, 11);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(31, 12);
            this.lblPanel.TabIndex = 16;
            this.lblPanel.Text = "(0,0)";
            this.lblPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPanel1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lboxLog);
            this.Controls.Add(this.lblPanel);
            this.Name = "ucPanel1";
            this.Size = new System.Drawing.Size(720, 644);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox lboxLog;
        private System.Windows.Forms.Label lblPanel;
    }
}
