
namespace Formularios
{
    partial class FlightPlanData
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
            this.Response1Lbl = new System.Windows.Forms.Label();
            this.Title2 = new System.Windows.Forms.Label();
            this.Title1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Response2Lbl = new System.Windows.Forms.Label();
            this.OKBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Response1Lbl
            // 
            this.Response1Lbl.Location = new System.Drawing.Point(11, 39);
            this.Response1Lbl.Name = "Response1Lbl";
            this.Response1Lbl.Size = new System.Drawing.Size(348, 196);
            this.Response1Lbl.TabIndex = 2;
            this.Response1Lbl.Text = "---";
            // 
            // Title2
            // 
            this.Title2.AutoSize = true;
            this.Title2.Location = new System.Drawing.Point(34, 246);
            this.Title2.Name = "Title2";
            this.Title2.Size = new System.Drawing.Size(101, 17);
            this.Title2.TabIndex = 5;
            this.Title2.Text = "Company Data";
            // 
            // Title1
            // 
            this.Title1.AutoSize = true;
            this.Title1.Location = new System.Drawing.Point(11, 14);
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(104, 17);
            this.Title1.TabIndex = 4;
            this.Title1.Text = "FlightPlan Data";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(382, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(403, 281);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Response2Lbl
            // 
            this.Response2Lbl.Location = new System.Drawing.Point(34, 272);
            this.Response2Lbl.Name = "Response2Lbl";
            this.Response2Lbl.Size = new System.Drawing.Size(345, 50);
            this.Response2Lbl.TabIndex = 6;
            this.Response2Lbl.Text = "aaa \\n aaa\\n aaa";
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.Location = new System.Drawing.Point(707, 302);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(77, 26);
            this.OKBtn.TabIndex = 7;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // FlightPlanData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 338);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.Response2Lbl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Title1);
            this.Controls.Add(this.Title2);
            this.Controls.Add(this.Response1Lbl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FlightPlanData";
            this.Text = "Flightplan";
            this.Load += new System.EventHandler(this.FlightPlanData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Response1Lbl;
        private System.Windows.Forms.Label Title2;
        private System.Windows.Forms.Label Title1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Response2Lbl;
        private System.Windows.Forms.Button OKBtn;
    }
}