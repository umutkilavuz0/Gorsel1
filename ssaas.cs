namespace WinFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        bool basili = false;

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            basili = true;
        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (basili)
            {
                button1.Left = e.X + button1.Left;
                button1.Top = e.Y + button1.Top;
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            basili = false;
        }

    }
}
