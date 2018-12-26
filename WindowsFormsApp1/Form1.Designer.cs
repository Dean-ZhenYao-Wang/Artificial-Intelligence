namespace WindowsFormsApp1
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ckA = new System.Windows.Forms.CheckBox();
            this.ckB = new System.Windows.Forms.CheckBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "X-OR神经网络训练";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 72);
            this.button1.TabIndex = 1;
            this.button1.Text = "执行 X-OR 训练";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ckA
            // 
            this.ckA.AutoSize = true;
            this.ckA.Location = new System.Drawing.Point(141, 136);
            this.ckA.Name = "ckA";
            this.ckA.Size = new System.Drawing.Size(54, 28);
            this.ckA.TabIndex = 2;
            this.ckA.Text = "A";
            this.ckA.UseVisualStyleBackColor = true;
            // 
            // ckB
            // 
            this.ckB.AutoSize = true;
            this.ckB.Location = new System.Drawing.Point(141, 171);
            this.ckB.Name = "ckB";
            this.ckB.Size = new System.Drawing.Size(54, 28);
            this.ckB.TabIndex = 3;
            this.ckB.Text = "B";
            this.ckB.UseVisualStyleBackColor = true;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(137, 223);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(106, 24);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "测试结果";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(141, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(254, 57);
            this.button2.TabIndex = 5;
            this.button2.Text = "测试";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 351);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.ckB);
            this.Controls.Add(this.ckA);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ckA;
        private System.Windows.Forms.CheckBox ckB;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button button2;
    }
}

