using adopse.Forms;
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
using System.Collections;

namespace adopse
{
    public partial class MainFrame : Form
    {
        static public int userid = 0;
        public MainFrame()
        {
            InitializeComponent();
            aggeliesPanel.AutoScroll = false;
            aggeliesPanel.HorizontalScroll.Enabled = false;
            aggeliesPanel.HorizontalScroll.Visible = false;
            aggeliesPanel.HorizontalScroll.Maximum = 0;
            aggeliesPanel.AutoScroll = true;
            userAggeliesPanel.AutoScroll = false;
            userAggeliesPanel.HorizontalScroll.Enabled = false;
            userAggeliesPanel.HorizontalScroll.Visible = false;
            userAggeliesPanel.HorizontalScroll.Maximum = 0;
            aggeliesPanel.AutoScroll = true;
            loginPanel.Visible = false;
            myFavoritesPanel.Visible = false;
            userAggeliesFrame.Visible = false;
            registerPanel.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Aggelies Clicked!");
            loginPanel.Visible = false;
            userAggeliesFrame.Visible = false;
            myFavoritesPanel.Visible = false;
            registerPanel.Visible = false;
            mainPanel.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Rythmiseis Clicked!");
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProsthikiAggelias f = new ProsthikiAggelias(aggeliesPanel);
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            userAggeliesFrame.Visible = false;
            myFavoritesPanel.Visible = false;
            registerPanel.Visible = false;
            loginPanel.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();



            NpgsqlCommand cmd = new NpgsqlCommand("login", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(usernameText.Text);
            cmd.Parameters.AddWithValue(passwordText.Text);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            //shows a dialog window if the textbox data finds a match
            while (dr.Read())
            {
                userid = dr.GetInt32(0);
                if(userid != 0)
                {
                    myAggeliesNav.Visible = true;
                    myFavoritesNav.Visible = true;
                    loginNav.Visible = false;
                    loginPanel.Visible = false;
                    mainPanel.Visible = true;
                    mainPanel.Focus();
                }

            }

            conn.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("getadswithtags", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(textBox3.Text);

            NpgsqlDataReader dr = cmd.ExecuteReader();

            //shows a dialog window if the textbox data finds a match
            while (dr.Read())
            {
                int val = dr.GetInt32(4);
                Panel adPanel = new Panel();
                Label title, description, salary, currDate;
                adPanel.BackColor = SystemColors.Highlight;
                title = new Label();
                description = new Label();
                salary = new Label();
                currDate = new Label();
                title.Text = dr.GetString(2);
                title.AutoSize = true;
                title.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
                title.Location = new Point(3, 9);
                title.Name = "adTitle" + ProsthikiAggelias.ads;
                title.Size = new Size(163, 16);
                description.Text = dr.GetString(3);
                description.AutoSize = true;
                description.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
                description.Location = new Point(3, 35);
                description.Name = "adDescription" + ProsthikiAggelias.ads;
                description.MaximumSize = new Size(520, 0);
                description.Size = new Size(477, 32);
                salary.Text = "Μισθός " + val.ToString();
                salary.AutoSize = true;
                salary.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                salary.Location = new Point(435, 9);
                salary.Name = "adSalary" + ProsthikiAggelias.ads;
                salary.Size = new Size(99, 16);
                currDate.Text = "date";
                currDate.AutoSize = true;
                currDate.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                currDate.Location = new Point(462, 67);
                currDate.Name = "adCurrDate" + ProsthikiAggelias.ads;
                currDate.Size = new Size(72, 16);
                adPanel.Controls.Add(title);
                adPanel.Controls.Add(description);
                adPanel.Controls.Add(salary);
                adPanel.Controls.Add(currDate);
                adPanel.Size = new Size(537, 100);
                adPanel.Name = "adPanel" + ProsthikiAggelias.ads;
                adPanel.Location = new Point(3, ProsthikiAggelias.lastPos);
                ProsthikiAggelias.lastPos += 106;
                ProsthikiAggelias.ads++;
                aggeliesPanel.Controls.Add(adPanel);
                adPanel.Show();

            }

            conn.Close();

        }

        private void mainPanel_MouseEnter(object sender, EventArgs e)
        {

        }

        private void aggeliesPanel_MouseEnter(object sender, EventArgs e)
        {
            aggeliesPanel.Focus();
        }

        private void userAggeliesPanel_MouseEnter(object sender, EventArgs e)
        {
            userAggeliesPanel.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            loginPanel.Visible = false;
            myFavoritesPanel.Visible = false;
            registerPanel.Visible = false;
            userAggeliesFrame.Visible = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {



            mainPanel.Visible = false;
            loginPanel.Visible = false;
            userAggeliesFrame.Visible = false;
            registerPanel.Visible = false;
            myFavoritesPanel.Visible = true;


            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("getfavorites", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(userid);

            NpgsqlDataReader dr = cmd.ExecuteReader();
            ArrayList favids = new ArrayList();
            int i = 0;
            while (dr.Read())
            {
                favids.Add(dr.GetInt32(0));


            }
            conn.Close();

            for (i = 0; i < favids.Count; i++)
            {

                NpgsqlConnection conn2 = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
                conn2.Open();


                NpgsqlCommand cmd2 = new NpgsqlCommand("getads", conn2);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue(favids[i]);

                NpgsqlDataReader dr2 = cmd2.ExecuteReader();


                int lastPos = 3;
                int ads = 0;
                while (dr2.Read())
                {
                    int val = dr2.GetInt32(4);
                    myFavoritesAdPanel.Controls.Clear();
                    ads++;
                    Panel adPanel = new Panel();
                    Label title, description, salary, currDate;
                    adPanel.BackColor = SystemColors.Highlight;
                    title = new Label();
                    description = new Label();
                    salary = new Label();
                    currDate = new Label();
                    title.Text = dr2.GetString(2);
                    title.AutoSize = true;
                    title.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
                    title.Location = new Point(3, 9);
                    title.Name = "adTitle" + ads;
                    title.Size = new Size(163, 16);
                    description.Text = dr2.GetString(3);
                    description.AutoSize = true;
                    description.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    description.Location = new Point(3, 35);
                    description.Name = "adDescription" + ads;
                    description.MaximumSize = new Size(520, 0);
                    description.Size = new Size(477, 32);
                    salary.Text = "Μισθός " + val.ToString();
                    salary.AutoSize = true;
                    salary.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                    salary.Location = new Point(435, 9);
                    salary.Name = "adSalary" + ads;
                    salary.Size = new Size(99, 16);
                    currDate.Text = "date";
                    currDate.AutoSize = true;
                    currDate.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                    currDate.Location = new Point(462, 67);
                    currDate.Name = "adCurrDate" + ads;
                    currDate.Size = new Size(72, 16);
                    adPanel.Controls.Add(title);
                    adPanel.Controls.Add(description);
                    adPanel.Controls.Add(salary);
                    adPanel.Controls.Add(currDate);
                    adPanel.Size = new Size(537, 100);
                    adPanel.Name = "adPanel" + ads;
                    adPanel.Location = new Point(3, lastPos);
                    lastPos += 106;
                    myFavoritesAdPanel.Controls.Add(adPanel);
                    adPanel.Show();


                }
                conn2.Close();
            }

        }

        private void registerNavButton_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            loginPanel.Visible = false;
            userAggeliesFrame.Visible = false;
            myFavoritesPanel.Visible = false;
            registerPanel.Visible = true;
        }
    }
}
