namespace TSDN.SnakeGame
{
    partial class frmSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPixelSize = new System.Windows.Forms.Label();
            this.lblXwidth = new System.Windows.Forms.Label();
            this.numPixel = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.lblYhight = new System.Windows.Forms.Label();
            this.grboxPlayground = new System.Windows.Forms.GroupBox();
            this.lblTCPport = new System.Windows.Forms.Label();
            this.lblHostname = new System.Windows.Forms.Label();
            this.radioStandalone = new System.Windows.Forms.RadioButton();
            this.radioServer = new System.Windows.Forms.RadioButton();
            this.radioClient = new System.Windows.Forms.RadioButton();
            this.grboxGameType = new System.Windows.Forms.GroupBox();
            this.grboxAdvancedOptions = new System.Windows.Forms.GroupBox();
            this.chkboxRespawn = new System.Windows.Forms.CheckBox();
            this.grboxSnakeFood = new System.Windows.Forms.GroupBox();
            this.numFoodCount = new System.Windows.Forms.NumericUpDown();
            this.numFoodMax = new System.Windows.Forms.NumericUpDown();
            this.numFoodMin = new System.Windows.Forms.NumericUpDown();
            this.lblFoodCount = new System.Windows.Forms.Label();
            this.lblFoodMinSize = new System.Windows.Forms.Label();
            this.lblFoodMaxSize = new System.Windows.Forms.Label();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.grboxNetworkSettings = new System.Windows.Forms.GroupBox();
            this.numTCPport = new System.Windows.Forms.NumericUpDown();
            this.textHostname = new System.Windows.Forms.TextBox();
            this.grboxPlayers = new System.Windows.Forms.GroupBox();
            this.chkboxPlayerIJKL = new System.Windows.Forms.CheckBox();
            this.chkboxPlayer8456 = new System.Windows.Forms.CheckBox();
            this.chkboxPlayerWASD = new System.Windows.Forms.CheckBox();
            this.chkboxPlayerArrow = new System.Windows.Forms.CheckBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.grboxGameplay = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPixel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            this.grboxPlayground.SuspendLayout();
            this.grboxGameType.SuspendLayout();
            this.grboxAdvancedOptions.SuspendLayout();
            this.grboxSnakeFood.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFoodCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFoodMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFoodMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            this.grboxNetworkSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTCPport)).BeginInit();
            this.grboxPlayers.SuspendLayout();
            this.grboxGameplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPixelSize
            // 
            this.lblPixelSize.AutoSize = true;
            this.lblPixelSize.Location = new System.Drawing.Point(6, 33);
            this.lblPixelSize.Name = "lblPixelSize";
            this.lblPixelSize.Size = new System.Drawing.Size(50, 13);
            this.lblPixelSize.TabIndex = 2;
            this.lblPixelSize.Text = "Pixel size";
            // 
            // lblXwidth
            // 
            this.lblXwidth.AutoSize = true;
            this.lblXwidth.Location = new System.Drawing.Point(6, 59);
            this.lblXwidth.Name = "lblXwidth";
            this.lblXwidth.Size = new System.Drawing.Size(42, 13);
            this.lblXwidth.TabIndex = 3;
            this.lblXwidth.Text = "X width";
            // 
            // numPixel
            // 
            this.numPixel.Location = new System.Drawing.Point(62, 26);
            this.numPixel.Name = "numPixel";
            this.numPixel.Size = new System.Drawing.Size(76, 20);
            this.numPixel.TabIndex = 4;
            this.numPixel.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numX
            // 
            this.numX.Location = new System.Drawing.Point(62, 52);
            this.numX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(76, 20);
            this.numX.TabIndex = 5;
            this.numX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numY
            // 
            this.numY.Location = new System.Drawing.Point(62, 78);
            this.numY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(76, 20);
            this.numY.TabIndex = 6;
            this.numY.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblYhight
            // 
            this.lblYhight.AutoSize = true;
            this.lblYhight.Location = new System.Drawing.Point(6, 85);
            this.lblYhight.Name = "lblYhight";
            this.lblYhight.Size = new System.Drawing.Size(40, 13);
            this.lblYhight.TabIndex = 7;
            this.lblYhight.Text = "Y hight";
            // 
            // grboxPlayground
            // 
            this.grboxPlayground.Controls.Add(this.numPixel);
            this.grboxPlayground.Controls.Add(this.lblPixelSize);
            this.grboxPlayground.Controls.Add(this.lblXwidth);
            this.grboxPlayground.Controls.Add(this.lblYhight);
            this.grboxPlayground.Controls.Add(this.numX);
            this.grboxPlayground.Controls.Add(this.numY);
            this.grboxPlayground.Location = new System.Drawing.Point(6, 19);
            this.grboxPlayground.Name = "grboxPlayground";
            this.grboxPlayground.Size = new System.Drawing.Size(147, 111);
            this.grboxPlayground.TabIndex = 8;
            this.grboxPlayground.TabStop = false;
            this.grboxPlayground.Text = "Playground";
            // 
            // lblTCPport
            // 
            this.lblTCPport.AutoSize = true;
            this.lblTCPport.Location = new System.Drawing.Point(7, 33);
            this.lblTCPport.Name = "lblTCPport";
            this.lblTCPport.Size = new System.Drawing.Size(49, 13);
            this.lblTCPport.TabIndex = 9;
            this.lblTCPport.Text = "TCP port";
            // 
            // lblHostname
            // 
            this.lblHostname.AutoSize = true;
            this.lblHostname.Location = new System.Drawing.Point(114, 150);
            this.lblHostname.Name = "lblHostname";
            this.lblHostname.Size = new System.Drawing.Size(107, 13);
            this.lblHostname.TabIndex = 10;
            this.lblHostname.Text = "Servers IP/hostname";
            // 
            // radioStandalone
            // 
            this.radioStandalone.AutoSize = true;
            this.radioStandalone.Checked = true;
            this.radioStandalone.Location = new System.Drawing.Point(6, 19);
            this.radioStandalone.Name = "radioStandalone";
            this.radioStandalone.Size = new System.Drawing.Size(79, 17);
            this.radioStandalone.TabIndex = 11;
            this.radioStandalone.TabStop = true;
            this.radioStandalone.Text = "Standalone";
            this.radioStandalone.UseVisualStyleBackColor = true;
            this.radioStandalone.CheckedChanged += new System.EventHandler(this.radioGameType_CheckedChanged);
            // 
            // radioServer
            // 
            this.radioServer.AutoSize = true;
            this.radioServer.Location = new System.Drawing.Point(6, 42);
            this.radioServer.Name = "radioServer";
            this.radioServer.Size = new System.Drawing.Size(56, 17);
            this.radioServer.TabIndex = 12;
            this.radioServer.Text = "Server";
            this.radioServer.UseVisualStyleBackColor = true;
            this.radioServer.CheckedChanged += new System.EventHandler(this.radioGameType_CheckedChanged);
            // 
            // radioClient
            // 
            this.radioClient.AutoSize = true;
            this.radioClient.Location = new System.Drawing.Point(6, 65);
            this.radioClient.Name = "radioClient";
            this.radioClient.Size = new System.Drawing.Size(51, 17);
            this.radioClient.TabIndex = 13;
            this.radioClient.Text = "Client";
            this.radioClient.UseVisualStyleBackColor = true;
            this.radioClient.CheckedChanged += new System.EventHandler(this.radioGameType_CheckedChanged);
            // 
            // grboxGameType
            // 
            this.grboxGameType.Controls.Add(this.radioStandalone);
            this.grboxGameType.Controls.Add(this.radioClient);
            this.grboxGameType.Controls.Add(this.radioServer);
            this.grboxGameType.Location = new System.Drawing.Point(12, 12);
            this.grboxGameType.Name = "grboxGameType";
            this.grboxGameType.Size = new System.Drawing.Size(91, 89);
            this.grboxGameType.TabIndex = 14;
            this.grboxGameType.TabStop = false;
            this.grboxGameType.Text = "Game type";
            // 
            // grboxAdvancedOptions
            // 
            this.grboxAdvancedOptions.Controls.Add(this.grboxGameplay);
            this.grboxAdvancedOptions.Controls.Add(this.grboxSnakeFood);
            this.grboxAdvancedOptions.Controls.Add(this.grboxNetworkSettings);
            this.grboxAdvancedOptions.Controls.Add(this.grboxPlayground);
            this.grboxAdvancedOptions.Location = new System.Drawing.Point(12, 183);
            this.grboxAdvancedOptions.Name = "grboxAdvancedOptions";
            this.grboxAdvancedOptions.Size = new System.Drawing.Size(318, 230);
            this.grboxAdvancedOptions.TabIndex = 15;
            this.grboxAdvancedOptions.TabStop = false;
            this.grboxAdvancedOptions.Text = "Advanced options";
            // 
            // chkboxRespawn
            // 
            this.chkboxRespawn.AutoSize = true;
            this.chkboxRespawn.Checked = true;
            this.chkboxRespawn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxRespawn.Location = new System.Drawing.Point(9, 19);
            this.chkboxRespawn.Name = "chkboxRespawn";
            this.chkboxRespawn.Size = new System.Drawing.Size(71, 17);
            this.chkboxRespawn.TabIndex = 20;
            this.chkboxRespawn.Text = "Respawn";
            this.chkboxRespawn.UseVisualStyleBackColor = true;
            // 
            // grboxSnakeFood
            // 
            this.grboxSnakeFood.Controls.Add(this.numFoodCount);
            this.grboxSnakeFood.Controls.Add(this.numFoodMax);
            this.grboxSnakeFood.Controls.Add(this.numFoodMin);
            this.grboxSnakeFood.Controls.Add(this.lblFoodCount);
            this.grboxSnakeFood.Controls.Add(this.lblFoodMinSize);
            this.grboxSnakeFood.Controls.Add(this.lblFoodMaxSize);
            this.grboxSnakeFood.Location = new System.Drawing.Point(159, 19);
            this.grboxSnakeFood.Name = "grboxSnakeFood";
            this.grboxSnakeFood.Size = new System.Drawing.Size(147, 111);
            this.grboxSnakeFood.TabIndex = 19;
            this.grboxSnakeFood.TabStop = false;
            this.grboxSnakeFood.Text = "Snake food";
            // 
            // numFoodCount
            // 
            this.numFoodCount.Location = new System.Drawing.Point(74, 78);
            this.numFoodCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFoodCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFoodCount.Name = "numFoodCount";
            this.numFoodCount.Size = new System.Drawing.Size(60, 20);
            this.numFoodCount.TabIndex = 25;
            this.numFoodCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numFoodMax
            // 
            this.numFoodMax.Location = new System.Drawing.Point(74, 52);
            this.numFoodMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFoodMax.Name = "numFoodMax";
            this.numFoodMax.Size = new System.Drawing.Size(60, 20);
            this.numFoodMax.TabIndex = 24;
            this.numFoodMax.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numFoodMax.ValueChanged += new System.EventHandler(this.numFoodMax_ValueChanged);
            // 
            // numFoodMin
            // 
            this.numFoodMin.Location = new System.Drawing.Point(74, 26);
            this.numFoodMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFoodMin.Name = "numFoodMin";
            this.numFoodMin.Size = new System.Drawing.Size(60, 20);
            this.numFoodMin.TabIndex = 23;
            this.numFoodMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFoodMin.ValueChanged += new System.EventHandler(this.numFoodMin_ValueChanged);
            // 
            // lblFoodCount
            // 
            this.lblFoodCount.AutoSize = true;
            this.lblFoodCount.Location = new System.Drawing.Point(5, 85);
            this.lblFoodCount.Name = "lblFoodCount";
            this.lblFoodCount.Size = new System.Drawing.Size(62, 13);
            this.lblFoodCount.TabIndex = 22;
            this.lblFoodCount.Text = "Food Count";
            // 
            // lblFoodMinSize
            // 
            this.lblFoodMinSize.AutoSize = true;
            this.lblFoodMinSize.Location = new System.Drawing.Point(5, 33);
            this.lblFoodMinSize.Name = "lblFoodMinSize";
            this.lblFoodMinSize.Size = new System.Drawing.Size(45, 13);
            this.lblFoodMinSize.TabIndex = 20;
            this.lblFoodMinSize.Text = "Min size";
            // 
            // lblFoodMaxSize
            // 
            this.lblFoodMaxSize.AutoSize = true;
            this.lblFoodMaxSize.Location = new System.Drawing.Point(5, 59);
            this.lblFoodMaxSize.Name = "lblFoodMaxSize";
            this.lblFoodMaxSize.Size = new System.Drawing.Size(48, 13);
            this.lblFoodMaxSize.TabIndex = 21;
            this.lblFoodMaxSize.Text = "Max size";
            // 
            // numSpeed
            // 
            this.numSpeed.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numSpeed.Location = new System.Drawing.Point(62, 45);
            this.numSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(75, 20);
            this.numSpeed.TabIndex = 18;
            this.numSpeed.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(6, 52);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(38, 13);
            this.lblSpeed.TabIndex = 17;
            this.lblSpeed.Text = "Speed";
            // 
            // grboxNetworkSettings
            // 
            this.grboxNetworkSettings.Controls.Add(this.numTCPport);
            this.grboxNetworkSettings.Controls.Add(this.lblTCPport);
            this.grboxNetworkSettings.Location = new System.Drawing.Point(159, 136);
            this.grboxNetworkSettings.Name = "grboxNetworkSettings";
            this.grboxNetworkSettings.Size = new System.Drawing.Size(147, 60);
            this.grboxNetworkSettings.TabIndex = 16;
            this.grboxNetworkSettings.TabStop = false;
            this.grboxNetworkSettings.Text = "Network Settings";
            // 
            // numTCPport
            // 
            this.numTCPport.Location = new System.Drawing.Point(62, 26);
            this.numTCPport.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.numTCPport.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTCPport.Name = "numTCPport";
            this.numTCPport.Size = new System.Drawing.Size(76, 20);
            this.numTCPport.TabIndex = 10;
            this.numTCPport.Value = new decimal(new int[] {
            8005,
            0,
            0,
            0});
            // 
            // textHostname
            // 
            this.textHostname.Location = new System.Drawing.Point(230, 147);
            this.textHostname.Name = "textHostname";
            this.textHostname.Size = new System.Drawing.Size(100, 20);
            this.textHostname.TabIndex = 17;
            this.textHostname.Text = "127.0.0.1";
            // 
            // grboxPlayers
            // 
            this.grboxPlayers.Controls.Add(this.chkboxPlayerIJKL);
            this.grboxPlayers.Controls.Add(this.chkboxPlayer8456);
            this.grboxPlayers.Controls.Add(this.chkboxPlayerWASD);
            this.grboxPlayers.Controls.Add(this.chkboxPlayerArrow);
            this.grboxPlayers.Location = new System.Drawing.Point(109, 12);
            this.grboxPlayers.Name = "grboxPlayers";
            this.grboxPlayers.Size = new System.Drawing.Size(221, 112);
            this.grboxPlayers.TabIndex = 18;
            this.grboxPlayers.TabStop = false;
            this.grboxPlayers.Text = "Players on this computer";
            // 
            // chkboxPlayerIJKL
            // 
            this.chkboxPlayerIJKL.AutoSize = true;
            this.chkboxPlayerIJKL.Location = new System.Drawing.Point(7, 88);
            this.chkboxPlayerIJKL.Name = "chkboxPlayerIJKL";
            this.chkboxPlayerIJKL.Size = new System.Drawing.Size(150, 17);
            this.chkboxPlayerIJKL.TabIndex = 3;
            this.chkboxPlayerIJKL.Text = "Player controlled with IJKL";
            this.chkboxPlayerIJKL.UseVisualStyleBackColor = true;
            // 
            // chkboxPlayer8456
            // 
            this.chkboxPlayer8456.AutoSize = true;
            this.chkboxPlayer8456.Location = new System.Drawing.Point(7, 65);
            this.chkboxPlayer8456.Name = "chkboxPlayer8456";
            this.chkboxPlayer8456.Size = new System.Drawing.Size(153, 17);
            this.chkboxPlayer8456.TabIndex = 2;
            this.chkboxPlayer8456.Text = "Player controlled with 8456";
            this.chkboxPlayer8456.UseVisualStyleBackColor = true;
            // 
            // chkboxPlayerWASD
            // 
            this.chkboxPlayerWASD.AutoSize = true;
            this.chkboxPlayerWASD.Location = new System.Drawing.Point(7, 42);
            this.chkboxPlayerWASD.Name = "chkboxPlayerWASD";
            this.chkboxPlayerWASD.Size = new System.Drawing.Size(162, 17);
            this.chkboxPlayerWASD.TabIndex = 1;
            this.chkboxPlayerWASD.Text = "Player controlled with WASD";
            this.chkboxPlayerWASD.UseVisualStyleBackColor = true;
            // 
            // chkboxPlayerArrow
            // 
            this.chkboxPlayerArrow.AutoSize = true;
            this.chkboxPlayerArrow.Checked = true;
            this.chkboxPlayerArrow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxPlayerArrow.Location = new System.Drawing.Point(7, 19);
            this.chkboxPlayerArrow.Name = "chkboxPlayerArrow";
            this.chkboxPlayerArrow.Size = new System.Drawing.Size(181, 17);
            this.chkboxPlayerArrow.TabIndex = 0;
            this.chkboxPlayerArrow.Text = "Player controlled with Arrow keys";
            this.chkboxPlayerArrow.UseVisualStyleBackColor = true;
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(12, 145);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(75, 23);
            this.btnStartGame.TabIndex = 19;
            this.btnStartGame.Text = "Start game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // grboxGameplay
            // 
            this.grboxGameplay.Controls.Add(this.chkboxRespawn);
            this.grboxGameplay.Controls.Add(this.lblSpeed);
            this.grboxGameplay.Controls.Add(this.numSpeed);
            this.grboxGameplay.Location = new System.Drawing.Point(6, 136);
            this.grboxGameplay.Name = "grboxGameplay";
            this.grboxGameplay.Size = new System.Drawing.Size(147, 80);
            this.grboxGameplay.TabIndex = 21;
            this.grboxGameplay.TabStop = false;
            this.grboxGameplay.Text = "Gameplay";
            // 
            // frmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 424);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.grboxPlayers);
            this.Controls.Add(this.textHostname);
            this.Controls.Add(this.grboxAdvancedOptions);
            this.Controls.Add(this.grboxGameType);
            this.Controls.Add(this.lblHostname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmSetup";
            this.Text = "SnakeGame setup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSetup_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.numPixel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            this.grboxPlayground.ResumeLayout(false);
            this.grboxPlayground.PerformLayout();
            this.grboxGameType.ResumeLayout(false);
            this.grboxGameType.PerformLayout();
            this.grboxAdvancedOptions.ResumeLayout(false);
            this.grboxSnakeFood.ResumeLayout(false);
            this.grboxSnakeFood.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFoodCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFoodMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFoodMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            this.grboxNetworkSettings.ResumeLayout(false);
            this.grboxNetworkSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTCPport)).EndInit();
            this.grboxPlayers.ResumeLayout(false);
            this.grboxPlayers.PerformLayout();
            this.grboxGameplay.ResumeLayout(false);
            this.grboxGameplay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPixelSize;
        private System.Windows.Forms.Label lblXwidth;
        private System.Windows.Forms.NumericUpDown numPixel;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.Label lblYhight;
        private System.Windows.Forms.GroupBox grboxPlayground;
        private System.Windows.Forms.Label lblTCPport;
        private System.Windows.Forms.Label lblHostname;
        private System.Windows.Forms.RadioButton radioStandalone;
        private System.Windows.Forms.RadioButton radioServer;
        private System.Windows.Forms.RadioButton radioClient;
        private System.Windows.Forms.GroupBox grboxGameType;
        private System.Windows.Forms.GroupBox grboxAdvancedOptions;
        private System.Windows.Forms.GroupBox grboxNetworkSettings;
        private System.Windows.Forms.NumericUpDown numTCPport;
        private System.Windows.Forms.TextBox textHostname;
        private System.Windows.Forms.GroupBox grboxPlayers;
        private System.Windows.Forms.CheckBox chkboxPlayerWASD;
        private System.Windows.Forms.CheckBox chkboxPlayerArrow;
        private System.Windows.Forms.CheckBox chkboxPlayerIJKL;
        private System.Windows.Forms.CheckBox chkboxPlayer8456;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.NumericUpDown numSpeed;
        private System.Windows.Forms.GroupBox grboxSnakeFood;
        private System.Windows.Forms.CheckBox chkboxRespawn;
        private System.Windows.Forms.NumericUpDown numFoodMin;
        private System.Windows.Forms.Label lblFoodCount;
        private System.Windows.Forms.Label lblFoodMinSize;
        private System.Windows.Forms.Label lblFoodMaxSize;
        private System.Windows.Forms.NumericUpDown numFoodCount;
        private System.Windows.Forms.NumericUpDown numFoodMax;
        private System.Windows.Forms.GroupBox grboxGameplay;



    }
}

