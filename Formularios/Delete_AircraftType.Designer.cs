
namespace Formularios
{
    partial class Delete_AircraftType
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
            this.AircraftTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AircraftTypeComboBox
            // 
            this.AircraftTypeComboBox.FormattingEnabled = true;
            this.AircraftTypeComboBox.Location = new System.Drawing.Point(16, 56);
            this.AircraftTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AircraftTypeComboBox.Name = "AircraftTypeComboBox";
            this.AircraftTypeComboBox.Size = new System.Drawing.Size(358, 33);
            this.AircraftTypeComboBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(569, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select the name of the aircraft type that you want to delete";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(495, 106);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 41);
            this.button1.TabIndex = 17;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Delete_AircraftType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 161);
            this.Controls.Add(this.AircraftTypeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Delete_AircraftType";
            this.Text = "Delete_AircraftType";
            this.Load += new System.EventHandler(this.Delete_AircraftType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox AircraftTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}