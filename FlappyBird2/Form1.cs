using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird2
{
    public partial class Form1 : Form
    {
        int boruHızı = 8;
        int gravity = 7;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            boruAlt.Left -= boruHızı;
            boruUst.Left -= boruHızı;
            scoreText.Text = "Score : " + score;

            if (boruAlt.Left < - 150)
            {
                boruAlt.Left = 800;
                score++;
            }
            if (boruUst.Left < -180)
            {
                boruUst.Left = 950;
            }
            if (flappyBird.Bounds.IntersectsWith(boruAlt.Bounds)|| flappyBird.Bounds.IntersectsWith(boruUst.Bounds)|| flappyBird.Bounds.IntersectsWith(zemin.Bounds))
      
            {
                endGame();
            }
            if (score > 5)
            {
                boruHızı = 12;
            }
            if (flappyBird.Top < -25)
            {
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -7;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 7;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text = "Game Over!!";
        }
    }
}
