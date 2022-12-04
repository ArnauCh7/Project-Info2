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

namespace Formularios
{
    public partial class Register : Form
    {
        DataBase mibase = new DataBase();//Crear el objeto "Base de datos"
        bool mute;
        public Register()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Las labels de los errores se colocan en oculto, los caracteres de la contraseña son "*" y se abre la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Register_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
            error.Visible = false;
            emailerror.Visible = false;
            passwd.PasswordChar = '*';
            mibase.Open();

        }
        /// <summary>
        /// Registra al usuario despues de pasar por el control de errores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reg_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            //Detecta si hay error con el mail
            if (email.Text != confirmEmail.Text)
            {
                emailerror.Text = "Confirm with the correct email";
                emailerror.Visible = true;
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
            }
            else
            {
                //Detecta si el usuario ya esta registrado y si no lo esta lo registra
                if (mibase.FindUser(username.Text) == false)
                {
                    mibase.AddUser(username.Text, passwd.Text, email.Text);
                    Tutorial tutorial = new Tutorial();
                    Hide();
                    tutorial.ShowDialog();
                    Principal principal = new Principal();
                    principal.setCheckBox(mute);
                    principal.SetUser(username.Text);
                    principal.ShowDialog();
                    Close();
                }
                else
                {
                    error.Text = "User not available";
                    error.Visible = true;
                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                    soundplayer.Play();
                }
            }

        }
        /// <summary>
        /// Actva la ckeckbox para mutear la musica
        /// </summary>
        /// <param name="mute"></param>
        public void SetBool(bool mute)
        {
            this.mute = mute;
        }


    }
}

