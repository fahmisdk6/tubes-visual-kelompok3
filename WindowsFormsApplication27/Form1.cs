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
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost; UID=root; Pwd=; " +
    "database=database;");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string username = textBox1.Text;
            string password = textBox2.Text;
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
                    string message = "Login berhasil:\n";
                    /*message += "user_id: " + id + "\n";
                    message += "username: " + user + "\n";
                    message += "firstname: " + first + "\n";
                    message += "lastname: " + last + "\n";
                    message += "password: " + pass + "\n";
                    message += "role: " + roles + "\n";
                    */
                    var home = new Form2();
                    home.Show();
                    //this.Hide();


                    //MessageBox.Show(message);
                }



                if (found == false)
                {
                    MessageBox.Show("Login Tidak Behasil mohon di cek username dan password");
                }

            }
            conn.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tombol daftar diklik");
        }
    }
}
