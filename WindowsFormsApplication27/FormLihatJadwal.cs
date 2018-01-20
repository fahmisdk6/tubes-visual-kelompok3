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
    public partial class FormLihatJadwal : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost; UID=root; Pwd=; database=database");
        int userId;
        public FormLihatJadwal(int userId)
        {
            InitializeComponent();
            this.userId = userId;
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
            string query = "Select jadwal.id_jadwal , jadwal.waktu, rute.nama_rute , bus.kode_bus, jadwal.harga from jadwal, rute, bus where " +
                "jadwal.id_rute = rute.id and bus.kode_bus = jadwal.kode_bus";
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button_Click(object sender, EventArgs e)
        {

            //Get Data Jadwal 
            string query = "Select jadwal.id_jadwal , jadwal.waktu, rute.nama_rute , bus.kode_bus, jadwal.harga from jadwal, rute, bus where " +
                "jadwal.id_rute = rute.id and bus.kode_bus = jadwal.kode_bus and jadwal.id_jadwal = "+ textBox1.Text.ToString();
            
            String jadwalId = textBox1.Text.ToString();
            String jadwalWaktu = "", namaRute = "", kodeBus = "";
            int harga = 0;
            int kuantitas = Int32.Parse(textBox2.Text.ToString());
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            bool found = false;
            while (read.Read())
            {
                found = true;
                jadwalWaktu = read.GetString("waktu");
                namaRute = read.GetString("nama_rute");
                kodeBus = read.GetString("kode_bus");
                harga = read.GetInt32("harga");
            }
            read.Close();



            //Get Data user 
            query = "Select * from user where user_id = " + userId;
            cmd = new MySqlCommand(query, conn);
            read = cmd.ExecuteReader();

            String firstName = "", lastname = "";
            while (read.Read())
            {
                firstName = read.GetString("firstname");
                lastname = read.GetString("lastname");
            }
            read.Close();

            if (!found)
            {
                MessageBox.Show("Id Jadwal tidak valid");
                return;
            }
            string message = "Detail pembelian :\n" +
                "Pembeli : " + firstName + " " + lastname +"\n" +
                "Jadwal : " + jadwalWaktu + "\n" +
                "Rute : " + namaRute + "\n" +
                "Bus : " + kodeBus + "\n" +
                "Harga : " + harga + "\n" +
                "Kuantitas : " + kuantitas + "\n" +
                "Total Harga : " + harga * kuantitas + "\n";

            DialogResult result = MessageBox.Show(message, "Konfirmasi Pembelian" , MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                String insert = "Insert into tiket (user_id, id_jadwal, kuantitas, total_harga) " +
                    "values (" + userId + ", " + jadwalId + ", " + kuantitas + "," + harga * kuantitas + ")";
                cmd = new MySqlCommand(insert, conn);
                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tiket berhasil dibeli");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Gagal : " + ex.Message);
                }
            }
            else if (result == DialogResult.Cancel)
            {
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["id_jadwal"].Value.ToString();
        }
    }
}
