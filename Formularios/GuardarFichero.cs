using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;

namespace Formularios
{
    
    public partial class GuardarFichero : Form
    {
        string filename;//nombre del fichero
        string path;//direccion de la carpeta donde se guarda el fichero
        bool Btn; // true if it browse the folder
        bool sendmail = false;
        string destination;

        public GuardarFichero()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Guarda el nombre del fichero en la variable filename
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            filename = SaveTxt.Text + ".txt";
            Close();
        }
        /// <summary>
        /// Getter del filename
        /// </summary>
        /// <returns></returns>
        public string GetFilename()
        {
            return this.filename;
        }
        /// <summary>
        /// Getter de la ruta del archivo
        /// </summary>
        /// <returns></returns>
        public string GetPath()
        {
            return this.path;
        }

        /// <summary>
        /// Metodo para obtener la respuesta del boton en otros forms
        /// </summary>
        /// <returns></returns>
        public bool GetBtn()
        {
            return this.Btn;
        }

        /// <summary>
        /// Guarda el nombre del fichero + .txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveDefaultBtn_Click(object sender, EventArgs e)
        {
            filename = SaveTxt.Text + ".txt";
            Btn = false;
            Close();
        }

        /// <summary>
        /// Boton para buscar la direccion del fichero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            Hide();
            FolderBrowserDialog FBdlg = new FolderBrowserDialog();
            FBdlg.Description = "Select the folder that you want to save the simulation.";
            FBdlg.ShowDialog();
            this.path = FBdlg.SelectedPath;
            filename = SaveTxt.Text + ".txt";
            Btn = true;
            Close();
        }

        /// <summary>
        /// Agre el form para añadir el mail destinatario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendMail_Click(object sender, EventArgs e)
        {
            destEmail dest = new destEmail();
            dest.ShowDialog();
            string email = dest.GetEmail();
            this.destination = email;
            ErrLbl.Text = "Now, please save on a file and the table will be sent to your email";
            this.sendmail = true;
        }

        /// <summary>
        /// getter del bool sendemail
        /// </summary>
        /// <returns></returns>
        public bool GetSendEmail()
        {
            return this.sendmail;
        }

        /// <summary>
        /// Getter del email destinatario
        /// </summary>
        /// <returns></returns>
        public string GetEmail()
        {
            return this.destination;
        }

        /// <summary>
        /// Setea el icono
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarFichero_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
        }
        
        public void SetDialog(bool email, string lbltxt)
        {
            if (!email)
            {
                sendMail.Visible = false;
            }
            this.TextLbl.Text = lbltxt;
        }
    }
}
