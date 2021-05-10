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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            loadUsers();
            loadlogfiles();
            loadAds();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

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
            using (var connection = dbConnector.GetConnection())
            {
                connection.Open();
                int id = int.Parse(used_id.Text);
                using (var command = new NpgsqlCommand("UPDATE users SET type = 'moderator' WHERE id = @n", connection))
                {
                    command.Parameters.AddWithValue("n", id);
                    int nRows = command.ExecuteNonQuery();
                    loadUsers();
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
                        System.Diagnostics.Debug.WriteLine("katevikan ta ads");
                    }
                }
            }
        }

    }
}
