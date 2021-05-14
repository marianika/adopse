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
using NpgsqlTypes;

namespace adopse
{
    public partial class MainFrame : Form
    {
        static public int userid = 0;
        
        private Panel selectedUserAd, selectedFavoriteAd, selectedSearchAd = null;
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
            createAdPanel.Visible = false;
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
            createAdPanel.Visible = false;
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

        private void editAdButton_Click(object sender, EventArgs e)
        {
            foreach(Control c in selectedUserAd.Controls)
            {
                if (c.Name.StartsWith("adTitle"))
                {
                    adTitle.Text = c.Text;
                    adTitle.Name = new String(c.Name.Where(Char.IsDigit).ToArray());
                }
                else if (c.Name.StartsWith("adDescription"))
                    adDescription.Text = c.Text;
                else if (c.Name.StartsWith("adSalary"))
                    adSalary.Text = c.Text;
            }
            createAd.Text = "Επεξεργασία";
            selectedUserAd.BackColor = Color.LightSkyBlue;
            selectedUserAd = null;
            userAggeliesFrame.Visible = false;
            createAdPanel.Visible = true;
        }

        private void addToFavorites_Click(object sender, EventArgs e)
        {
            // selectedSearchAd is the selected panel
            selectedSearchAd.BackColor = Color.LightSkyBlue;
            selectedSearchAd = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (String.Equals(loginNav.Name, "logout"))
            {
                userid = 0;
                myAggeliesNav.Visible = false;
                myFavoritesNav.Visible = false;
                userAggeliesFrame.Visible = false;
                myFavoritesPanel.Visible = false;
                addToFavoritesButton.Visible = false;
                createAdPanel.Visible = false;
                loginNav.Text = "Σύνδεση";
                loginNav.Name = "login";
                loginPanel.Visible = false;
                mainPanel.Visible = true;
                mainPanel.Focus();
                return;
            }
            mainPanel.Visible = false;
            userAggeliesFrame.Visible = false;
            myFavoritesPanel.Visible = false;
            registerPanel.Visible = false;
            createAdPanel.Visible = false;
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


            while (dr.Read())
            {
                userid = dr.GetInt32(0);
                if (userid != 0)
                {
                    profileLabel.Text = dr.GetString(3);
                    myAggeliesNav.Visible = true;
                    myFavoritesNav.Visible = true;
                    addToFavoritesButton.Visible = true;
                    loginNav.Text = "Αποσύνδεση";
                    loginNav.Name = "logout";
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

            //shows an window if the inserted tag finds a match
            while (dr.Read())
            {
                int val = dr.GetInt32(4);
                int adId = 0;
                Panel adPanel = new Panel();
                Label title, description, salary, currDate;
                adPanel.BackColor = System.Drawing.Color.LightSkyBlue;
                adPanel.Name = adId.ToString();
                adPanel.Click += new System.EventHandler(this.adPanel_Click);
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

        private void adPanel_Click(object sender, EventArgs e)
        {
            if (selectedSearchAd != null)
            {
                selectedSearchAd.BackColor = Color.LightSkyBlue;
                selectedSearchAd = null;
            }
            selectedSearchAd = (Panel)sender;
            selectedSearchAd.BackColor = SystemColors.Highlight;
        }

        private void userAdPanel_Click(object sender, EventArgs e)
        {
            if (selectedUserAd != null)
            {
                selectedUserAd.BackColor = Color.LightSkyBlue;
                selectedUserAd = null;
            }
            selectedUserAd = (Panel)sender;
            selectedUserAd.BackColor = SystemColors.Highlight;
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
            createAdPanel.Visible = false;

            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("getmyads", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(userid);

            NpgsqlDataReader dr = cmd.ExecuteReader();
            int lastPos = 3;
            userAggeliesPanel.Controls.Clear();
            while (dr.Read())
            {

                if (dr.IsDBNull(0))
                {
                }
                else
                {
                    int db_id = dr.GetInt32(0);
                    int db_com_id = dr.GetInt32(1);
                    string db_title = dr.GetString(2);
                    string db_description = dr.GetString(3);
                    int db_salary = dr.GetInt32(4);
                    NpgsqlDate db_date = dr.GetDate(5);
                    string db_tags = dr.GetString(6);
                    Panel adPanel = new Panel();
                    Label title, description, salary, currDate;
                    adPanel.BackColor = Color.LightSkyBlue;
                    adPanel.Click += new System.EventHandler(this.userAdPanel_Click);
                    title = new Label();
                    description = new Label();
                    salary = new Label();
                    currDate = new Label();
                    title.Text = db_title;
                    title.AutoSize = true;
                    title.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
                    title.Location = new Point(3, 9);
                    title.Name = "adTitle" + db_id;
                    title.Size = new Size(163, 16);
                    description.Text = db_description;
                    description.AutoSize = true;
                    description.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    description.Location = new Point(3, 35);
                    description.Name = "adDescription" + db_id;
                    description.MaximumSize = new Size(520, 0);
                    description.Size = new Size(477, 32);
                    salary.Text = "Μισθός " + db_salary.ToString();
                    salary.AutoSize = true;
                    salary.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                    salary.Location = new Point(435, 9);
                    salary.Name = "adSalary" + db_id;
                    salary.Size = new Size(99, 16);
                    currDate.Text = db_date.ToString();
                    currDate.AutoSize = true;
                    currDate.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                    currDate.Location = new Point(462, 67);
                    currDate.Name = "adCurrDate" + db_id;
                    currDate.Size = new Size(72, 16);
                    adPanel.Controls.Add(title);
                    adPanel.Controls.Add(description);
                    adPanel.Controls.Add(salary);
                    adPanel.Controls.Add(currDate);
                    adPanel.Size = new Size(537, 100);
                    adPanel.Name = "adPanel" + db_com_id;
                    adPanel.Location = new Point(3, lastPos);
                    lastPos += 106;
                    userAggeliesPanel.Controls.Add(adPanel);
                    adPanel.Show();
                }
            }

            conn.Close();

            userAggeliesFrame.Visible = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           


            mainPanel.Visible = false;
            loginPanel.Visible = false;
            userAggeliesFrame.Visible = false;
            registerPanel.Visible = false;
            createAdPanel.Visible = false;
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
                
                if (dr.IsDBNull(0))
                {
                  
                }
                else
                {
                    favids.Add(dr.GetInt32(0));
                }
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
                        adPanel.BackColor = Color.LightSkyBlue;
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
            createAdPanel.Visible = false;
            registerPanel.Visible = true;
        }

        /* Credits: https://stackoverflow.com/a/1592899
         * Because WinForms don't bubble up events i can't simply put a MouseDown event handler
         * in MainFrame because all the panels are stacked upon it so it doesn't fire up
         * so i chose topBar panel which is the most empty panel so the dragging works only from the topBar
         */
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void topBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void createAdButton_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            loginPanel.Visible = false;
            userAggeliesFrame.Visible = false;
            myFavoritesPanel.Visible = false;
            registerPanel.Visible = false;
            createAdPanel.Visible = true;
        }

        private void createAd_Click(object sender, EventArgs e)
        {
            if(createAd.Text.Equals("Επεξεργασία"))
            {
                createAd.Text = "Δημιουργία";
                createAdPanel.Visible = false;
                mainPanel.Visible = true;
                mainPanel.Focus();
                return;
            }
            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("createads", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(userid);
            cmd.Parameters.AddWithValue(adTitle.Text);
            cmd.Parameters.AddWithValue(adDescription.Text);
            cmd.Parameters.AddWithValue(Int32.Parse(adSalary.Text));
            cmd.Parameters.AddWithValue(new NpgsqlDate(DateTime.Now.Date));
            cmd.Parameters.AddWithValue(adTags.SelectedItem.ToString());

            cmd.ExecuteReader();

            conn.Close();

            createAdPanel.Visible = false;
            mainPanel.Visible = true;
            mainPanel.Focus();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            int number = maxnum() + 1;


            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();



            NpgsqlCommand cmd = new NpgsqlCommand("reguser", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(number);
            cmd.Parameters.AddWithValue(email.Text);
            cmd.Parameters.AddWithValue(password.Text);
            cmd.Parameters.AddWithValue(firstName.Text);
            cmd.Parameters.AddWithValue(lastName.Text);                      
            cmd.Parameters.AddWithValue(phone.Text);
            cmd.Parameters.AddWithValue(birthDate.Text);
            cmd.Parameters.AddWithValue(city.Text);
            cmd.Parameters.AddWithValue(gender.Text);
            cmd.Parameters.AddWithValue(username.Text);
            cmd.Parameters.AddWithValue(userType.Text);

            NpgsqlDataReader dr = cmd.ExecuteReader();

            conn.Close();

        }

        //gets last user id
        static int maxnum()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();


            int num = 0;
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
