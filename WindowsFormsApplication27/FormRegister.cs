using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication27
{
    public partial class FormRegister : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost; UID=root; Pwd=; " +
    "database=database;");
        public FormRegister()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string username = textBox1.Text;
            string firstname = textBox2.Text;
            string lastname = textBox3.Text;
            string password = textBox4.Text;
            MySqlCommand cmd = new MySqlCommand("SELECT *FROM user", conn);
            MySqlDataReader read = cmd.ExecuteReader();
            bool found = false;
            while (read.Read())
            {

                int id = read.GetInt32("user_id");
                string user = read.GetString("username").ToLower();
                string first = read.GetString("firstname");
                string last = read.GetString("lastname");
                string pass = read.GetString("password");
                string role = read.GetString("role");

                if (username == user && password == pass)
                {
                    found = true;
                    string message = "Okay Anda berhasil mendaftar:\n";
                    /*message += "user_id: " + id + "\n";
                    message += "username: " + user + "\n";
                    message += "firstname: " + first + "\n";
                    message += "lastname: " + last + "\n";
                    message += "password: " + pass + "\n";
                    message += "role: " + roles + "\n";
                    */
                    var home = new FormRegister();
                    home.Show();
                    //this.Hide();


                    //MessageBox.Show(message);
                }
        }
    }

        private void button2_Click(object sender, EventArgs e)
        {
        this.Close();
        }
}
