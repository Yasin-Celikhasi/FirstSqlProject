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

namespace Personel
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Personel;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Kisiler", connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand kayitekle = new SqlCommand("insert into Kisiler (PersonelNo,PersonelAd,PersonelSoyad,PersonelGörev,PersonelMaas,PersonelSehir) values (@p1,@p2,@p3,@p4,@p5,@p6)", connection);
            kayitekle.Parameters.AddWithValue("@p1", textBox1.Text);
            kayitekle.Parameters.AddWithValue("@p2", textBox2.Text);
            kayitekle.Parameters.AddWithValue("@p3", textBox3.Text);
            kayitekle.Parameters.AddWithValue("@p4", textBox6.Text);
            kayitekle.Parameters.AddWithValue("@p5", textBox5.Text);
            kayitekle.Parameters.AddWithValue("@p6", textBox6.Text);

            kayitekle.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıt Eklendi!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand delete = new SqlCommand("Delete from Kisiler where PersonelAd=@adi", connection);
            delete.Parameters.AddWithValue("@adi", textBox2.Text);
            delete.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıt Silindi!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string no = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string gorev = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            string maas = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            string sehir = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

            textBox1.Text = no;
            textBox2.Text = ad;
            textBox3.Text = soyad;
            textBox4.Text = gorev;
            textBox5.Text = maas;
            textBox6.Text = sehir;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand update = new SqlCommand("update Kisiler set PersonelNo=@p1,PersonelAd=@p2,PersonelSoyad=@p3,PersonelGörev=@p4,PersonelMaas=@p5,PersonelSehir=@p6 where PersonelNo=@p1", connection);
            update.Parameters.AddWithValue("@p1", textBox1.Text);
            update.Parameters.AddWithValue("@p2", textBox2.Text);
            update.Parameters.AddWithValue("@p3", textBox3.Text);
            update.Parameters.AddWithValue("@p4", textBox4.Text);
            update.Parameters.AddWithValue("@p5", textBox5.Text);
            update.Parameters.AddWithValue("@p6", textBox6.Text);

            update.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Kayıt Güncellendi!");
        }
    }
}
