using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Classic_Snake_Game_with_cSharp
{
    public partial class Form1 : Form
    {
        private List<circle> Snake = new List<circle>();
        private circle food = new circle();
       

        public Form1()
        {
            InitializeComponent();
            new settings();
            gameTimer.Interval = 1000/settings.speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();
            StartGame();
        }

        private void UpdateScreen(Object sender, EventArgs e)
        {
            if (settings.gameOver)
            {
               
                if (inputs.keyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }

            else
            {

                int maxXPos = pbCanvas.Size.Width / settings.width;
                int maxYPos = pbCanvas.Size.Height / settings.height;

                if (inputs.keyPressed(Keys.Right) && settings.direction != Direction.left)
                { settings.direction = Direction.right; }

                else if (inputs.keyPressed(Keys.Left) && settings.direction != Direction.right)
                    settings.direction = Direction.left;

                else if (inputs.keyPressed(Keys.Up) && settings.direction != Direction.down)
                    settings.direction = Direction.up;

                else if (inputs.keyPressed(Keys.Down) && settings.direction != Direction.up)
                    settings.direction = Direction.down;

                if (Snake[0].X < 0 || Snake[0].Y < 0 || Snake[0].X >= maxXPos || Snake[0].Y >= maxYPos+1)
                {
                    settings.gameOver = true;                   
                }

                if(Snake[0].X==food.X&&Snake[0].Y==food.Y)
                {
                    eat();
                }


                //MessageBox.Show("anisha");

                MovePlayer();
           
            }
            pbCanvas.Invalidate();
             
        }
   
        private void MovePlayer()
        {

            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (settings.direction)
                    {
                        case Direction.right:
                            Snake[i].X++;
                            break;

                        case Direction.left:
                            Snake[i].X--;
                            break;

                        case Direction.down:
                            Snake[i].Y++;
                            break;

                        case Direction.up:
                            Snake[i].Y--;
                            break;
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y; 
                }
            }
        }

        private void StartGame()
        {
            lblGameOver.Visible = false;
            new settings();
            Snake.Clear();
            circle head = new circle { X = 10, Y = 5 };
            Snake.Add(head);
            lblScore.Text = settings.score.ToString();
            GenerateFood();
        }

        private void GenerateFood()//places random food object in the screen randomly
        {
            int maxXPos = pbCanvas.Size.Width / settings.width;
            int maxYPos = pbCanvas.Size.Height / settings.height;

            Random random = new Random();
            food = new circle { X = random.Next(0, maxXPos), Y = random.Next(0, maxYPos) };
        }

        private void eat()
        {
            settings.score += settings.points;
            lblScore.Text = settings.score.ToString();
            Snake.Add(new circle { });
            GenerateFood();
        }


        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics; 
            if(settings.gameOver == false)
            {
                Brush snakeColor;
                for(int i = 0; i < Snake.Count; i++)//drawing snake
                {
                    if (i == 0)
                        snakeColor = Brushes.Black;//head
                    else
                        snakeColor = Brushes.Green;//rest of the body

                    canvas.FillEllipse(snakeColor,
                        new Rectangle(Snake[i].X * settings.width,
                        Snake[i].Y * settings.height,
                        settings.width, settings.height
                        ));

                   canvas.FillEllipse(Brushes.Red,
                        new Rectangle(food.X * settings.width,
                        food.Y * settings.height,
                        settings.width, settings.height
                        ));
                }
            }
            else
            {
                string gameOver = "Game Over \nYour final score is: "+settings.score+"\nPress enter to try again";
                lblGameOver.Text = gameOver;
                lblGameOver.Visible = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            inputs.changeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            inputs.changeState(e.KeyCode, false);
        }
    }
}
