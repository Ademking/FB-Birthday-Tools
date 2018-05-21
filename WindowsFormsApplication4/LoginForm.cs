using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mmosoft.Facebook.Sdk;
using Mmosoft.Facebook.Sdk.Exceptions;
using System.Collections.Generic;
using Mmosoft.Facebook.Sdk.Utilities;
using Mmosoft.Facebook.Sdk.Models;
using HtmlAgilityPack;
using System.Net;
using static Mmosoft.Facebook.Sdk.FacebookClient;
using System.Threading;

namespace WindowsFormsApplication4
{
    public partial class LoginForm : Form
    {
        public static FacebookClient fb;
        public static Boolean connected = false;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About The Program : \n\n Send Birthday Wishes to all of your friends in just one click \n\nBy AdemKouki\nEmail : ademkingnew@gmail.com", "About Me", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string myusername = textBox1.Text;
            string mypassword = textBox2.Text;

            try
            {
                fb = new FacebookClient(user: myusername, password: mypassword);
                MessageBox.Show("You Have Successfully Connected ! Welcome", "Great", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connected = true;
                //textBox1.Enabled = true;
                Form1 frm = new Form1();
                frm.ShowDialog();
            }
            catch (Mmosoft.Facebook.Sdk.Exceptions.UnAuthorizedException exp)
            {
                MessageBox.Show("Error While Connecting...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pictureBox7_Click(this.pictureBox7, null);
            }
        }
    }
}
