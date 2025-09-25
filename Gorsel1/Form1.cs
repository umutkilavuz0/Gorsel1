using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace gorsel
{
    public partial class Form1 : Form
    {
        enum Mode { Idle, Up, Down }
        Mode _mode = Mode.Idle;

        
        int _elapsedCs = 0;            
        int _remainingCs = 0;           

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10; 
            button1.Text = "başla";
            ResetDisplays();
        }

       

        

       
        void ResetDisplays()
        {
         
            label1.Text = "Saat";
            label2.Text = "Dakika";
            label3.Text = "Saniye";
            label4.Text = "Salise";

            label8.Text = "Saat";
            label7.Text = "Dakika";
            label6.Text = "Saniye";
            label5.Text = "Salise";
        }

        void SetTimeToTop(int centiseconds)
        {
            (int h, int m, int s, int cs) = SplitTime(centiseconds);
            label1.Text = h.ToString("00");
            label2.Text = m.ToString("00");
            label3.Text = s.ToString("00");
            label4.Text = cs.ToString("00");
        }

        void SetTimeToBottom(int centiseconds)
        {
            (int h, int m, int s, int cs) = SplitTime(centiseconds);
            label8.Text = h.ToString("00");
            label7.Text = m.ToString("00");
            label6.Text = s.ToString("00");
            label5.Text = cs.ToString("00");
        }

        (int h, int m, int s, int cs) SplitTime(int centiseconds)
        {
            int cs = centiseconds % 100;
            int totalSeconds = centiseconds / 100;
            int s = totalSeconds % 60;
            int m = (totalSeconds / 60) % 60;
            int h = totalSeconds / 3600;
            return (h, m, s, cs);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_mode == Mode.Idle)
            {
               
                _mode = Mode.Up;
                _elapsedCs = 0;
                button1.Text = "Geri Sayım";
                timer1.Start();
            }
            else if (_mode == Mode.Up)
            {
                
                _mode = Mode.Down;
                _remainingCs = _elapsedCs; 
               
            }
            else if (_mode == Mode.Down)
            {
              
                _mode = Mode.Idle;
                timer1.Stop();
                button1.Text = "başla";
                ResetDisplays();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_mode == Mode.Up)
            {
                _elapsedCs++;
                SetTimeToTop(_elapsedCs);
            }
            else if (_mode == Mode.Down)
            {
                if (_remainingCs > 0)
                {
                    _remainingCs--;
                    SetTimeToBottom(_remainingCs);
                }
                else
                {
                    timer1.Stop();
                    _mode = Mode.Idle;
                    button1.Text = "başla";
                }
            }
        }
    }
}
