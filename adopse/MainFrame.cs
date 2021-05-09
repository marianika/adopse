using adopse.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adopse
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
            aggeliesPanel.AutoScroll = false;
            aggeliesPanel.HorizontalScroll.Enabled = false;
            aggeliesPanel.HorizontalScroll.Visible = false;
            aggeliesPanel.HorizontalScroll.Maximum = 0;
            aggeliesPanel.AutoScroll = true;
            loginPanel.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Aggelies Clicked!");
            loginPanel.Visible = false;
            aggeliesPanel.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Biografiko Clicked!");
            Forms.ViografikoForm viografikoF = new Forms.ViografikoForm();
            viografikoF.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Rythmiseis Clicked!");
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProsthikiAggelias f = new ProsthikiAggelias(aggeliesPanel);
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            aggeliesPanel.Visible = false;
            loginPanel.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
