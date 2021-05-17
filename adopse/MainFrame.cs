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
using System.IO;

namespace adopse
{
    public partial class MainFrame : Form
    {
        public enum UserType
        {
            Guest,
            User,
            Employer,
            Moderator
        }

        public static int userid = 0;
        public static UserType type = 0;
        private static bool hasCompany = false;

        private Panel selectedUserAd, selectedFavoriteAd, selectedSearchAd, selectedAithma = null;
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
            userAggeliesPanel.AutoScroll = true;
            aithmataCVPanel.AutoScroll = false;
            aithmataCVPanel.HorizontalScroll.Enabled = false;
            aithmataCVPanel.HorizontalScroll.Visible = false;
            aithmataCVPanel.HorizontalScroll.Maximum = 0;
            aithmataCVPanel.AutoScroll = true;
            loginPanel.Visible = false;
            myFavoritesPanel.Visible = false;
            userAggeliesFrame.Visible = false;
            registerPanel.Visible = false;
            createAdPanel.Visible = false;
            viografikoPanel.Visible = false;
            rythmiseisPanel.Visible = false;
            aithmataPanel.Visible = false;
            loadAds();
        }

        private void loadAds()
        {
            selectedSearchAd = null;
            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM ads", conn);

            NpgsqlDataReader dr = cmd.ExecuteReader();
            int lastPos = 3;
            aggeliesPanel.Controls.Clear();
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
                    adPanel.Click += new System.EventHandler(this.adPanel_Click);
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
                    salary.Text = "Μισθός: " + db_salary.ToString() + "€";
                    salary.AutoSize = true;
                    salary.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                    salary.Location = new Point(440, 9);
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
                    adPanel.Size = new Size(500, 100);
                    adPanel.Name = "adPanel" + db_id;
                    adPanel.Location = new Point(3, lastPos);
                    lastPos += 106;
                    adPanel.AutoSize = true;
                    aggeliesPanel.Controls.Add(adPanel);
                    adPanel.Show();
                }
            }

            conn.Close();
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
            viografikoPanel.Visible = false;
            rythmiseisPanel.Visible = false;
            aithmataPanel.Visible = false;
            mainPanel.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (type != UserType.Employer)
                return;

            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();
            
            NpgsqlCommand cmd = new NpgsqlCommand("getcompany", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(userid);

            NpgsqlDataReader dr = cmd.ExecuteReader();

            hasCompany = false;
            if(dr.HasRows)
            {
                hasCompany = true;
                while(dr.Read())
                {
                    textboxEpwnymiaEpixeirhshs.Text = dr.GetString(2);
                    textboxIstotoposEpixeirhshs.Text = dr.GetString(3);
                    textboxEdraEpixeirhshs.Text = dr.GetString(4);
                    textboxTyposEpixeirhshs.Text = dr.GetString(5);
                    textboxArErgEpixeirhshs.Text = dr.GetInt32(6).ToString();
                }
            }

            conn.Close();

            mainPanel.Visible = false;
            loginPanel.Visible = false;
            userAggeliesFrame.Visible = false;
            myFavoritesPanel.Visible = false;
            registerPanel.Visible = false;
            createAdPanel.Visible = false;
            viografikoPanel.Visible = false;
            rythmiseisPanel.Visible = true;
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private string extractNumber(string str)
        {
            return new String(str.Where(Char.IsDigit).ToArray());
        }

        private void editAdButton_Click(object sender, EventArgs e)
        {
            foreach (Control c in selectedUserAd.Controls)
            {
                if (c.Name.StartsWith("adTitle"))
                {
                    adTitle.Text = c.Text;
                    adTitle.Name = extractNumber(c.Name);
                }
                else if (c.Name.StartsWith("adDescription"))
                    adDescription.Text = c.Text;
                else if (c.Name.StartsWith("adSalary"))
                    adSalary.Text = extractNumber(c.Text);
            }
            adTags.SetItemChecked(0, true);
            adTags.SetSelected(0, true);
            createAd.Text = "Επεξεργασία";
            selectedUserAd.BackColor = Color.LightSkyBlue;
            selectedUserAd = null;
            userAggeliesFrame.Visible = false;
            createAdPanel.Visible = true;
        }

        private void addToFavorites_Click(object sender, EventArgs e)
        {
            String pname = selectedSearchAd.Name;
            int val = Int32.Parse(extractNumber(pname));

            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();



            NpgsqlCommand cmd = new NpgsqlCommand("addfavorite", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(userid);
            cmd.Parameters.AddWithValue(val);


            NpgsqlDataReader dr = cmd.ExecuteReader();

            conn.Close();


            //selectedSearchAd is the selected panel
            selectedSearchAd.BackColor = Color.LightSkyBlue;
            selectedSearchAd = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (String.Equals(loginNav.Name, "logout"))
            {
                profileLabel.Text = "Επισκεπτης";
                userid = 0;
                type = UserType.Guest;
                myAggeliesNav.Visible = false;
                myFavoritesNav.Visible = false;
                aithmataNav.Visible = false;
                userAggeliesFrame.Visible = false;
                myFavoritesPanel.Visible = false;
                addToFavoritesButton.Visible = false;
                sendCVButton.Visible = false;
                createAdPanel.Visible = false;
                viografikoPanel.Visible = false;
                rythmiseisPanel.Visible = false;
                aithmataPanel.Visible = false;
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
            viografikoPanel.Visible = false;
            rythmiseisPanel.Visible = false;
            aithmataPanel.Visible = false;
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
                type = getUserType(dr.GetString(10));

                if (type > UserType.Guest)
                {
                    profileLabel.Text = dr.GetString(3);
                    myAggeliesNav.Visible = true;
                    myFavoritesNav.Visible = true;
                    addToFavoritesButton.Visible = true;
                    sendCVButton.Visible = true;
                    if (type == UserType.Employer)
                        aithmataNav.Visible = true;
                    loginNav.Text = "Αποσύνδεση";
                    loginNav.Name = "logout";
                    loginPanel.Visible = false;
                    mainPanel.Visible = true;
                    mainPanel.Focus();
                }

            }

            conn.Close();
        }

        private UserType getUserType(string v)
        {
            switch(v)
            {
                case "Εργαζόμενος": return UserType.User;
                case "Επιχείρηση": return UserType.Employer;
                case "moderator": return UserType.Moderator;
                default:
                    {
                        if (userid != 0)
                            return UserType.User;
                        return UserType.Guest;
                    }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            selectedSearchAd = null;
            if(searchTextBox.Text.Equals(""))
            {
                loadAds();
                return;
            }

            aggeliesPanel.Controls.Clear();
            int lastPos = 3;

            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("getadswithtags", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(searchTextBox.Text);

            NpgsqlDataReader dr = cmd.ExecuteReader();

            //shows an window if the inserted tag finds a match
            while (dr.Read())
            {
                int val = dr.GetInt32(4);
                Panel adPanel = new Panel();
                int adId = dr.GetInt32(0);
                NpgsqlDate db_date = dr.GetDate(5);
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
                title.Name = "adTitle";
                title.Size = new Size(163, 16);
                description.Text = dr.GetString(3);
                description.AutoSize = true;
                description.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
                description.Location = new Point(3, 35);
                description.Name = "adDescription";
                description.MaximumSize = new Size(520, 0);
                description.Size = new Size(477, 32);
                salary.Text = "Μισθός: " + val.ToString() + "€";
                salary.AutoSize = true;
                salary.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                salary.Location = new Point(440, 9);
                salary.Name = "adSalary";
                salary.Size = new Size(99, 16);
                currDate.Text = db_date.ToString();
                currDate.AutoSize = true;
                currDate.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                currDate.Location = new Point(462, 67);
                currDate.Name = "adCurrDate";
                currDate.Size = new Size(72, 16);
                adPanel.Controls.Add(title);
                adPanel.Controls.Add(description);
                adPanel.Controls.Add(salary);
                adPanel.Controls.Add(currDate);
                adPanel.Size = new Size(537, 100);
                adPanel.Location = new Point(3, lastPos);
                lastPos += 106;
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

        private void favAdPanel_Click(object sender, EventArgs e)
        {
            if (selectedFavoriteAd != null)
            {
                selectedFavoriteAd.BackColor = Color.LightSkyBlue;
                selectedFavoriteAd = null;
            }
            selectedFavoriteAd = (Panel)sender;
            selectedFavoriteAd.BackColor = SystemColors.Highlight;
        }

        private void aithmaPanel_Click(object sender, EventArgs e)
        {
            if (selectedAithma != null)
            {
                selectedAithma.BackColor = Color.LightSkyBlue;
                selectedAithma = null;
            }
            selectedAithma = (Panel)sender;
            selectedAithma.BackColor = SystemColors.Highlight;
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
            viografikoPanel.Visible = false;
            rythmiseisPanel.Visible = false;
            aithmataPanel.Visible = false;

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
                    salary.Text = "Μισθός: " + db_salary.ToString() + "€";
                    salary.AutoSize = true;
                    salary.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                    salary.Location = new Point(440, 9);
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
                    adPanel.Name = "adPanel" + db_id;
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
            viografikoPanel.Visible = false;
            rythmiseisPanel.Visible = false;
            aithmataPanel.Visible = false;
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
                    favids.Add(dr.GetInt32(1));
                }
            }

            conn.Close();

            int lastPos = 3;
            myFavoritesAdPanel.Controls.Clear();
            for (i = 0; i < favids.Count; i++)
            {
                NpgsqlConnection conn2 = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
                conn2.Open();

                NpgsqlCommand cmd2 = new NpgsqlCommand("getads", conn2);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue(favids[i]);

                NpgsqlDataReader dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    int ad_id = dr.GetInt32(0);
                    int val = dr2.GetInt32(4);
                    NpgsqlDate db_date = dr.GetDate(5);
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
                    title.Name = "adTitle" + ad_id;
                    title.Size = new Size(163, 16);
                    description.Text = dr2.GetString(3);
                    description.AutoSize = true;
                    description.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    description.Location = new Point(3, 35);
                    description.Name = "adDescription" + ad_id;
                    description.MaximumSize = new Size(520, 0);
                    description.Size = new Size(477, 32);
                    salary.Text = "Μισθός: " + val.ToString() + "€";
                    salary.AutoSize = true;
                    salary.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                    salary.Location = new Point(435, 9);
                    salary.Name = "adSalary" + ad_id;
                    salary.Size = new Size(99, 16);
                    currDate.Text = db_date.ToString();
                    currDate.AutoSize = true;
                    currDate.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                    currDate.Location = new Point(462, 67);
                    currDate.Name = "adCurrDate" + ad_id;
                    currDate.Size = new Size(72, 16);
                    adPanel.Controls.Add(title);
                    adPanel.Controls.Add(description);
                    adPanel.Controls.Add(salary);
                    adPanel.Controls.Add(currDate);
                    adPanel.Size = new Size(537, 100);
                    adPanel.Name = "adPanel" + ad_id;
                    adPanel.Location = new Point(3, lastPos);
                    adPanel.Click += new EventHandler(this.favAdPanel_Click);
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
            viografikoPanel.Visible = false;
            rythmiseisPanel.Visible = false;
            aithmataPanel.Visible = false;
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

            adTitle.Text = "";
            adDescription.Text = "";
            adSalary.Text = "";
            adTags.SetItemChecked(0, true);
            adTags.SetSelected(0, true);
            mainPanel.Visible = false;
            loginPanel.Visible = false;
            userAggeliesFrame.Visible = false;
            myFavoritesPanel.Visible = false;
            registerPanel.Visible = false;
            viografikoPanel.Visible = false;
            rythmiseisPanel.Visible = false;
            aithmataPanel.Visible = false;
            createAdPanel.Visible = true;
        }

        private void createAd_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();

            NpgsqlCommand cmd;

            if (createAd.Text.Equals("Επεξεργασία"))
            {

                // TODO: execute sql query for ad edit with functin updateads
                cmd = new NpgsqlCommand("updateads", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(Int32.Parse(adTitle.Name)); // ad id
                cmd.Parameters.AddWithValue(adTitle.Text);
                cmd.Parameters.AddWithValue(adDescription.Text);
                cmd.Parameters.AddWithValue(Int32.Parse(extractNumber(adSalary.Text)));
                cmd.Parameters.AddWithValue(new NpgsqlDate(DateTime.Now.Date));
                cmd.Parameters.AddWithValue(adTags.SelectedItem.ToString());

                cmd.ExecuteReader();

                conn.Close();

                createAd.Text = "Δημιουργία";
                createAdPanel.Visible = false;
                mainPanel.Visible = true;
                mainPanel.Focus();
                loadAds();
                return;
            }

            cmd = new NpgsqlCommand("createads", conn);

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
            loadAds();
        }

        private void deleteAdButton_Click(object sender, EventArgs e)
        {
            if (selectedUserAd == null)
                return;
            DialogResult dialog = MessageBox.Show("Θέλετε να διαγράψετε την επιλεγμένη αγγελία;", "JobFinder", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand("dropads", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(Int32.Parse(extractNumber(selectedUserAd.Name)));
                // FIXME: if i attempt to delete an ad that's been favorited, it will throw an exception because of foreign key relation
                cmd.ExecuteReader();

                conn.Close();

                selectedUserAd.Dispose();
                selectedUserAd = null;
            }
        }

        private void birthDate_Enter(object sender, EventArgs e)
        {
            if(birthDate.ForeColor == Color.Gray)
            {
                birthDate.Text = "";
                birthDate.ForeColor = Color.Black;
            }
        }

        private Button selectCVButton;
        private OpenFileDialog openFileDialog1;
        private TextBox CVTextBox;

        private void biografikoNav_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            loginPanel.Visible = false;
            userAggeliesFrame.Visible = false;
            myFavoritesPanel.Visible = false;
            registerPanel.Visible = false;
            createAdPanel.Visible = false;
            viografikoPanel.Visible = true;
        }

        private void selectCVButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse PDF Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "pdf",
                Filter = "PDF files (*.pdf)|*.pdf",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedCVTextBox.Text = openFileDialog1.FileName;
                byte[] pdfFile = File.ReadAllBytes(selectedCVTextBox.Text);

                NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand("addcv", conn);

                NpgsqlDate currDate = new NpgsqlDate(DateTime.Now.Date);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(userid);
                cmd.Parameters.AddWithValue(pdfFile);

                cmd.ExecuteReader();

                conn.Close();

                MessageBox.Show("Το βιογραφικό ανέβηκε επιτυχώς!");
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void downloadCVButton_Click(object sender, EventArgs e)
        {
            Stream fileStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((fileStream = saveFileDialog1.OpenFile()) != null)
                {
                    NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
                    conn.Open();

                    NpgsqlCommand cmd = new NpgsqlCommand("getcv", conn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(userid);

                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    
                    while (dr.Read())
                    {
                        long len = dr.GetBytes(0, 0, null, 0, 0);
                        byte[] buffer = new byte[len];
                        dr.GetBytes(0, 0, buffer, 0, (int) len);
                        fileStream.Write(buffer, 0, (int) len);
                    }
                    fileStream.Close();
                }
            }
        }

        private void deleteFavAdButton_Click(object sender, EventArgs e)
        {
            if (selectedFavoriteAd == null)
                return;
            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("dropfavorite", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(userid);
            cmd.Parameters.AddWithValue(Int32.Parse(extractNumber(selectedFavoriteAd.Name)));

            cmd.ExecuteReader();

            conn.Close();

            selectedFavoriteAd.Dispose();
            selectedFavoriteAd = null;
        }

        private void sendCVButton_Click(object sender, EventArgs e)
        {
            if (selectedSearchAd == null)
                return;
            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("sendcv", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(userid);
            cmd.Parameters.AddWithValue(Int32.Parse(extractNumber(selectedSearchAd.Name)));

            cmd.ExecuteReader();

            conn.Close();

            MessageBox.Show("Το βιογραφικό σας στάλθηκε επιτυχώς!");
        }

        private void buttonProsthikiEnimerwshEpixeirhshs_Click(object sender, EventArgs e)
        {
            if(textboxEpwnymiaEpixeirhshs.Equals(""))
            {
                MessageBox.Show("Παρακαλώ συμπληρώστε όλα τα υποχρεωτικά πεδία!");
                return;
            }

            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();
            NpgsqlCommand cmd;

            if (hasCompany)
            {
                cmd = new NpgsqlCommand("updatecompany", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(userid);
                cmd.Parameters.AddWithValue(textboxEpwnymiaEpixeirhshs.Text);
                cmd.Parameters.AddWithValue(textboxIstotoposEpixeirhshs.Text);
                cmd.Parameters.AddWithValue(textboxEdraEpixeirhshs.Text);
                cmd.Parameters.AddWithValue(textboxTyposEpixeirhshs.Text);
                cmd.Parameters.AddWithValue(Int32.Parse(textboxArErgEpixeirhshs.Text));

                cmd.ExecuteNonQuery();
            } else
            {
                cmd = new NpgsqlCommand("addcompany", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(userid);
                cmd.Parameters.AddWithValue(textboxEpwnymiaEpixeirhshs.Text);
                cmd.Parameters.AddWithValue(textboxIstotoposEpixeirhshs.Text);
                cmd.Parameters.AddWithValue(textboxEdraEpixeirhshs.Text);
                cmd.Parameters.AddWithValue(textboxTyposEpixeirhshs.Text);
                cmd.Parameters.AddWithValue(Int32.Parse(textboxArErgEpixeirhshs.Text));

                cmd.ExecuteNonQuery();
            }

            conn.Close();

            MessageBox.Show("Τα στοιχεία σας ενημερώθηκαν επιτυχώς!");
        }

        private void aithmaDownloadPDF_Click(object sender, EventArgs e)
        {
            Stream fileStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((fileStream = saveFileDialog1.OpenFile()) != null)
                {
                    NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
                    conn.Open();

                    NpgsqlCommand cmd = new NpgsqlCommand("getcv", conn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(Int32.Parse(extractNumber(selectedAithma.Name)));

                    NpgsqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        long len = dr.GetBytes(0, 0, null, 0, 0);
                        byte[] buffer = new byte[len];
                        dr.GetBytes(0, 0, buffer, 0, (int)len);
                        fileStream.Write(buffer, 0, (int)len);
                    }
                    fileStream.Close();
                }
            }
        }

        private void aithmataButton_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            loginPanel.Visible = false;
            myFavoritesPanel.Visible = false;
            registerPanel.Visible = false;
            createAdPanel.Visible = false;
            viografikoPanel.Visible = false;
            rythmiseisPanel.Visible = false;
            aithmataPanel.Visible = true;

            NpgsqlConnection conn = new NpgsqlConnection("Server=dblabs.it.teithe.gr;port=5432;Database=it185244;User Id=it185244;Password=adopse21");
            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("getmyaithmata", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(userid);

            NpgsqlDataReader dr = cmd.ExecuteReader();
            int lastPos = 3;
            aithmataCVPanel.Controls.Clear();
            while (dr.Read())
            {

                if (dr.IsDBNull(0))
                {
                }
                else
                {
                    int u_id = dr.GetInt32(0);
                    string db_firstName = dr.GetString(1);
                    string db_lastName = dr.GetString(2);
                    string db_gender = dr.GetString(3);
                    string db_city = dr.GetString(4);
                    string db_phone = dr.GetString(5);
                    NpgsqlDate db_birthDate = dr.GetDate(6);

                    Panel adPanel = new Panel();
                    adPanel.BackColor = Color.LightSkyBlue;
                    adPanel.Click += new System.EventHandler(this.aithmaPanel_Click);
                    Label name = new Label();
                    Label gender = new Label();
                    Label city = new Label();
                    Label phone = new Label();
                    Label birthDate = new Label();
                    name.Text = db_lastName + " " + db_firstName;
                    name.AutoSize = true;
                    name.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
                    name.Location = new Point(206, 13);
                    name.Name = "adName" + u_id;
                    name.Size = new Size(113, 16);
                    gender.Text = (db_gender == "M") ? "Αρρεν" : "Θηλυ";
                    gender.AutoSize = true;
                    gender.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    gender.Location = new Point(206, 70);
                    gender.Name = "adGender" + u_id;
                    gender.Size = new Size(95, 16);
                    city.Text = "Πόλη: " + db_city;
                    city.AutoSize = true;
                    city.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                    city.Location = new Point(206, 43);
                    city.Name = "adCity" + u_id;
                    city.Size = new Size(127, 16);
                    phone.Text = "Τηλέφωνο: " + db_phone;
                    phone.AutoSize = true;
                    phone.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                    phone.Location = new Point(4, 43);
                    phone.Name = "adPhone" + u_id;
                    phone.Size = new Size(147, 16);
                    birthDate.Text = "Ημ. Γέννησης: " + db_birthDate.ToString();
                    birthDate.AutoSize = true;
                    birthDate.Font = new Font("Microsoft Sans Serif", 9.75F);
                    birthDate.Location = new Point(4, 70);
                    birthDate.Name = "adDate" + u_id;
                    birthDate.Size = new Size(159, 16);
                    adPanel.Controls.Add(name);
                    adPanel.Controls.Add(gender);
                    adPanel.Controls.Add(city);
                    adPanel.Controls.Add(phone);
                    adPanel.Controls.Add(birthDate);
                    adPanel.Size = new Size(537, 100);
                    adPanel.Name = "adPanel" + u_id;
                    adPanel.Location = new Point(3, lastPos);
                    lastPos += 106;
                    aithmataCVPanel.Controls.Add(adPanel);
                    adPanel.Show();
                }
            }

            conn.Close();
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
            cmd.Parameters.AddWithValue(userTypeComboBox.Text);

            NpgsqlDataReader dr = cmd.ExecuteReader();

            conn.Close();

            registerPanel.Visible = false;
            loginPanel.Visible = true;
            loginPanel.Focus();
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
