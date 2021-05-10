
namespace adopse.Forms
{
    partial class AdminForm
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
            this.usersTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.used_id = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.logFilesTable = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.usersTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logFilesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // usersTable
            // 
            this.usersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersTable.Location = new System.Drawing.Point(57, 65);
            this.usersTable.Name = "usersTable";
            this.usersTable.Size = new System.Drawing.Size(343, 376);
            this.usersTable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 488);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "users id";
            // 
            // used_id
            // 
            this.used_id.Location = new System.Drawing.Point(197, 481);
            this.used_id.Name = "used_id";
            this.used_id.Size = new System.Drawing.Size(100, 20);
            this.used_id.TabIndex = 2;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(197, 523);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(100, 39);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add Moderator";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // logFilesTable
            // 
            this.logFilesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logFilesTable.Location = new System.Drawing.Point(433, 65);
            this.logFilesTable.Name = "logFilesTable";
            this.logFilesTable.Size = new System.Drawing.Size(545, 376);
            this.logFilesTable.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label2.Location = new System.Drawing.Point(143, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "List of Users";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label3.Location = new System.Drawing.Point(669, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Log Files";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 599);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logFilesTable);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.used_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usersTable);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.usersTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logFilesTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView usersTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox used_id;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridView logFilesTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}