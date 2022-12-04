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
    public partial class Tutorial : Form
    {
        int i = 2;
        public Tutorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dependiendo de las veces que se haya dado click te enseña un mensage o otro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            switch (i)
            {
                case 2:
                    TutorialPB.Image = new Bitmap("foto2TUTORIAL.png");
                    TutorialLbl.Text = "There are many ways to create a FlightPlan, but the easiest is the selected one!";
                    i++;
                    break;
                case 3:
                    TutorialPB.Image = new Bitmap("foto3TUTORIAL.png");
                    TutorialLbl.Text = "Now enter all the data or if you wish click on a default button, these FlightPlans are created automatically!\n" +
                        "When all the boxes are filled correctly, enter confirm!";
                    i++;
                    break;
                case 4:
                    TutorialPB.Image = new Bitmap("foto4TUTORIAL.png");
                    TutorialLbl.Text = "After clicking confirm this window will appear, just enter 2 numbers. But beware! The distance of security is limited to 100!";
                    i++;
                    break;
                case 5:
                    TutorialPB.Image = new Bitmap("foto5TUTORIAL.png");
                    TutorialLbl.Text = "Congratulations!\nYou have created your first FlightPlan in our ConflictDetector!\nWe hope you create many more!";
                    i++;
                    break;
                case 6:
                    TutorialPB.Image = new Bitmap("foto6TUTORIAL.png");
                    TutorialLbl.Text = "If you want to create a whole simulation from a textfile, you can!\nJust go to 'Options' and then click on 'Load From a File'";
                    i++;
                    break;
                case 7:
                    TutorialPB.Image = new Bitmap("foto7TUTORIAL.png");
                    TutorialLbl.Text = "This is the format that your file should have. \nBut don't worry if you forget it, just press 'Help' on the option bar and then the green '?'";
                    i++;
                    break;
                case 8:
                    TutorialPB.Image = new Bitmap("foto8TUTORIAL.png");
                    TutorialLbl.Text = "When you save a file, do not edit it, as it is very sensitive!\nAnd now for the easy part, enjoy our work! :)";
                    i++;
                    break;
                case 9:
                    Close();
                    break;
            }
        }

        /// <summary>
        /// Muestra el mensage inicial del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tutorial_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");
            TutorialPB.Image = new Bitmap("foto1TUTORIAL.png");
            TutorialLbl.Text = "Welcome! Let's go through a small Tutorial of the program that you are going to see. \n First of all, let's make our first plane, clicking on the 'New' tab in the top left side!";
        }
    }
}
