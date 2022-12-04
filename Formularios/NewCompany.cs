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
using FlightLib;
using System.Media;

namespace Formularios
{
    public partial class NewCompany : Form
    {
        string name;
        int telephone;
        string email;
        Image Photo;
        bool foto_cargada;
        DataBase miBaseCompany = new DataBase();
        public NewCompany()
        {
            InitializeComponent();
        }


        /// <summary>
        /// funcion load del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCompany_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
            miBaseCompany.Open();
            foto_cargada = false;
        }


        /// <summary>
        /// Convierte una lista de bytes a un Image
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
        /// Convierte un Image a una lista de bytes
        /// </summary>
        /// <param name="image"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public byte[] ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format) {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;

            }
        }
        /// <summary>
        /// Boton Para añadir una foto en el picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_photobtn_Click(object sender, EventArgs e)
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
                this.Photo = foto;
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
        /// Boton para introducir todos los datos a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okbtn_Click(object sender, EventArgs e)
        {
            if (foto_cargada)
            {
                this.name = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Nameln.Text.ToLower());
                
                this.telephone = Convert.ToInt32(Telln.Text);
                this.email = emailn.Text;
                byte[] pic = ImageToByte(this.Photo, System.Drawing.Imaging.ImageFormat.Jpeg);
                miBaseCompany.AddCompany(this.name, this.telephone, this.email, pic);
                miBaseCompany.Close();
                Close();
            }
            else
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("Enter the photo first");
            }
        }

        /// <summary>
        /// Metodo para visualizar el nombre de una compañia que aun no esta en la base de datos
        /// </summary>
        /// <param name="name"></param>
        public void NameReadOnly(string name)
        {
            Nameln.Text = name;
            Nameln.ReadOnly = true;
        }
        

        
    }
}
