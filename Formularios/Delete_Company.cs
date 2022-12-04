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
    public partial class Delete_Company : Form
    {
        DataBase mibase = new DataBase();
        public Delete_Company()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Borra la compañia de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {   
            string text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Response.Text.ToLower());
            if (mibase.FindCompany(text))
            {
                var result = MessageBox.Show("Are you sure you want to delete the company from the database?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    
                    if (mibase.DeleteCompany(text))
                    {
                        MessageBox.Show("Company deleted Successfully");
                        mibase.Close();
                        Close();
                    }


                }
                else
                {
                    mibase.Close();
                    Close();
                }
            }
            
        }

        /// <summary>
        /// Carga las compañias en la combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Company_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
            mibase.Open();
            List<string> nombresCompanies = mibase.GetAllCompanyNames();
            nombresCompanies.Sort();
            foreach (string nombre in nombresCompanies)
            {
                Response.Items.Add(nombre);
            }
            Response.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
