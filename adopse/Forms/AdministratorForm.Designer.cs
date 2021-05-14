
namespace adopse.Forms
{
    partial class AdministratorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.used_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.usersTable = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.logFilesTable = new System.Windows.Forms.DataGridView();
            this.AddModeratorButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logFilesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label2.Location = new System.Drawing.Point(1098, 490);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 29);
            this.label2.TabIndex = 44;
            this.label2.Text = "User List";
            // 
            // used_id
            // 
            this.used_id.Location = new System.Drawing.Point(1364, 635);
            this.used_id.Name = "used_id";
            this.used_id.Size = new System.Drawing.Size(100, 20);
            this.used_id.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1388, 595);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "users id";
            // 
            // usersTable
            // 
            this.usersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersTable.Location = new System.Drawing.Point(990, 522);
            this.usersTable.Name = "usersTable";
            this.usersTable.Size = new System.Drawing.Size(343, 285);
            this.usersTable.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label4.Location = new System.Drawing.Point(1329, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 29);
            this.label4.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label3.Location = new System.Drawing.Point(1141, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 29);
            this.label3.TabIndex = 46;
            this.label3.Text = "Log Files";
            // 
            // logFilesTable
            // 
            this.logFilesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logFilesTable.Location = new System.Drawing.Point(935, 82);
            this.logFilesTable.Name = "logFilesTable";
            this.logFilesTable.Size = new System.Drawing.Size(545, 376);
            this.logFilesTable.TabIndex = 45;
            // 
            // AddModeratorButton
            // 
            this.AddModeratorButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.AddModeratorButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AddModeratorButton.Location = new System.Drawing.Point(1364, 676);
            this.AddModeratorButton.Name = "AddModeratorButton";
            this.AddModeratorButton.Size = new System.Drawing.Size(100, 39);
            this.AddModeratorButton.TabIndex = 48;
            this.AddModeratorButton.Text = "Add Moderator";
            this.AddModeratorButton.UseVisualStyleBackColor = false;
            this.AddModeratorButton.Click += new System.EventHandler(this.AddModeratorButton_Click);
            // 
            // AdministratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1588, 839);
            this.Controls.Add(this.AddModeratorButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.logFilesTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.used_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usersTable);
            this.Name = "AdministratorForm";
            this.Controls.SetChildIndex(this.usersTable, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.used_id, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.logFilesTable, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.AddModeratorButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.usersTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logFilesTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox used_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView usersTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView logFilesTable;
        private System.Windows.Forms.Button AddModeratorButton;
    }
}
