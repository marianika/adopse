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
            string sql = "select id, username, type from users order by id";
            createTable(sql, usersTable);
        }

        private void loadlogfiles()
        {
            string sql = "select * from log_files order by id";
            createTable(sql, logFilesTable);
        }

        protected override void addButton_Click(object sender, EventArgs e)
        {
            base.addButton_Click(sender, e);
            loadlogfiles();
        }

        protected override void editButton_Click(object sender, EventArgs e)
        {
            base.editButton_Click(sender, e);
            loadlogfiles();
        }

        override protected void deleteButton_Click(object sender, EventArgs e)
        {
            base.deleteButton_Click(sender, e);
            loadlogfiles();
        }


        private void AddModeratorButton_Click(object sender, EventArgs e)
        {
            int id;
            bool success = Int32.TryParse(used_id.Text, out id);
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
    }
}
