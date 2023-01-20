using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zmeykajopika
{
    public partial class GamePoleForm : Form
    {
        Controller controller;
        public GamePoleForm()
        {
            InitializeComponent();
            this.ClientSize = new Size(800, 800);
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            controller = new Controller(ClientSize);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            controller.Draw(e.Graphics);

            Kletochki.poleDraw(e.Graphics, this.ClientSize);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            controller.MoveHandler();

            this.Invalidate();
        }

        private void GamePoleForm_Shown(object sender, EventArgs e)
        {
            StartGame();
        }
        public void StartGame()
        {
            timer.Start();
        }

        private void GamePoleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.KeyCode == Keys.Up || e.KeyCode==Keys.W) && controller.snake.state!= SnakeStateEnum.Down)
            {
                controller.snake.state = SnakeStateEnum.Up;
            }
            else if((e.KeyCode==Keys.Down || e.KeyCode == Keys.S) && controller.snake.state != SnakeStateEnum.Up)
            {
                controller.snake.state = SnakeStateEnum.Down;
            }
            else if((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && controller.snake.state != SnakeStateEnum.Right)
            {
                controller.snake.state = SnakeStateEnum.Left;
            }
            else if((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && controller.snake.state != SnakeStateEnum.Left)
            {
                controller.snake.state = SnakeStateEnum.Right;
            }
        }
    }
}
