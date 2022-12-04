
namespace Formularios
{
    partial class Tutorial
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
            this.TutorialPB = new System.Windows.Forms.PictureBox();
            this.TutorialLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TutorialPB)).BeginInit();
            this.SuspendLayout();
            // 
            // TutorialPB
            // 
            this.TutorialPB.Dock = System.Windows.Forms.DockStyle.Top;
            this.TutorialPB.Location = new System.Drawing.Point(0, 0);
            this.TutorialPB.Name = "TutorialPB";
            this.TutorialPB.Size = new System.Drawing.Size(1578, 708);
            this.TutorialPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TutorialPB.TabIndex = 0;
            this.TutorialPB.TabStop = false;
            this.TutorialPB.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // TutorialLbl
            // 
            this.TutorialLbl.ForeColor = System.Drawing.Color.Lime;
            this.TutorialLbl.Location = new System.Drawing.Point(12, 711);
            this.TutorialLbl.Name = "TutorialLbl";
            this.TutorialLbl.Size = new System.Drawing.Size(1554, 75);
            this.TutorialLbl.TabIndex = 1;
            this.TutorialLbl.Text = "label1";
            // 
            // Tutorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1578, 795);
            this.Controls.Add(this.TutorialLbl);
            this.Controls.Add(this.TutorialPB);
            this.Name = "Tutorial";
            this.Text = "Tutorial";
            this.Load += new System.EventHandler(this.Tutorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TutorialPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox TutorialPB;
        private System.Windows.Forms.Label TutorialLbl;
    }
}