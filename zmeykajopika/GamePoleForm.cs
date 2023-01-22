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

            Text = "Количество очков = " + controller.score;

            this.Invalidate();

            if (controller.snake.head.x == controller.snake.tail.x && controller.snake.head.y == controller.snake.tail.y
                || controller.snake.body.Any(blok => controller.snake.head.x == blok.x && controller.snake.head.y == blok.y))
                GameLose();

            if (controller.score == controller.CountCellsHeigth * controller.CountCellsWidth)
                GameWin();
        }

        private void GamePoleForm_Shown(object sender, EventArgs e)
        {
            timer.Start();
        }

        public void GameWin()
        {
            timer.Stop();
            MessageBox.Show("Вы выиграли!");
            controller.NewGame();
            timer.Start();
        }
        public void GameLose()
        {
            timer.Stop();
            MessageBox.Show("Вы проиграли!");
            controller.NewGame();
            timer.Start();
        }
        private void GamePoleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.KeyCode == Keys.Up || e.KeyCode==Keys.W) && controller.snake.state!= SnakeStateEnum.Down)
            {
                controller.nextState = SnakeStateEnum.Up;
            }
            else if((e.KeyCode==Keys.Down || e.KeyCode == Keys.S) && controller.snake.state != SnakeStateEnum.Up)
            {
                controller.nextState = SnakeStateEnum.Down;
            }
            else if((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && controller.snake.state != SnakeStateEnum.Right)
            {
                controller.nextState = SnakeStateEnum.Left;
            }
            else if((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && controller.snake.state != SnakeStateEnum.Left)
            {
                controller.nextState = SnakeStateEnum.Right;
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(controller, timer);
            form.Show();
        }

        private void GamePoleForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y <= menuStrip1.Bottom && !menuStrip1.Visible)
                menuStrip1.Visible = true;
            else if(e.Y > menuStrip1.Bottom && menuStrip1.Visible)
                menuStrip1.Visible = false;
        }
    }
}
