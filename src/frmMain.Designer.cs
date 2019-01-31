namespace ExcelDocTxtTemplateReplace
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.txtPaths = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.lblFileRemark = new System.Windows.Forms.Label();
            this.lblKeywordRule = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtLogMsg = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "生成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtPaths
            // 
            this.txtPaths.Location = new System.Drawing.Point(92, 56);
            this.txtPaths.Multiline = true;
            this.txtPaths.Name = "txtPaths";
            this.txtPaths.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPaths.Size = new System.Drawing.Size(407, 111);
            this.txtPaths.TabIndex = 9;
            this.txtPaths.WordWrap = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(92, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 29);
            this.button3.TabIndex = 10;
            this.button3.Text = "选择文件";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "模板规则";
            // 
            // txtKeywords
            // 
            this.txtKeywords.Location = new System.Drawing.Point(92, 182);
            this.txtKeywords.Multiline = true;
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtKeywords.Size = new System.Drawing.Size(407, 141);
            this.txtKeywords.TabIndex = 13;
            this.txtKeywords.WordWrap = false;
            // 
            // lblFileRemark
            // 
            this.lblFileRemark.AutoSize = true;
            this.lblFileRemark.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblFileRemark.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFileRemark.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblFileRemark.Location = new System.Drawing.Point(184, 29);
            this.lblFileRemark.Name = "lblFileRemark";
            this.lblFileRemark.Size = new System.Drawing.Size(92, 17);
            this.lblFileRemark.TabIndex = 15;
            this.lblFileRemark.Text = "选择文件或输入";
            // 
            // lblKeywordRule
            // 
            this.lblKeywordRule.AutoSize = true;
            this.lblKeywordRule.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblKeywordRule.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKeywordRule.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblKeywordRule.Location = new System.Drawing.Point(92, 333);
            this.lblKeywordRule.Name = "lblKeywordRule";
            this.lblKeywordRule.Size = new System.Drawing.Size(134, 17);
            this.lblKeywordRule.TabIndex = 15;
            this.lblKeywordRule.Text = "规则：关键字==替换值";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(170, 364);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 35);
            this.button2.TabIndex = 16;
            this.button2.Text = "保存关键字";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtLogMsg
            // 
            this.txtLogMsg.Location = new System.Drawing.Point(92, 414);
            this.txtLogMsg.Multiline = true;
            this.txtLogMsg.Name = "txtLogMsg";
            this.txtLogMsg.ReadOnly = true;
            this.txtLogMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogMsg.Size = new System.Drawing.Size(407, 115);
            this.txtLogMsg.TabIndex = 17;
            this.txtLogMsg.WordWrap = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(279, 364);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 35);
            this.button4.TabIndex = 18;
            this.button4.Text = "打开生成目录";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(401, 364);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 35);
            this.button5.TabIndex = 19;
            this.button5.Text = "清除日志";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "文件选择";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "操作日志";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 548);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFileRemark);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtLogMsg);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblKeywordRule);
            this.Controls.Add(this.txtKeywords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtPaths);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel/Doc/Txt文件模板替换工具";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPaths;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Label lblFileRemark;
        private System.Windows.Forms.Label lblKeywordRule;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtLogMsg;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
    }
}

