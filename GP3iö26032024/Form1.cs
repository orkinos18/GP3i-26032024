using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GP3iö26032024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string kelime = "";
        string gizli = "";
        string yeni = "";


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection bag = new SqlConnection(@"server=orkinos\orkinos;initial catalog=gorsel3kelimetahmin;integrated security=true");
            string sql = "select * from kelimeler";
            SqlDataAdapter da = new SqlDataAdapter(sql,bag);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int satirsayisi=dt.Rows.Count;

            Random rnd=new Random();
            int satir=rnd.Next(0,satirsayisi);
            if (checkBox1.Checked)
                kelime=dt.Rows[satir][2].ToString();
            else
                kelime = dt.Rows[satir][1].ToString();
            kelime = kelime.Trim();
            foreach (char harf in kelime)
            {
                gizli+= '*';
            }
            labelKelime.Text = gizli;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yeni = "";
            char karakter = Convert.ToChar(textBoxKarakter.Text);
            textBoxKarakter.Clear();
            for (int i = 0; i <kelime.Length; i++)
            {
                if (karakter == kelime[i])
                    yeni += kelime[i];
                else
                    yeni += gizli[i];
            }
            gizli = yeni;
            labelKelime.Text = gizli;
            if (kelime==labelKelime.Text)
                MessageBox.Show("Tebrikler");

        }
    }
}
