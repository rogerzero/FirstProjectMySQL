using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstProjectMySQL
{
    public partial class AddAccount : Form
    {

        string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public AddAccount()
        {
            InitializeComponent();
        }

        private void AddAccount_Load(object sender, EventArgs e)
        {
            
        }
        
        private void ObjStatus(bool status)
        {
            textUsername.Enabled = status;
            textPassword.Enabled = status;
            textUlangPassword.Enabled = status;
            buttonSimpan.Enabled = status;
            buttonTambah.Enabled = !status;
            buttonBatal.Enabled = status;
            textUsername.Text = string.Empty;
            textPassword.Text = string.Empty;
            textUlangPassword.Text = string.Empty;
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            ObjStatus(true);
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {

            
            if (textPassword.Text != textUlangPassword.Text)
            {
                MessageBox.Show("Password tidak sama");
                return;
            }

            Username = textUsername.Text;
            Password = textPassword.Text;

            DatabaseClass.InsertSQL(
                "account",
                "idaccount, username, password, created_date",
                " 2, '" + Username + "', MD5('" + Password + "'), '" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss") + "'"
                );
            ObjStatus(false);
        }

        private void buttonBatal_Click(object sender, EventArgs e)
        {
            ObjStatus(false);
        }
    }
}
