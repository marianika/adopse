using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace adopse.Forms
{
    public partial class AdministratorForm : adopse.Forms.ModeratorForm
    {
        public AdministratorForm()
        {
            InitializeComponent();
            loadUsers();
            loadlogfiles();
        }
        private void loadUsers()
        {
            using (var connection = dbConnector.GetConnection())
            {
                connection.Open();
                string sql = "select id, username, type from users order by id";
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    var dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        usersTable.DataSource = dataTable;
                        System.Diagnostics.Debug.WriteLine("katevikan oi users");
                    }
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string text = used_id.Text;
            int id;
            bool success = Int32.TryParse(text, out id);
            if (success)
            {
                using (var connection = dbConnector.GetConnection())
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("UPDATE users SET type = 'moderator' WHERE id = @i", connection))
                    {
                        command.Parameters.AddWithValue("i", id);
                        int nRows = command.ExecuteNonQuery();
                        loadUsers();
                    }
                }
            }
        }

        private void loadlogfiles()
        {
            using (var connection = dbConnector.GetConnection())
            {
                connection.Open();
                string sql = "select * from log_files order by id";
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    var dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        logFilesTable.DataSource = dataTable;
                        System.Diagnostics.Debug.WriteLine("katevikan ta log files");
                    }
                }
            }
        }
    }
}
