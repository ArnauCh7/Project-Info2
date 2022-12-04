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
using System.Net;
using System.Net.Mail;

namespace Formularios
{
    public partial class SendEmail : Form
    {
        DataBase mibase = new DataBase();
        public SendEmail()
        {
            InitializeComponent();
        }
        string username;//Nombre de usuario
        string password;//Contraseña
        string email;//Correo electronico del cliente

        /// <summary>
        /// Abre la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendEmail_Load_1(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
            mibase.Open();
        }
        /// <summary>
        /// Recibiendo un usuario y contraseña crea el texto del correo electronico
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string getHTML(string username, string password)
        {
            string messageBody = "<front> Hello " + username + ": </font> <br><br> This is your password:" + password;
            return messageBody;
        }

        /// <summary>
        /// Recibiendo el texto del correo, crea el correo y lo envia
        /// </summary>
        /// <param name="htmlString"></param>
        public void Email(string htmlString)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("collisiondetectorhelp@gmail.com");
            message.To.Add(new MailAddress(this.email));
            message.Subject = "non-reply_password_recovery";
            message.IsBodyHtml = true;
            message.Body = htmlString;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("collisiondetectorhelp@gmail.com", "collision1234");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }

        /// <summary>
        /// Boton para enviar el correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void send_Click(object sender, EventArgs e)
        {
            this.username = input.Text;
            this.password = mibase.GetPassword(input.Text);
            this.email = mibase.GetEmail(input.Text);
            string htmlString = getHTML(username, password);
            Email(htmlString);
            MessageBox.Show("DONE");
            Close();
        }

    }
}