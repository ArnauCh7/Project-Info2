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
    public partial class FlightPlanData : Form
    {
        string title1;
        string Data1;
        string Data2;
        Image photo;
        public FlightPlanData()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Metodo para importar un string con toda la informacion del plan de vuelo
        /// </summary>
        /// <param name="Response1"></param>
        /// <param name="Response2"></param>
        /// <param name="image"></param>
        public void LoadData(string Response1, string Response2, Image image)
        {

            this.Data1 = Response1;
            this.Data2 = Response2;
            this.photo = image;
        }
        /// <summary>
        /// Setter del title
        /// </summary>
        /// <param name="title1"></param>
        public void SetTitle(string title1)
        {
            this.title1 = title1;

        }

        /// <summary>
        /// Carga la data1
        /// </summary>
        /// <param name="Response1"></param>
        public void LoadData1Response(string Response1)
        {
            this.Data1 = Response1;
            this.Data2 = "---";

        }

        /// <summary>
        /// Setea los datos cargados en los labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlightPlanData_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
            Title1.Text = this.title1;
            Response1Lbl.Text = this.Data1;
            Response2Lbl.Text = this.Data2;
            pictureBox1.Image = this.photo;


        }

        /// <summary>
        /// Cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
