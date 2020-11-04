using BuisnesLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCWF
{
    public partial class LoginForm : Form
    {
        protected readonly IAuthManager _manager;
        public LoginForm(IAuthManager manager)
        {
            InitializeComponent();
            _manager = manager;
        }

        private void doLogin()
        {
            if (_manager.Login(txtUserName.Text, txtPassword.Text))
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Email or Password");
            }    
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                doLogin();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            doLogin();
        }
    }
}
