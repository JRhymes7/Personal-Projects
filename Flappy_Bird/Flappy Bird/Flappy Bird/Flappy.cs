namespace Flappy_Bird
{
    public partial class Flappy : Form
    {
        //public variables
        int obstacleSpeed = 5;
        int gravity = 5;
        int score = 0;

        public Flappy()
        {
            InitializeComponent();
            gameTimer.Start();
        }

        //function defining what will happn during game start 
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            birdPlayer.Top += gravity;
            obstacleBottom.Left -= obstacleSpeed;
            obstacleTop.Left -= obstacleSpeed;
            scoreText.Text = score.ToString();

            //this will allow us to spawn the obstacles again and again
            if(obstacleBottom.Left < -150 )
            {
                obstacleBottom.Left = 950;
                score++;
            }

            if (obstacleTop.Left < -180)
            {
                obstacleTop.Left = 950;
                score++;
            }

            if (birdPlayer.Bounds.IntersectsWith(obstacleBottom.Bounds) || birdPlayer.Bounds.IntersectsWith(obstacleTop.Bounds) || birdPlayer.Bounds.IntersectsWith(ground.Bounds) || birdPlayer.Top < -25)
            {
                if (score > 0)
                {
                   score--;
                }
                else
                {
                    gameOver();
                }
            }

            //this will increase the obstacle speed as the game runs to make it harder
            if (score > 5)
            {
                obstacleSpeed += 5;
            }
        }

        //function for when the player pressed the up arrow key
        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                gravity = -5;
            }  
        }

        //function for when the player releases the down arrow key
        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gravity = 5;
            }
        }

        private void gameOver()
        {
            gameTimer.Stop();
            scoreText.Text = "Oops! Game Over";
        }
    }
}