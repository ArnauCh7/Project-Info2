
namespace Formularios
{
    partial class ChangeVelocity
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
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HelpLbl = new System.Windows.Forms.Label();
            this.VelTxt = new System.Windows.Forms.TextBox();
            this.ErrLbl = new System.Windows.Forms.Label();
            this.IDTxt = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(295, 199);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(99, 29);
            this.SaveBtn.TabIndex = 11;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Velocity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Flightplan ID";
            // 
            // HelpLbl
            // 
            this.HelpLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpLbl.Location = new System.Drawing.Point(21, 114);
            this.HelpLbl.Name = "HelpLbl";
            this.HelpLbl.Size = new System.Drawing.Size(213, 62);
            this.HelpLbl.TabIndex = 10;
            this.HelpLbl.Text = "?";
            this.HelpLbl.Click += new System.EventHandler(this.HelpLbl_Click);
            // 
            // VelTxt
            // 
            this.VelTxt.Location = new System.Drawing.Point(25, 91);
            this.VelTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VelTxt.Name = "VelTxt";
            this.VelTxt.Size = new System.Drawing.Size(109, 22);
            this.VelTxt.TabIndex = 9;
            // 
            // ErrLbl
            // 
            this.ErrLbl.ForeColor = System.Drawing.Color.Red;
            this.ErrLbl.Location = new System.Drawing.Point(177, 30);
            this.ErrLbl.Name = "ErrLbl";
            this.ErrLbl.Size = new System.Drawing.Size(198, 82);
            this.ErrLbl.TabIndex = 7;
            // 
            // IDTxt
            // 
            this.IDTxt.FormattingEnabled = true;
            this.IDTxt.Location = new System.Drawing.Point(25, 41);
            this.IDTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IDTxt.Name = "IDTxt";
            this.IDTxt.Size = new System.Drawing.Size(109, 24);
            this.IDTxt.TabIndex = 8;
            // 
            // ChangeVelocity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 238);
            this.Controls.Add(this.IDTxt);
            this.Controls.Add(this.ErrLbl);
            this.Controls.Add(this.VelTxt);
            this.Controls.Add(this.HelpLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "ChangeVelocity";
            this.Text = "ChangeVelocity";
            this.Load += new System.EventHandler(this.ChangeVelocity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label HelpLbl;
        private System.Windows.Forms.TextBox VelTxt;
        private System.Windows.Forms.Label ErrLbl;
        private System.Windows.Forms.ComboBox IDTxt;
    }
}