
namespace Formularios
{
    partial class Login
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
            this.password = new System.Windows.Forms.Label();
            this.un = new System.Windows.Forms.TextBox();
            this.pw = new System.Windows.Forms.TextBox();
            this.log = new System.Windows.Forms.Button();
            this.registernow = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.forgotPassword = new System.Windows.Forms.Label();
            this.MuteMusic = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 28.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(142, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conflict Detector";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(273, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.Lime;
            this.password.Location = new System.Drawing.Point(273, 260);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(120, 29);
            this.password.TabIndex = 2;
            this.password.Text = "Password";
            // 
            // un
            // 
            this.un.Location = new System.Drawing.Point(234, 208);
            this.un.Name = "un";
            this.un.Size = new System.Drawing.Size(178, 26);
            this.un.TabIndex = 3;
            // 
            // pw
            // 
            this.pw.Location = new System.Drawing.Point(234, 315);
            this.pw.Name = "pw";
            this.pw.Size = new System.Drawing.Size(178, 26);
            this.pw.TabIndex = 4;
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.Color.Black;
            this.log.ForeColor = System.Drawing.Color.Lime;
            this.log.Location = new System.Drawing.Point(267, 368);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(116, 43);
            this.log.TabIndex = 5;
            this.log.Text = "Log in";
            this.log.UseVisualStyleBackColor = false;
            this.log.Click += new System.EventHandler(this.log_Click);
            // 
            // registernow
            // 
            this.registernow.AutoSize = true;
            this.registernow.BackColor = System.Drawing.Color.Transparent;
            this.registernow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registernow.ForeColor = System.Drawing.Color.Lime;
            this.registernow.Location = new System.Drawing.Point(194, 478);
            this.registernow.Name = "registernow";
            this.registernow.Size = new System.Drawing.Size(283, 18);
            this.registernow.TabIndex = 8;
            this.registernow.Text = "Don\'t have an account yet? Register Now!";
            this.registernow.Click += new System.EventHandler(this.registernow_Click);
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.ForeColor = System.Drawing.Color.Red;
            this.error.Location = new System.Drawing.Point(218, 512);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(51, 20);
            this.error.TabIndex = 7;
            this.error.Text = "label3";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.ForeColor = System.Drawing.Color.Lime;
            this.checkBox1.Location = new System.Drawing.Point(250, 417);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(140, 24);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Show Pasword";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // forgotPassword
            // 
            this.forgotPassword.AutoSize = true;
            this.forgotPassword.BackColor = System.Drawing.Color.Transparent;
            this.forgotPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgotPassword.ForeColor = System.Drawing.Color.Lime;
            this.forgotPassword.Location = new System.Drawing.Point(248, 446);
            this.forgotPassword.Name = "forgotPassword";
            this.forgotPassword.Size = new System.Drawing.Size(162, 18);
            this.forgotPassword.TabIndex = 7;
            this.forgotPassword.Text = "Forgot your password?";
            this.forgotPassword.Click += new System.EventHandler(this.forgotPassword_Click);
            // 
            // MuteMusic
            // 
            this.MuteMusic.AutoSize = true;
            this.MuteMusic.ForeColor = System.Drawing.Color.Lime;
            this.MuteMusic.Location = new System.Drawing.Point(13, 585);
            this.MuteMusic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MuteMusic.Name = "MuteMusic";
            this.MuteMusic.Size = new System.Drawing.Size(136, 24);
            this.MuteMusic.TabIndex = 10;
            this.MuteMusic.Text = "MUTE MUSIC";
            this.MuteMusic.UseVisualStyleBackColor = true;
            this.MuteMusic.CheckedChanged += new System.EventHandler(this.MuteMusic_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(652, 623);
            this.Controls.Add(this.MuteMusic);
            this.Controls.Add(this.forgotPassword);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.error);
            this.Controls.Add(this.registernow);
            this.Controls.Add(this.log);
            this.Controls.Add(this.pw);
            this.Controls.Add(this.un);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.ShowInTaskbar = false;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox un;
        private System.Windows.Forms.TextBox pw;
        private System.Windows.Forms.Button log;
        private System.Windows.Forms.Label registernow;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label forgotPassword;
        private System.Windows.Forms.CheckBox MuteMusic;
    }
}