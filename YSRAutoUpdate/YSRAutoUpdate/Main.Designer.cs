namespace YSR
{
    partial class Main
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.lboxLog = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.labelProgressBar1 = new YSRAutoUpdate.LabelProgressBar();
            this.labelProgressBar2 = new YSRAutoUpdate.LabelProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lboxLog, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelProgressBar1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelProgressBar2, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(435, 512);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Font = new System.Drawing.Font("Tmon몬소리 Black", 10F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 301);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(435, 17);
            this.textBox1.TabIndex = 21;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.SandyBrown;
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("배달의민족 도현", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Location = new System.Drawing.Point(0, 318);
            this.button9.Margin = new System.Windows.Forms.Padding(0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(435, 50);
            this.button9.TabIndex = 20;
            this.button9.Text = "버튼";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // lboxLog
            // 
            this.lboxLog.BackColor = System.Drawing.SystemColors.MenuText;
            this.lboxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lboxLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.lboxLog.Font = new System.Drawing.Font("Tmon몬소리 Black", 12F, System.Drawing.FontStyle.Bold);
            this.lboxLog.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lboxLog.FormattingEnabled = true;
            this.lboxLog.ItemHeight = 20;
            this.lboxLog.Location = new System.Drawing.Point(0, 0);
            this.lboxLog.Margin = new System.Windows.Forms.Padding(0);
            this.lboxLog.Name = "lboxLog";
            this.lboxLog.Size = new System.Drawing.Size(435, 300);
            this.lboxLog.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 401);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 108);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(125, 20);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.Text = "테스트";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(6, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(99, 16);
            this.radioButton1.TabIndex = 18;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "자동 업데이트";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // labelProgressBar1
            // 
            this.labelProgressBar1.CustomText = "";
            this.labelProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProgressBar1.Location = new System.Drawing.Point(0, 368);
            this.labelProgressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.labelProgressBar1.MarqueeAnimationSpeed = 1000;
            this.labelProgressBar1.Maximum = 84;
            this.labelProgressBar1.Name = "labelProgressBar1";
            this.labelProgressBar1.ProgressColor = System.Drawing.Color.LightGreen;
            this.labelProgressBar1.Size = new System.Drawing.Size(435, 15);
            this.labelProgressBar1.TabIndex = 24;
            this.labelProgressBar1.TextColor = System.Drawing.Color.Black;
            this.labelProgressBar1.TextFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.labelProgressBar1.VisualMode = YSRAutoUpdate.ProgressBarDisplayMode.CurrProgress;
            // 
            // labelProgressBar2
            // 
            this.labelProgressBar2.CustomText = "";
            this.labelProgressBar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProgressBar2.Location = new System.Drawing.Point(0, 383);
            this.labelProgressBar2.Margin = new System.Windows.Forms.Padding(0);
            this.labelProgressBar2.Name = "labelProgressBar2";
            this.labelProgressBar2.ProgressColor = System.Drawing.Color.LightGreen;
            this.labelProgressBar2.Size = new System.Drawing.Size(435, 15);
            this.labelProgressBar2.TabIndex = 25;
            this.labelProgressBar2.TextColor = System.Drawing.Color.Black;
            this.labelProgressBar2.TextFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.labelProgressBar2.VisualMode = YSRAutoUpdate.ProgressBarDisplayMode.CurrProgress;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(435, 510);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(10, 10);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "의사랑 자동 업데이트";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ListBox lboxLog;
        private YSRAutoUpdate.LabelProgressBar labelProgressBar1;
        private YSRAutoUpdate.LabelProgressBar labelProgressBar2;
    }
}

