
namespace Formularios
{
    partial class NewCompany
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Nameln = new System.Windows.Forms.TextBox();
            this.Telln = new System.Windows.Forms.TextBox();
            this.emailn = new System.Windows.Forms.TextBox();
            this.Add_photobtn = new System.Windows.Forms.Button();
            this.okbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telephone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Name";
            // 
            // Nameln
            // 
            this.Nameln.Location = new System.Drawing.Point(148, 83);
            this.Nameln.Name = "Nameln";
            this.Nameln.Size = new System.Drawing.Size(164, 26);
            this.Nameln.TabIndex = 4;
            // 
            // Telln
            // 
            this.Telln.Location = new System.Drawing.Point(148, 132);
            this.Telln.Name = "Telln";
            this.Telln.Size = new System.Drawing.Size(164, 26);
            this.Telln.TabIndex = 5;
            // 
            // emailn
            // 
            this.emailn.Location = new System.Drawing.Point(148, 188);
            this.emailn.Name = "emailn";
            this.emailn.Size = new System.Drawing.Size(164, 26);
            this.emailn.TabIndex = 6;
            // 
            // Add_photobtn
            // 
            this.Add_photobtn.Location = new System.Drawing.Point(220, 251);
            this.Add_photobtn.Name = "Add_photobtn";
            this.Add_photobtn.Size = new System.Drawing.Size(94, 37);
            this.Add_photobtn.TabIndex = 7;
            this.Add_photobtn.Text = "Add photo";
            this.Add_photobtn.UseVisualStyleBackColor = true;
            this.Add_photobtn.Click += new System.EventHandler(this.Add_photobtn_Click);
            // 
            // okbtn
            // 
            this.okbtn.Location = new System.Drawing.Point(220, 305);
            this.okbtn.Name = "okbtn";
            this.okbtn.Size = new System.Drawing.Size(94, 37);
            this.okbtn.TabIndex = 8;
            this.okbtn.Text = "Aceptar";
            this.okbtn.UseVisualStyleBackColor = true;
            this.okbtn.Click += new System.EventHandler(this.okbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(328, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(478, 316);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // NewCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 378);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.okbtn);
            this.Controls.Add(this.Add_photobtn);
            this.Controls.Add(this.emailn);
            this.Controls.Add(this.Telln);
            this.Controls.Add(this.Nameln);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "NewCompany";
            this.Text = "NewCompany";
            this.Load += new System.EventHandler(this.NewCompany_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Nameln;
        private System.Windows.Forms.TextBox Telln;
        private System.Windows.Forms.TextBox emailn;
        private System.Windows.Forms.Button Add_photobtn;
        private System.Windows.Forms.Button okbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}