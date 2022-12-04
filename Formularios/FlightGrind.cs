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

namespace Formularios
{
    public partial class FlightGrind : Form
    {

        FlightPlanList lista = new FlightPlanList();//Crea objeto del tipo FlightPlanList
        int rowindex;//indice de la fila de la tabla
        DataBase miBase = new DataBase();
        string name_Comp;
        string tel_Comp;
        string email_Comp;

        public FlightGrind()
        {
            InitializeComponent();
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

        /// <summary>
        /// guarda la lista proporcionada en la variable correspondiente
        /// </summary>
        /// <param name="fl"></param>
        public void GiveList(FlightPlanList fl)
        {
            this.lista = fl;
        }

        /// <summary>
        /// Escribe la informacion en el DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlightGrind_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");

            miBase.Open();
            try
            {
                if (lista.GetLength() == 0)
                {
                }
                else
                {
                    viewFlights.RowCount = lista.GetLength();
                    viewFlights.ColumnCount = 7;
                    viewFlights.Columns[0].HeaderText = "Identifier";
                    viewFlights.Columns[1].HeaderText = "Current X";
                    viewFlights.Columns[2].HeaderText = "Current Y";
                    viewFlights.Columns[3].HeaderText = "Velocity";
                    viewFlights.Columns[4].HeaderText = "Company Name";
                    viewFlights.Columns[5].HeaderText = "Telephone";
                    viewFlights.Columns[6].HeaderText = "Email";

                    for (int i = 0; i < lista.GetLength(); i++)
                    {
                        if (lista.GetFlightPlan(i).GetCompany() != "")
                        {
                            viewFlights.Rows[i].Cells[0].Value = lista.GetFlightPlan(i).GetID();
                            viewFlights.Rows[i].Cells[1].Value = lista.GetFlightPlan(i).GetCurrentPosition().GetX();
                            viewFlights.Rows[i].Cells[2].Value = lista.GetFlightPlan(i).GetCurrentPosition().GetY();
                            viewFlights.Rows[i].Cells[3].Value = lista.GetFlightPlan(i).GetVelocity();
                            DataTable dt = miBase.GetCompany(lista.GetFlightPlan(i).GetCompany());

                            viewFlights.Rows[i].Cells[4].Value = dt.Rows[0][0].ToString();
                            this.name_Comp = dt.Rows[0][0].ToString();
                            viewFlights.Rows[i].Cells[5].Value = dt.Rows[0][1].ToString();
                            this.tel_Comp = dt.Rows[0][1].ToString();
                            viewFlights.Rows[i].Cells[6].Value = dt.Rows[0][2].ToString();
                            this.email_Comp = dt.Rows[0][2].ToString();
                        }
                        else
                        {
                            viewFlights.Rows[i].Cells[0].Value = lista.GetFlightPlan(i).GetID();
                            viewFlights.Rows[i].Cells[1].Value = lista.GetFlightPlan(i).GetCurrentPosition().GetX();
                            viewFlights.Rows[i].Cells[2].Value = lista.GetFlightPlan(i).GetCurrentPosition().GetY();
                            viewFlights.Rows[i].Cells[3].Value = lista.GetFlightPlan(i).GetVelocity();
                            viewFlights.Rows[i].Cells[4].Value = "---";
                            this.name_Comp = "---";
                            viewFlights.Rows[i].Cells[5].Value = "---";
                            this.tel_Comp = "---";
                            viewFlights.Rows[i].Cells[6].Value = "---";
                            this.email_Comp = "---";

                        }


                    }
                }
            }
            catch (NullReferenceException)
            {
                viewFlights.ColumnCount = 7;
                viewFlights.Columns[0].HeaderText = "Identifier";
                viewFlights.Columns[1].HeaderText = "Current X";
                viewFlights.Columns[2].HeaderText = "Current Y";
                viewFlights.Columns[3].HeaderText = "Velocity";
                viewFlights.Columns[4].HeaderText = "Company Name";
                viewFlights.Columns[5].HeaderText = "Telephone";
                viewFlights.Columns[6].HeaderText = "Email";
            }

        }

        private Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image Image = new Bitmap(ms);
            return Image;

        }

        /// <summary>
        /// Muestra la distancia del flightplan clicado respecto del resto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewFlights_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            double[] distancelist = new double[lista.GetLength()];
            this.rowindex = e.RowIndex;
            string Text = ("");
            if (rowindex >= 0)
            {
                for (int i = 0; i < lista.GetLength(); i++)
                {


                    if (lista.GetFlightPlan(rowindex) == lista.GetFlightPlan(i))
                    {
                    }
                    else
                    {


                        Position p1 = lista.GetFlightPlan(rowindex).GetCurrentPosition();
                        Position p2 = lista.GetFlightPlan(i).GetCurrentPosition();

                        double distancia = p1.Distancia(p2);
                        if (p1 == p2)
                        {

                        }
                        else
                        {
                            distancelist[i] = distancia;

                        }



                    }

                }



                for (int i = 0; i < lista.GetLength(); i++)
                {

                    Text = Text + ("ID: " + lista.GetFlightPlan(i).GetID() + "     " + "Distance: " + Convert.ToString(distancelist[i]) + "\n");

                }
                if (lista.GetFlightPlan(rowindex).GetCompany() != "")
                {
                    FlightPlanData fpd = new FlightPlanData();
                    fpd.SetTitle("Distances to " + lista.GetFlightPlan(rowindex));
                    fpd.LoadData(Text, name_Comp + "\n" + tel_Comp + "\n" + email_Comp, ByteToImage(miBase.LoadImage(lista.GetFlightPlan(rowindex).GetCompany())));
                    fpd.ShowDialog();
                }
                else
                {
                    FlightPlanData fpd = new FlightPlanData();
                    fpd.SetTitle("Distances to " + lista.GetFlightPlan(rowindex));
                    fpd.LoadData1Response(Text);
                    fpd.ShowDialog();
                }
            }
        }
    }
}
