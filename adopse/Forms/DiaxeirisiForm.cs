﻿using Npgsql;
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

                using (var command = new NpgsqlCommand("select * from admin where email = @u and pwd = @p", connection))
                {
                    command.Parameters.AddWithValue("u", username);
                    command.Parameters.AddWithValue("p", password);
                    var dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        System.Diagnostics.Debug.WriteLine("sidethike o admin");
                        AdministratorForm administratorForm = new AdministratorForm();
                        administratorForm.ShowDialog();
                        dataReader.Close();
                        return;
                    }
                    dataReader.Close();
                }

                using (var command = new NpgsqlCommand("select * from users where username = @u and pwd = @p and type = 'moderator'", connection))
                {
                    command.Parameters.AddWithValue("u", username);
                    command.Parameters.AddWithValue("p", password);
                    var dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        System.Diagnostics.Debug.WriteLine("sidethike o moderator");
                        ModeratorForm moderatorForm = new ModeratorForm();
                        moderatorForm.ShowDialog();
                        dataReader.Close();
                    }
                }
            }
        }
    }
}
