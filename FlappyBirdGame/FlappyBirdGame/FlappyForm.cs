namespace FlappyBirdGame;

public partial class FlappyForm : Form
{
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
    }
}
