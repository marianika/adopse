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
    public partial class ModeratorForm : Form
    {
        public ModeratorForm()
        {
            InitializeComponent();
            loadAds();
        }

        private void loadAds()
        {
            using (var connection = dbConnector.GetConnection())
            {
                connection.Open();
                string sql = "select * from ads order by id";
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    var dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        AdsTable.DataSource = dataTable;
                    }
                }
            }
        }


        virtual protected void editButton_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int id;
            bool success = Int32.TryParse(text, out id);
            int com_id = int.Parse(textBox2.Text);
            string position = textBox3.Text;
            string description = textBox4.Text;
            int salary = int.Parse(textBox5.Text);
            string tags = textBox6.Text;

            if (success)
            {
                using (var connection = dbConnector.GetConnection())
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(
                        "UPDATE ads SET com_id = @c, position = @p, description = @d, salary = @s, tags = @t WHERE id = @i", connection))
                    {
                        command.Parameters.AddWithValue("c", com_id);
                        command.Parameters.AddWithValue("p", position);
                        command.Parameters.AddWithValue("d", description);
                        command.Parameters.AddWithValue("s", salary);
                        command.Parameters.AddWithValue("t", tags);
                        command.Parameters.AddWithValue("i", id);
                        int nRows = command.ExecuteNonQuery();

                        loadAds();
                        resetForm();
                    }
                }
            } 
        }


        virtual protected void deleteButton_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int id;
            bool success = Int32.TryParse(text, out id);
            if (success)
            {
                using (var connection = dbConnector.GetConnection())
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("DELETE FROM ads WHERE id = @i", connection))
                    {
                        command.Parameters.AddWithValue("i", id);
                        int nRows = command.ExecuteNonQuery();

                        loadAds();
                        resetForm();
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int id;
            bool success = Int32.TryParse(text, out id);
            if (success)
            {
                using (var connection = dbConnector.GetConnection())
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("select * from ads where id = @i", connection))
                    {
                        command.Parameters.AddWithValue("i", id);

                        var reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(1))
                                textBox2.Text = reader.GetInt32(1).ToString();
                            if (!reader.IsDBNull(2))
                                textBox3.Text = reader.GetString(2);
                            if (!reader.IsDBNull(3))
                                textBox4.Text = reader.GetString(3);
                            if (!reader.IsDBNull(4))
                                textBox5.Text = reader.GetInt32(4).ToString();
                            if (!reader.IsDBNull(6))
                                textBox6.Text = reader.GetString(6);
                        }
                        reader.Close();
                    }
                }
            }
            else
            {
                resetForm();
            }
        }

        private void resetForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

    }
}
