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
    public partial class AggeliesForm : Form
    {
        public AggeliesForm()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AggeliesForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.SetStyle(ControlStyles.ResizeRedraw, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Biografiko Clicked!");
            Forms.ViografikoForm viografikoF = new Forms.ViografikoForm();
            viografikoF.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Nea Aggelia Clicked!");
            Forms.ProsthikiNeasAggeliasForm neaAggeliaF = new Forms.ProsthikiNeasAggeliasForm();
            neaAggeliaF.Show();
            Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Biografiko Clicked!");
            Forms.ViografikoForm viografikoF = new Forms.ViografikoForm();
            viografikoF.Show();
            Visible = false;
        }
    }
}
