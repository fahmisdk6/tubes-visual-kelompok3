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
    public partial class FormHalte : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost; UID=root; Pwd=; database=database");
        public FormHalte()
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

        private void FormHalte_Load(object sender, EventArgs e)
        {

        }

        private void initData()
        {
            string query = "Select * from halte";
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO halte (kode_halte, nama, kota) VALUES('" + textBox1.Text.ToString() + "', '" + textBox2.Text.ToString() + "'" +
                ", '" + textBox3.Text.ToString() + "')";
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

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            string query = "Update halte set nama= '" + textBox2.Text.ToString() + "', kota= '" + textBox3.Text.ToString() + "' Where kode_halte ='" + textBox1.Text.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diubah");
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

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            string query = "delete from halte Where kode_halte ='" + textBox1.Text.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus");
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["kode_halte"].Value.ToString();
            textBox2.Text = row.Cells["nama"].Value.ToString();
            textBox3.Text = row.Cells["kota"].Value.ToString();
        }
    }
}
