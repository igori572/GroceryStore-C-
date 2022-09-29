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
    public partial class Form3 : Form
    {
        Baza baza;
        BazaDataSet bazadb;
        BazaDataSetTableAdapters.KategorijaTableAdapter bazakat;
        BazaDataSetTableAdapters.ProizvodiTableAdapter bazaproi;
        List<Kategorija> kategorija;
        List<Proizvod> proizvod;
        public Form3()
        {
            InitializeComponent();
            baza = new Baza();
            bazadb = new BazaDataSet();
            bazakat = new BazaDataSetTableAdapters.KategorijaTableAdapter();
            bazaproi = new BazaDataSetTableAdapters.ProizvodiTableAdapter();
            kategorija = new List<Kategorija>();
            proizvod = new List<Proizvod>();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            bazakat.Fill(bazadb.Kategorija);
            dataGridView1.DataSource = bazadb.Kategorija;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ID"].Value != null)
                {
                    Kategorija k = new Kategorija();
                    k.Id = (int)row.Cells["ID"].Value;
                    k.Naziv = (string)row.Cells["Naziv"].Value;
                    
                    kategorija.Add(k);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int cena;
            int provera;
            if (txtNaziv.Text == "")
                MessageBox.Show("Niste uneli naziv proizvoda");
            else if (int.TryParse(txtNaziv.Text, out provera))
                MessageBox.Show("Naziv ne može biti broj");
            else if (txtCena.Text == "")
                MessageBox.Show("Niste uneli cenu");
            else if (!int.TryParse(txtCena.Text, out cena))
                MessageBox.Show("Niste uneli broj");
            else if (cena < 0)
            {
                MessageBox.Show("Cena ne moze biti manje od 0.Unesi ponovo");
                txtCena.Text = "";
            }

            else
            {
                try
                {
                    baza.otvoriKonekciju();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;

                    cmd.CommandText = "SELECT * FROM Proizvodi";


                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Proizvod p = new Proizvod();

                        p.iD = int.Parse(reader["ID"].ToString());
                        p.Naziv = reader["Proizvod"].ToString();
                        p.Cena = int.Parse(reader["Cena"].ToString());
                        p.ID_kat = int.Parse(reader["ID_kategorija"].ToString());

                        proizvod.Add(p);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    baza.zatvoriKonekciju();
                }


                BazaDataSet.ProizvodiRow nov = bazadb.Proizvodi.NewProizvodiRow();
                nov.Proizvod = txtNaziv.Text;
                nov.Cena = cena;
                nov.ID_kategorija = dataGridView1.CurrentCell.RowIndex + 2;
                nov.ID = proizvod.Count + 1;
                bazadb.Proizvodi.AddProizvodiRow(nov);

                bazaproi.Update(bazadb.Proizvodi);
                MessageBox.Show("Uspešno dodato");
                this.Close();
            }
        }
    }
}
