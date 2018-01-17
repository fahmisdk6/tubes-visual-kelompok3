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
    public partial class FormBus : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost; UID=root; Pwd=; database=database");

        public FormBus()
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
            string query = "Select * from bus";
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void FormBus_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Kecil");
            comboBox1.Items.Add("Sedang");
            comboBox1.Items.Add("Besar");
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO bus (kode_bus, no_pol, tipe) VALUES('" + textBox1.Text.ToString() + "', '" + textBox2.Text.ToString() + "'" +
                ", '" + comboBox1.GetItemText(this.comboBox1.SelectedItem) +"')";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["kode_bus"].Value.ToString();
            textBox2.Text = row.Cells["no_pol"].Value.ToString();
            String tipe = row.Cells["tipe"].Value.ToString();
            comboBox1.SelectedIndex = comboBox1.FindStringExact(tipe);
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            string query = "Update bus set no_pol= '" + textBox2.Text.ToString() + "', tipe= '" + comboBox1.GetItemText(this.comboBox1.SelectedItem) + "' Where kode_bus ='" + textBox1.Text.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diubah");
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

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            string query = "delete from bus Where kode_bus ='" + textBox1.Text.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus");
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
