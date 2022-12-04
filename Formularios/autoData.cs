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

namespace Formularios
{
    public partial class autoData : Form
    {
        int time;//tiempo del intervalo del timer
        int dist;//distancia que recorre el avion en cada tick del timer
        public autoData()
        {

            InitializeComponent();
        }

        /// <summary>
        /// Guarda la informacion de las textbox en las variables y las pasa por el control de errores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dist = Convert.ToInt32(distance.Text);
                time = Convert.ToInt32(timeInt.Text);
                if (dist > 100 || dist < 0)
                {
                    SoundPlayer sound = new SoundPlayer("ErrorSnd.wav");
                    sound.Play();
                    ErrLbl.Text = "The distance of security is too big or not possible. Please, choose another one\n(maximum 100)";
                    
                }
                else if (time > 100 || time < 1)
                {
                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                    soundplayer.Play();
                    ErrLbl.Text = "The time interval is too bigor not possible. Please, choose another one";
                }
                else if (distance.Text == null)
                {
                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                    soundplayer.Play();
                    ErrLbl.Text = "Please, put a distance of security value";
                    
                }
                else if (timeInt.Text == null)
                {
                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                    soundplayer.Play();
                    ErrLbl.Text = "Please, put a timestep value";
                    
                }
                else if (distance.Text == null && timeInt.Text == null)
                {
                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                    soundplayer.Play();
                    ErrLbl.Text = "Please, put some values";
                    
                }
                else
                {
                    Close();
                }


            }
            catch (FormatException)
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                ErrLbl.Text = "Error in the values";
                
            }
        }
        /// <summary>
        /// Metodo para usar time en otro form
        /// </summary>
        /// <returns></returns>
        public int GetTiempo()
        {
            return this.time;
        }
        /// <summary>
        /// Metodo para usar list en otro form
        /// </summary>
        /// <returns></returns>
        public int GetDist()
        {
            return this.dist;
        }

        private void autoData_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
        }
    }
}
