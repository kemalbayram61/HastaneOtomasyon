using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        OleDbConnection con;
        OleDbDataAdapter da;
        DataSet ds;
        OleDbCommand komut;
        OleDbCommand cmd2;


        public Form1()
        {
            InitializeComponent();
        }
        void griddoldur()
        {
            con = new OleDbConnection("provider=microsoft.ace.oledb.12.0;data source=hasta.accdb"); //bağlantı tamamlanıyor
            da = new OleDbDataAdapter("select*from hasta", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "hasta");
            dataGridView1.DataSource = ds.Tables["hasta"];
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Kayıt ekleme
            komut = new OleDbCommand();
            con.Open(); //bağlantıyı açma
            komut.Connection = con;
            komut.CommandText = "insert into hasta(tc_no,adi_soyadi,d_tarihi,randevu_tarihi,randevu_saati,doktor_adi,polıkınlık) values ('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "', '" + comboBox2.Text + "', '" + comboBox1.Text + "')";
            komut.ExecuteNonQuery();
            con.Close();
            //Ekleme yaptıktan sonra gridde görüntüleme yapmak için griddoldur metodunu çağırabiliriz.
            griddoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            con = new OleDbConnection("provider=microsoft.ace.oledb.12.0;data source=hasta.accdb"); //bağlantı tamamlanıyor
            da = new OleDbDataAdapter("select*from hasta where adi_soyadi like '"+textBox7 .Text  +"%' ", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "hasta");
            dataGridView1.DataSource = ds.Tables["hasta"];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //kimliğe göre kalan bilgileri güncelleme
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //kayit silme
            con.Open();
            cmd2 = new OleDbCommand();
            cmd2.Connection = con;
            cmd2.CommandText = "delete from hasta where tc_no="+textBox1.Text+"";
            cmd2.ExecuteNonQuery();
            con.Close();
            griddoldur();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1 .Text  = "";
            comboBox2.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      
    }
}
