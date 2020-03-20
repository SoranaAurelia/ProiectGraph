namespace ProiectGraphuri
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbn = new System.Windows.Forms.TextBox();
            this.tbm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMuchii = new System.Windows.Forms.TextBox();
            this.tbClasa = new System.Windows.Forms.TextBox();
            this.tbFunctia = new System.Windows.Forms.TextBox();
            this.tbRez = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "n:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "m:";
            // 
            // tbn
            // 
            this.tbn.Location = new System.Drawing.Point(74, 84);
            this.tbn.Name = "tbn";
            this.tbn.Size = new System.Drawing.Size(25, 20);
            this.tbn.TabIndex = 0;
            // 
            // tbm
            // 
            this.tbm.Location = new System.Drawing.Point(144, 84);
            this.tbm.Name = "tbm";
            this.tbm.Size = new System.Drawing.Size(25, 20);
            this.tbm.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "muchii:";
            // 
            // tbMuchii
            // 
            this.tbMuchii.Location = new System.Drawing.Point(55, 148);
            this.tbMuchii.Multiline = true;
            this.tbMuchii.Name = "tbMuchii";
            this.tbMuchii.Size = new System.Drawing.Size(114, 250);
            this.tbMuchii.TabIndex = 5;
            // 
            // tbClasa
            // 
            this.tbClasa.Location = new System.Drawing.Point(317, 83);
            this.tbClasa.Name = "tbClasa";
            this.tbClasa.Size = new System.Drawing.Size(100, 20);
            this.tbClasa.TabIndex = 6;
            // 
            // tbFunctia
            // 
            this.tbFunctia.Location = new System.Drawing.Point(317, 129);
            this.tbFunctia.Name = "tbFunctia";
            this.tbFunctia.Size = new System.Drawing.Size(100, 20);
            this.tbFunctia.TabIndex = 7;
            // 
            // tbRez
            // 
            this.tbRez.Location = new System.Drawing.Point(536, 81);
            this.tbRez.Multiline = true;
            this.tbRez.Name = "tbRez";
            this.tbRez.Size = new System.Drawing.Size(200, 317);
            this.tbRez.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "test me owo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbRez);
            this.Controls.Add(this.tbFunctia);
            this.Controls.Add(this.tbClasa);
            this.Controls.Add(this.tbMuchii);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbn;
        private System.Windows.Forms.TextBox tbm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMuchii;
        private System.Windows.Forms.TextBox tbClasa;
        private System.Windows.Forms.TextBox tbFunctia;
        private System.Windows.Forms.TextBox tbRez;
        private System.Windows.Forms.Button button1;
    }
}

