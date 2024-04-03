
namespace Snake_Game
{
    partial class Form1
    { 
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.startButton = new System.Windows.Forms.Button();
            this.snapButton = new System.Windows.Forms.Button();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.txtScore = new System.Windows.Forms.Label();
            this.txtHighScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьНовуюИгруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.паузаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияОИгреToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameOverLabel = new System.Windows.Forms.Label();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.durationOfGameLabel = new System.Windows.Forms.Label();
            this.durationOfGameTimer = new System.Windows.Forms.Timer(this.components);
            this.pauseLabel = new System.Windows.Forms.Label();
            this.boosterLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBoxBarriersSettings = new System.Windows.Forms.GroupBox();
            this.rbtnB2 = new System.Windows.Forms.RadioButton();
            this.rbtnB1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.groupBoxBarriersSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.SkyBlue;
            resources.ApplyResources(this.startButton, "startButton");
            this.startButton.Name = "startButton";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartGame);
            // 
            // snapButton
            // 
            this.snapButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            resources.ApplyResources(this.snapButton, "snapButton");
            this.snapButton.Name = "snapButton";
            this.snapButton.UseVisualStyleBackColor = false;
            this.snapButton.Click += new System.EventHandler(this.TakeSnapShot);
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.picCanvas, "picCanvas");
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGraphics);
            // 
            // txtScore
            // 
            resources.ApplyResources(this.txtScore, "txtScore");
            this.txtScore.Name = "txtScore";
            // 
            // txtHighScore
            // 
            resources.ApplyResources(this.txtHighScore, "txtHighScore");
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.UseMnemonic = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 60;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.информацияОИгреToolStripMenuItem,
            this.управлениеToolStripMenuItem,
            this.выходToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.начатьНовуюИгруToolStripMenuItem,
            this.паузаToolStripMenuItem,
            this.оПрограммеToolStripMenuItem1});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            resources.ApplyResources(this.менюToolStripMenuItem, "менюToolStripMenuItem");
            // 
            // начатьНовуюИгруToolStripMenuItem
            // 
            this.начатьНовуюИгруToolStripMenuItem.Name = "начатьНовуюИгруToolStripMenuItem";
            resources.ApplyResources(this.начатьНовуюИгруToolStripMenuItem, "начатьНовуюИгруToolStripMenuItem");
            this.начатьНовуюИгруToolStripMenuItem.Click += new System.EventHandler(this.начатьНовуюИгруToolStripMenuItem_Click);
            // 
            // паузаToolStripMenuItem
            // 
            this.паузаToolStripMenuItem.Name = "паузаToolStripMenuItem";
            resources.ApplyResources(this.паузаToolStripMenuItem, "паузаToolStripMenuItem");
            this.паузаToolStripMenuItem.Click += new System.EventHandler(this.паузаToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem1
            // 
            this.оПрограммеToolStripMenuItem1.Name = "оПрограммеToolStripMenuItem1";
            resources.ApplyResources(this.оПрограммеToolStripMenuItem1, "оПрограммеToolStripMenuItem1");
            this.оПрограммеToolStripMenuItem1.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem1_Click);
            // 
            // информацияОИгреToolStripMenuItem
            // 
            this.информацияОИгреToolStripMenuItem.Name = "информацияОИгреToolStripMenuItem";
            resources.ApplyResources(this.информацияОИгреToolStripMenuItem, "информацияОИгреToolStripMenuItem");
            this.информацияОИгреToolStripMenuItem.Click += new System.EventHandler(this.информацияОИгреToolStripMenuItem_Click);
            // 
            // управлениеToolStripMenuItem
            // 
            this.управлениеToolStripMenuItem.Name = "управлениеToolStripMenuItem";
            resources.ApplyResources(this.управлениеToolStripMenuItem, "управлениеToolStripMenuItem");
            this.управлениеToolStripMenuItem.Click += new System.EventHandler(this.управлениеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            resources.ApplyResources(this.выходToolStripMenuItem, "выходToolStripMenuItem");
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // GameOverLabel
            // 
            resources.ApplyResources(this.GameOverLabel, "GameOverLabel");
            this.GameOverLabel.ForeColor = System.Drawing.Color.Maroon;
            this.GameOverLabel.Name = "GameOverLabel";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.radioButton3);
            this.groupBoxSettings.Controls.Add(this.radioButton2);
            this.groupBoxSettings.Controls.Add(this.radioButton1);
            resources.ApplyResources(this.groupBoxSettings, "groupBoxSettings");
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.TabStop = false;
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // durationOfGameLabel
            // 
            resources.ApplyResources(this.durationOfGameLabel, "durationOfGameLabel");
            this.durationOfGameLabel.Name = "durationOfGameLabel";
            // 
            // durationOfGameTimer
            // 
            this.durationOfGameTimer.Interval = 1000;
            this.durationOfGameTimer.Tick += new System.EventHandler(this.durationGameEvent);
            // 
            // pauseLabel
            // 
            resources.ApplyResources(this.pauseLabel, "pauseLabel");
            this.pauseLabel.ForeColor = System.Drawing.Color.Maroon;
            this.pauseLabel.Name = "pauseLabel";
            // 
            // boosterLabel
            // 
            resources.ApplyResources(this.boosterLabel, "boosterLabel");
            this.boosterLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.boosterLabel.Name = "boosterLabel";
            // 
            // groupBoxBarriersSettings
            // 
            this.groupBoxBarriersSettings.Controls.Add(this.rbtnB2);
            this.groupBoxBarriersSettings.Controls.Add(this.rbtnB1);
            resources.ApplyResources(this.groupBoxBarriersSettings, "groupBoxBarriersSettings");
            this.groupBoxBarriersSettings.Name = "groupBoxBarriersSettings";
            this.groupBoxBarriersSettings.TabStop = false;
            // 
            // rbtnB2
            // 
            resources.ApplyResources(this.rbtnB2, "rbtnB2");
            this.rbtnB2.Name = "rbtnB2";
            this.rbtnB2.TabStop = true;
            this.rbtnB2.UseVisualStyleBackColor = true;
            // 
            // rbtnB1
            // 
            resources.ApplyResources(this.rbtnB1, "rbtnB1");
            this.rbtnB1.Name = "rbtnB1";
            this.rbtnB1.TabStop = true;
            this.rbtnB1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxBarriersSettings);
            this.Controls.Add(this.boosterLabel);
            this.Controls.Add(this.pauseLabel);
            this.Controls.Add(this.durationOfGameLabel);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.GameOverLabel);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.snapButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.groupBoxBarriersSettings.ResumeLayout(false);
            this.groupBoxBarriersSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button snapButton;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtHighScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem начатьНовуюИгруToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem паузаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияОИгреToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem1;
        private System.Windows.Forms.Label GameOverLabel;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label durationOfGameLabel;
        private System.Windows.Forms.Timer durationOfGameTimer;
        private System.Windows.Forms.Label pauseLabel;
        private System.Windows.Forms.ToolStripMenuItem управлениеToolStripMenuItem;
        private System.Windows.Forms.Label boosterLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBoxBarriersSettings;
        private System.Windows.Forms.RadioButton rbtnB2;
        private System.Windows.Forms.RadioButton rbtnB1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

