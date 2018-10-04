namespace FirstProjectMySQL
{
    partial class AddAccount
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
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelPasswordUlang = new System.Windows.Forms.Label();
            this.textUlangPassword = new System.Windows.Forms.TextBox();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.buttonTambah = new System.Windows.Forms.Button();
            this.buttonBatal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textUsername
            // 
            this.textUsername.Enabled = false;
            this.textUsername.Location = new System.Drawing.Point(163, 51);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(100, 20);
            this.textUsername.TabIndex = 0;
            // 
            // textPassword
            // 
            this.textPassword.Enabled = false;
            this.textPassword.Location = new System.Drawing.Point(163, 77);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(100, 20);
            this.textPassword.TabIndex = 1;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(44, 54);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "Username";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(44, 80);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password";
            // 
            // labelPasswordUlang
            // 
            this.labelPasswordUlang.AutoSize = true;
            this.labelPasswordUlang.Location = new System.Drawing.Point(44, 106);
            this.labelPasswordUlang.Name = "labelPasswordUlang";
            this.labelPasswordUlang.Size = new System.Drawing.Size(86, 13);
            this.labelPasswordUlang.TabIndex = 4;
            this.labelPasswordUlang.Text = "Ulangi Password";
            // 
            // textUlangPassword
            // 
            this.textUlangPassword.Enabled = false;
            this.textUlangPassword.Location = new System.Drawing.Point(163, 103);
            this.textUlangPassword.Name = "textUlangPassword";
            this.textUlangPassword.PasswordChar = '*';
            this.textUlangPassword.Size = new System.Drawing.Size(100, 20);
            this.textUlangPassword.TabIndex = 5;
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.Enabled = false;
            this.buttonSimpan.Location = new System.Drawing.Point(94, 180);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(75, 23);
            this.buttonSimpan.TabIndex = 6;
            this.buttonSimpan.Text = "Simpan";
            this.buttonSimpan.UseVisualStyleBackColor = true;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // buttonTambah
            // 
            this.buttonTambah.Location = new System.Drawing.Point(13, 180);
            this.buttonTambah.Name = "buttonTambah";
            this.buttonTambah.Size = new System.Drawing.Size(75, 23);
            this.buttonTambah.TabIndex = 8;
            this.buttonTambah.Text = "Tambah";
            this.buttonTambah.UseVisualStyleBackColor = true;
            this.buttonTambah.Click += new System.EventHandler(this.buttonTambah_Click);
            // 
            // buttonBatal
            // 
            this.buttonBatal.Enabled = false;
            this.buttonBatal.Location = new System.Drawing.Point(175, 180);
            this.buttonBatal.Name = "buttonBatal";
            this.buttonBatal.Size = new System.Drawing.Size(75, 23);
            this.buttonBatal.TabIndex = 9;
            this.buttonBatal.Text = "Batal";
            this.buttonBatal.UseVisualStyleBackColor = true;
            this.buttonBatal.Click += new System.EventHandler(this.buttonBatal_Click);
            // 
            // AddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 215);
            this.ControlBox = false;
            this.Controls.Add(this.buttonBatal);
            this.Controls.Add(this.buttonTambah);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.textUlangPassword);
            this.Controls.Add(this.labelPasswordUlang);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Account";
            this.Load += new System.EventHandler(this.AddAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelPasswordUlang;
        private System.Windows.Forms.TextBox textUlangPassword;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Button buttonTambah;
        private System.Windows.Forms.Button buttonBatal;
    }
}

