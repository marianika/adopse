
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
            ((System.ComponentModel.ISupportInitialize)(this.usersTable)).BeginInit();
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
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 599);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.used_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usersTable);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.usersTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView usersTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox used_id;
        private System.Windows.Forms.Button AddButton;
    }
}