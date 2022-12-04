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
    public partial class Ranking : Form
    {
        DataBase miBase = new DataBase();
        public Ranking()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga los nombres de los usuarios y añade colores a las posiciones de los primeros basado en sus puntos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ranking_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
            miBase.Open();
            try
            {
                DataTable dt = miBase.Ranking100();
                Top10.DataSource = dt;
                for (int i = 0; i < Top10.Rows.Count; i++)
                {
                    string row = Convert.ToString(i+1);
                    Top10.Rows[i].HeaderCell.Value = row;
                    if (i == 0)
                    {
                        Top10.Rows[i].DefaultCellStyle.BackColor = Color.Gold;
                    }
                    if (i == 1)
                    {
                        Top10.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
                    }
                    if (i == 2)
                    {
                        Top10.Rows[i].DefaultCellStyle.BackColor = Color.DarkGoldenrod;
                    }
                }
                
            }
            catch (NullReferenceException)
            {
                
                Top10.ColumnCount = 3;
                Top10.Columns[1].HeaderText = "Username";
                Top10.Columns[2].HeaderText = "Score";

            }
            
        }
    }
}
