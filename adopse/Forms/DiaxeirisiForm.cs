using Npgsql;
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
    public partial class DiaxeirisiForm : Form
    {
        public DiaxeirisiForm()
        {
            InitializeComponent();
        }

        private void DiaxeirisiForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.SetStyle(ControlStyles.ResizeRedraw, false);
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
            System.Diagnostics.Debug.WriteLine("Biografiko Clicked!");
            Forms.ViografikoForm viografikoF = new Forms.ViografikoForm();
            viografikoF.Show();
            Visible = false;
        }

        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("sundesh2 Clicked!");
            string username = usernameText.Text;
            string password = passwordText.Text;

            string sql = "select * from admin where email='" + username +"'" + "and pwd='" + password + "'";

            using (var connection = dbConnector.GetConnection())
            {
                Console.Out.WriteLine("Opening connection");
                connection.Open();

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    var dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        System.Diagnostics.Debug.WriteLine("sidethike o admin");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("kati pige lathos");
                    }
                }
            }



            //System.Diagnostics.Debug.WriteLine(username);
            //System.Diagnostics.Debug.WriteLine(password);


        }
    }
}
