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
    public partial class ChangeVelocity : Form
    {
        bool help;//booleano para ver si las casillas de ayuda estan visibles
        string id;//ID del flightplan al que se el cambia la velocidad
        double velocity;//velocidad nueva
        FlightPlan fp_modificado;// flightplan para obtener velocidad antigua
        FlightPlanList fpl_aux;// lista flghtplans auxiliar
        DataBase mibase = new DataBase();
        string cambio;
        bool cambiado = false;

        public ChangeVelocity()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hace visible la casilla de ayuda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpLbl_Click(object sender, EventArgs e)
        {
            if (help)
            {
                HelpLbl.Text = "?";
            }
            else
                HelpLbl.Text = "Enter the flightplan ID and the new velocity\n Beware capitalization is on";
        }

        /// <summary>
        /// Pone la casilla de ayuda en oculto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeVelocity_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
            List<string> Simulation_IDs = fpl_aux.GetAllID();
            Simulation_IDs.Sort();
            foreach (string nombre in Simulation_IDs)
            {
                IDTxt.Items.Add(nombre);
            }
            IDTxt.DropDownStyle = ComboBoxStyle.DropDownList;
            help = false;
        }
        /// <summary>
        /// Guarda la velocidad en la variable global
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                mibase.Open();
                id = IDTxt.Text;
                velocity = Convert.ToDouble(VelTxt.Text);
                Close();
                try
                {
                    // Necessitem escriure : Flight ID, velocitat antiga, valocitat nova, COmpañia del avio (name, telephone, email)
                    fp_modificado = fpl_aux.GetFlightPlanID(id);
                    if (fp_modificado != null)
                    {
                        double velocidad_antigua = fp_modificado.GetVelocity();
                        if (fp_modificado.GetCompany() == null)
                        {
                            cambio = "-------------------------------------------------------------------------------------\n " +
                                "ID: " + id + "\n Velocities: " + velocidad_antigua + " --> " + velocity + " \n Company: Doesn't have a company \n";
                            cambiado = true;

                        }
                        else
                        {
                            DataTable dt_Company = mibase.GetCompany(fp_modificado.GetCompany());
                            string Company_name = dt_Company.Rows[0][0].ToString();
                            string Company_tel = dt_Company.Rows[0][1].ToString();
                            string Company_email = dt_Company.Rows[0][2].ToString();

                            cambio = "-------------------------------------------------------------------------------------\n " +
                                "ID: " + id + "\n Velocities: " + velocidad_antigua + " --> " + velocity + " \n Company: " + Company_name + " Telephone: " + Company_tel + " Email: " + Company_email + "\n";
                            cambiado = true;
                        }

                        mibase.Close();
                    }
                }

                catch (NullReferenceException)
                {
                    Close();
                }
            }

            catch (FormatException)
            {

                Close();
            }
            catch (NullReferenceException)
            {
                Close();
            }
        }
        /// <summary>
        /// Metodo para pasar la id a otro form
        /// </summary>
        /// <returns></returns>
        public string GetID()
        {
            return this.id;
        }
        /// <summary>
        /// devuelve true si ha habido un cambio
        /// </summary>
        /// <returns></returns>
        public bool Ha_Cambiado()
        {
            return cambiado;
        }
        /// <summary>
        /// Metodo para pasar la velocidad nueva a otro form
        /// </summary>
        /// <returns></returns>
        public double GetVelocity()
        {
            if (this.velocity < 0)
            {

                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play(); 
                ErrLbl.Text = "The velocity must be a positive number";
                
            }
            return this.velocity;
        }
        public void SetFlightPlanList(FlightPlanList fp)
        {
            this.fpl_aux = fp;
        }
        public string GetCambio()
        {
            return this.cambio;
        }
    }
}
