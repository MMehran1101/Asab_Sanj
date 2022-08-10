using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Asab_Sanj
{
    public partial class Form1 : Form
    {
        public MessageEngine winMessage, gameoverMessage, timeoutMessage;
        public Label[] allLabels = new Label[25];
        public bool language_EN;
        private bool isStart;
        private int time;

        public Form1()
        {
            InitializeComponent();
        }

         // Road array
        private Label[] LabaleGenerator(Label[] labels)
        {
            Label[] lbls =
                        {
                label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12,
                label13,
                label14, label15, label16, label17, label18, label19, label20, label21, label22, label23, label24,
                label25
            };

            for (int i = 0; i < lbls.Length; i++)
            {
                labels[i] = lbls[i];
            }

            return labels;
        }     
        
        private void Form1_Load(object sender, EventArgs e)
        {
            winMessage = new MessageEngine(new WinMessage());
            gameoverMessage = new MessageEngine(new GameOverMessage());
            timeoutMessage = new MessageEngine(new TimeoutMessage());

            LabaleGenerator(allLabels);
        }

        // Start button
        private void btnStart_Click(object sender, EventArgs e)
        {
            isStart = true;
            timer1.Enabled = true;
            time = 99;
        }

        // Win player
        private void btnFinish_MouseEnter(object sender, EventArgs e)
        {
            if (isStart)
            {
                timer1.Enabled = false;
                Console.Beep(500, 700);

                winMessage.Send(language_EN);
                isStart = false;
            }
        }

        // Timeout
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimeleft.Text = time.ToString();
            if (time <= 10) Console.Beep(850, 250);
            if (time == 0)
            {
                Console.Beep(850, 1200);
                timer1.Enabled = false;

                timeoutMessage.Send(language_EN);
                isStart = false;
            }
            time--;
        }

        // GAME OVER
        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            if (isStart)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Beep(850, 250);
                }
                Console.Beep(850, 1000);
                timer1.Enabled = false;

                gameoverMessage.Send(language_EN);
                isStart = false;
            }
        }

        // Exit
        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Change Color Label (Road)
        private void ToolStripMenuItem_randomColor_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int redColor = r.Next(1, 150);
            int greenColor = r.Next(1, 150);
            int blueColor = r.Next(1, 150);
            foreach (var l in allLabels) l.BackColor = Color.FromArgb(redColor, greenColor, blueColor);
        }

        private void ToolStripMenuItem_chColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            for (var i = 0; i < allLabels.Length; i++) allLabels[i].BackColor = colorDialog1.Color;
        }

        // Change languages
        private void ToolStripMenuItem_En_Click(object sender, EventArgs e)
        {
            language_EN = true;

            //Checkeds
            ToolStripMenuItem_En.Checked = true;
            فارسیToolStripMenuItem.Checked = false;

            //Locations
            lblTimeleft.Left += 150;
            lblTime.Left -= 50;

            //Fonts
            lblTimeleft.Font = new Font("Tahoma", 24F, FontStyle.Regular, GraphicsUnit.Point);

            //RTLs
            lblTime.RightToLeft = RightToLeft.No;
            lblTimeleft.RightToLeft = RightToLeft.No;
            menuStrip1.RightToLeft = RightToLeft.No;

            //Names
            Text = "Asab Sanj";
            lblTime.Text = "Time Left :";
            btnStart.Text = "Start";
            btnFinish.Text = "Finish";
            ToolStripMenuItem_En.Text = "English";
            منوToolStripMenuItem.Text = "Menu";
            ToolStripMenuItem_Color.Text = "Settings";
            فارسیToolStripMenuItem.Text = "Persian";
            ToolStripMenuItem_ColorDialog.Text = "Color";
            ToolStripMenuItem_chColor.Text = "Choose Color";
            ToolStripMenuItem_randomColor.Text = "Random Color";
            زبانToolStripMenuItem.Text = "Language";
            ToolStripMenuItem_Exit.Text = "Exit";
        }

        private void فارسیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}