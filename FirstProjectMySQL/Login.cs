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
    public partial class Login : Form
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

        public Login()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Username = textUsername.Text;
            Password = textPassword.Text;

            string username = DatabaseClass.ExecSQL("username", "account", "username='" + Username + "' AND password =MD5('" + Password + "')");
            if (username == null)
            {
                MessageBox.Show("Password Salah");
            }
            else
            {
                (new AddAccount()).Show();
                this.Hide();

            }
        }
    }
}
