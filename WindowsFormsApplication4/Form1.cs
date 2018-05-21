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
    public partial class Form1 : Form
    {

        public List<string> today_birthday_ids;
        //public FacebookClient fb;
        //public Boolean connected = false; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LoginForm frm = new LoginForm();
            
           // tabControl1.Enabled = false;
            //checkBox1.Checked = false;

           label1.Text += DateTime.Now.ToString("dd-MM-yyyy");


        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginForm.connected)
            {
                string post_content = textBox1.Text;
                LoginForm.fb.PostToWall(post_content);
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show(LoginForm.fb.get_fb_dtsg());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String id = textBox2.Text;
            String message = textBox3.Text;
            LoginForm.fb.sendMessageToUser(id, message);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LoginForm.fb.get_my_user_id());



        }

        void SaveData()
        {
            for (int i = 0; i < 500; i++)
            {
                Thread.Sleep(10);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(fb.get_birthday_key());
            Cursor.Current = Cursors.WaitCursor;
            //fb.ParseICS();

            using (Loading frm = new Loading(SaveData)) {
                LoginForm.fb.download_ics();
                frm.ShowDialog(this);
                button6.PerformClick();
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Remove old rows
            dataGridView1.Rows.Clear();

            string date_today = DateTime.Now.ToString("dd-MM-yyyy");
            //string date_today = "21-06-2018";

            //get new rows
            today_birthday_ids = new List<string>();
            foreach (friend item in LoginForm.fb.myfriends)

            {
                if (item.friend_date == date_today)
                {
                    dataGridView1.Rows.Add(item.friend_name, item.friend_id, item.friend_date);
                    today_birthday_ids.Add(item.friend_id);
                }

                else
                {
                    continue;
                }
                
            }

            if (today_birthday_ids.Count == 0)
                MessageBox.Show("You don't have any birthday today", "No Birthdays Today", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string message_content = textBox4.Text;
            foreach (var item in today_birthday_ids)
            {
                LoginForm.fb.sendMessageToUser(item, message_content);
            }
            MessageBox.Show("Messages Sent Successfully" , "Done!" , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How To Send Birthday Wishes :\n\n1) Click On \"Today Birthday List\" Button\n2) Write Your Birthday Message\n3) Click On \"Send Birthday Wishes To All\"", "Help", MessageBoxButtons.OK , MessageBoxIcon.Question);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/ademkouki_/");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/AdemKouki.Officiel");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        
            System.Diagnostics.Process.Start("https://github.com/Ademking/");

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        
            System.Diagnostics.Process.Start("https://about.me/AdemKouki");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
