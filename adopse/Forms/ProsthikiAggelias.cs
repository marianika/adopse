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
    public partial class ProsthikiAggelias : Form
    {
        public ProsthikiAggelias()
        {
            InitializeComponent();
        }

        public ProsthikiAggelias(Panel p)
        {
            this.aggeliesPanel = p;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel adPanel = new Panel();
            Label title, description, salary, currDate;
            adPanel.BackColor = System.Drawing.Color.LightSkyBlue;
            title = new Label();
            description = new Label();
            salary = new Label();
            currDate = new Label();
            title.Text = textBox1.Text;
            title.AutoSize = true;
            title.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            title.Location = new Point(3, 9);
            title.Name = "adTitle" + ProsthikiAggelias.ads;
            title.Size = new Size(163, 16);
            description.Text = textBox2.Text;
            description.AutoSize = true;
            description.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            description.Location = new Point(3, 35);
            description.Name = "adDescription" + ProsthikiAggelias.ads;
            description.MaximumSize = new Size(520, 0);
            description.Size = new Size(477, 32);
            salary.Text = "Μισθός: " + textBox3.Text + "€/ώρα";
            salary.AutoSize = true;
            salary.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            salary.Location = new Point(435, 9);
            salary.Name = "adSalary" + ProsthikiAggelias.ads;
            salary.Size = new Size(99, 16);
            currDate.Text = textBox4.Text;
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
    }
}
