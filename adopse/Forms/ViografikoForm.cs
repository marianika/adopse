using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adopse.Forms
{
    public partial class ViografikoForm : Form
    {
        public ViografikoForm()
        {
            InitializeComponent();
        }

        private void ViografikoForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.SetStyle(ControlStyles.ResizeRedraw, false);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            this.BackgroundImageLayout = ImageLayout.Center;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Aggelies Clicked!");
            Forms.AggeliesForm aggeliesF = new Forms.AggeliesForm();
            aggeliesF.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Diaxeirisi Clicked!");
            Forms.DiaxeirisiForm diaxeirisiF = new Forms.DiaxeirisiForm();
            diaxeirisiF.Show();
            Visible = false;
        }
    }
}
