namespace WinFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();

        }
        int dx = 5, dy = 5;
        int score = 0;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && panel1.Left > 0)
            {
                panel1.Left -= 30;
            }
            if (e.KeyCode == Keys.Right && panel1.Right < ClientSize.Width)
            {
                panel1.Left += 30;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Top += dy;
            pictureBox1.Left += dx;
            if (pictureBox1.Left <= 0)
            {
                pictureBox1.Left = 0;
                dx=Math.Abs(dx);
            }

            if (pictureBox1.Right >= ClientSize.Width)
            {
                dx = -Math.Abs(dx);
                pictureBox1.Left = ClientSize.Width - pictureBox1.Width;
            }

            if (pictureBox1.Top <= 0)
            {
                dy = Math.Abs(dy);
                pictureBox1.Top = 0;
            }
            if (dy > 0 &&
                pictureBox1.Bottom >= panel1.Top &&
                pictureBox1.Top < panel1.Bottom &&
                pictureBox1.Right > panel1.Left &&
                pictureBox1.Left < panel1.Right)
            {
                dy = -Math.Abs(dy);
                pictureBox1.Top = panel1.Top - pictureBox1.Height;
                score++;
                label2.Text = score.ToString();
            }
            else if (pictureBox1.Top > panel1.Bottom)
            {
                timer1.Stop();

                DialogResult d=MessageBox.Show("Oyun bitdi.Sizin xaliniz: "+score+"\nYeni oyun ucun Ok duymesine basin","Oyin bitdi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (d == DialogResult.OK) {
                    score = 0;
                    label2.Text = "0";

                    pictureBox1.Left = ClientSize.Width / 2 - pictureBox1.Width / 2;
                    pictureBox1.Top = 20;
                    dx = 5;
                    dy = 5;

                    timer1.Start();
                }
            }
        }
    }
}
