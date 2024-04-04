namespace yazproje3
{
    partial class Form3
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
            this.problem1 = new System.Windows.Forms.Button();
            this.problem2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // problem1
            // 
            this.problem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.problem1.Location = new System.Drawing.Point(355, 214);
            this.problem1.Name = "problem1";
            this.problem1.Size = new System.Drawing.Size(502, 318);
            this.problem1.TabIndex = 0;
            this.problem1.Text = "Problem 1";
            this.problem1.UseVisualStyleBackColor = false;
            this.problem1.Click += new System.EventHandler(this.problem1_Click);
            // 
            // problem2
            // 
            this.problem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.problem2.Location = new System.Drawing.Point(1123, 225);
            this.problem2.Name = "problem2";
            this.problem2.Size = new System.Drawing.Size(485, 318);
            this.problem2.TabIndex = 1;
            this.problem2.Text = "Problem 2";
            this.problem2.UseVisualStyleBackColor = false;
            this.problem2.Click += new System.EventHandler(this.problem2_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1868, 903);
            this.Controls.Add(this.problem2);
            this.Controls.Add(this.problem1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button problem1;
        private System.Windows.Forms.Button problem2;
    }
}