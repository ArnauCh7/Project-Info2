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
    public partial class NewAircraft : Form
    {
        FlightPlan p;//Nuevo flightplan
        bool fullsim = false;
        DataBase mibase = new DataBase();
        public NewAircraft()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crea un flightplan y lo devuelve
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if(companyComboBox.Text == "" )
                {
                    companyComboBox.Text = "Default Airlines";
                }
                if(AircraftTypeComboBox.Text == "")
                {
                    AircraftTypeComboBox.Text = "A320";
                }
                if ( Convert.ToDouble(currentX.Text) <= 800 && Convert.ToDouble(currentX.Text) >= 0 && Convert.ToDouble(currentY.Text) <= 550 && Convert.ToDouble(currentY.Text) >= 0 && Convert.ToDouble(finalX.Text) <= 800 && Convert.ToDouble(finalX.Text) >= 0 && Convert.ToDouble(finalY.Text) <= 550 && Convert.ToDouble(finalY.Text) >= 0 && Convert.ToDouble(velocity.Text) > 0 && id.Text != "")
                {
                    p = new FlightPlan(id.Text, Convert.ToDouble(currentX.Text), Convert.ToDouble(currentY.Text), Convert.ToDouble(finalX.Text), Convert.ToDouble(finalY.Text), Convert.ToDouble(velocity.Text), companyComboBox.Text, AircraftTypeComboBox.Text);
                    Close();
                }
                else
                {
                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                    soundplayer.Play();
                    ErrLbl.Text = "There is an error on the data";
                    
                }
                
                
            }
            catch(FormatException)
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                ErrLbl.Text = "Format Error";
                
            }
        }
        /// <summary>
        /// Metodo para poder pasar el flightplan creado a otros forms
        /// </summary>
        /// <returns></returns>
        public FlightPlan GetFlight()
        {
            return this.p;
        }

        //Los siguientes metodos rellenan las casillas con informacion para flighplans predeterminados
        private void default1_Click(object sender, EventArgs e)
        {
            id.Text = "Default 1";
            currentX.Text = "400";
            currentY.Text = "50";
            finalX.Text = "400";
            finalY.Text = "500";
            velocity.Text = "50";
            companyComboBox.Text = "Default Airlines";
            AircraftTypeComboBox.Text = "A320";

        }

        private void default2_Click(object sender, EventArgs e)
        {
            id.Text = "Default 2";
            currentX.Text = "50";
            currentY.Text = "500";
            finalX.Text = "750";
            finalY.Text = "50";
            velocity.Text = "50";
            companyComboBox.Text = "Default Airlines";
            AircraftTypeComboBox.Text = "A320";

        }

        private void default3_Click(object sender, EventArgs e)
        {
            id.Text = "Default 3";
            currentX.Text = "50";
            currentY.Text = "50";
            finalX.Text = "750";
            finalY.Text = "500";
            velocity.Text = "50";
            companyComboBox.Text = "Default Airlines";
            AircraftTypeComboBox.Text = "A320";
        }

        private void default4_Click(object sender, EventArgs e)
        {
            id.Text = "Default 4";
            finalX.Text = "520";
            finalY.Text = "520";
            currentX.Text = "50";
            currentY.Text = "200";
            velocity.Text = "50";
            companyComboBox.Text = "Default Airlines";
            AircraftTypeComboBox.Text = "A320";
        }

        private void Full_Sim_Click(object sender, EventArgs e)
        {
            fullsim = true;
            Close();
        }

        public bool GetBool()
        {
            return fullsim;
        }

        /// <summary>
        /// carga los nombres de los tipos de aviones y las compañias desde la base de datos a las combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewAircraft_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
            mibase.Open();
            List<string> nombresCompanies = mibase.GetAllCompanyNames();
            nombresCompanies.Sort();
            foreach(string nombre in nombresCompanies)
            {
                companyComboBox.Items.Add(nombre);
            }
            companyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<string> nombresAircraftTypes = mibase.GetAllAircraftTypes();
            nombresAircraftTypes.Sort();
            foreach(string name in nombresAircraftTypes)
            {
                AircraftTypeComboBox.Items.Add(name);
            }
            AircraftTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
