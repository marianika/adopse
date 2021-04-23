using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace adopse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            
        }
        //login button calls login sql function compares UI's textbox data with the database's
        
        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21") ;
            conn.Open();

            

            NpgsqlCommand cmd= new NpgsqlCommand("login", conn); 
            
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(UsernameText.Text);
            cmd.Parameters.AddWithValue(PasswordText.Text);
            NpgsqlDataReader dr = cmd.ExecuteReader();
          
           //shows a dialog window if the textbox data finds a match
            while (dr.Read())
            {
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
                
            }
            
            conn.Close();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();

        }
    }
}
