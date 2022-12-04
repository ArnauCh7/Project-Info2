using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using FlightLib;

namespace Formularios
{
    public partial class NewAircraftType : Form
    {
        string nombre;
        int pasajeros;
        Image picture;
        bool foto_cargada;
        DataBase miBase = new DataBase();
        public NewAircraftType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Setea el icono y la variable de foto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewAircraftType_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
            miBase.Open();
            foto_cargada = false;
        }

        /// <summary>
        /// Transforma una cadena de bytes a imagen
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <returns></returns>
        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image Image = new Bitmap(ms);
            return Image;

        }

        /// <summary>
        /// Transforma una imagen en cadena de bytes
        /// </summary>
        /// <param name="image"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public byte[] ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;

            }
        }

        /// <summary>
        /// Abre un browser para buscar la foto que quieres añadir como avión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Load photo";
                openFileDialog1.InitialDirectory = @"C:\\TXT\\";
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.DefaultExt = "jpeg";
                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;
                openFileDialog1.ShowDialog();
                string file = openFileDialog1.FileName;
                Image foto = new Bitmap(file);
                pictureBox1.Image = foto;
                this.picture = foto;
                foto_cargada = true;
            }
            catch (FormatException)
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("Error loading the data");
            }
            catch (ArgumentException)
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("Error loading the data");
            }
        }

        /// <summary>
        /// Añade el nuevo tipo de avion a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirm_Click(object sender, EventArgs e)
        {
            if (foto_cargada)
            {
                this.nombre = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name.Text.ToLower());

                this.pasajeros = Convert.ToInt32(passengers.Text);
                byte[] pic = ImageToByte(this.picture, System.Drawing.Imaging.ImageFormat.Jpeg);
                miBase.AddAircraftType(this.nombre, this.pasajeros, pic);
                miBase.Close();
                Close();
            }
            else
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("Enter the photo first");
            }
        }
    }
}
