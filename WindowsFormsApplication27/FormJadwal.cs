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
    public partial class FormJadwal : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost; UID=root; Pwd=; database=database");
        public FormJadwal()
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
            string query = "Select * from jadwal";
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["id_jadwal"].Value.ToString();
            textBox2.Text = row.Cells["tanggal_&_jam"].Value.ToString();
            textBox3.Text = row.Cells["id_rute"].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO jadwal (id_jadwal, tanggal_&_jam, id_rute) VALUES('" + textBox1.Text.ToString() + "', '" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "' )";
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, conn);

            //Execute command
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambahkan");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                initData();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Gagal : " + ex.Message);
            }
        }
    }
}
