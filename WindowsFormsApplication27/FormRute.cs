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
using MySql.Data;
using MySql.Data.MySqlClient;

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
                    ", '" + textBox3.Text.ToString() + "' , '" + textBox4.Text.ToString() + "' )";
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
                textBox4.Text = "";
                initData();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Gagal : " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "Update rute set id= '" + textBox1.Text.ToString() + "', halte_asal= '" + textBox3.Text.ToString() + "', halte_tujuan= '" + textBox4.Text.ToString() + "' Where nama_rute='" + textBox2.Text.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diubah");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
               
                initData();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Gagal : " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["id"].Value.ToString();
            textBox2.Text = row.Cells["nama_rute"].Value.ToString();
            textBox3.Text = row.Cells["halte_asal"].Value.ToString();
            textBox4.Text = row.Cells["halte_tujuan"].Value.ToString();
            //comboBox1.SelectedIndex = comboBox1.FindStringExact(tipe);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "delete from rute Where id ='" + textBox1.Text.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                initData();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Gagal : " + ex.Message);
            }
        }
    }
}
