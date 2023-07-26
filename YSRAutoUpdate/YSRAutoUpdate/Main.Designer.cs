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
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
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
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "서울안과",
            "보리수의원2014",
            "중앙진단방사선과",
            "이상용내과",
            "다나의원",
            "손정형외과",
            "인성의원"});
            this.comboBox3.Location = new System.Drawing.Point(299, 46);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 20);
            this.comboBox3.TabIndex = 27;
            this.comboBox3.SelectionChangeCommitted += new System.EventHandler(this.comboBox3_SelectionChangeCommitted);
            // 
            // comboBox2
            // 
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "5306",
            "5307",
            "5308",
            "5309",
            "5310",
            "5311",
            "5312",
            "5313",
            "5314",
            "5315",
            "5316",
            "5317",
            "5318",
            "5319",
            "5320",
            "5321",
            "5322",
            "5323",
            "5324",
            "5325",
            "5326",
            "5327",
            "5328",
            "5329",
            "5330",
            "5331",
            "5332",
            "5333",
            "5334",
            "5335",
            "5336",
            "5337",
            "5338",
            "5339",
            "5340",
            "5341",
            "5342",
            "5343",
            "5344",
            "5345",
            "5346",
            "5347",
            "5348",
            "5349",
            "5350",
            "5351",
            "5352",
            "5353",
            "5354",
            "5355",
            "5356",
            "5357",
            "5358",
            "5359",
            "5360",
            "5361",
            "5362",
            "5363",
            "5364",
            "5365",
            "5366",
            "5367",
            "5368",
            "5369",
            "5370",
            "5371",
            "5372",
            "5373",
            "5374",
            "5375",
            "5376",
            "5377",
            "5378",
            "5379",
            "5380",
            "5381",
            "5382",
            "5383",
            "5384",
            "5385",
            "5386",
            "5387",
            "5388",
            "5389"});
            this.comboBox2.Location = new System.Drawing.Point(354, 20);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(66, 20);
            this.comboBox2.TabIndex = 26;
            this.comboBox2.SelectionChangeCommitted += new System.EventHandler(this.comboBox2_SelectionChangeCommitted);
            // 
            // comboBox1
            // 
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "5306",
            "5307",
            "5308",
            "5309",
            "5310",
            "5311",
            "5312",
            "5313",
            "5314",
            "5315",
            "5316",
            "5317",
            "5318",
            "5319",
            "5320",
            "5321",
            "5322",
            "5323",
            "5324",
            "5325",
            "5326",
            "5327",
            "5328",
            "5329",
            "5330",
            "5331",
            "5332",
            "5333",
            "5334",
            "5335",
            "5336",
            "5337",
            "5338",
            "5339",
            "5340",
            "5341",
            "5342",
            "5343",
            "5344",
            "5345",
            "5346",
            "5347",
            "5348",
            "5349",
            "5350",
            "5351",
            "5352",
            "5353",
            "5354",
            "5355",
            "5356",
            "5357",
            "5358",
            "5359",
            "5360",
            "5361",
            "5362",
            "5363",
            "5364",
            "5365",
            "5366",
            "5367",
            "5368",
            "5369",
            "5370",
            "5371",
            "5372",
            "5373",
            "5374",
            "5375",
            "5376",
            "5377",
            "5378",
            "5379",
            "5380",
            "5381",
            "5382",
            "5383",
            "5384",
            "5385",
            "5386",
            "5387",
            "5388",
            "5389"});
            this.comboBox1.Location = new System.Drawing.Point(262, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(66, 20);
            this.comboBox1.TabIndex = 25;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton3.ForeColor = System.Drawing.Color.White;
            this.radioButton3.Location = new System.Drawing.Point(6, 72);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(65, 16);
            this.radioButton3.TabIndex = 24;
            this.radioButton3.Text = "테스트2";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(334, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "~";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(212, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "TETBL";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(6, 47);
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
            this.radioButton1.Location = new System.Drawing.Point(6, 23);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(99, 16);
            this.radioButton1.TabIndex = 18;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "자동 업데이트";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "기본",
            "최소화"});
            this.comboBox4.Location = new System.Drawing.Point(299, 72);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 20);
            this.comboBox4.TabIndex = 28;
            this.comboBox4.SelectionChangeCommitted += new System.EventHandler(this.comboBox4_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(212, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "병의원이름";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(212, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "창 옵션";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton3;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBox4;
    }
}

