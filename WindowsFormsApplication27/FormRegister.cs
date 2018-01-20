using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication27
{
    public partial class FormRegister : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost; UID=root; Pwd=; database=database");

        public FormRegister()
        {
            InitializeComponent();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed with error : " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO user (username, password, firstname, lastname, role) VALUES('" + textBox1.Text.ToString() + "', '" + textBox2.Text.ToString() + "'" +
                ", '" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() +"','user')";
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, conn);

            //Execute command
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registrasi berhasil");
                Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Gagal : " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
