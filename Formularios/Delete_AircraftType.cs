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
    public partial class Delete_AircraftType : Form
    {
        DataBase mibase = new DataBase();
        public Delete_AircraftType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga los tipos de avion en la combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_AircraftType_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
            mibase.Open();
            List<string> nombresAircraftTypes = mibase.GetAllAircraftTypes();
            nombresAircraftTypes.Sort();
            foreach (string name in nombresAircraftTypes)
            {
                AircraftTypeComboBox.Items.Add(name);
            }
            AircraftTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Borra el vion de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(AircraftTypeComboBox.Text.ToLower());
            if (mibase.FindAircraftType(text))
            {
                var result = MessageBox.Show("Are you sure you want to delete the aircraft type from the database?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    if (mibase.DeleteAircraftType(text))
                    {
                        MessageBox.Show("Aircraft type deleted Successfully");
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
    }
}
