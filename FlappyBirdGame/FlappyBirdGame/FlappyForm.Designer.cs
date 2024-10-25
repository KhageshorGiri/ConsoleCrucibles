namespace FlappyBirdGame
{
    partial class FlappyForm
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
            components = new System.ComponentModel.Container();
            bird = new PictureBox();
            toppiller = new PictureBox();
            ground = new PictureBox();
            bottompiller = new PictureBox();
            GameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)bird).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toppiller).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bottompiller).BeginInit();
            SuspendLayout();
            // 
            // bird
            // 
            bird.Image = Properties.Resources.bird;
            bird.Location = new Point(215, 193);
            bird.Name = "bird";
            bird.Size = new Size(77, 57);
            bird.SizeMode = PictureBoxSizeMode.StretchImage;
            bird.TabIndex = 0;
            bird.TabStop = false;
            // 
            // toppiller
            // 
            toppiller.Image = Properties.Resources.pipedown;
            toppiller.Location = new Point(582, 1);
            toppiller.Name = "toppiller";
            toppiller.Size = new Size(54, 154);
            toppiller.SizeMode = PictureBoxSizeMode.StretchImage;
            toppiller.TabIndex = 1;
            toppiller.TabStop = false;
            // 
            // ground
            // 
            ground.Image = Properties.Resources.ground;
            ground.Location = new Point(2, 470);
            ground.Name = "ground";
            ground.Size = new Size(785, 57);
            ground.SizeMode = PictureBoxSizeMode.StretchImage;
            ground.TabIndex = 2;
            ground.TabStop = false;
            // 
            // bottompiller
            // 
            bottompiller.Image = Properties.Resources.pipe;
            bottompiller.Location = new Point(609, 284);
            bottompiller.Name = "bottompiller";
            bottompiller.Size = new Size(59, 184);
            bottompiller.SizeMode = PictureBoxSizeMode.StretchImage;
            bottompiller.TabIndex = 3;
            bottompiller.TabStop = false;
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Tick += GameTimerEvent;
            // 
            // FlappyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(785, 527);
            Controls.Add(bottompiller);
            Controls.Add(ground);
            Controls.Add(toppiller);
            Controls.Add(bird);
            Name = "FlappyForm";
            Text = "Flappy Bird Game";
            ((System.ComponentModel.ISupportInitialize)bird).EndInit();
            ((System.ComponentModel.ISupportInitialize)toppiller).EndInit();
            ((System.ComponentModel.ISupportInitialize)ground).EndInit();
            ((System.ComponentModel.ISupportInitialize)bottompiller).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox bird;
        private PictureBox toppiller;
        private PictureBox ground;
        private PictureBox bottompiller;
        private System.Windows.Forms.Timer GameTimer;
    }
}