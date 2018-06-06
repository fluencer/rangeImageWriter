namespace RangeImageWriter
{
    partial class Form1
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnSlctFlder2 = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.txtBoxOutputFlder = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxIPFldr = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnSlctFlder2);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.txtBoxOutputFlder);
            this.groupBox6.Location = new System.Drawing.Point(22, 29);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(651, 66);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Save Results";
            // 
            // btnSlctFlder2
            // 
            this.btnSlctFlder2.Location = new System.Drawing.Point(536, 28);
            this.btnSlctFlder2.Name = "btnSlctFlder2";
            this.btnSlctFlder2.Size = new System.Drawing.Size(102, 19);
            this.btnSlctFlder2.TabIndex = 5;
            this.btnSlctFlder2.Text = "Select Folder";
            this.btnSlctFlder2.UseVisualStyleBackColor = true;
            this.btnSlctFlder2.Click += new System.EventHandler(this.btnSlctFlder2_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(14, 31);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(79, 13);
            this.label32.TabIndex = 4;
            this.label32.Text = "Save to Folder:";
            // 
            // txtBoxOutputFlder
            // 
            this.txtBoxOutputFlder.Location = new System.Drawing.Point(96, 28);
            this.txtBoxOutputFlder.Name = "txtBoxOutputFlder";
            this.txtBoxOutputFlder.Size = new System.Drawing.Size(422, 20);
            this.txtBoxOutputFlder.TabIndex = 3;
            this.txtBoxOutputFlder.Text = "C:\\temp\\specialProblem\\imgData";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBoxIPFldr);
            this.groupBox1.Location = new System.Drawing.Point(22, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 66);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FIS Filde folder";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(536, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 19);
            this.button1.TabIndex = 5;
            this.button1.Text = "Select Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Folder:";
            // 
            // txtBoxIPFldr
            // 
            this.txtBoxIPFldr.Location = new System.Drawing.Point(96, 28);
            this.txtBoxIPFldr.Name = "txtBoxIPFldr";
            this.txtBoxIPFldr.Size = new System.Drawing.Size(422, 20);
            this.txtBoxIPFldr.TabIndex = 3;
            this.txtBoxIPFldr.Text = "C:\\temp\\specialProblem\\Data";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(598, 191);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Convert";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 244);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnSlctFlder2;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtBoxOutputFlder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxIPFldr;
        private System.Windows.Forms.Button button2;
    }
}

