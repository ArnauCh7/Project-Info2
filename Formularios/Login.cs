using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using FlightLib;
using WMPLib;

namespace Formularios
{
    public partial class Login : Form
    {
        DataBase mibase = new DataBase();//crea el objeto "base de datos"
        string userLoged;
        bool mute = false;
        WindowsMediaPlayer player = new WindowsMediaPlayer();


        public Login()
        {
            InitializeComponent();
            player.URL = "wethands.mp3";
        }
        /// <summary>
        /// Textos de error en oculto, caracteres de la contraseña "*" y abre la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
            error.Visible = false;
            pw.PasswordChar = '*';
            mibase.Open();
        }
        /// <summary>
        /// Comprueba si el usuario esta registrado, si lo esta y la contraseña es correcta lo deja entrar al simulador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void log_Click(object sender, EventArgs e)
        {
            if (mibase.FindUser(un.Text) == true)
            {
                if (pw.Text == mibase.GetPassword(un.Text))
                {
                    player.controls.stop();
                    userLoged = un.Text;
                    Hide();
                    Principal principal = new Principal();
                    principal.setCheckBox(mute);
                    principal.SetUser(un.Text);
                    principal.ShowDialog();
                    mibase.Close();
                    Close();
                }
                else
                {
                    error.Text = "Password is incorrect";
                    error.Visible = true;
                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                    soundplayer.Play();
                    
                }
            }
            else
            {
                error.Text = "This user is not registered";
                error.Visible = true;
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
            }
        }

        /// <summary>
        /// Abre el form para registrarse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registernow_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            Hide();
            reg.SetBool(mute);
            reg.ShowDialog();
            Close();
        }

        /// <summary>
        /// Permite ver la contraseña
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (pw.PasswordChar == '*')
                {
                    pw.PasswordChar = '\0';
                }
            }
            else
            {
                pw.PasswordChar = '*';
            }

        }

        /// <summary>
        /// Abre el form para mandar el correo de recuperación de contraseña
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forgotPassword_Click(object sender, EventArgs e)
        {
            SendEmail mail = new SendEmail();
            mail.ShowDialog();

        }

        /// <summary>
        /// getter del userloged
        /// </summary>
        /// <returns></returns>
        public string GetUserLoged()
        {
            return this.userLoged;
        }

        /// <summary>
        /// combrueba el estado de la checkbox de musica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MuteMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (MuteMusic.Checked)
            {
                player.controls.pause();
                mute = true;
            }
            else
            {
                player.controls.play();
                mute = false;
            }
        }
    }
}