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
    public partial class CompanyGrind : Form
    {
        int rowindex;//indice de la fila de la tabla
        DataBase miBase = new DataBase();
        public CompanyGrind()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga la tabla con las compañias que hay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompanyGrind_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
            miBase.Open();
            try
            {
                DataTable dt =  miBase.GetAllCompanies();
                viewCompanies.DataSource = dt;
            }
            catch (NullReferenceException)
            {
                viewCompanies.ColumnCount = 3;
                viewCompanies.Columns[0].HeaderText = "Company Name";
                viewCompanies.Columns[1].HeaderText = "Telephone";
                viewCompanies.Columns[2].HeaderText = "Email";
                viewCompanies.Columns[3].HeaderText = "Image";
            }
        }
        /// <summary>
        /// Cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            miBase.Close();
            Close();
        }

    }
}
