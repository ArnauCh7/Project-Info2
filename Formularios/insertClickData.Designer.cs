
namespace Formularios
{
    partial class insertClickData
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
            this.id = new System.Windows.Forms.TextBox();
            this.velocity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.ErrLbl = new System.Windows.Forms.Label();
            this.CompanyCombobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AircraftTypeCombobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(55, 42);
            this.id.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(132, 22);
            this.id.TabIndex = 1;
            // 
            // velocity
            // 
            this.velocity.Location = new System.Drawing.Point(55, 116);
            this.velocity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.velocity.Name = "velocity";
            this.velocity.Size = new System.Drawing.Size(132, 22);
            this.velocity.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Velocity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID";
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(87, 308);
            this.ok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(100, 28);
            this.ok.TabIndex = 11;
            this.ok.Text = "Confirm";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // ErrLbl
            // 
            this.ErrLbl.AutoSize = true;
            this.ErrLbl.ForeColor = System.Drawing.Color.Red;
            this.ErrLbl.Location = new System.Drawing.Point(112, 226);
            this.ErrLbl.Name = "ErrLbl";
            this.ErrLbl.Size = new System.Drawing.Size(0, 17);
            this.ErrLbl.TabIndex = 6;
            // 
            // CompanyCombobox
            // 
            this.CompanyCombobox.FormattingEnabled = true;
            this.CompanyCombobox.Location = new System.Drawing.Point(55, 181);
            this.CompanyCombobox.Name = "CompanyCombobox";
            this.CompanyCombobox.Size = new System.Drawing.Size(121, 24);
            this.CompanyCombobox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Companies";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Aircraft Type";
            // 
            // AircraftTypeCombobox
            // 
            this.AircraftTypeCombobox.FormattingEnabled = true;
            this.AircraftTypeCombobox.Location = new System.Drawing.Point(55, 249);
            this.AircraftTypeCombobox.Name = "AircraftTypeCombobox";
            this.AircraftTypeCombobox.Size = new System.Drawing.Size(121, 24);
            this.AircraftTypeCombobox.TabIndex = 10;
            // 
            // insertClickData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 349);
            this.Controls.Add(this.AircraftTypeCombobox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CompanyCombobox);
            this.Controls.Add(this.ErrLbl);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.velocity);
            this.Controls.Add(this.id);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "insertClickData";
            this.Text = "Insert Data";
            this.Load += new System.EventHandler(this.insertClickData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.TextBox velocity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Label ErrLbl;
        private System.Windows.Forms.ComboBox CompanyCombobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AircraftTypeCombobox;
    }
}