namespace Pong_Game
{
    public partial class PongGameForm : Form
    {
        Random rand = new Random();

        // ball speed in both direction
        int ballXspeed = 4;
        int ballYspeed = 4;
        int speed = 2;

        // control the bool movement
        bool goDown, goUp;

        int computer_speed_change = 50;
        int playerSpeed = 8;

        // scores
        int playerScore = 0;
        int computerScore = 0;

        // computer speeds, form array
        int[] computer_speeds = { 5, 6, 8, 9 };
        int[] ball_speeds = { 10, 9, 8, 11, 12 };

        public PongGameForm()
        {
            InitializeComponent();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            ball.Top -= ballYspeed;
            ball.Left -= ballXspeed;

            this.Text = $"Player Score : {playerScore} | Computer Score : {computerScore}";

            if(ball.Top < 0 || ball.Bottom > this.ClientSize.Height)
            {
                ballYspeed = -ballYspeed;
            }

            // computer scores
            if(ball.Left < -2)
            {
                ball.Left = 300;
                ballXspeed = -ballXspeed;
                computerScore++;
            }

            // player score
            if(ball.Right > this.ClientSize.Width + 2)
            {
                ball.Left = 300;
                ballXspeed = -ballXspeed;
                playerScore++;
            }

            // computer movement
            if(computer.Top <= 1)
            {
                computer.Top = 0;
            }
            else if(computer.Bottom >= this.ClientSize.Height)
            {
                computer.Top = this.ClientSize.Height - computer.Height;
            }

            if(ball.Top < computer.Top + (computer.Height /2 ) && ball.Left > 300)
            {
                computer.Top -= speed;
            }

            if( ball.Top > computer.Top + (computer.Height / 2) && ball.Left > 300)
            {
                computer.Top += speed;
            }

            computer_speed_change -= 1;
            if(computer_speed_change < 0)
            {
                speed = computer_speeds[rand.Next(computer_speeds.Length)];
                computer_speed_change = 50;
            }

            if(goDown && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += playerSpeed;
            }

            if(goUp && player.Top > 0)
            {
                player.Top -= playerSpeed;
            }

            CheckCollision(ball, player, player.Right + 5);
            CheckCollision(ball, computer, computer.Left - 35);

            if(computerScore > 5)
            {
                GameOver("Sorry You loss the game");
            }
            else if(playerScore > 5)
            {
                GameOver("You Won this game.");
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                goDown = true;

            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = true;

            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
        }

        // first pic is for ball, and is for either player or computer
        private void CheckCollision(PictureBox PicOne, PictureBox PicTwo, int offset)
        {
            if (PicOne.Bounds.IntersectsWith(PicTwo.Bounds))
            {
                PicOne.Left = offset;

                int x = ball_speeds[rand.Next(ball_speeds.Length)];
                int y = ball_speeds[rand.Next(ball_speeds.Length)];

                // ball movement in x axis
                if( ballXspeed < 0)
                {
                    ballXspeed = x;
                }
                else
                {
                    ballXspeed = -x;
                }

                // ball movement in y axis
                if(ballYspeed < 0)
                {
                    ballYspeed = -y;
                }
                else
                {
                    ballYspeed = y;
                }
            }
        }

        
        private void GameOver(string message)
        {
            // re-setting everytings
            GameTimer.Stop();
            MessageBox.Show(message, "Hello there...");
            computerScore = 0;
            playerScore = 0;
            ballXspeed = ballYspeed = 4;
            computer_speed_change = 50;
            GameTimer.Start();
        }
    }
}
