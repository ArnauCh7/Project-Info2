using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class destEmail : Form
    {
        string email;
        public destEmail()
        {

            InitializeComponent();
        }

        /// <summary>
        /// Setea el email a una variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.email = input.Text;
            Close();
        }

        /// <summary>
        /// Getter del email
        /// </summary>
        /// <returns></returns>
        public string GetEmail()
        {
            return this.email;
        }

        /// <summary>
        /// Setea el icono
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void destEmail_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
        }
    }
}
