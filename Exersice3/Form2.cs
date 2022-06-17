using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Exersice3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (txtnama.Text != string.Empty && txtkode.Text != string.Empty && txtharga.Text != string.Empty && txtstok.Text != string.Empty)
            {
                cmd = new SqlCommand("barangstoreprocedure", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Kode_Barang",txtkode.Text);
                cmd.Parameters.AddWithValue("@Nama_Barang",txtnama.Text);
                cmd.Parameters.AddWithValue("@Harga_Barang",txtharga.Text);
                cmd.Parameters.AddWithValue("@Stok_Barang", txtstok.Text);
                cmd.Parameters.AddWithValue("@BarangType", "1");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record inserted successfully.", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAllEmployeeRecord();
                txtkode.Text = "";
                txtnama.Text = "";
                txtharga.Text = "";
                txtstok.Text = "";
            }
            else
            {
                MessageBox.Show("Please enter value in all fields", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cn = new SqlConnection("Data Source=LAPTOP-POGI16I0\\CINDYNUR;Initial Catalog=JS_Steak;User Id=sa; Password=Nurhabibah345");
            cn.Open();
            //bind data in data grid view  
            GetAllEmployeeRecord();
            //disable delete and update button on load  
            btnupdt.Enabled = false;
            btndel.Enabled = false;
        }

        private void GetAllEmployeeRecord()
        {
            cmd = new SqlCommand("barangstoreprocedure", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Kode_Barang", "");
            cmd.Parameters.AddWithValue("@Nama_Barang", "");
            cmd.Parameters.AddWithValue("@Harga_Barang", "");
            cmd.Parameters.AddWithValue("@Stok_Barang", "");
            cmd.Parameters.AddWithValue("@BarangType", "5");
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
