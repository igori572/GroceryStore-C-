using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat
{
    public partial class Form2 : Form
    {
        Baza baza;
        BazaDataSet bazadb;
        BazaDataSetTableAdapters.RačunTableAdapter bazaracun;

        List<Proizvod> proizovidiIzKorpe;
        List<Racun> racuni;

        ListBox lb1;
        Label form1_cena;
        int racun = 0;
        OleDbConnection veza = new OleDbConnection();
        public Form2()
        {
            InitializeComponent();         
        }
        
        public Form2(List<Proizvod> proizovidiIzKorpe, ListBox lb1, Label form1_cena, List<Proizvod> kolicine)
        {
            this.proizovidiIzKorpe = proizovidiIzKorpe;
            this.lb1 = lb1;
            this.form1_cena = form1_cena;
            InitializeComponent();
            baza = new Baza();
            bazadb = new BazaDataSet();
            bazaracun = new BazaDataSetTableAdapters.RačunTableAdapter();
            veza.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Aspire\Documents\Baza.accdb";
            izracunajCenu();
        }

        private void izracunajCenu()
        {
            racun = 0;
            foreach (Proizvod p in proizovidiIzKorpe)
            {
                racun += p.Cena*p.kolicina;
            }

            lblRacun.Text = racun + "RSD";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            proizovidiIzKorpe.RemoveAt(lbPlati.SelectedIndex);

            lbPlati.DataSource = null;
            lbPlati.DataSource = proizovidiIzKorpe;

            izracunajCenu();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lbPlati.DataSource = proizovidiIzKorpe;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string poruka = "Potvrdi brisanje" + Environment.NewLine + "Ovo će isprazniti korpu.";
            if (MessageBox.Show(poruka, "Storniraj", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                proizovidiIzKorpe.Clear();
                MessageBox.Show("Račun uspešno storniran");
                form1_cena.Text = "0RSD";
                this.Close();
            }
            else
            {
                MessageBox.Show("Storniranje prekinuto");
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            lb1.DataSource = null;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baza.zatvoriKonekciju();
            int racunID = -1;
            racuni = new List<Racun>();
            try
            {

                baza.otvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                //Citanje racuna
                cmd.Connection = baza.Conn;
                cmd.CommandText = "SELECT * FROM Račun";
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Racun r = new Racun();

                    r.RacunID = int.Parse(reader["ID"].ToString());
                    r.Cena = int.Parse(reader["Cena"].ToString());
                    r.Vreme = DateTime.Parse(reader["Vreme"].ToString());
                    racuni.Add(r);
                }

                if (racuni.Count() == 0)
                {
                    racunID = 1;
                }
                else
                {
                    racunID = racuni.Count() + 1;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baza.zatvoriKonekciju();
            }
                //UBACIVANJE U BAZU RACUNA
            try
            {
                baza.otvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = $"INSERT INTO Račun (ID, Cena, Vreme) values({racunID}, {racun}, Now())";
                cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baza.zatvoriKonekciju();
            }
            try
            {
                baza.otvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                //UPISIVANJE U BAZU drugog
                foreach (Proizvod p in proizovidiIzKorpe)
                {
                    cmd.CommandText = $"INSERT INTO Stavke (ID_racuna, ID_proizvoda, Cena,Kolicina) values({racunID}, {p.iD}, {p.cena},{p.kolicina})";
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                baza.zatvoriKonekciju();
            }

            MessageBox.Show("Uspesna prodaja !");

            proizovidiIzKorpe.Clear();
            form1_cena.Text = "0RSD";
            this.Close();
        }
    }
}
