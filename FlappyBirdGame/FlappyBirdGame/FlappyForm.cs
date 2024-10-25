using System.Media;

namespace FlappyBirdGame;

public partial class FlappyForm : Form
{
    // game variables
    int pipeSpeed = 8;
    int gravity = 8;
    int score = 0;
    int level = 1;
    string formHeader = string.Empty;

    public FlappyForm()
    {
        InitializeComponent();

        formHeader = this.Text;

        this.Text += formHeader;
        this.Text += "   ";
        this.Text += $"|   Score : {score}   ";
        this.Text += $"|   Level : {level}";

        this.Text = formHeader;
    }

    private void GameTimerEvent(object sender, EventArgs e)
    {
        // Movements : Bird, Top-Piller and Bottom-Piller
        bird.Top += gravity;
        bottompiller.Left -= pipeSpeed;
        toppiller.Left -= pipeSpeed;

        this.Text = formHeader + "   " + $"|   Score : {score}   " + $"|   Level : {level}";

        // Check Whether Pillers Cross Window or not
        if (bottompiller.Left < -100)
        {
            bottompiller.Left = 800;
        }
        if(toppiller.Left < -100)
        {
            toppiller.Left = 800;
        }

        // Insrease score if bird cross piller
        if (bottompiller.Left < bird.Left || toppiller.Left < -bird.Left)
        {
            score++;
        }

        // Insrease level if bird cross both pillers
        if (bottompiller.Left < bird.Left && toppiller.Left < -bird.Left)
        {
            level++;
        }

        // Check for collision detection
        if (CheckForCollosionDetection(bird, toppiller, bottompiller, ground))
            EndGame();

        // check score and set pipe speed as per it
        if(score > 5)
        {
            pipeSpeed = pipeSpeed * (int)level % 1;
        }

    }

    private void GameKeyIsUp(object sender, KeyEventArgs e)
    {
        if(e.KeyCode == Keys.Space)
        {
            gravity = -6;
        }
    }

    private void GameKeyIsDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
        {
            gravity = 6;
        }
    }

    // Collision Detection : Implementation
    private bool CheckForCollosionDetection(PictureBox bird ,PictureBox topPiller, PictureBox bottomPiller, PictureBox ground)
    {
        if (bird.Bounds.IntersectsWith(topPiller.Bounds) || 
            bird.Bounds.IntersectsWith(bottomPiller.Bounds) ||
            bird.Bounds.IntersectsWith(ground.Bounds) || bird.Top < -20)
            return true;
        return false;
    }

    // End Game
    private void EndGame()
    {
        GameTimer.Stop();

        // Play a sound to indicate the game is over
        SystemSounds.Exclamation.Play();  // Plays a Windows default sound

        // Display a message box asking the user if they want to play again
        DialogResult result = MessageBox.Show(this, "Game Over! Your score: " + score +
                                              "\nWould you like to play again?",
                                              "Game Over",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
            RestratGame();

        else
            this.Close();
    }

    // RestartGame

    private void RestratGame()
    {
        // Reset game variables
        pipeSpeed = 8;
        gravity = 8;
        score = 0;
        level = 1;

        // Reset positions of bird and pillars
        bird.Top = 100;  
        bottompiller.Left = 800;
        toppiller.Left = 800;

        GameTimer.Start();

    }
}
