
namespace Formularios
{
    partial class GuardarFichero
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
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.SaveTxt = new System.Windows.Forms.TextBox();
            this.TextLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveDefaultBtn = new System.Windows.Forms.Button();
            this.sendMail = new System.Windows.Forms.Button();
            this.ErrLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(85, 202);
            this.BrowseBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(101, 25);
            this.BrowseBtn.TabIndex = 5;
            this.BrowseBtn.Text = "Browse...";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // SaveTxt
            // 
            this.SaveTxt.Location = new System.Drawing.Point(27, 67);
            this.SaveTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveTxt.Name = "SaveTxt";
            this.SaveTxt.Size = new System.Drawing.Size(200, 22);
            this.SaveTxt.TabIndex = 1;
            // 
            // TextLbl
            // 
            this.TextLbl.Location = new System.Drawing.Point(24, 31);
            this.TextLbl.Name = "TextLbl";
            this.TextLbl.Size = new System.Drawing.Size(228, 34);
            this.TextLbl.TabIndex = 2;
            this.TextLbl.Text = "Enter the name of the file that you want to save the simulation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = ".txt";
            // 
            // SaveDefaultBtn
            // 
            this.SaveDefaultBtn.Location = new System.Drawing.Point(192, 202);
            this.SaveDefaultBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveDefaultBtn.Name = "SaveDefaultBtn";
            this.SaveDefaultBtn.Size = new System.Drawing.Size(98, 25);
            this.SaveDefaultBtn.TabIndex = 6;
            this.SaveDefaultBtn.Text = "Default";
            this.SaveDefaultBtn.UseVisualStyleBackColor = true;
            this.SaveDefaultBtn.Click += new System.EventHandler(this.SaveDefaultBtn_Click);
            // 
            // sendMail
            // 
            this.sendMail.Location = new System.Drawing.Point(60, 98);
            this.sendMail.Margin = new System.Windows.Forms.Padding(4);
            this.sendMail.Name = "sendMail";
            this.sendMail.Size = new System.Drawing.Size(132, 46);
            this.sendMail.TabIndex = 4;
            this.sendMail.Text = "Send table to Email";
            this.sendMail.UseVisualStyleBackColor = true;
            this.sendMail.Click += new System.EventHandler(this.sendMail_Click);
            // 
            // ErrLbl
            // 
            this.ErrLbl.AutoSize = true;
            this.ErrLbl.ForeColor = System.Drawing.Color.Red;
            this.ErrLbl.Location = new System.Drawing.Point(11, 159);
            this.ErrLbl.Name = "ErrLbl";
            this.ErrLbl.Size = new System.Drawing.Size(0, 17);
            this.ErrLbl.TabIndex = 5;
            // 
            // GuardarFichero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 238);
            this.Controls.Add(this.ErrLbl);
            this.Controls.Add(this.sendMail);
            this.Controls.Add(this.SaveDefaultBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextLbl);
            this.Controls.Add(this.SaveTxt);
            this.Controls.Add(this.BrowseBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "GuardarFichero";
            this.Text = "Save File";
            this.Load += new System.EventHandler(this.GuardarFichero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.TextBox SaveTxt;
        private System.Windows.Forms.Label TextLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveDefaultBtn;
        private System.Windows.Forms.Button sendMail;
        private System.Windows.Forms.Label ErrLbl;
    }
}