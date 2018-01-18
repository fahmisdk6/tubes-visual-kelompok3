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
    public partial class FormRute : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost; UID=root; Pwd=; database=database");
        public FormRute()
        {
            InitializeComponent();
        try
        {
            conn.Open();
            initData();
        }
             catch (Exception ex)
        {
            MessageBox.Show("Failed with error : " + ex.Message);
        }
        }

        private void initData()
        {
            string query = "Select * from rute";
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }


        private void FormRute_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO rute (id, nama_rute, halte_asal, halte_tujuan) VALUES('" + textBox1.Text.ToString() + "', '" + textBox2.Text.ToString() + "'" +
                    ", '" + comboBox1.GetItemText(this.comboBox1.SelectedItem) + "' , '" +comboBox1.GetItemText(this.comboBox1.SelectedItem)+ "' )";
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, conn);

            //Execute command
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambahkan");
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedItem = 0;
                initData();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Gagal : " + ex.Message);
            }
        }
    }
}
