
namespace Formularios
{
    partial class Register
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
            this.label4 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.passwd = new System.Windows.Forms.TextBox();
            this.reg = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.emailerror = new System.Windows.Forms.Label();
            this.confirmEmail = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(256, 125);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(208, 26);
            this.username.TabIndex = 1;
            // 
            // passwd
            // 
            this.passwd.Location = new System.Drawing.Point(256, 215);
            this.passwd.Name = "passwd";
            this.passwd.Size = new System.Drawing.Size(208, 26);
            this.passwd.TabIndex = 2;
            // 
            // reg
            // 
            this.reg.Location = new System.Drawing.Point(246, 432);
            this.reg.Name = "reg";
            this.reg.Size = new System.Drawing.Size(88, 43);
            this.reg.TabIndex = 5;
            this.reg.Text = "Register";
            this.reg.UseVisualStyleBackColor = true;
            this.reg.Click += new System.EventHandler(this.reg_Click);
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Location = new System.Drawing.Point(252, 158);
            this.error.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(51, 20);
            this.error.TabIndex = 9;
            this.error.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Confirm Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "Email";
            // 
            // emailerror
            // 
            this.emailerror.AutoSize = true;
            this.emailerror.Location = new System.Drawing.Point(254, 383);
            this.emailerror.Name = "emailerror";
            this.emailerror.Size = new System.Drawing.Size(51, 20);
            this.emailerror.TabIndex = 12;
            this.emailerror.Text = "label6";
            // 
            // confirmEmail
            // 
            this.confirmEmail.Location = new System.Drawing.Point(256, 352);
            this.confirmEmail.Name = "confirmEmail";
            this.confirmEmail.Size = new System.Drawing.Size(208, 26);
            this.confirmEmail.TabIndex = 4;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(256, 288);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(208, 26);
            this.email.TabIndex = 3;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 489);
            this.Controls.Add(this.email);
            this.Controls.Add(this.confirmEmail);
            this.Controls.Add(this.emailerror);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.error);
            this.Controls.Add(this.reg);
            this.Controls.Add(this.passwd);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Register";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox passwd;
        private System.Windows.Forms.Button reg;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label emailerror;
        private System.Windows.Forms.TextBox confirmEmail;
        private System.Windows.Forms.TextBox email;
    }
}