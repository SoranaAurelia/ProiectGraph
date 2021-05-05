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
            this.tbRez = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panelInData = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbFunction = new System.Windows.Forms.ComboBox();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.tbInfo3 = new System.Windows.Forms.TextBox();
            this.labelInfo3 = new System.Windows.Forms.Label();
            this.tbInfo2 = new System.Windows.Forms.TextBox();
            this.labelInfo2 = new System.Windows.Forms.Label();
            this.tbInfo1 = new System.Windows.Forms.TextBox();
            this.labelInfo1 = new System.Windows.Forms.Label();
            this.labelInfos = new System.Windows.Forms.Label();
            this.labelAlgorithm = new System.Windows.Forms.Label();
            this.labelClass = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelInData.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of vertices:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Edges:";
            // 
            // tbn
            // 
            this.tbn.Location = new System.Drawing.Point(107, 26);
            this.tbn.Name = "tbn";
            this.tbn.Size = new System.Drawing.Size(95, 20);
            this.tbn.TabIndex = 0;
            // 
            // tbm
            // 
            this.tbm.Location = new System.Drawing.Point(107, 52);
            this.tbm.Name = "tbm";
            this.tbm.Size = new System.Drawing.Size(95, 20);
            this.tbm.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Edges:";
            // 
            // tbMuchii
            // 
            this.tbMuchii.Location = new System.Drawing.Point(107, 80);
            this.tbMuchii.Multiline = true;
            this.tbMuchii.Name = "tbMuchii";
            this.tbMuchii.Size = new System.Drawing.Size(95, 230);
            this.tbMuchii.TabIndex = 5;
            this.tbMuchii.WordWrap = false;
            // 
            // tbRez
            // 
            this.tbRez.Location = new System.Drawing.Point(39, 53);
            this.tbRez.Multiline = true;
            this.tbRez.Name = "tbRez";
            this.tbRez.Size = new System.Drawing.Size(168, 271);
            this.tbRez.TabIndex = 8;
            this.tbRez.WordWrap = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 37);
            this.button1.TabIndex = 9;
            this.button1.Text = "Execute!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "The solution:";
            // 
            // panelInData
            // 
            this.panelInData.BackColor = System.Drawing.Color.AliceBlue;
            this.panelInData.Controls.Add(this.tbMuchii);
            this.panelInData.Controls.Add(this.label3);
            this.panelInData.Controls.Add(this.label2);
            this.panelInData.Controls.Add(this.tbn);
            this.panelInData.Controls.Add(this.label1);
            this.panelInData.Controls.Add(this.tbm);
            this.panelInData.Location = new System.Drawing.Point(-1, -1);
            this.panelInData.Margin = new System.Windows.Forms.Padding(30);
            this.panelInData.Name = "panelInData";
            this.panelInData.Size = new System.Drawing.Size(221, 318);
            this.panelInData.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.cbFunction);
            this.panel1.Controls.Add(this.cbClass);
            this.panel1.Controls.Add(this.tbInfo3);
            this.panel1.Controls.Add(this.labelInfo3);
            this.panel1.Controls.Add(this.tbInfo2);
            this.panel1.Controls.Add(this.labelInfo2);
            this.panel1.Controls.Add(this.tbInfo1);
            this.panel1.Controls.Add(this.labelInfo1);
            this.panel1.Controls.Add(this.labelInfos);
            this.panel1.Controls.Add(this.labelAlgorithm);
            this.panel1.Controls.Add(this.labelClass);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(226, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 339);
            this.panel1.TabIndex = 12;
            // 
            // cbFunction
            // 
            this.cbFunction.FormattingEnabled = true;
            this.cbFunction.Location = new System.Drawing.Point(156, 48);
            this.cbFunction.Name = "cbFunction";
            this.cbFunction.Size = new System.Drawing.Size(121, 21);
            this.cbFunction.TabIndex = 20;
            this.cbFunction.SelectedIndexChanged += new System.EventHandler(this.cbFunction_SelectedIndexChanged);
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(156, 17);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(121, 21);
            this.cbClass.TabIndex = 19;
            this.cbClass.SelectedIndexChanged += new System.EventHandler(this.cbClass_SelectedIndexChanged);
            // 
            // tbInfo3
            // 
            this.tbInfo3.Location = new System.Drawing.Point(156, 144);
            this.tbInfo3.Name = "tbInfo3";
            this.tbInfo3.Size = new System.Drawing.Size(121, 20);
            this.tbInfo3.TabIndex = 18;
            // 
            // labelInfo3
            // 
            this.labelInfo3.Location = new System.Drawing.Point(22, 147);
            this.labelInfo3.Name = "labelInfo3";
            this.labelInfo3.Size = new System.Drawing.Size(118, 13);
            this.labelInfo3.TabIndex = 17;
            this.labelInfo3.Text = "info3";
            this.labelInfo3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbInfo2
            // 
            this.tbInfo2.Location = new System.Drawing.Point(156, 118);
            this.tbInfo2.Name = "tbInfo2";
            this.tbInfo2.Size = new System.Drawing.Size(121, 20);
            this.tbInfo2.TabIndex = 16;
            // 
            // labelInfo2
            // 
            this.labelInfo2.Location = new System.Drawing.Point(22, 121);
            this.labelInfo2.Name = "labelInfo2";
            this.labelInfo2.Size = new System.Drawing.Size(118, 13);
            this.labelInfo2.TabIndex = 15;
            this.labelInfo2.Text = "info2";
            this.labelInfo2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbInfo1
            // 
            this.tbInfo1.Location = new System.Drawing.Point(156, 92);
            this.tbInfo1.Name = "tbInfo1";
            this.tbInfo1.Size = new System.Drawing.Size(121, 20);
            this.tbInfo1.TabIndex = 14;
            // 
            // labelInfo1
            // 
            this.labelInfo1.Location = new System.Drawing.Point(17, 95);
            this.labelInfo1.Name = "labelInfo1";
            this.labelInfo1.Size = new System.Drawing.Size(123, 17);
            this.labelInfo1.TabIndex = 13;
            this.labelInfo1.Text = "info1";
            this.labelInfo1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelInfos
            // 
            this.labelInfos.AutoSize = true;
            this.labelInfos.Location = new System.Drawing.Point(6, 76);
            this.labelInfos.Name = "labelInfos";
            this.labelInfos.Size = new System.Drawing.Size(88, 13);
            this.labelInfos.TabIndex = 12;
            this.labelInfos.Text = "Please complete:";
            // 
            // labelAlgorithm
            // 
            this.labelAlgorithm.AutoSize = true;
            this.labelAlgorithm.Location = new System.Drawing.Point(6, 51);
            this.labelAlgorithm.Name = "labelAlgorithm";
            this.labelAlgorithm.Size = new System.Drawing.Size(134, 13);
            this.labelAlgorithm.TabIndex = 11;
            this.labelAlgorithm.Text = "What algorithm to perform?";
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Location = new System.Drawing.Point(6, 22);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(122, 13);
            this.labelClass.TabIndex = 10;
            this.labelClass.Text = "What type of graph is it?";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbRez);
            this.panel2.Location = new System.Drawing.Point(522, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 339);
            this.panel2.TabIndex = 13;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(2, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(224, 339);
            this.tabControl.TabIndex = 6;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelInData);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(216, 313);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "By list";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(216, 313);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "By design";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.AliceBlue;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(216, 313);
            this.panel3.TabIndex = 0;
            this.panel3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 340);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelInData.ResumeLayout(false);
            this.panelInData.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbn;
        private System.Windows.Forms.TextBox tbm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMuchii;
        private System.Windows.Forms.TextBox tbRez;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelInData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelInfos;
        private System.Windows.Forms.Label labelAlgorithm;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.ComboBox cbFunction;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.TextBox tbInfo3;
        private System.Windows.Forms.Label labelInfo3;
        private System.Windows.Forms.TextBox tbInfo2;
        private System.Windows.Forms.Label labelInfo2;
        private System.Windows.Forms.TextBox tbInfo1;
        private System.Windows.Forms.Label labelInfo1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
    }
}

