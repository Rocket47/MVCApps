namespace Round_Robin
{
    partial class SettingsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.responseTimeInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.maxPerformanceInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.minPerformanceInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maxCountWorkerInput = new System.Windows.Forms.TextBox();
            this.minCountWorkerInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.maxComplexityInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.minComplexityInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.maxCountTasksInput = new System.Windows.Forms.TextBox();
            this.minCountTasksInput = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.responseTimeInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Timer";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(152, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "seconds";
            // 
            // responseTimeInput
            // 
            this.responseTimeInput.Location = new System.Drawing.Point(92, 22);
            this.responseTimeInput.Name = "responseTimeInput";
            this.responseTimeInput.Size = new System.Drawing.Size(54, 20);
            this.responseTimeInput.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Response time:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maxPerformanceInput);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.minPerformanceInput);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.maxCountWorkerInput);
            this.groupBox2.Controls.Add(this.minCountWorkerInput);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 78);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Performers";
            // 
            // maxPerformanceInput
            // 
            this.maxPerformanceInput.Location = new System.Drawing.Point(256, 42);
            this.maxPerformanceInput.Name = "maxPerformanceInput";
            this.maxPerformanceInput.Size = new System.Drawing.Size(54, 20);
            this.maxPerformanceInput.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(152, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Max performance:";
            // 
            // minPerformanceInput
            // 
            this.minPerformanceInput.Location = new System.Drawing.Point(92, 42);
            this.minPerformanceInput.Name = "minPerformanceInput";
            this.minPerformanceInput.Size = new System.Drawing.Size(54, 20);
            this.minPerformanceInput.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(3, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Min performance:";
            // 
            // maxCountWorkerInput
            // 
            this.maxCountWorkerInput.Location = new System.Drawing.Point(256, 18);
            this.maxCountWorkerInput.Name = "maxCountWorkerInput";
            this.maxCountWorkerInput.Size = new System.Drawing.Size(54, 20);
            this.maxCountWorkerInput.TabIndex = 5;
            // 
            // minCountWorkerInput
            // 
            this.minCountWorkerInput.Location = new System.Drawing.Point(92, 18);
            this.minCountWorkerInput.Name = "minCountWorkerInput";
            this.minCountWorkerInput.Size = new System.Drawing.Size(54, 20);
            this.minCountWorkerInput.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(152, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Max count:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Min count:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.maxComplexityInput);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.minComplexityInput);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.maxCountTasksInput);
            this.groupBox3.Controls.Add(this.minCountTasksInput);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(12, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 78);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tasks";
            // 
            // maxComplexityInput
            // 
            this.maxComplexityInput.Location = new System.Drawing.Point(256, 45);
            this.maxComplexityInput.Name = "maxComplexityInput";
            this.maxComplexityInput.Size = new System.Drawing.Size(54, 20);
            this.maxComplexityInput.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(152, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Max complexity:";
            // 
            // minComplexityInput
            // 
            this.minComplexityInput.Location = new System.Drawing.Point(92, 45);
            this.minComplexityInput.Name = "minComplexityInput";
            this.minComplexityInput.Size = new System.Drawing.Size(54, 20);
            this.minComplexityInput.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(3, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "Min complexity:";
            // 
            // maxCountTasksInput
            // 
            this.maxCountTasksInput.Location = new System.Drawing.Point(256, 18);
            this.maxCountTasksInput.Name = "maxCountTasksInput";
            this.maxCountTasksInput.Size = new System.Drawing.Size(54, 20);
            this.maxCountTasksInput.TabIndex = 5;
            // 
            // minCountTasksInput
            // 
            this.minCountTasksInput.Location = new System.Drawing.Point(92, 18);
            this.minCountTasksInput.Name = "minCountTasksInput";
            this.minCountTasksInput.Size = new System.Drawing.Size(54, 20);
            this.minCountTasksInput.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(152, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 14);
            this.label8.TabIndex = 2;
            this.label8.Text = "Max count:";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(3, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 14);
            this.label9.TabIndex = 1;
            this.label9.Text = "Min count:";
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(187, 261);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 11;
            this.button_Save.Text = "SAVE";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(92, 261);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(75, 23);
            this.buttonDefault.TabIndex = 12;
            this.buttonDefault.Text = "DEFAULT";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 292);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox maxCountWorkerInput;
        private System.Windows.Forms.TextBox minCountWorkerInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox maxPerformanceInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox minPerformanceInput;
        private System.Windows.Forms.TextBox responseTimeInput;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox maxComplexityInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox minComplexityInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox maxCountTasksInput;
        private System.Windows.Forms.TextBox minCountTasksInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.Label label10;
    }
}