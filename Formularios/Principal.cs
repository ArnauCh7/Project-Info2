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
using System.IO;
using System.Media;
using System.Net;
using System.Net.Mail;
using WMPLib;

namespace Formularios
{
    public partial class Principal : Form
    {
        FlightPlanList milista = new FlightPlanList();//Lista de Flightplans
        List<PictureBox> misPics = new List<PictureBox>();//Lista de las fotos de los aviones
        List<PictureBox> finalPics = new List<PictureBox>();//Lista de las fotos de los puntos finales
        List<PictureBox> initialPics = new List<PictureBox>();//Lista de las fotos de los puntos iniciales
        List<PictureBox> distanceCircles = new List<PictureBox>();//Lista de las fotos de los circulos de distancia
        Stack<FlightPlanList> historial_movimientos = new Stack<FlightPlanList>();//Lista del historial de movimientos
        List<Position> clickPositionList = new List<Position>();
        DataBase mibase = new DataBase();
        WindowsMediaPlayer player = new WindowsMediaPlayer();


        System.Drawing.Graphics graphics;
        string username;
        bool romper = false;//bool para que no aparezcan dos ventanas de que hay colision en la comprovación por cada tick del reloj
        int numPics = 0;//numero de imagenes en las listas (son todas iguales porque es una por avion)
        int segundos;//texto que sale en el contador de tiempo
        double distanciaSeguridad;//variable donde se guarda la distancia de seguridad
        int timeStep;//intervalo del timer_tick
        bool ha_sido_movido = false;
        bool primer_avion = true; //indica true si aun no se han insertado aviones manualmente
        int allArrived = 0;//cantidad de aviones que han llegado a si posicion final
        int panelClick_Counter = 0;//cantidad de clicks en el panel para añadir un avion
        bool executingClickFlightplan = false;//bool para saber si se ha clicado el boton para añadir un flightplan clicando
        string clickID;//ID del flightplan que se añade clicando
        double clickVelocity;//Velocidad del flightplan 
        string clickCompany;
        string clickAircraftType;
        string cambios; //String con todos los cambios de velocidades de la simulacion
        bool avanza_atrasa; //true si avanza y false si se retrasa
        bool respondido = false; //respondido es un bool para determinar si se ha de resolver la simulacion o no.
        int respuesta; // determinar si se resuelve la simulacion o no 0=cancelar, 1=si, 2=no
        




        public Principal()
        {
            InitializeComponent();
            player.URL = "sweden.mp3";
        }
        /// <summary>
        /// Todos los labels de ayuda los pone en oculto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Principal_Load(object sender, EventArgs e)
        {
            
            player.settings.autoStart = true;
            player.settings.setMode("loop", true);
            this.Icon = Icon.ExtractAssociatedIcon("detectorIcon.ico");

            Helpmove.Visible = false;
            Helpstop.Visible = false;
            Helpmoveratras.Visible = false;
            Helpsimulate.Visible = false;
            Helprestart.Visible = false;
            Helpsimulateatras.Visible = false;
            Helpchangevel.Visible = false;
            Helptimer.Visible = false;
            Helppanel.Visible = false;
            HelpFileOptions.Visible = false;
            HelpReset.Visible = false;
            mibase.Open();
            TotalScore.Text = Convert.ToString(mibase.GetScore(username));

        }
        public void SetUser(string user)
        {
            this.username = user;
        }
        
        /// <summary>
        /// Añade un nuevo avion, tanto a la lista como al panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newAircraftToolStripMenuItem_Click(object sender, EventArgs e)
        {

            NewAircraft form = new NewAircraft();
            form.ShowDialog();
            bool simulacion_default = form.GetBool();
            if (!simulacion_default)
            {
                if (primer_avion)
                {
                    autoData t = new autoData();
                    t.ShowDialog();
                    try
                    {
                        this.timeStep = Convert.ToInt32(t.GetTiempo());
                        this.distanciaSeguridad = Convert.ToDouble(t.GetDist());
                    }
                    catch (FormatException)
                    {
                        SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                        soundplayer.Play();
                        MessageBox.Show("Format Error");
                        
                    }
                    primer_avion = false;
                }
                FlightPlan p = form.GetFlight();
                milista.AddFlightPlan(p);
                if (p == null)
                {
                }
                else
                {
                    PictureBox pic = new PictureBox();
                    pic.Width = 40;
                    pic.Height = 40;
                    pic.ClientSize = new Size(40, 40);
                    pic.Location = new Point(Convert.ToInt32(p.GetCurrentPosition().GetX() - 20), Convert.ToInt32(p.GetCurrentPosition().GetY() - 20));
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Tag = p;
                    pic.Click += new System.EventHandler(this.evento);
                    //Bitmap fotoAvion = new Bitmap("avion.gif");
                    pic.Image = ByteToImage(mibase.LoadImageFromAircrafts(p.GetAircraftType()));

                    PictureBox pic1 = new PictureBox();
                    pic1.Width = 20;
                    pic1.Height = 20;
                    pic1.ClientSize = new Size(20, 20);
                    pic1.Location = new Point(Convert.ToInt32(p.GetInitialPosition().GetX() - 10), Convert.ToInt32(p.GetInitialPosition().GetY() - 10));
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap fotoInicio = new Bitmap("puntoInicial.png");
                    pic1.Image = (Image)fotoInicio;

                    PictureBox pic2 = new PictureBox();
                    pic2.Width = 20;
                    pic2.Height = 20;
                    pic2.ClientSize = new Size(20, 20);
                    pic2.Location = new Point(Convert.ToInt32(p.GetFinalPosition().GetX() - 10), Convert.ToInt32(p.GetFinalPosition().GetY() - 10));
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap fotoFinal = new Bitmap("puntoFinal.png");
                    pic2.Image = (Image)fotoFinal;

                    PictureBox pic3 = new PictureBox();
                    pic3.Width = Convert.ToInt32(distanciaSeguridad);
                    pic3.Height = Convert.ToInt32(distanciaSeguridad);
                    pic3.ClientSize = new Size(Convert.ToInt32(distanciaSeguridad), Convert.ToInt32(distanciaSeguridad));
                    pic3.Location = new Point(Convert.ToInt32(p.GetCurrentPosition().GetX() - Convert.ToInt32(distanciaSeguridad) / 2), Convert.ToInt32(p.GetCurrentPosition().GetY() - Convert.ToInt32(distanciaSeguridad) / 2));
                    pic3.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap fotoCirculo = new Bitmap("circuloDistancia.png");
                    pic3.Image = (Image)fotoCirculo;


                    Pen myPen = new Pen(Color.Green);
                    Point initialPoint = new Point(Convert.ToInt32(p.GetInitialPosition().GetX()), Convert.ToInt32(p.GetInitialPosition().GetY()));
                    Point finalPoint = new Point(Convert.ToInt32(p.GetFinalPosition().GetX()), Convert.ToInt32(p.GetFinalPosition().GetY()));
                    //this.graphics.DrawEllipse(myPen, Convert.ToInt32(p.GetInitialPosition().GetX()-distanciaSeguridad/2), Convert.ToInt32(p.GetInitialPosition().GetY()-distanciaSeguridad/2), Convert.ToInt32(distanciaSeguridad), Convert.ToInt32(distanciaSeguridad));
                    this.graphics.DrawLine(myPen, initialPoint, finalPoint);
                    myPen.Dispose();

                    panel.Controls.Add(pic);
                    panel.Controls.Add(pic1);
                    panel.Controls.Add(pic2);
                    panel.Controls.Add(pic3);
                    misPics.Add(pic);
                    initialPics.Add(pic1);
                    finalPics.Add(pic2);
                    distanceCircles.Add(pic3);
                    numPics++;
                }
            }
            else
            {
                this.ReadFile(@"TXT\\8aviones.txt"); 
                primer_avion = false;
                int flightplan = 0;
                while (flightplan < milista.GetLength())
                {
                    FlightPlan p = milista.GetFlightPlan(flightplan);
                    if (p == null)
                    {
                    }
                    else
                    {
                        PictureBox pic = new PictureBox();
                        pic.Width = 40;
                        pic.Height = 40;
                        pic.ClientSize = new Size(40, 40);
                        pic.Location = new Point(Convert.ToInt32(p.GetCurrentPosition().GetX() - 20), Convert.ToInt32(p.GetCurrentPosition().GetY() - 20));
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic.Tag = p;
                        pic.Click += new System.EventHandler(this.evento);
                        //Bitmap fotoAvion = new Bitmap("avion.gif");
                        Image fotoavion = ByteToImage(mibase.LoadImageFromAircrafts(p.GetAircraftType()));
                        pic.Image = fotoavion;

                        PictureBox pic1 = new PictureBox();
                        pic1.Width = 20;
                        pic1.Height = 20;
                        pic1.ClientSize = new Size(20, 20);
                        pic1.Location = new Point(Convert.ToInt32(p.GetInitialPosition().GetX() - 10), Convert.ToInt32(p.GetInitialPosition().GetY() - 10));
                        pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                        Bitmap fotoInicio = new Bitmap("puntoInicial.png");
                        pic1.Image = (Image)fotoInicio;

                        PictureBox pic2 = new PictureBox();
                        pic2.Width = 20;
                        pic2.Height = 20;
                        pic2.ClientSize = new Size(20, 20);
                        pic2.Location = new Point(Convert.ToInt32(p.GetFinalPosition().GetX() - 10), Convert.ToInt32(p.GetFinalPosition().GetY() - 10));
                        pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                        Bitmap fotoFinal = new Bitmap("puntoFinal.png");
                        pic2.Image = (Image)fotoFinal;

                        PictureBox pic3 = new PictureBox();
                        pic3.Width = Convert.ToInt32(distanciaSeguridad);
                        pic3.Height = Convert.ToInt32(distanciaSeguridad);
                        pic3.ClientSize = new Size(Convert.ToInt32(distanciaSeguridad), Convert.ToInt32(distanciaSeguridad));
                        pic3.Location = new Point(Convert.ToInt32(p.GetCurrentPosition().GetX() - Convert.ToInt32(distanciaSeguridad) / 2), Convert.ToInt32(p.GetCurrentPosition().GetY() - Convert.ToInt32(distanciaSeguridad) / 2));
                        pic3.SizeMode = PictureBoxSizeMode.StretchImage;
                        Bitmap fotoCirculo = new Bitmap("circuloDistancia.png");
                        pic3.Image = (Image)fotoCirculo;


                        Pen myPen = new Pen(Color.Green);
                        Point initialPoint = new Point(Convert.ToInt32(p.GetInitialPosition().GetX()), Convert.ToInt32(p.GetInitialPosition().GetY()));
                        Point finalPoint = new Point(Convert.ToInt32(p.GetFinalPosition().GetX()), Convert.ToInt32(p.GetFinalPosition().GetY()));
                        //this.graphics.DrawEllipse(myPen, Convert.ToInt32(p.GetInitialPosition().GetX()-distanciaSeguridad/2), Convert.ToInt32(p.GetInitialPosition().GetY()-distanciaSeguridad/2), Convert.ToInt32(distanciaSeguridad), Convert.ToInt32(distanciaSeguridad));
                        this.graphics.DrawLine(myPen, initialPoint, finalPoint);
                        myPen.Dispose();

                        panel.Controls.Add(pic);
                        panel.Controls.Add(pic1);
                        panel.Controls.Add(pic2);
                        panel.Controls.Add(pic3);
                        misPics.Add(pic);
                        initialPics.Add(pic1);
                        finalPics.Add(pic2);
                        distanceCircles.Add(pic3);
                        numPics++;
                        flightplan++;
                    }
                }

            }
        }
        /// <summary>
        /// Muestra una textbox con la informacion del vuelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void evento(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            FlightPlan info2 = (FlightPlan)pic.Tag;
            FlightPlan info = new FlightPlan();
            for (int i = 0; i < milista.GetLength(); i++)
            {
                if (info2.GetID() == milista.GetFlightPlan(i).GetID())
                {
                    info = milista.GetFlightPlan(i);
                    break;
                }
                info = milista.GetFlightPlan(i);
                double distancia = info.GetCurrentPosition().Distancia(info.GetInitialPosition());
                info.AñadirPosicion(distancia);
            }
            string response1;
            string response2;
            if (mibase.FindCompany(info.GetCompany()))
            {
                DataTable companydt = mibase.GetCompany(info.GetCompany());
                string nc = companydt.Rows[0][0].ToString();
                string telc = companydt.Rows[0][1].ToString();
                string emailc = companydt.Rows[0][2].ToString();
                DataTable actypedt = mibase.GetACType(info.GetAircraftType());
                string nac = actypedt.Rows[0][0].ToString();
                string numpassengers = actypedt.Rows[0][1].ToString();
                int landed = info.Landing();
                double distancia = info.GetCurrentPosition().Distancia(info.GetInitialPosition());
                info.AñadirPosicion(distancia);
                for(int i =0; i<milista.GetLength(); i++)
                {
                    if(info.GetID() == milista.GetFlightPlan(i).GetID())
                    {
                        milista.GetFlightPlan(i).AñadirPosicion(info.GetDistanciaRecorrida());
                        break;
                    }
                }
                if (landed == 0)
                {
                    if (info.Destino())
                    {
                        response1 = ("ID: " + info.GetID() + "\n" +
                            "Current X: " + Convert.ToString(info.GetCurrentPosition().GetX()) + "\n" +
                            "Current Y: " + Convert.ToString(info.GetCurrentPosition().GetY()) + "\n" +
                            "Final X: " + Convert.ToString(info.GetFinalPosition().GetX()) + "\n" +
                            "Final Y: " + Convert.ToString(info.GetFinalPosition().GetY()) + "\n" +
                            "Velocity: " + info.GetVelocity() + "\n" +
                            "Distance travelled: " + Convert.ToString(info.GetDistanciaRecorrida()) + "\n" +
                            "Aircraft Type: " + nac + "\n" +
                            "Passengers: " + numpassengers + "\n" +
                            "This Plane has already landed");
                        response2 = nc + "\n" + telc + "\n" + emailc;
                        FlightPlanData fpd = new FlightPlanData();
                        fpd.SetTitle("FlightPlan Data");
                        fpd.LoadData(response1, response2, ByteToImage(mibase.LoadImage(info.GetCompany())));
                        fpd.ShowDialog();

                    }
                    else
                    {
                        response1 = ("ID: " + info.GetID() + "\n" +
                            "Current X: " + Convert.ToString(info.GetCurrentPosition().GetX()) + "\n" +
                            "Current Y: " + Convert.ToString(info.GetCurrentPosition().GetY()) + "\n" +
                            "Final X: " + Convert.ToString(info.GetFinalPosition().GetX()) + "\n" +
                            "Final Y: " + Convert.ToString(info.GetFinalPosition().GetY()) + "\n" +
                            "Velocity: " + info.GetVelocity() + "\n" +
                            "Distance travelled: " + Convert.ToString(info.GetDistanciaRecorrida()) + "\n" +
                            "Aircraft Type: " + nac + "\n" +
                            "Passengers: " + numpassengers + "\n" +
                            "This Plane is currently in a landing procedure");
                        response2 = nc + "\n" + telc + "\n" + emailc;
                        FlightPlanData fpd = new FlightPlanData();
                        fpd.SetTitle("FlightPlan Data");
                        fpd.LoadData(response1, response2, ByteToImage(mibase.LoadImage(info.GetCompany())));
                        fpd.ShowDialog();
                    }
                }
                else if (landed != 0)
                {
                    response1 = ("ID: " + info.GetID() + "\n" +
                        "Current X: " + Convert.ToString(info.GetCurrentPosition().GetX()) + "\n" +
                        "Current Y: " + Convert.ToString(info.GetCurrentPosition().GetY()) + "\n" +
                        "Final X: " + Convert.ToString(info.GetFinalPosition().GetX()) + "\n" +
                        "Final Y: " + Convert.ToString(info.GetFinalPosition().GetY()) + "\n" +
                        "Velocity: " + info.GetVelocity() + "\n" +
                        "Distance travelled: " + Convert.ToString(info.GetDistanciaRecorrida()) + "\n" +
                        "Aircraft Type: " + nac + "\n" +
                        "Passengers: " + numpassengers + "\n");
                    response2 = nc + "\n" + telc + "\n" + emailc;
                    FlightPlanData fpd = new FlightPlanData();
                    fpd.SetTitle("FlightPlan Data");
                    fpd.LoadData(response1, response2, ByteToImage(mibase.LoadImage(info.GetCompany())));
                    fpd.ShowDialog();
                }
            }
            else
            {
                for (int i = 0; i < milista.GetLength(); i++)
                {
                    FlightPlan a = milista.GetFlightPlan(i);
                    if (info.GetID() == a.GetID())
                    {
                        info = a;
                        break;
                    }
                }
                int landed = info.Landing();

                if (landed == 0)
                {
                    if (info.Destino())
                    {
                        response1 = ("ID: " + info.GetID() + "\n" +
                            "Current X: " + Convert.ToString(info.GetCurrentPosition().GetX()) + "\n" +
                            "Current Y: " + Convert.ToString(info.GetCurrentPosition().GetY()) + "\n" +
                            "Final X: " + Convert.ToString(info.GetFinalPosition().GetX()) + "\n" +
                            "Final Y: " + Convert.ToString(info.GetFinalPosition().GetY()) + "\n" +
                            "Velocity: " + info.GetVelocity() + "\n" +
                            "Distance travelled: " + Convert.ToString(info.GetDistanciaRecorrida()) + "\n" +
                            "This Plane has already landed");
                        FlightPlanData fpd = new FlightPlanData();
                        fpd.LoadData1Response(response1);
                        fpd.SetTitle("FlightPlan Data");
                        fpd.ShowDialog();

                    }
                    else
                    {
                        response1 = ("ID: " + info.GetID() + "\n" +
                             "Current X: " + Convert.ToString(info.GetCurrentPosition().GetX()) + "\n" +
                             "Current Y: " + Convert.ToString(info.GetCurrentPosition().GetY()) + "\n" +
                             "Final X: " + Convert.ToString(info.GetFinalPosition().GetX()) + "\n" +
                             "Final Y: " + Convert.ToString(info.GetFinalPosition().GetY()) + "\n" +
                             "Velocity: " + info.GetVelocity() + "\n" +
                             "Distance travelled: " + Convert.ToString(info.GetDistanciaRecorrida()) + "\n" +
                             "This Plane is currently in a landing procedure");
                        FlightPlanData fpd = new FlightPlanData();
                        fpd.LoadData1Response(response1);
                        fpd.SetTitle("FlightPlan Data");
                        fpd.ShowDialog();
                    }
                }
                else if (landed != 0)
                {
                    response1 = ("ID: " + info.GetID() + "\n" +
                        "Current X: " + Convert.ToString(info.GetCurrentPosition().GetX()) + "\n" +
                        "Current Y: " + Convert.ToString(info.GetCurrentPosition().GetY()) + "\n" +
                        "Final X: " + Convert.ToString(info.GetFinalPosition().GetX()) + "\n" +
                        "Final Y: " + Convert.ToString(info.GetFinalPosition().GetY()) + "\n" +
                        "Velocity: " + info.GetVelocity() + "\n" +
                        "Distance travelled: " + Convert.ToString(info.GetDistanciaRecorrida()));
                    FlightPlanData fpd = new FlightPlanData();
                    fpd.LoadData1Response(response1);
                    fpd.SetTitle("FlightPlan Data");
                    fpd.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Mueve el avion una posición
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mover_Click(object sender, EventArgs e)
        {
            if (allArrived != milista.GetLength())
            {
                if (milista.GetLength() != 0)
                {
                    FlightPlanList lista_auxiliar_mover = new FlightPlanList();
                    lista_auxiliar_mover = milista.DeepCopy();
                    historial_movimientos.Push(lista_auxiliar_mover);
                    milista.Mover(10);
                    ha_sido_movido = true;

                    for (int i = 0; i < milista.GetLength(); i++)
                    {
                        misPics[i].Location = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - 20), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - 20));
                        Pen myPen = new Pen(Color.Green);
                        //this.graphics.DrawEllipse(myPen, Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - distanciaSeguridad / 2), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - distanciaSeguridad / 2), Convert.ToInt32(distanciaSeguridad), Convert.ToInt32(distanciaSeguridad));
                        Point initialPoint = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetInitialPosition().GetX()), Convert.ToInt32(milista.GetFlightPlan(i).GetInitialPosition().GetY()));
                        Point finalPoint = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetFinalPosition().GetX()), Convert.ToInt32(milista.GetFlightPlan(i).GetFinalPosition().GetY()));
                        this.graphics.DrawLine(myPen, initialPoint, finalPoint);
                        myPen.Dispose();
                        distanceCircles[i].Location = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - Convert.ToInt32(distanciaSeguridad) / 2), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - Convert.ToInt32(distanciaSeguridad) / 2));
                       
                    }
                    segundos = Convert.ToInt32(label5.Text) + 1; //variable para poner los ticks del timer en un label
                    label5.Text = Convert.ToString(segundos);
                    for (int i = 0; i < milista.GetLength(); i++)
                    {
                        FlightPlan info2 = milista.GetFlightPlan(i);
                        double distancia = info2.GetCurrentPosition().Distancia(info2.GetInitialPosition());
                        info2.AñadirPosicion(distancia);
                    }
                    milista.SetDistanciaTotal();
                    double score = Convert.ToDouble(Score.Text);
                    if (score < milista.GetDistanciaTotal())
                    {
                        Score.Text = Convert.ToString(milista.GetDistanciaTotal());
                    }
                }
                else
                {
                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                    soundplayer.Play();
                    MessageBox.Show("Enter a flightplan  before moving. ");
                    
                }
                for (int i = 0; i < milista.GetLength(); i++)
                {
                    if (romper == false)
                    {
                        for (int j = 0; j < milista.GetLength(); j++)
                        {
                            if (milista.GetFlightPlan(i) == milista.GetFlightPlan(j))
                            {
                            }
                            else
                            {
                                if (milista.GetFlightPlan(i).Conflicto(milista.GetFlightPlan(j), distanciaSeguridad) == true)
                                {

                                    ConflictLbl.Text = "Conflict!";
                                    ConflictLbl.BackColor = Color.Red;
                                    ConflictLbl.ForeColor = Color.Black;
                                    break;
                                }
                                else
                                {
                                    ConflictLbl.Text = "No Conflict";
                                    ConflictLbl.BackColor = Color.Transparent;
                                    ConflictLbl.ForeColor = Color.Lime;
                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Detecta si hay conflicto y muestra un form para decidir si resolverlo o no, en caso afirmativo, lo resuelve, en caso negatvo, no lo hace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void auto_Click(object sender, EventArgs e)
        {
            Reloj_Atrás.Stop();
            if (milista.GetLength() < 2)
            {

                if (timeStep == 0)
                {
                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                    soundplayer.Play();
                    MessageBox.Show("Timestep can't be 0");
                    
                }
                else
                {
                    reloj.Interval = timeStep;
                    reloj.Start();
                    stop.Text = "STOP";
                }
            }
            else
            {
                for (int i = 1; i < milista.GetLength(); i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (milista.GetFlightPlan(i).minDistance(milista.GetFlightPlan(j)) <= distanciaSeguridad)
                        {
                            if (!respondido)
                            {
                                var avoided = MessageBox.Show("A conflict has been detected!\nDo you want to avoid the conflict?", "Conflict Detected!", MessageBoxButtons.YesNoCancel);
                                if(avoided == DialogResult.Yes)
                                {
                                    respuesta = 1;
                                    respondido = true;
                                }
                                else if(avoided == DialogResult.No)
                                {
                                    respuesta = 2;
                                    respondido = true;
                                }
                                else if(avoided == DialogResult.Cancel)
                                {
                                    respuesta = 0;
                                    respondido = false;
                                }

                            }
                            
                            
                            
                            if (respuesta == 1)
                            {
                                if (milista.GetFlightPlan(i).GetInitialPosition() == milista.GetFlightPlan(j).GetFinalPosition() && milista.GetFlightPlan(j).GetInitialPosition() == milista.GetFlightPlan(i).GetFinalPosition())
                                {
                                    MessageBox.Show("The flightplans" + milista.GetFlightPlan(i).GetID() + " and " + milista.GetFlightPlan(j).GetID() + "are in the same line opposite direction");
                                }
                                else
                                {
                                    while (milista.GetFlightPlan(i).minDistance(milista.GetFlightPlan(j)) <= distanciaSeguridad)
                                    {
                                        if (milista.GetFlightPlan(i).GetVelocity() > 0)
                                        {
                                            milista.GetFlightPlan(i).SetVelocidad(milista.GetFlightPlan(i).GetVelocity() - 1);
                                        }
                                    }
                                    for (int k = 0; k < i; k++)
                                    {
                                        while (milista.GetFlightPlan(i).minDistance(milista.GetFlightPlan(k)) <= distanciaSeguridad)
                                        {
                                            if (milista.GetFlightPlan(i).GetVelocity() > 0)
                                            {
                                                milista.GetFlightPlan(i).SetVelocidad(milista.GetFlightPlan(i).GetVelocity() - 1);
                                            }
                                        }

                                    }
                                }

                            }
                            else if(respuesta == 2)
                            {
                                if (timeStep == 0)
                                {
                                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                                    soundplayer.Play();
                                    MessageBox.Show("Timestep can't be 0");

                                }
                                else
                                {
                                    reloj.Interval = timeStep;
                                    reloj.Start();
                                    stop.Text = "STOP";
                                }
                            }
                            else if(respuesta == 0)
                            {

                            }
                        }
                    }
                }
                bool allSolved = true;

                for (int j = 0; j < milista.GetLength(); j++)
                {
                    for (int l = 0; l < milista.GetLength(); l++)
                    {
                        if (milista.GetFlightPlan(j) != milista.GetFlightPlan(l))
                        {
                            if (milista.GetFlightPlan(j).minDistance(milista.GetFlightPlan(l)) <= distanciaSeguridad)
                            {
                                allSolved = false;
                            }
                        }
                    }
                }
                if (allSolved == true)
                {
                    if (timeStep == 0)
                    {
                        SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                        soundplayer.Play();
                        MessageBox.Show("Timestep can't be 0");
                        
                    }
                    else
                    {
                        
                        reloj.Interval = timeStep;
                        reloj.Start();
                        stop.Text = "STOP";

                    }
                }
                
            }
        }
        /// <summary>
        /// Detiene la simulación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stop_Click(object sender, EventArgs e)
        {
            string status = stop.Text;
            
            if (status == "STOP")
            {
                if (reloj.Enabled)
                {
                    avanza_atrasa = true;
                }
                else if(Reloj_Atrás.Enabled)
                {
                    avanza_atrasa = false;
                }
                reloj.Stop();
                Reloj_Atrás.Stop();
                stop.Text = "RESUME";
                for (int i = 0; i < milista.GetLength(); i++)
                {
                    FlightPlan info2 = milista.GetFlightPlan(i);
                    double distancia = info2.GetCurrentPosition().Distancia(info2.GetInitialPosition());
                    info2.AñadirPosicion(distancia);
                }
                milista.SetDistanciaTotal();
                double score = Convert.ToDouble(Score.Text);
                if (score < milista.GetDistanciaTotal())
                {
                    Score.Text = Convert.ToString(milista.GetDistanciaTotal());
                }
                
            }

            else if(status == "RESUME")
            {
                if (avanza_atrasa)
                {
                    reloj.Start();
                    stop.Text = "STOP";
                }
                else
                {
                    Reloj_Atrás.Start();
                    stop.Text = "STOP";
                }
            }
        }

        /// <summary>
        /// Abre el form del datagrid donde se muestran todos los aviones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aircraftListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlightGrind grind = new FlightGrind();
            grind.GiveList(milista);
            grind.ShowDialog();
        }

        /// <summary>
        /// Es lo que se va comprobando en cada tick del timer (comprueba si hay colision, mueve los aviones durante el recorrido, etc)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Reloj_Atrás.Enabled)
            {
                reloj.Stop();
                stop.Text = "RESUME";
                Reloj_Atrás.Stop();
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("First stop the forward simulation");
                
            }
            else
            {
                segundos = Convert.ToInt32(label5.Text) + 1; //variable para poner los ticks del timer en un label
                label5.Text = Convert.ToString(segundos);
                allArrived = 0;//cantidad de aviones que han llegado a si posicion final


                //le suma uno a allarrived cuando un avion llega en su destino
                for (int i = 0; i < milista.GetLength(); i++)
                {
                    if (milista.GetFlightPlan(i).Destino() == true)
                    {
                        allArrived += 1;
                    }
                }

                //Comprueba si dos aviones se estan a menos de su distancia de seguridad en ese momento
                for (int i = 0; i < milista.GetLength(); i++)
                {
                    if (romper == false)
                    {
                        for (int j = 0; j < milista.GetLength(); j++)
                        {
                            if (milista.GetFlightPlan(i) == milista.GetFlightPlan(j))
                            {
                            }
                            else
                            {
                                if (milista.GetFlightPlan(i).Conflicto(milista.GetFlightPlan(j), distanciaSeguridad) == true)
                                {
                                    
                                    ConflictLbl.Text = "Conflict!";
                                    ConflictLbl.BackColor = Color.Red;
                                    ConflictLbl.ForeColor = Color.Black;
                                    break;
                                }
                                else
                                {
                                    ConflictLbl.Text = "No Conflict";
                                    ConflictLbl.BackColor = Color.Transparent;
                                    ConflictLbl.ForeColor = Color.Lime;
                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (allArrived == milista.GetLength())//si todos los aviones han llegado a su destino enseña un mensaje
                {
                    reloj.Stop();
                    stop.Text = "RESUME";
                    MessageBox.Show("All planes have arrived to its destination.");
                    for (int i = 0; i < milista.GetLength(); i++)
                    {
                        FlightPlan info2 = milista.GetFlightPlan(i);
                        double distancia = info2.GetCurrentPosition().Distancia(info2.GetInitialPosition());
                        info2.AñadirPosicion(distancia);
                    }
                    milista.SetDistanciaTotal();
                    double score = Convert.ToDouble(Score.Text);
                    if (score < milista.GetDistanciaTotal())
                    {
                        Score.Text = Convert.ToString(milista.GetDistanciaTotal());
                    }
                    
                }
                else//sino los mueve y pinta las lineas y los circulos de distancia
                {
                    FlightPlanList lista_auxiliar_simulacion = new FlightPlanList();
                    lista_auxiliar_simulacion = milista.DeepCopy();
                    historial_movimientos.Push(lista_auxiliar_simulacion);
                    milista.Mover(10);
                    ha_sido_movido = true;
                    for (int i = 0; i < milista.GetLength(); i++)
                    {
                        misPics[i].Location = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - 20), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - 20));
                        Pen myPen = new Pen(Color.Green);
                        //this.graphics.DrawEllipse(myPen, Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - distanciaSeguridad / 2), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - distanciaSeguridad / 2), Convert.ToInt32(distanciaSeguridad), Convert.ToInt32(distanciaSeguridad));
                        Point initialPoint = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetInitialPosition().GetX()), Convert.ToInt32(milista.GetFlightPlan(i).GetInitialPosition().GetY()));
                        Point finalPoint = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetFinalPosition().GetX()), Convert.ToInt32(milista.GetFlightPlan(i).GetFinalPosition().GetY()));
                        this.graphics.DrawLine(myPen, initialPoint, finalPoint);
                        //panel.Invalidate();
                        myPen.Dispose();
                        distanceCircles[i].Location = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - Convert.ToInt32(distanciaSeguridad) / 2), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - Convert.ToInt32(distanciaSeguridad) / 2));
                    }
                }
                
            }
        }

        /// <summary>
        /// Devuelve los flightplans a su estado inicial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < milista.GetLength(); i++)
            {
                milista.GetFlightPlan(i).GoInitialPosition();
                misPics[i].Location = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - 20), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - 20));
                Pen myPen = new Pen(Color.Green);
                //this.graphics.DrawEllipse(myPen, Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - distanciaSeguridad / 2), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - distanciaSeguridad / 2), Convert.ToInt32(distanciaSeguridad), Convert.ToInt32(distanciaSeguridad));
                Point initialPoint = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetInitialPosition().GetX()), Convert.ToInt32(milista.GetFlightPlan(i).GetInitialPosition().GetY()));
                Point finalPoint = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetFinalPosition().GetX()), Convert.ToInt32(milista.GetFlightPlan(i).GetFinalPosition().GetY()));
                this.graphics.DrawLine(myPen, initialPoint, finalPoint);
                myPen.Dispose();
                distanceCircles[i].Location = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - Convert.ToInt32(distanciaSeguridad) / 2), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - Convert.ToInt32(distanciaSeguridad) / 2));
            }
            respondido = false;
            romper = false;
            reloj.Stop();
            historial_movimientos.Clear();
            stop.Text = "RESUME";
            string[] puntos = Score.Text.Split(',');
            mibase.UpdateScore(username, Convert.ToInt32(puntos[0]));
            Score.Text = "0";
            TotalScore.Text = Convert.ToString(mibase.GetScore(username));
        }
        /// <summary>
        /// Funcion que crea un objeto de metodo grafico para pintar el panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = panel.CreateGraphics();
            this.graphics = graphics;
        }
        /// <summary>
        /// Abre el form para cambiar la velocidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeVelocity_Click(object sender, EventArgs e)
        {
            ChangeVelocity t = new ChangeVelocity();
            t.SetFlightPlanList(milista);
            t.ShowDialog();
            bool cambiado = t.Ha_Cambiado();
            cambios = cambios + t.GetCambio();
            if (t.GetVelocity() == 0)
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("Velocities haven't been changed.");
                
            }
            else if (cambiado)
            {
                for(int i = 0;i<milista.GetLength(); i++)
                {
                    FlightPlan fp = milista.GetFlightPlan(i);
                    if (t.GetID() == fp.GetID())
                    {   
                        respuesta = 2;
                        milista.GetFlightPlan(i).SetVelocidad(t.GetVelocity());
                        
                    }
                }
            }
            else
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("Velocities haven't been changed, check that you have written the ID correctly.");
            }
        }
        /// <summary>
        /// Mueve los flightplans hacia atras una posición
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveBackBtn_Click(object sender, EventArgs e)
        {

            if (historial_movimientos.Count > 0)
            {
                this.milista = historial_movimientos.Pop();
                for (int i = 0; i < milista.GetLength(); i++)
                {
                    misPics[i].Location = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - 20), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - 20));
                    Pen myPen = new Pen(Color.Green);
                    //this.graphics.DrawEllipse(myPen, Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - distanciaSeguridad / 2), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - distanciaSeguridad / 2), Convert.ToInt32(distanciaSeguridad), Convert.ToInt32(distanciaSeguridad));
                    Point initialPoint = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetInitialPosition().GetX()), Convert.ToInt32(milista.GetFlightPlan(i).GetInitialPosition().GetY()));
                    Point finalPoint = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetFinalPosition().GetX()), Convert.ToInt32(milista.GetFlightPlan(i).GetFinalPosition().GetY()));
                    this.graphics.DrawLine(myPen, initialPoint, finalPoint);
                    //panel.Invalidate();
                    myPen.Dispose();
                    distanceCircles[i].Location = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - Convert.ToInt32(distanciaSeguridad) / 2), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - Convert.ToInt32(distanciaSeguridad) / 2));
                }
                segundos = Convert.ToInt32(label5.Text) - 1; //variable para poner los ticks del timer en un label
                label5.Text = Convert.ToString(segundos);
                allArrived = 0;
                
                for (int i = 0; i < milista.GetLength(); i++)
                {
                    if (romper == false)
                    {
                        for (int j = 0; j < milista.GetLength(); j++)
                        {
                            if (milista.GetFlightPlan(i) == milista.GetFlightPlan(j))
                            {
                            }
                            else
                            {
                                if (milista.GetFlightPlan(i).Conflicto(milista.GetFlightPlan(j), distanciaSeguridad) == true)
                                {

                                    ConflictLbl.Text = "Conflict!";
                                    ConflictLbl.BackColor = Color.Red;
                                    ConflictLbl.ForeColor = Color.Black;
                                    break;
                                }
                                else
                                {
                                    ConflictLbl.Text = "No Conflict";
                                    ConflictLbl.BackColor = Color.Transparent;
                                    ConflictLbl.ForeColor = Color.Lime;
                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (historial_movimientos.Count == 0 && ha_sido_movido)
            {
                reloj.Stop();
                stop.Text = "RESUME";
                MessageBox.Show("All the planes moved back to the start.");
            }
            else
            {

                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("Move forward first.");
                
            }
        }
        /// <summary>
        /// Mueve los flightplans hacia atras hasta que vuelven a su estado inicial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoBackBtn_Click(object sender, EventArgs e)
        {
            reloj.Stop();
            if (historial_movimientos.Count > 0)
            {
                Reloj_Atrás.Interval = timeStep;
                Reloj_Atrás.Start();
                stop.Text = "STOP";

            }
            else if (historial_movimientos.Count == 0 && ha_sido_movido)
            {
                MessageBox.Show("All the planes moved back to the start.");
            }
            else
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("Move forward first.");
                
            }
            
            
        }

        /// <summary>
        /// Es lo que se va comprobando en cada tick del timer pero hacia atras (comprueba si hay colision, mueve los aviones durante el recorrido en reversa, etc)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reloj_Atrás_Tick(object sender, EventArgs e)
        {
            if (milista.Inicio())
            {
                Reloj_Atrás.Stop();
                stop.Text = "RESUME";
                respondido = false;
            }
            else
            {
                if (reloj.Enabled)
                {
                    reloj.Stop();
                    stop.Text = "STOP";
                }
                else
                {
                    if (historial_movimientos.Count() > 0)
                    {
                        this.milista = historial_movimientos.Pop();
                        segundos = Convert.ToInt32(label5.Text) - 1; //variable para poner los ticks del timer en un label
                        label5.Text = Convert.ToString(segundos);
                        for (int i = 0; i < milista.GetLength(); i++)
                        {
                            misPics[i].Location = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - 20), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - 20));
                            Pen myPen = new Pen(Color.Green);
                            //this.graphics.DrawEllipse(myPen, Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - distanciaSeguridad / 2), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - distanciaSeguridad / 2), Convert.ToInt32(distanciaSeguridad), Convert.ToInt32(distanciaSeguridad));
                            Point initialPoint = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetInitialPosition().GetX()), Convert.ToInt32(milista.GetFlightPlan(i).GetInitialPosition().GetY()));
                            Point finalPoint = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetFinalPosition().GetX()), Convert.ToInt32(milista.GetFlightPlan(i).GetFinalPosition().GetY()));
                            this.graphics.DrawLine(myPen, initialPoint, finalPoint);
                            //panel.Invalidate();
                            myPen.Dispose();
                            distanceCircles[i].Location = new Point(Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetX() - Convert.ToInt32(distanciaSeguridad) / 2), Convert.ToInt32(milista.GetFlightPlan(i).GetCurrentPosition().GetY() - Convert.ToInt32(distanciaSeguridad) / 2));
                        }
                        for (int i = 0; i < milista.GetLength(); i++)
                        {
                            if (romper == false)
                            {
                                for (int j = 0; j < milista.GetLength(); j++)
                                {
                                    if (milista.GetFlightPlan(i) == milista.GetFlightPlan(j))
                                    {
                                    }
                                    else
                                    {
                                        if (milista.GetFlightPlan(i).Conflicto(milista.GetFlightPlan(j), distanciaSeguridad) == true)
                                        {

                                            ConflictLbl.Text = "Conflict!";
                                            ConflictLbl.BackColor = Color.Red;
                                            ConflictLbl.ForeColor = Color.Black;
                                            break;
                                        }
                                        else
                                        {
                                            ConflictLbl.Text = "No Conflict";
                                            ConflictLbl.BackColor = Color.Transparent;
                                            ConflictLbl.ForeColor = Color.Lime;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    else if (historial_movimientos.Count() == 0)
                    {
                        Reloj_Atrás.Stop();
                        stop.Text = "RESUME";
                        MessageBox.Show("All the planes moved back to the start.");
                    }
                }
            }
        }
        /// <summary>
        /// Cierra el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string[] puntos = Score.Text.Split(',');
                mibase.UpdateScore(username, Convert.ToInt32(puntos[0]));
                mibase.Close();
                Close();

            }
        }
        /// <summary>
        /// Permite cargar un fichero de flightplans
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadFromaAFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Load simulation";
                openFileDialog1.InitialDirectory = @"C:\\TXT\\";
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;
                openFileDialog1.ShowDialog();
                string file = openFileDialog1.FileName;
                ReadFile(file);
                bool error_carga = milista.GetError();
                if (error_carga)
                {
                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                    soundplayer.Play();
                    MessageBox.Show("Error loading the file");
                    
                }
            }
            catch (FormatException)
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("You must fill the Distance of security with a number and the timestep with an integer");
                
            }
            primer_avion = false;
            int flightplan = 0;
            while (flightplan < milista.GetLength())
            {
                FlightPlan p = milista.GetFlightPlan(flightplan);
                if (p == null)
                {
                }
                else
                {
                    PictureBox pic = new PictureBox();
                    pic.Width = 40;
                    pic.Height = 40;
                    pic.ClientSize = new Size(40, 40);
                    pic.Location = new Point(Convert.ToInt32(p.GetCurrentPosition().GetX() - 20), Convert.ToInt32(p.GetCurrentPosition().GetY() - 20));
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Tag = p;
                    pic.Click += new System.EventHandler(this.evento);
                    Bitmap fotoAvion = new Bitmap("avion.gif");
                    pic.Image = (Image)fotoAvion;

                    PictureBox pic1 = new PictureBox();
                    pic1.Width = 20;
                    pic1.Height = 20;
                    pic1.ClientSize = new Size(20, 20);
                    pic1.Location = new Point(Convert.ToInt32(p.GetInitialPosition().GetX() - 10), Convert.ToInt32(p.GetInitialPosition().GetY() - 10));
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap fotoInicio = new Bitmap("puntoInicial.png");
                    pic1.Image = (Image)fotoInicio;

                    PictureBox pic2 = new PictureBox();
                    pic2.Width = 20;
                    pic2.Height = 20;
                    pic2.ClientSize = new Size(20, 20);
                    pic2.Location = new Point(Convert.ToInt32(p.GetFinalPosition().GetX() - 10), Convert.ToInt32(p.GetFinalPosition().GetY() - 10));
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap fotoFinal = new Bitmap("puntoFinal.png");
                    pic2.Image = (Image)fotoFinal;

                    PictureBox pic3 = new PictureBox();
                    pic3.Width = Convert.ToInt32(distanciaSeguridad);
                    pic3.Height = Convert.ToInt32(distanciaSeguridad);
                    pic3.ClientSize = new Size(Convert.ToInt32(distanciaSeguridad), Convert.ToInt32(distanciaSeguridad));
                    pic3.Location = new Point(Convert.ToInt32(p.GetCurrentPosition().GetX() - Convert.ToInt32(distanciaSeguridad) / 2), Convert.ToInt32(p.GetCurrentPosition().GetY() - Convert.ToInt32(distanciaSeguridad) / 2));
                    pic3.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap fotoCirculo = new Bitmap("circuloDistancia.png");
                    pic3.Image = (Image)fotoCirculo;


                    Pen myPen = new Pen(Color.Green);
                    Point initialPoint = new Point(Convert.ToInt32(p.GetInitialPosition().GetX()), Convert.ToInt32(p.GetInitialPosition().GetY()));
                    Point finalPoint = new Point(Convert.ToInt32(p.GetFinalPosition().GetX()), Convert.ToInt32(p.GetFinalPosition().GetY()));
                    //this.graphics.DrawEllipse(myPen, Convert.ToInt32(p.GetInitialPosition().GetX()-distanciaSeguridad/2), Convert.ToInt32(p.GetInitialPosition().GetY()-distanciaSeguridad/2), Convert.ToInt32(distanciaSeguridad), Convert.ToInt32(distanciaSeguridad));
                    this.graphics.DrawLine(myPen, initialPoint, finalPoint);
                    myPen.Dispose();

                    panel.Controls.Add(pic);
                    panel.Controls.Add(pic1);
                    panel.Controls.Add(pic2);
                    panel.Controls.Add(pic3);
                    misPics.Add(pic);
                    initialPics.Add(pic1);
                    finalPics.Add(pic2);
                    distanceCircles.Add(pic3);
                    numPics++;
                    flightplan++;
                }
            }
        }

        /// <summary>
        /// Las labels para mostrar las textbox de ayuda dejan de estar en oculto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Helpmove.Visible)
            {
                Helpmove.Visible = false;
                Helpstop.Visible = false;
                Helpmoveratras.Visible = false;
                Helpsimulate.Visible = false;
                Helprestart.Visible = false;
                Helpsimulateatras.Visible = false;
                Helpchangevel.Visible = false;
                Helptimer.Visible = false;
                Helppanel.Visible = false;
                HelpFileOptions.Visible = false;
                HelpReset.Visible = false;

            }
            else
            {
                Helpmove.Visible = true;
                Helpstop.Visible = true;
                Helpmoveratras.Visible = true;
                Helpsimulate.Visible = true;
                Helprestart.Visible = true;
                Helpsimulateatras.Visible = true;
                Helpchangevel.Visible = true;
                Helptimer.Visible = true;
                Helppanel.Visible = true;
                HelpFileOptions.Visible = true;
                HelpReset.Visible = true;
            }
        }

        private void Helpmove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button moves 1 step forward all the aircraft that are in the simulation panel");
        }

        private void Helpstop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button stop all the aircraft that are in the simulation panel");
        }

        private void Helpmoveratras_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button moves 1 step backwards all the aircraft that are in the simulation panel");
        }

        private void Helpsimulate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button moves forward all the aircraft that are in the simulation panel to the final destination");
        }

        private void Helprestart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button moves all the aircraft that are in the simulation panel to their start position");
        }

        private void Helpsimulateatras_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button moves backwards all the aircraft that are in the simulation panel to the final destination");
        }

        private void Helpchangevel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button configurates any changes of the velocities of all the aircrafts in the panel");
        }

        private void Helptimer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This shows the time elapsed during the simulation");
        }

        private void Helppanel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This panel shows the movement of all aircraft");
        }

        private void HelpFileOptions_Click(object sender, EventArgs e)
        {
            if (HelpFileOptions.Text == "?")
            {
                MessageBox.Show("The File layout must be the next one:\n [First Line] Distance_Security Timestep \n [The next Lines as many as you want]\n " +
                "ID initialX initialY currentX currentY finalX finalY velocity Name_of_the_Company(Spaces must be _) aircraft type(only the first letter of the name can be capital)");
            }
            
        }

        private void HelpReset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reset the entire simulation panel after a confirmation of the action");
        }
        /// <summary>
        /// Permite guardar en un fichero los flightplans creados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToAFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            GuardarFichero guardarFichero = new GuardarFichero();
            guardarFichero.ShowDialog();
            bool WhichBtn = guardarFichero.GetBtn();
            /*SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Load simulation";
            sfd.InitialDirectory = @"C:\\TXT\\";
            sfd.RestoreDirectory = true;
            sfd.DefaultExt = "txt";
            sfd.CheckFileExists = true;
            sfd.CheckPathExists = true;
            string path = sfd.*/


            bool error_cargar = milista.GetError();
            if (error_cargar)
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("There has been a problem loading the file\n Make sure the name is correct with the correct extension");
                
            }
            else
            {
                if (WhichBtn)
                {
                    string fichero = guardarFichero.GetFilename();
                    string path = guardarFichero.GetPath();
                    WriteFilePath(path, fichero);
                }
                else
                {
                    string file = guardarFichero.GetFilename();
                    WriteFile(file);
                }
                
            }
            if(guardarFichero.GetSendEmail() == true)
            {
                mibase.Open();
                string email = guardarFichero.GetEmail();
                string htmlString = getHtml(milista);
                Email(htmlString, email);
                MessageBox.Show("DONE");
            }
            
        }

        /// <summary>
        /// Con la lista de flightplans crea una tabla en HTML
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static string getHtml(FlightPlanList lista)
        {
            string messageBody = "<font> Saved document information: </font><br><br>";
            string htmlTableStart = "<table style= \"border-collapse:collapse; text-align:center;\">";
            string htmlTableEnd = "</table>";
            string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
            string htmlHeaderRowEnd = "</tr>";
            string htmlTrStart = "<tr style=\"color:#555555;\">";
            string htmlTrEnd = "</tr>";
            string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
            string htmlTdEnd = "</td>";
            messageBody += htmlTableStart;
            messageBody += htmlHeaderRowStart;
            messageBody += htmlTdStart + "ID" + htmlTdEnd;
            messageBody += htmlTdStart + "Initial Position" + htmlTdEnd;
            messageBody += htmlTdStart + "Current Position" + htmlTdEnd;
            messageBody += htmlTdStart + "Final Position" + htmlTdEnd;
            messageBody += htmlTdStart + "Velocity" + htmlTdEnd;
            messageBody += htmlTdStart + "Company" + htmlTdEnd;
            messageBody += htmlTdStart + "Aircraft Type" + htmlTdEnd;
            messageBody += htmlHeaderRowEnd;
            for(int i = 0; i<lista.GetLength(); i++)
            {
                messageBody = messageBody + htmlTrStart;
                messageBody = messageBody + htmlTdStart + lista.GetFlightPlan(i).GetID() + htmlTdEnd;
                messageBody = messageBody + htmlTdStart + lista.GetFlightPlan(i).GetInitialPosition().GetX() + " , "+ lista.GetFlightPlan(i).GetInitialPosition().GetY() + htmlTdEnd;  
                messageBody = messageBody + htmlTdStart + lista.GetFlightPlan(i).GetCurrentPosition().GetX() + " , " + lista.GetFlightPlan(i).GetCurrentPosition().GetY() + htmlTdEnd;  
                messageBody = messageBody + htmlTdStart + lista.GetFlightPlan(i).GetFinalPosition().GetX() + " , " + lista.GetFlightPlan(i).GetFinalPosition().GetY() + htmlTdEnd;   
                messageBody = messageBody + htmlTdStart + lista.GetFlightPlan(i).GetVelocity() + htmlTdEnd;
                messageBody = messageBody + htmlTdStart + lista.GetFlightPlan(i).GetCompany() + htmlTdEnd;
                messageBody = messageBody + htmlTdStart + lista.GetFlightPlan(i).GetAircraftType() + htmlTdEnd;
                messageBody = messageBody + htmlTrEnd;
            }
            messageBody = messageBody + htmlTableEnd;
            return messageBody;
        }

        /// <summary>
        /// Envia la tabla en html por mail
        /// </summary>
        /// <param name="htmlString"></param>
        /// <param name="email"></param>
        public void Email(string htmlString, string email)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("collisiondetectorhelp@gmail.com");
            message.To.Add(new MailAddress(email));
            message.Subject = "non-reply_data_saved_table";
            message.IsBodyHtml = true;
            message.Body = htmlString;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("collisiondetectorhelp@gmail.com", "collision1234");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
        /// <summary>
        /// permite elegir donde se guarda el archivo a guardar
        /// </summary>
        /// <param name="path"></param>
        /// <param name="file"></param>
        private void WriteFilePath(string path, string file)
        {
            try
            {

                StreamWriter W = new StreamWriter(Path.Combine(path, file));
                W.WriteLine("{0} {1}", this.distanciaSeguridad, this.timeStep);
                for (int i = 0; i < milista.GetLength(); i++)
                {
                    FlightPlan fp = milista.GetFlightPlan(i);
                    string id = fp.GetID();
                    string iX = Convert.ToString(fp.GetInitialPosition().GetX());
                    string iY = Convert.ToString(fp.GetInitialPosition().GetY());
                    string cX = Convert.ToString(fp.GetCurrentPosition().GetX());
                    string cY = Convert.ToString(fp.GetCurrentPosition().GetY());
                    string fX = Convert.ToString(fp.GetFinalPosition().GetX());
                    string fY = Convert.ToString(fp.GetFinalPosition().GetY());
                    string velocity = Convert.ToString(fp.GetVelocity());
                    if (fp.GetCompany() != null)
                    {
                        string company = fp.GetCompany().Replace(' ', '_');

                        W.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}",
                            id, iX, iY, cX, cY, fX, fY, velocity, company);
                    }
                    else
                    {
                        W.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}",
                            id, iX, iY, cX, cY, fX, fY, velocity);
                    }
                }
                if (ha_sido_movido)
                {
                    string stack = "Stack: ";
                    foreach (FlightPlanList e in this.historial_movimientos)
                    {
                        stack = stack + "|";
                        for (int i = 0; i < e.GetLength(); i++)
                        {
                            FlightPlan aux = e.GetFlightPlan(i);
                            string id = aux.GetID();
                            string cX = Convert.ToString(aux.GetCurrentPosition().GetX());
                            string cY = Convert.ToString(aux.GetCurrentPosition().GetY());
                            stack = stack + "%" + id + "/" + cX + "/" + cY;
                        }
                        ;

                    }
                    W.WriteLine(stack);
                }

                W.Close();
            }
            catch (ArgumentException)
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("There has been a problem saving the file");

            }
        }   
        /// <summary>
        /// Escribe el archivo a guardar
        /// </summary>
        /// <param name="file"></param>
        private void WriteFile(string file)
        {
            try
            {

                StreamWriter W = new StreamWriter(Path.Combine("TXT\\", file));
                W.WriteLine("{0} {1}", this.distanciaSeguridad, this.timeStep);
                for (int i = 0; i < milista.GetLength(); i++)
                {
                    FlightPlan fp = milista.GetFlightPlan(i);
                    string id = fp.GetID();
                    string iX = Convert.ToString(fp.GetInitialPosition().GetX());
                    string iY = Convert.ToString(fp.GetInitialPosition().GetY());
                    string cX = Convert.ToString(fp.GetCurrentPosition().GetX());
                    string cY = Convert.ToString(fp.GetCurrentPosition().GetY());
                    string fX = Convert.ToString(fp.GetFinalPosition().GetX());
                    string fY = Convert.ToString(fp.GetFinalPosition().GetY());
                    string velocity = Convert.ToString(fp.GetVelocity());
                    string aircraftType = fp.GetAircraftType();
                    if (fp.GetCompany() != null)
                    {
                        string company = fp.GetCompany().Replace(' ', '_');

                        W.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
                            id, iX, iY, cX, cY, fX, fY, velocity, company, aircraftType);
                    }
                    else
                    {
                        W.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}",
                            id, iX, iY, cX, cY, fX, fY, velocity);
                    }
                }
                if (ha_sido_movido)
                {
                    string stack = "Stack: ";
                    foreach (FlightPlanList e in this.historial_movimientos)
                    {
                        stack = stack + "|";
                        for (int i = 0; i < e.GetLength(); i++)
                        {
                            FlightPlan aux = e.GetFlightPlan(i);
                            string id = aux.GetID();
                            string cX = Convert.ToString(aux.GetCurrentPosition().GetX());
                            string cY = Convert.ToString(aux.GetCurrentPosition().GetY());
                            stack = stack + "%" + id + "/" + cX + "/" + cY;
                        }
                        ;

                    }
                    W.WriteLine(stack);
                }

                W.Close();
            }
            catch (ArgumentException)
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("There has been a problem saving the file");

            }
        }
        /// <summary>
        /// Lee el archivo a cargar y añade los flightplans a la lista y al panel
        /// </summary>
        /// <param name="file"></param>
        private void ReadFile(string file)
        {
            try
            {
                if (milista.GetLength() != 0)
                {
                    var result = MessageBox.Show("Are you sure you want to reset the simulation?", "Reset Simulation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        milista.Clear();
                        panel.Invalidate();
                        misPics.Clear();
                        finalPics.Clear();
                        initialPics.Clear();
                        distanceCircles.Clear();
                        historial_movimientos.Clear();
                        panel.Controls.Clear();
                        label5.Text = "0";
                    }
                }
                StreamReader R = new StreamReader(file);
                List<FlightPlan> resultado = new List<FlightPlan>();
                string line = R.ReadLine();
                string[] Distancia_seguridad_y_Timestep = line.Split(' ');
                if (Distancia_seguridad_y_Timestep.Length == 2)
                {
                    this.distanciaSeguridad = Convert.ToDouble(Distancia_seguridad_y_Timestep[0]);
                    this.timeStep = Convert.ToInt32(Distancia_seguridad_y_Timestep[1]);
                    line = R.ReadLine();
                }
                else
                {
                    autoData auto = new autoData();
                    auto.ShowDialog();
                    this.distanciaSeguridad = auto.GetDist();
                    this.timeStep = auto.GetTiempo();
                }
                string[] datos;
                while (line != null)
                {

                    datos = line.Split(' ');
                    if (datos[0] == "Stack:" && datos.Length == 2)
                    {

                        string final = R.ReadToEnd();
                        string para_apilar = line + final;

                        Stack<FlightPlanList> pila_auxiliar = new Stack<FlightPlanList>();
                        string[] Modificadores = para_apilar.Split('|');
                        for (int i = 1; i < Modificadores.Length; i++)
                        {
                            FlightPlanList lista_auxiliar_Read = new FlightPlanList();
                            lista_auxiliar_Read = milista.DeepCopy();

                            string[] Modificadores2 = Modificadores[i].Split('%');
                            for (int j = 1; j < Modificadores2.Length; j++)
                            {
                                string[] cambios = Modificadores2[j].Split('/');
                                int k = 0;
                                while (k < lista_auxiliar_Read.GetLength())
                                {
                                    if (lista_auxiliar_Read.GetFlightPlan(k).GetID() != cambios[0])
                                        k++;
                                    else
                                    {
                                        lista_auxiliar_Read.GetFlightPlan(k).SetCurrentPosition(Convert.ToDouble(cambios[1]), Convert.ToDouble(cambios[2]));
                                        break;
                                    }
                                }
                            }
                            pila_auxiliar.Push(lista_auxiliar_Read);
                        }
                        while (pila_auxiliar.Count != 0)
                        {
                            historial_movimientos.Push(pila_auxiliar.Pop());
                        }
                        break;
                    }
                    else if (datos[0] == "Stack:" && datos.Length == 1)
                    {
                        R.Close();
                    }
                    else
                    {
                        if (datos.Length == 10)
                        {
                            string identificador = datos[0];
                            double inicial_x = Convert.ToDouble(datos[1]);
                            double inicial_y = Convert.ToDouble(datos[2]);
                            double actual_x = Convert.ToDouble(datos[3]);
                            double actual_y = Convert.ToDouble(datos[4]);
                            double final_x = Convert.ToDouble(datos[5]);
                            double final_y = Convert.ToDouble(datos[6]);
                            double velocidad = Convert.ToDouble(datos[7]);
                            string company = datos[8].Replace('_', ' ');
                            string aircraftType = datos[9];

                            company = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(company.ToLower());
                            aircraftType = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(aircraftType.ToLower());

                            if (!mibase.FindCompany(company))
                            {
                                if (company != "")
                                {
                                    MessageBox.Show("The company is not in our database, you must add the company to the database to see all the flight information");
                                    NewCompany nc = new NewCompany();


                                    nc.NameReadOnly(company);
                                    nc.ShowDialog();
                                    FlightPlan fp = new FlightPlan(identificador, inicial_x, inicial_y, actual_x, actual_y, final_x, final_y, velocidad, company, aircraftType);
                                    milista.AddFlightPlan(fp);
                                    line = R.ReadLine();
                                }
                                else
                                {
                                    FlightPlan fp = new FlightPlan(identificador, inicial_x, inicial_y, actual_x, actual_y, final_x, final_y, velocidad, company, aircraftType);
                                    milista.AddFlightPlan(fp);
                                    line = R.ReadLine();
                                }

                            }
                            else
                            {
                                FlightPlan fp = new FlightPlan(identificador, inicial_x, inicial_y, actual_x, actual_y, final_x, final_y, velocidad, company, aircraftType);
                                milista.AddFlightPlan(fp);
                                line = R.ReadLine();
                            }

                        }
                        else if (datos.Length == 8)
                        {
                            string identificador = datos[0];
                            double inicial_x = Convert.ToDouble(datos[1]);
                            double inicial_y = Convert.ToDouble(datos[2]);
                            double actual_x = Convert.ToDouble(datos[3]);
                            double actual_y = Convert.ToDouble(datos[4]);
                            double final_x = Convert.ToDouble(datos[5]);
                            double final_y = Convert.ToDouble(datos[6]);
                            double velocidad = Convert.ToDouble(datos[7]);
                            FlightPlan fp = new FlightPlan(identificador, inicial_x, inicial_y, actual_x, actual_y, final_x, final_y, velocidad);

                            milista.AddFlightPlan(fp);
                            line = R.ReadLine();

                        }
                    }

                }

                R.Close();

            }
            catch (ArgumentException)
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("There has been a problem loading the file");

            }
            catch (FileNotFoundException)
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("File not found error");

            }
            catch (NullReferenceException)
            {
                SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                soundplayer.Play();
                MessageBox.Show("There has been a problem loading the file");

            }
        }
        /// <summary>
        /// Borra toda la informacion de todas las listas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to reset the simulation?", "Reset Simulation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                milista.Clear();
                panel.Invalidate();
                misPics.Clear();
                finalPics.Clear();
                initialPics.Clear();
                distanceCircles.Clear();
                historial_movimientos.Clear();
                panel.Controls.Clear();
                label5.Text = "0";
                string[] puntos = Score.Text.Split(',');
                mibase.UpdateScore(username, Convert.ToInt32(puntos[0]));
                Score.Text = "0";
                respondido = false;
                TotalScore.Text = Convert.ToString(mibase.GetScore(username));
            }
            else
            {

            }
        }
        /// <summary>
        /// Muestra la posicion del mouse en el panel en un label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            posicionRaton.Text = "Mouse Position: X = " + e.X + " Y = " + e.Y;
            
        }

        /// <summary>
        /// Muestra "out of range" cuando el mouse abandona el panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_MouseLeave(object sender, EventArgs e)
        {
            posicionRaton.Text = "Out of range";
        }

        /// <summary>
        /// Abre una ventana donde pide ID, velocidad, compañia y tipo de avion y activa el modo de añadir avion clicando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addAircraftByClickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertClickData form = new insertClickData();
            form.ShowDialog();
            executingClickFlightplan = true;
            clickID = form.GetID();
            clickVelocity = form.GetV();
            clickCompany = form.GetCompany();
            clickAircraftType = form.GetAircrafttype();
            
            if (primer_avion)
            {
                autoData t = new autoData();
                t.ShowDialog();
                try
                {
                    this.timeStep = Convert.ToInt32(t.GetTiempo());
                    this.distanciaSeguridad = Convert.ToDouble(t.GetDist());
                }
                catch (FormatException)
                {
                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                    soundplayer.Play();
                    MessageBox.Show("Format Error");
                }
                primer_avion = false;
            }
            MessageBox.Show("Now click at 2 points on the panel to set the initial and final positions of the flightplan.");


        }

        /// <summary>
        /// Te deja hacer 2 clicks, el primero seteara la posicion inicial y el segundo la final y se añadira el avion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (executingClickFlightplan == true && clickPositionList.Count < 2)
            {
                Position point = new Position(e.X, e.Y);
                clickPositionList.Add(point);
                panelClick_Counter++;
            }
            else
            {
            }
            if (panelClick_Counter == 2)
            {
                FlightPlan p = new FlightPlan(clickID, clickPositionList[0].GetX(), clickPositionList[0].GetY(), clickPositionList[1].GetX(), clickPositionList[1].GetY(), clickVelocity, clickCompany, clickAircraftType);
                clickPositionList.Clear();
                panelClick_Counter = 0;
                milista.AddFlightPlan(p);
                if (p == null)
                {
                }
                else
                {
                    PictureBox pic = new PictureBox();
                    pic.Width = 40;
                    pic.Height = 40;
                    pic.ClientSize = new Size(40, 40);
                    pic.Location = new Point(Convert.ToInt32(p.GetCurrentPosition().GetX() - 20), Convert.ToInt32(p.GetCurrentPosition().GetY() - 20));
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Tag = p;
                    pic.Click += new System.EventHandler(this.evento);
                    //Bitmap fotoAvion = new Bitmap("avion.gif");
                    pic.Image = ByteToImage(mibase.LoadImageFromAircrafts(clickAircraftType));

                    PictureBox pic1 = new PictureBox();
                    pic1.Width = 20;
                    pic1.Height = 20;
                    pic1.ClientSize = new Size(20, 20);
                    pic1.Location = new Point(Convert.ToInt32(p.GetInitialPosition().GetX() - 10), Convert.ToInt32(p.GetInitialPosition().GetY() - 10));
                    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap fotoInicio = new Bitmap("puntoInicial.png");
                    pic1.Image = (Image)fotoInicio;

                    PictureBox pic2 = new PictureBox();
                    pic2.Width = 20;
                    pic2.Height = 20;
                    pic2.ClientSize = new Size(20, 20);
                    pic2.Location = new Point(Convert.ToInt32(p.GetFinalPosition().GetX() - 10), Convert.ToInt32(p.GetFinalPosition().GetY() - 10));
                    pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap fotoFinal = new Bitmap("puntoFinal.png");
                    pic2.Image = (Image)fotoFinal;

                    PictureBox pic3 = new PictureBox();
                    pic3.Width = Convert.ToInt32(distanciaSeguridad);
                    pic3.Height = Convert.ToInt32(distanciaSeguridad);
                    pic3.ClientSize = new Size(Convert.ToInt32(distanciaSeguridad), Convert.ToInt32(distanciaSeguridad));
                    pic3.Location = new Point(Convert.ToInt32(p.GetCurrentPosition().GetX() - Convert.ToInt32(distanciaSeguridad) / 2), Convert.ToInt32(p.GetCurrentPosition().GetY() - Convert.ToInt32(distanciaSeguridad) / 2));
                    pic3.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap fotoCirculo = new Bitmap("circuloDistancia.png");
                    pic3.Image = (Image)fotoCirculo;


                    Pen myPen = new Pen(Color.Green);
                    Point initialPoint = new Point(Convert.ToInt32(p.GetInitialPosition().GetX()), Convert.ToInt32(p.GetInitialPosition().GetY()));
                    Point finalPoint = new Point(Convert.ToInt32(p.GetFinalPosition().GetX()), Convert.ToInt32(p.GetFinalPosition().GetY()));
                    //this.graphics.DrawEllipse(myPen, Convert.ToInt32(p.GetInitialPosition().GetX()-distanciaSeguridad/2), Convert.ToInt32(p.GetInitialPosition().GetY()-distanciaSeguridad/2), Convert.ToInt32(distanciaSeguridad), Convert.ToInt32(distanciaSeguridad));
                    this.graphics.DrawLine(myPen, initialPoint, finalPoint);
                    myPen.Dispose();

                    panel.Controls.Add(pic);
                    panel.Controls.Add(pic1);
                    panel.Controls.Add(pic2);
                    panel.Controls.Add(pic3);
                    misPics.Add(pic);
                    initialPics.Add(pic1);
                    finalPics.Add(pic2);
                    distanceCircles.Add(pic3);
                    numPics++;
                    executingClickFlightplan = false;
                }
            }
            
        }
        /// <summary>
        /// Abre el formulario para añadir una nueva compañia a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCompany form = new NewCompany();
            form.Show();
        }


        /// <summary>
        /// Convierte una lista de bytes a un Image
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <returns></returns>
        private Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image Image = new Bitmap(ms);
            return Image;
        }

        /// <summary>
        /// Abre el form para borrar compañia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_Company DC = new Delete_Company();
            DC.ShowDialog();
        }
        /// <summary>
        /// Escribe los cambios
        /// </summary>
        /// <param name="cambios"></param>
        /// <param name="filename"></param>
        private void WriteChanges(string cambios, string filename)
        {
            StreamWriter sw = new StreamWriter(Path.Combine("TXT\\", filename));
            sw.Write(cambios);
            sw.Close();
        }
        
        private void WriteChangesPath(string cambios, string filename, string path)
        {
            StreamWriter sw = new StreamWriter(Path.Combine(path, filename));
            sw.Write(cambios);
            sw.Close();
        }

        /// <summary>
        /// Guadra los cambios de velocidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveVelocityChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarFichero guardarFichero = new GuardarFichero();
                guardarFichero.SetDialog(false, "Enter the name of your changelog:");
                guardarFichero.ShowDialog();
                bool WhichBtn = guardarFichero.GetBtn();

                bool error_cargar = milista.GetError();
                if (error_cargar)
                {
                    SoundPlayer soundplayer = new SoundPlayer(@"ErrorSnd.wav");
                    soundplayer.Play();
                    MessageBox.Show("There has been a problem loading the file\n Make sure the name is correct with the correct extension");

                }
                else
                {
                    if (WhichBtn)
                    {
                        string fichero = guardarFichero.GetFilename();
                        string path = guardarFichero.GetPath();
                        WriteChangesPath(cambios, fichero, path);
                        MessageBox.Show("ChangeLog saved succesfully");
                    }
                    else
                    {
                        string file = guardarFichero.GetFilename();
                        WriteChanges(cambios, file);
                        MessageBox.Show("ChangeLog saved succesfully");
                    }

                }
            }
            catch (Exception)
            {
                //ErrLbl.Text = "file not created succesfully";

            }
        }

        /// <summary>
        /// Abre la ventana para insertar un nuevo tipo de avion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newAircraftTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewAircraftType form = new NewAircraftType();
            form.Show();
        }

        /// <summary>
        /// Mira el estado de la checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                player.controls.pause();
            }
            else
            {
                player.controls.play();
            }
        }
        public void setCheckBox(bool mute)
        {
            if (mute)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }


        /// <summary>
        /// Muestra una lista de todos los aviones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aircraftListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FlightGrind grind = new FlightGrind();
            grind.GiveList(milista);
            grind.ShowDialog();
        }

        /// <summary>
        /// Abre el form para borrar una compañia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteCompanyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Delete_Company DC = new Delete_Company();
            DC.ShowDialog();
        }

        /// <summary>
        /// Abre el form para borrar un avion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAircraftTypeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Delete_AircraftType DAT = new Delete_AircraftType();
            DAT.ShowDialog();
        }

        /// <summary>
        /// muastra una lista de compañias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void companyListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyGrind CG = new CompanyGrind();
            CG.ShowDialog();
        }

        /// <summary>
        /// Muestra el ranking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void airCraftTypeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ranking rnk = new Ranking();
            rnk.ShowDialog();
        }
    }
}