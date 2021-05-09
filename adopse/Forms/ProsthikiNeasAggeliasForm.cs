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
    public partial class ProsthikiNeasAggeliasForm : Form
    {
        public ProsthikiNeasAggeliasForm()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ProsthikiNeasAggeliasForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.SetStyle(ControlStyles.ResizeRedraw, false);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Anevasma Aggelias Clicked!");
            Forms.AggeliesForm aggeliesF = new Forms.AggeliesForm();
            aggeliesF.Show();
            Visible = false;
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
