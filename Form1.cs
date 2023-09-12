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

namespace PansiyonKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan=new SqlConnection("Data Source=IRFAN\\SQLEXPRESS;Initial Catalog=pansiyon;Integrated Security=True");
        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from pansiyonbilgi",baglan);
            SqlDataReader oku= komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle= new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["sehir"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["hesap"].ToString());
                ekle.SubItems.Add(oku["gtarihi"].ToString());
                ekle.SubItems.Add(oku["ctarihi"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
            hepsinitemizle();

        }


        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
           if (comboBox2.Text == "Kaydet")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("insert into pansiyonbilgi (id,ad,soyad,sehir,telefon,hesap,gtarihi,ctarihi) Values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + dateTimePicker2.Text.ToString() + "')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                verilerigoster();
                hepsinitemizle();
            }
            if (comboBox2.Text == "Sil")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from pansiyonbilgi where id=(" + id + ")", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                verilerigoster();
                hepsinitemizle();

            }
            if (comboBox2.Text == "Güncelle")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("update pansiyonbilgi set id='" + textBox1.Text.ToString() + "',ad='" + textBox2.Text.ToString() + "',soyad='" + textBox3.Text.ToString() + "',sehir='" + comboBox1.Text.ToString() + "',telefon='" + textBox4.Text.ToString() + "',hesap='" + textBox5.Text.ToString() + "',gtarihi='" + dateTimePicker1.Text.ToString() + "',ctarihi='" + dateTimePicker2.Text.ToString() + "'where id=" + id + "", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                verilerigoster();
                hepsinitemizle();

            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[5].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[6].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[7].Text;


        }
        private void hepsinitemizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            textBox4.Clear();
            textBox5.Clear();
            
        

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * From pansiyonbilgi where ad like '%" + textBox6.Text + "%'", baglan);
            SqlDataReader oku= komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["sehir"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["hesap"].ToString());
                ekle.SubItems.Add(oku["gtarihi"].ToString());
                ekle.SubItems.Add(oku["ctarihi"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();


        }
    }
}
