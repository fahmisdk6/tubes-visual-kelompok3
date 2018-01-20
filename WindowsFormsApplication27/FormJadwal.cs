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
        List<String> bus = new List<string>();
        Dictionary<String, String> rute = new Dictionary<String, String>();
        MySqlConnection conn = new MySqlConnection("server=localhost; UID=root; Pwd=; database=database");
        public FormJadwal()
        {
            InitializeComponent();
            try
            {
                conn.Open();
                initData();
                initRute();
                initBus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed with error : " + ex.Message);
            }
        }


        void initRute()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Rute", conn);
            MySqlDataReader read = cmd.ExecuteReader();
            bool found = false;
            while (read.Read())
            {
                rute.Add(read.GetString("nama_rute"), read.GetString("id"));
                comboBox1.Items.Add(read.GetString("nama_rute"));
                
            }
            read.Close();
        }

        void initBus()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM bus", conn);
            MySqlDataReader read = cmd.ExecuteReader();
            bool found = false;
            while (read.Read())
            {
                bus.Add(read.GetString("kode_bus"));
                comboBox2.Items.Add(read.GetString("kode_bus"));
            }
            read.Close();
        }

        private void initData()
        {
            string query = "Select jadwal.id_jadwal , jadwal.waktu, rute.nama_rute , bus.kode_bus, jadwal.harga from jadwal, rute, bus where " +
                "jadwal.id_rute = rute.id and bus.kode_bus = jadwal.kode_bus";
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
            //textBox2.Text = row.Cells["tanggal_&_jam"].Value.ToString();
            //textBox3.Text = row.Cells["id_rute"].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO jadwal (waktu, id_rute, kode_bus, harga) VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss.SSS") + "','" + rute[comboBox1.GetItemText(this.comboBox1.SelectedItem)] + "' " +
                ",'" + comboBox2.GetItemText(this.comboBox2.SelectedItem) + "', " + textBox1.Text.ToString() + ")";
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, conn);

            //Execute command
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambahkan");
                //textBox3.Text = "";
                initData();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Gagal : " + ex.Message);
            }
        }

        private void FormJadwal_Load(object sender, EventArgs e)
        {
            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss.SSS";
        }
    }
}
