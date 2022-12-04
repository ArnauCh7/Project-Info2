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
    public partial class insertClickData : Form
    {
        string identificador;
        double vel;
        bool clickFP;
        string company;
        DataBase mibase = new DataBase();
        string aircraftType;
        public insertClickData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Guarda la info del flightplan en variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ok_Click(object sender, EventArgs e)
        {
            try
            {
                this.identificador = id.Text;
                this.company = CompanyCombobox.Text;
                this.vel = Convert.ToDouble(velocity.Text);
                this.aircraftType = AircraftTypeCombobox.Text;


                if (this.company == "")
                {
                    CompanyCombobox.Text = "Default Airlines";
                }
                if(this.aircraftType == "")
                {
                    AircraftTypeCombobox.Text = "A320";
                }
                if (this.identificador == "")
                {
                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                    soundplayer.Play();
                    ErrLbl.Text = "Insert an Id for the aircraft";
                }
                else if (vel <= 0 || velocity.Text == "")
                {
                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                    soundplayer.Play();
                    ErrLbl.Text = "Insert a correct velocity greater than 0";
                    
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
                ErrLbl.Text = "Format Error";
                
            }
        }

        /// <summary>
        /// Getter del id
        /// </summary>
        /// <returns></returns>
        public string GetID()
        {
            return this.identificador;
        }

        /// <summary>
        /// Getter de la velocidad
        /// </summary>
        /// <returns></returns>
        public double GetV()
        {
            return this.vel;
        }

        /// <summary>
        /// Getter del bool clickFP
        /// </summary>
        /// <returns></returns>
        public bool GetBool()
        {
            return this.clickFP;
        }

        /// <summary>
        /// Getter de la compañia
        /// </summary>
        /// <returns></returns>
        public string GetCompany()
        {
            return this.company;
        }

        /// <summary>
        /// Getter del tipo de avion
        /// </summary>
        /// <returns></returns>
        public string GetAircrafttype()
        {
            return this.aircraftType;
        }

        /// <summary>
        /// Carga los nombres de las compañias y los tipos de avion desde la base de datos a las combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertClickData_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
            clickFP = true;
            mibase.Open();
            List<string> nombresComanies = mibase.GetAllCompanyNames();
            nombresComanies.Sort();
            foreach (string nombre in nombresComanies)
            {
                CompanyCombobox.Items.Add(nombre);
            }
            CompanyCombobox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<string> nombresAircraftTypes = mibase.GetAllAircraftTypes();
            nombresAircraftTypes.Sort();
            foreach (string name in nombresAircraftTypes)
            {
                AircraftTypeCombobox.Items.Add(name);
            }
            AircraftTypeCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
