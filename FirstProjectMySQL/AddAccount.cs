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
        public AddAccount()
        {
            InitializeComponent();
        }

        private void AddAccount_Load(object sender, EventArgs e)
        {

        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ObjStatus(bool status)
        {
            textUsername.Enabled = status;
            textPassword.Enabled = status;
            textUlangPassword.Enabled = status;
            buttonSimpan.Enabled = status;
            buttonTambah.Enabled = !status;
            buttonKeluar.Enabled = !status;
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            ObjStatus(true);
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            ObjStatus(false);
        }
    }
}
