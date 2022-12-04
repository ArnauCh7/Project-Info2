
namespace Formularios
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.stop = new System.Windows.Forms.Button();
            this.mover = new System.Windows.Forms.Button();
            this.auto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAircraftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAircraftTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAircraftByClickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aircraftListToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.companyListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.airCraftTypeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromaAFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToAFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveVelocityChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCompanyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAircraftTypeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloj = new System.Windows.Forms.Timer(this.components);
            this.restart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.changeVelocity = new System.Windows.Forms.Button();
            this.MoveBackBtn = new System.Windows.Forms.Button();
            this.AutoBackBtn = new System.Windows.Forms.Button();
            this.Reloj_Atrás = new System.Windows.Forms.Timer(this.components);
            this.Helpstop = new System.Windows.Forms.Label();
            this.Helpmove = new System.Windows.Forms.Label();
            this.Helpmoveratras = new System.Windows.Forms.Label();
            this.Helpsimulate = new System.Windows.Forms.Label();
            this.Helprestart = new System.Windows.Forms.Label();
            this.Helpsimulateatras = new System.Windows.Forms.Label();
            this.Helpchangevel = new System.Windows.Forms.Label();
            this.Helptimer = new System.Windows.Forms.Label();
            this.HelpFileOptions = new System.Windows.Forms.Label();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.HelpReset = new System.Windows.Forms.Label();
            this.posicionRaton = new System.Windows.Forms.Label();
            this.ConflictLbl = new System.Windows.Forms.Label();
            this.Helppanel = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Score = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TotalScore = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // stop
            // 
            this.stop.BackColor = System.Drawing.Color.Black;
            this.stop.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop.ForeColor = System.Drawing.Color.Lime;
            this.stop.Location = new System.Drawing.Point(56, 135);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(97, 32);
            this.stop.TabIndex = 3;
            this.stop.Text = "STOP";
            this.stop.UseVisualStyleBackColor = false;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // mover
            // 
            this.mover.BackColor = System.Drawing.Color.Black;
            this.mover.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mover.ForeColor = System.Drawing.Color.Lime;
            this.mover.Location = new System.Drawing.Point(56, 84);
            this.mover.Name = "mover";
            this.mover.Size = new System.Drawing.Size(97, 32);
            this.mover.TabIndex = 1;
            this.mover.Text = "MOVE";
            this.mover.UseVisualStyleBackColor = false;
            this.mover.Click += new System.EventHandler(this.mover_Click);
            // 
            // auto
            // 
            this.auto.BackColor = System.Drawing.Color.Black;
            this.auto.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auto.ForeColor = System.Drawing.Color.Lime;
            this.auto.Location = new System.Drawing.Point(184, 84);
            this.auto.Name = "auto";
            this.auto.Size = new System.Drawing.Size(97, 32);
            this.auto.TabIndex = 2;
            this.auto.Text = "SIMULATE";
            this.auto.UseVisualStyleBackColor = false;
            this.auto.Click += new System.EventHandler(this.auto_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(1141, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "800";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(349, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(335, 584);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "550";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(367, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.fileOptionsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 33);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAircraftToolStripMenuItem,
            this.newCompanyToolStripMenuItem,
            this.newAircraftTypeToolStripMenuItem,
            this.addAircraftByClickToolStripMenuItem});
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(63, 29);
            this.optionsToolStripMenuItem.Text = "New";
            // 
            // newAircraftToolStripMenuItem
            // 
            this.newAircraftToolStripMenuItem.Name = "newAircraftToolStripMenuItem";
            this.newAircraftToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.newAircraftToolStripMenuItem.Text = "New Aircraft";
            this.newAircraftToolStripMenuItem.Click += new System.EventHandler(this.newAircraftToolStripMenuItem_Click);
            // 
            // newCompanyToolStripMenuItem
            // 
            this.newCompanyToolStripMenuItem.Name = "newCompanyToolStripMenuItem";
            this.newCompanyToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.newCompanyToolStripMenuItem.Text = "New Company";
            this.newCompanyToolStripMenuItem.Click += new System.EventHandler(this.newCompanyToolStripMenuItem_Click);
            // 
            // newAircraftTypeToolStripMenuItem
            // 
            this.newAircraftTypeToolStripMenuItem.Name = "newAircraftTypeToolStripMenuItem";
            this.newAircraftTypeToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.newAircraftTypeToolStripMenuItem.Text = "New Aircraft Type";
            this.newAircraftTypeToolStripMenuItem.Click += new System.EventHandler(this.newAircraftTypeToolStripMenuItem_Click);
            // 
            // addAircraftByClickToolStripMenuItem
            // 
            this.addAircraftByClickToolStripMenuItem.Name = "addAircraftByClickToolStripMenuItem";
            this.addAircraftByClickToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.addAircraftByClickToolStripMenuItem.Text = "New Aircraft by Click";
            this.addAircraftByClickToolStripMenuItem.Click += new System.EventHandler(this.addAircraftByClickToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aircraftListToolStripMenuItem1,
            this.companyListToolStripMenuItem,
            this.airCraftTypeListToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // aircraftListToolStripMenuItem1
            // 
            this.aircraftListToolStripMenuItem1.Name = "aircraftListToolStripMenuItem1";
            this.aircraftListToolStripMenuItem1.Size = new System.Drawing.Size(247, 34);
            this.aircraftListToolStripMenuItem1.Text = "Aircraft List";
            this.aircraftListToolStripMenuItem1.Click += new System.EventHandler(this.aircraftListToolStripMenuItem1_Click);
            // 
            // companyListToolStripMenuItem
            // 
            this.companyListToolStripMenuItem.Name = "companyListToolStripMenuItem";
            this.companyListToolStripMenuItem.Size = new System.Drawing.Size(247, 34);
            this.companyListToolStripMenuItem.Text = "Company List";
            this.companyListToolStripMenuItem.Click += new System.EventHandler(this.companyListToolStripMenuItem_Click);
            // 
            // airCraftTypeListToolStripMenuItem
            // 
            this.airCraftTypeListToolStripMenuItem.Name = "airCraftTypeListToolStripMenuItem";
            this.airCraftTypeListToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.airCraftTypeListToolStripMenuItem.Text = "Leaderboard";
            this.airCraftTypeListToolStripMenuItem.Click += new System.EventHandler(this.airCraftTypeListToolStripMenuItem_Click);
            // 
            // fileOptionsToolStripMenuItem
            // 
            this.fileOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromaAFileToolStripMenuItem,
            this.loadToAFileToolStripMenuItem1,
            this.saveVelocityChangesToolStripMenuItem,
            this.deleteCompanyToolStripMenuItem1,
            this.deleteAircraftTypeToolStripMenuItem1});
            this.fileOptionsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileOptionsToolStripMenuItem.Name = "fileOptionsToolStripMenuItem";
            this.fileOptionsToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.fileOptionsToolStripMenuItem.Text = "Options";
            // 
            // loadFromaAFileToolStripMenuItem
            // 
            this.loadFromaAFileToolStripMenuItem.Name = "loadFromaAFileToolStripMenuItem";
            this.loadFromaAFileToolStripMenuItem.Size = new System.Drawing.Size(290, 34);
            this.loadFromaAFileToolStripMenuItem.Text = "Load from a file";
            this.loadFromaAFileToolStripMenuItem.Click += new System.EventHandler(this.loadFromaAFileToolStripMenuItem_Click);
            // 
            // loadToAFileToolStripMenuItem1
            // 
            this.loadToAFileToolStripMenuItem1.Name = "loadToAFileToolStripMenuItem1";
            this.loadToAFileToolStripMenuItem1.Size = new System.Drawing.Size(290, 34);
            this.loadToAFileToolStripMenuItem1.Text = "Save to a file";
            this.loadToAFileToolStripMenuItem1.Click += new System.EventHandler(this.loadToAFileToolStripMenuItem1_Click);
            // 
            // saveVelocityChangesToolStripMenuItem
            // 
            this.saveVelocityChangesToolStripMenuItem.Name = "saveVelocityChangesToolStripMenuItem";
            this.saveVelocityChangesToolStripMenuItem.Size = new System.Drawing.Size(290, 34);
            this.saveVelocityChangesToolStripMenuItem.Text = "Save Velocity Changes";
            this.saveVelocityChangesToolStripMenuItem.Click += new System.EventHandler(this.saveVelocityChangesToolStripMenuItem_Click);
            // 
            // deleteCompanyToolStripMenuItem1
            // 
            this.deleteCompanyToolStripMenuItem1.Name = "deleteCompanyToolStripMenuItem1";
            this.deleteCompanyToolStripMenuItem1.Size = new System.Drawing.Size(290, 34);
            this.deleteCompanyToolStripMenuItem1.Text = "Delete Company";
            this.deleteCompanyToolStripMenuItem1.Click += new System.EventHandler(this.deleteCompanyToolStripMenuItem1_Click);
            // 
            // deleteAircraftTypeToolStripMenuItem1
            // 
            this.deleteAircraftTypeToolStripMenuItem1.Name = "deleteAircraftTypeToolStripMenuItem1";
            this.deleteAircraftTypeToolStripMenuItem1.Size = new System.Drawing.Size(290, 34);
            this.deleteAircraftTypeToolStripMenuItem1.Text = "Delete Aircraft Type";
            this.deleteAircraftTypeToolStripMenuItem1.Click += new System.EventHandler(this.deleteAircraftTypeToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(55, 29);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // reloj
            // 
            this.reloj.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // restart
            // 
            this.restart.BackColor = System.Drawing.Color.Black;
            this.restart.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restart.ForeColor = System.Drawing.Color.Lime;
            this.restart.Location = new System.Drawing.Point(184, 135);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(97, 32);
            this.restart.TabIndex = 4;
            this.restart.Text = "RESTART";
            this.restart.UseVisualStyleBackColor = false;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(50, 533);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 40);
            this.label5.TabIndex = 11;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Lime;
            this.label6.Location = new System.Drawing.Point(52, 508);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Time counter";
            // 
            // changeVelocity
            // 
            this.changeVelocity.BackColor = System.Drawing.Color.Black;
            this.changeVelocity.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeVelocity.ForeColor = System.Drawing.Color.Lime;
            this.changeVelocity.Location = new System.Drawing.Point(110, 385);
            this.changeVelocity.Name = "changeVelocity";
            this.changeVelocity.Size = new System.Drawing.Size(115, 57);
            this.changeVelocity.TabIndex = 8;
            this.changeVelocity.Text = "CHANGE VELOCITY";
            this.changeVelocity.UseVisualStyleBackColor = false;
            this.changeVelocity.Click += new System.EventHandler(this.changeVelocity_Click);
            // 
            // MoveBackBtn
            // 
            this.MoveBackBtn.BackColor = System.Drawing.Color.Black;
            this.MoveBackBtn.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveBackBtn.ForeColor = System.Drawing.Color.Lime;
            this.MoveBackBtn.Location = new System.Drawing.Point(56, 185);
            this.MoveBackBtn.Name = "MoveBackBtn";
            this.MoveBackBtn.Size = new System.Drawing.Size(97, 32);
            this.MoveBackBtn.TabIndex = 5;
            this.MoveBackBtn.Text = "MOVE BACK";
            this.MoveBackBtn.UseVisualStyleBackColor = false;
            this.MoveBackBtn.Click += new System.EventHandler(this.MoveBackBtn_Click);
            // 
            // AutoBackBtn
            // 
            this.AutoBackBtn.BackColor = System.Drawing.Color.Black;
            this.AutoBackBtn.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoBackBtn.ForeColor = System.Drawing.Color.Lime;
            this.AutoBackBtn.Location = new System.Drawing.Point(184, 185);
            this.AutoBackBtn.Name = "AutoBackBtn";
            this.AutoBackBtn.Size = new System.Drawing.Size(97, 41);
            this.AutoBackBtn.TabIndex = 6;
            this.AutoBackBtn.Text = "SIMULATE BACK";
            this.AutoBackBtn.UseVisualStyleBackColor = false;
            this.AutoBackBtn.Click += new System.EventHandler(this.AutoBackBtn_Click);
            // 
            // Reloj_Atrás
            // 
            this.Reloj_Atrás.Tick += new System.EventHandler(this.Reloj_Atrás_Tick);
            // 
            // Helpstop
            // 
            this.Helpstop.BackColor = System.Drawing.Color.Transparent;
            this.Helpstop.Font = new System.Drawing.Font("Arial Black", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Helpstop.ForeColor = System.Drawing.Color.Lime;
            this.Helpstop.Location = new System.Drawing.Point(24, 135);
            this.Helpstop.Name = "Helpstop";
            this.Helpstop.Size = new System.Drawing.Size(20, 23);
            this.Helpstop.TabIndex = 19;
            this.Helpstop.Text = "?";
            this.Helpstop.Click += new System.EventHandler(this.Helpstop_Click);
            // 
            // Helpmove
            // 
            this.Helpmove.BackColor = System.Drawing.Color.Transparent;
            this.Helpmove.Font = new System.Drawing.Font("Arial Black", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Helpmove.ForeColor = System.Drawing.Color.Lime;
            this.Helpmove.Location = new System.Drawing.Point(24, 84);
            this.Helpmove.Name = "Helpmove";
            this.Helpmove.Size = new System.Drawing.Size(20, 23);
            this.Helpmove.TabIndex = 20;
            this.Helpmove.Text = "?";
            this.Helpmove.Click += new System.EventHandler(this.Helpmove_Click);
            // 
            // Helpmoveratras
            // 
            this.Helpmoveratras.BackColor = System.Drawing.Color.Transparent;
            this.Helpmoveratras.Font = new System.Drawing.Font("Arial Black", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Helpmoveratras.ForeColor = System.Drawing.Color.Lime;
            this.Helpmoveratras.Location = new System.Drawing.Point(24, 187);
            this.Helpmoveratras.Name = "Helpmoveratras";
            this.Helpmoveratras.Size = new System.Drawing.Size(20, 23);
            this.Helpmoveratras.TabIndex = 21;
            this.Helpmoveratras.Text = "?";
            this.Helpmoveratras.Click += new System.EventHandler(this.Helpmoveratras_Click);
            // 
            // Helpsimulate
            // 
            this.Helpsimulate.BackColor = System.Drawing.Color.Transparent;
            this.Helpsimulate.Font = new System.Drawing.Font("Arial Black", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Helpsimulate.ForeColor = System.Drawing.Color.Lime;
            this.Helpsimulate.Location = new System.Drawing.Point(287, 84);
            this.Helpsimulate.Name = "Helpsimulate";
            this.Helpsimulate.Size = new System.Drawing.Size(20, 23);
            this.Helpsimulate.TabIndex = 22;
            this.Helpsimulate.Text = "?";
            this.Helpsimulate.Click += new System.EventHandler(this.Helpsimulate_Click);
            // 
            // Helprestart
            // 
            this.Helprestart.BackColor = System.Drawing.Color.Transparent;
            this.Helprestart.Font = new System.Drawing.Font("Arial Black", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Helprestart.ForeColor = System.Drawing.Color.Lime;
            this.Helprestart.Location = new System.Drawing.Point(287, 137);
            this.Helprestart.Name = "Helprestart";
            this.Helprestart.Size = new System.Drawing.Size(20, 23);
            this.Helprestart.TabIndex = 23;
            this.Helprestart.Text = "?";
            this.Helprestart.Click += new System.EventHandler(this.Helprestart_Click);
            // 
            // Helpsimulateatras
            // 
            this.Helpsimulateatras.BackColor = System.Drawing.Color.Transparent;
            this.Helpsimulateatras.Font = new System.Drawing.Font("Arial Black", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Helpsimulateatras.ForeColor = System.Drawing.Color.Lime;
            this.Helpsimulateatras.Location = new System.Drawing.Point(287, 190);
            this.Helpsimulateatras.Name = "Helpsimulateatras";
            this.Helpsimulateatras.Size = new System.Drawing.Size(20, 23);
            this.Helpsimulateatras.TabIndex = 24;
            this.Helpsimulateatras.Text = "?";
            this.Helpsimulateatras.Click += new System.EventHandler(this.Helpsimulateatras_Click);
            // 
            // Helpchangevel
            // 
            this.Helpchangevel.BackColor = System.Drawing.Color.Transparent;
            this.Helpchangevel.Font = new System.Drawing.Font("Arial Black", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Helpchangevel.ForeColor = System.Drawing.Color.Lime;
            this.Helpchangevel.Location = new System.Drawing.Point(231, 399);
            this.Helpchangevel.Name = "Helpchangevel";
            this.Helpchangevel.Size = new System.Drawing.Size(20, 23);
            this.Helpchangevel.TabIndex = 25;
            this.Helpchangevel.Text = "?";
            this.Helpchangevel.Click += new System.EventHandler(this.Helpchangevel_Click);
            // 
            // Helptimer
            // 
            this.Helptimer.BackColor = System.Drawing.Color.Transparent;
            this.Helptimer.Font = new System.Drawing.Font("Arial Black", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Helptimer.ForeColor = System.Drawing.Color.Lime;
            this.Helptimer.Location = new System.Drawing.Point(225, 542);
            this.Helptimer.Name = "Helptimer";
            this.Helptimer.Size = new System.Drawing.Size(20, 23);
            this.Helptimer.TabIndex = 26;
            this.Helptimer.Text = "?";
            this.Helptimer.Click += new System.EventHandler(this.Helptimer_Click);
            // 
            // HelpFileOptions
            // 
            this.HelpFileOptions.AutoSize = true;
            this.HelpFileOptions.BackColor = System.Drawing.Color.Transparent;
            this.HelpFileOptions.Font = new System.Drawing.Font("Arial Black", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpFileOptions.ForeColor = System.Drawing.Color.Lime;
            this.HelpFileOptions.Location = new System.Drawing.Point(133, 33);
            this.HelpFileOptions.Name = "HelpFileOptions";
            this.HelpFileOptions.Size = new System.Drawing.Size(20, 23);
            this.HelpFileOptions.TabIndex = 27;
            this.HelpFileOptions.Text = "?";
            this.HelpFileOptions.Click += new System.EventHandler(this.HelpFileOptions_Click);
            // 
            // ResetBtn
            // 
            this.ResetBtn.BackColor = System.Drawing.Color.Black;
            this.ResetBtn.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetBtn.ForeColor = System.Drawing.Color.Lime;
            this.ResetBtn.Location = new System.Drawing.Point(56, 235);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(97, 32);
            this.ResetBtn.TabIndex = 7;
            this.ResetBtn.Text = "RESET";
            this.ResetBtn.UseVisualStyleBackColor = false;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // HelpReset
            // 
            this.HelpReset.BackColor = System.Drawing.Color.Transparent;
            this.HelpReset.Font = new System.Drawing.Font("Arial Black", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpReset.ForeColor = System.Drawing.Color.Lime;
            this.HelpReset.Location = new System.Drawing.Point(30, 240);
            this.HelpReset.Name = "HelpReset";
            this.HelpReset.Size = new System.Drawing.Size(20, 23);
            this.HelpReset.TabIndex = 29;
            this.HelpReset.Text = "?";
            this.HelpReset.Click += new System.EventHandler(this.HelpReset_Click);
            // 
            // posicionRaton
            // 
            this.posicionRaton.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posicionRaton.ForeColor = System.Drawing.Color.Lime;
            this.posicionRaton.Location = new System.Drawing.Point(53, 482);
            this.posicionRaton.Name = "posicionRaton";
            this.posicionRaton.Size = new System.Drawing.Size(190, 26);
            this.posicionRaton.TabIndex = 30;
            // 
            // ConflictLbl
            // 
            this.ConflictLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConflictLbl.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConflictLbl.ForeColor = System.Drawing.Color.Lime;
            this.ConflictLbl.Location = new System.Drawing.Point(78, 445);
            this.ConflictLbl.Name = "ConflictLbl";
            this.ConflictLbl.Size = new System.Drawing.Size(173, 26);
            this.ConflictLbl.TabIndex = 31;
            this.ConflictLbl.Text = "No Conflict";
            this.ConflictLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Helppanel
            // 
            this.Helppanel.AutoSize = true;
            this.Helppanel.Font = new System.Drawing.Font("Arial Black", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Helppanel.Location = new System.Drawing.Point(772, 517);
            this.Helppanel.Name = "Helppanel";
            this.Helppanel.Size = new System.Drawing.Size(20, 23);
            this.Helppanel.TabIndex = 27;
            this.Helppanel.Text = "?";
            this.Helppanel.Click += new System.EventHandler(this.Helppanel_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Black;
            this.panel.Controls.Add(this.Helppanel);
            this.panel.ForeColor = System.Drawing.Color.Lime;
            this.panel.Location = new System.Drawing.Point(370, 50);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(801, 551);
            this.panel.TabIndex = 4;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_MouseClick);
            this.panel.MouseLeave += new System.EventHandler(this.panel_MouseLeave);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Lime;
            this.checkBox1.Location = new System.Drawing.Point(34, 570);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(146, 30);
            this.checkBox1.TabIndex = 33;
            this.checkBox1.Text = "MUTE MUSIC";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Score
            // 
            this.Score.BackColor = System.Drawing.Color.Transparent;
            this.Score.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.ForeColor = System.Drawing.Color.Lime;
            this.Score.Location = new System.Drawing.Point(147, 345);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(104, 26);
            this.Score.TabIndex = 34;
            this.Score.Text = "0";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(24, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 26);
            this.label7.TabIndex = 35;
            this.label7.Text = "Total Score";
            // 
            // TotalScore
            // 
            this.TotalScore.BackColor = System.Drawing.Color.Transparent;
            this.TotalScore.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalScore.ForeColor = System.Drawing.Color.Lime;
            this.TotalScore.Location = new System.Drawing.Point(147, 306);
            this.TotalScore.Name = "TotalScore";
            this.TotalScore.Size = new System.Drawing.Size(104, 26);
            this.TotalScore.TabIndex = 36;
            this.TotalScore.Text = "0";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Lime;
            this.label9.Location = new System.Drawing.Point(24, 345);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 26);
            this.label9.TabIndex = 37;
            this.label9.Text = "Score";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1182, 612);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TotalScore);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ConflictLbl);
            this.Controls.Add(this.posicionRaton);
            this.Controls.Add(this.HelpReset);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.HelpFileOptions);
            this.Controls.Add(this.Helptimer);
            this.Controls.Add(this.Helpchangevel);
            this.Controls.Add(this.Helpsimulateatras);
            this.Controls.Add(this.Helprestart);
            this.Controls.Add(this.Helpsimulate);
            this.Controls.Add(this.Helpmoveratras);
            this.Controls.Add(this.Helpmove);
            this.Controls.Add(this.Helpstop);
            this.Controls.Add(this.AutoBackBtn);
            this.Controls.Add(this.MoveBackBtn);
            this.Controls.Add(this.changeVelocity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.auto);
            this.Controls.Add(this.mover);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button mover;
        private System.Windows.Forms.Button auto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAircraftToolStripMenuItem;
        private System.Windows.Forms.Timer reloj;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button changeVelocity;
        private System.Windows.Forms.Button MoveBackBtn;
        private System.Windows.Forms.Button AutoBackBtn;
        private System.Windows.Forms.Timer Reloj_Atrás;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromaAFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToAFileToolStripMenuItem1;
        private System.Windows.Forms.Label Helpstop;
        private System.Windows.Forms.Label Helpmove;
        private System.Windows.Forms.Label Helpmoveratras;
        private System.Windows.Forms.Label Helpsimulate;
        private System.Windows.Forms.Label Helprestart;
        private System.Windows.Forms.Label Helpsimulateatras;
        private System.Windows.Forms.Label Helpchangevel;
        private System.Windows.Forms.Label Helptimer;
        private System.Windows.Forms.Label HelpFileOptions;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Label HelpReset;
        private System.Windows.Forms.Label posicionRaton;
        private System.Windows.Forms.ToolStripMenuItem addAircraftByClickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCompanyToolStripMenuItem;
        private System.Windows.Forms.Label ConflictLbl;
        private System.Windows.Forms.ToolStripMenuItem saveVelocityChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAircraftTypeToolStripMenuItem;
        private System.Windows.Forms.Label Helppanel;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aircraftListToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem companyListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem airCraftTypeListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCompanyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteAircraftTypeToolStripMenuItem1;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label TotalScore;
        private System.Windows.Forms.Label label9;
    }
}

