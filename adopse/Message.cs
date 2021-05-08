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
    public partial class Message : Form
    {
        public Message()
        {   int val = Login.userid;
            InitializeComponent();
            label1.Text = val.ToString();
        }
        

        private void label1_Click(object sender, EventArgs e)
        {
            

        }
    }
}
