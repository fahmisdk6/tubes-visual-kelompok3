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
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            MySqlCommand cmd = new MySqlCommand("SELECT *FROM user where username = '" + username + "' and password = '"+ password + "'", conn);
            MySqlDataReader read = cmd.ExecuteReader();
            bool found = false;
            while (read.Read())
            {
                string role = read.GetString("role");
                string message = "Login berhasil:\n";
                if(role == "admin")
                {
                    var home = new Form2();
                    home.Show();
                }
                else
                {
                    var jadwal = new FormLihatJadwal(read.GetInt32("user_id"));
                    jadwal.Show();
                }
                read.Close();
                return;
            }

            read.Close();
            MessageBox.Show("Login Tidak Behasil mohon di cek username dan password");
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
            var register = new FormRegister();
            register.Show();
        }
    }
}
