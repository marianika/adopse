using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace adopse.Forms
{
    public partial class ModeratorForm : Form
    {

        public ModeratorForm()
        {
            InitializeComponent();
            loadAds();
            dateTimePicker.Value = DateTime.Now;
        }

        private void loadAds()
        {
            string sql = "select * from ads order by id";
            createTable(sql, AdsTable);
        }

        protected void createTable(string sql, DataGridView dataGridView)
        {
            using (var connection = dbConnector.GetConnection())
            {
                connection.Open();
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    var dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        dataGridView.DataSource = dataTable;
                    }
                }
            }
        }

        virtual protected void addButton_Click(object sender, EventArgs e)
        {
            bool success1 = Int32.TryParse(textBox_company_id.Text, out int company_id);
            bool success2 = Int32.TryParse(textBox_salary.Text, out int salary);

            if (success1 && success2)
            {
                using (var connection = dbConnector.GetConnection())
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(
                        "INSERT INTO ads (com_id, position, description, salary, c_date, tags) VALUES (@c, @p, @d, @s, @date, @t)", connection))
                    {
                        command.Parameters.AddWithValue("c", company_id);
                        command.Parameters.AddWithValue("p", textBox_position.Text);
                        command.Parameters.AddWithValue("d", textBox_description.Text);
                        command.Parameters.AddWithValue("s", salary);
                        command.Parameters.AddWithValue("t", textBox_tags.Text);
                        command.Parameters.AddWithValue("date", dateTimePicker.Value.Date);
                        int nRows = command.ExecuteNonQuery();

                        loadAds();
                        resetForm();
                    }
                }
            }
        }

        virtual protected void editButton_Click(object sender, EventArgs e)
        {
            bool success = Int32.TryParse(textBox_id.Text, out int id);
            bool success1 = Int32.TryParse(textBox_company_id.Text, out int company_id);
            bool success2 = Int32.TryParse(textBox_salary.Text, out int salary);

            if (success && success1 && success2)
            {
                using (var connection = dbConnector.GetConnection())
                {
                    connection.Open();
                    
                    using (var command = new NpgsqlCommand(
                        "UPDATE ads SET com_id = @c, position = @p, description = @d, salary = @s,c_date = @date, tags = @t WHERE id = @i", connection))
                    {
                        command.Parameters.AddWithValue("c", company_id);
                        command.Parameters.AddWithValue("p", textBox_position.Text);
                        command.Parameters.AddWithValue("d", textBox_description.Text);
                        command.Parameters.AddWithValue("s", salary);
                        command.Parameters.AddWithValue("t", textBox_tags.Text);
                        command.Parameters.AddWithValue("date", dateTimePicker.Value.Date);
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
            bool success = Int32.TryParse(textBox_id.Text, out int id);
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
            bool success = Int32.TryParse(textBox_id.Text, out int id);
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
                                textBox_company_id.Text = reader.GetInt32(1).ToString();
                            if (!reader.IsDBNull(2))
                                textBox_position.Text = reader.GetString(2);
                            if (!reader.IsDBNull(3))
                                textBox_description.Text = reader.GetString(3);
                            if (!reader.IsDBNull(4))
                                textBox_salary.Text = reader.GetInt32(4).ToString();
                            if (!reader.IsDBNull(5))
                                dateTimePicker.Value = (DateTime)reader.GetDate(5);
                            if (!reader.IsDBNull(6))
                                textBox_tags.Text = reader.GetString(6);
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
            textBox_id.Clear();
            textBox_company_id.Clear();
            textBox_position.Clear();
            textBox_description.Clear();
            textBox_salary.Clear();
            textBox_tags.Clear();
            dateTimePicker.Value = DateTime.Now;
        }

    }
}
