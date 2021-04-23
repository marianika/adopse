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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        
        
//register button calls adduser2 and registers user using UI's textbox data
        private void button1_Click(object sender, EventArgs e)


        {   //calls maxnum method used to return the biggest id integer on the user table
            //adds to that value to create a unique id for the newly registered user
            int number = maxnum()+1;
            

            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();



            NpgsqlCommand cmd = new NpgsqlCommand("adduser2", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(number);
            cmd.Parameters.AddWithValue(EmailBox.Text);
            cmd.Parameters.AddWithValue(PasswordBox.Text);
            cmd.Parameters.AddWithValue(NameBox.Text);
            cmd.Parameters.AddWithValue(SurnameBox.Text);
            cmd.Parameters.AddWithValue(PhoneBox.Text);
            cmd.Parameters.AddWithValue(BirthdayBox.Text);
            cmd.Parameters.AddWithValue(CityBox.Text);
            cmd.Parameters.AddWithValue(GenderBox.Text);
            cmd.Parameters.AddWithValue(UsernameBox.Text);

            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();

            }

            conn.Close();

        }
        static int maxnum()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();


            int num=0;
            NpgsqlCommand cmd = new NpgsqlCommand("getmax", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    num = dr.GetInt32(0);

                }
            }
                        return num;
        }

    }
}
