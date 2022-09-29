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
   
    public partial class Form1 : Form
    {
        BazaDataSet bazadb;
        BazaDataSetTableAdapters.KategorijaTableAdapter bazakat;
        BazaDataSetTableAdapters.ProizvodiTableAdapter bazaproi;
        BazaDataSetTableAdapters.RačunTableAdapter bazaracun;
        List<Proizvod> proizvodi;
     
        List<Proizvod> proizvodiIzLB;
        List<Proizvod> pretraga_pom;
        List<Proizvod> kolicine;
        List<Kategorija> lista;
        List<Proizvod> listaP;
        Baza baza;

        public int racun = 0;
        public Form1()
        {
            InitializeComponent();
            bazadb = new BazaDataSet();
            bazakat = new BazaDataSetTableAdapters.KategorijaTableAdapter();
            bazaproi = new BazaDataSetTableAdapters.ProizvodiTableAdapter();
            bazaracun = new BazaDataSetTableAdapters.RačunTableAdapter();
            

            baza = new Baza();
            proizvodi = new List<Proizvod>();
            proizvodiIzLB = new List<Proizvod>();
            lista = new List<Kategorija>();
            listaP = new List<Proizvod>();
            kolicine = new List<Proizvod>();
            pretraga_pom = new List<Proizvod>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            try
            {
                baza.otvoriKonekciju();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "SELECT * FROM KATEGORIJA";
                OleDbDataReader reader = cmd.ExecuteReader();

                lista.Clear();
                while (reader.Read())
                {
                    Kategorija k = new Kategorija();
                    k.Id = int.Parse(reader["ID"].ToString());
                    k.Naziv = reader["Naziv"].ToString();
                    lista.Add(k);
                }
                
                comboBox1.DataSource = null;
                comboBox1.ValueMember = "ID";
                comboBox1.DisplayMember = "Naziv";
                comboBox1.DataSource = lista;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baza.zatvoriKonekciju();
            }

           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                proizvodi.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                var linq = from x in bazadb.Proizvodi
                           where x.ID_kategorija.Equals(2)
                           select x;
                bazaproi.Fill(bazadb.Proizvodi);
                dataGridView1.DataSource = linq.CopyToDataTable();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                proizvodi.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                var linq = from x in bazadb.Proizvodi
                           where x.ID_kategorija.Equals(3)
                           select x;
                bazaproi.Fill(bazadb.Proizvodi);
                dataGridView1.DataSource = linq.CopyToDataTable();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                proizvodi.Clear();
                var linq = from x in bazadb.Proizvodi
                           where x.ID_kategorija.Equals(4)
                           select x;
                bazaproi.Fill(bazadb.Proizvodi);
                dataGridView1.DataSource = linq.CopyToDataTable();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                proizvodi.Clear();
                var linq = from x in bazadb.Proizvodi
                           where x.ID_kategorija.Equals(5)
                           select x;
                bazaproi.Fill(bazadb.Proizvodi);
                dataGridView1.DataSource = linq.CopyToDataTable();
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                proizvodi.Clear();
                var linq = from x in bazadb.Proizvodi
                           where x.ID_kategorija.Equals(6)
                           select x;
                bazaproi.Fill(bazadb.Proizvodi);
                dataGridView1.DataSource = linq.CopyToDataTable();
                
            }
            this.dataGridView1.Sort(this.dataGridView1.Columns["Proizvod"],
                ListSortDirection.Ascending);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ID"].Value != null)
                {
                    Proizvod p = new Proizvod();
                    p.ID = (int)row.Cells["ID"].Value;
                    p.Naziv = (string)row.Cells["Proizvod"].Value;
                    p.Cena = (int)row.Cells["Cena"].Value;
                    p.ID_kat = (int)row.Cells["ID_kategorija"].Value;
                    proizvodi.Add(p);
                }
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            racun = 0;
            listBox1.DataSource = null;
            int red = dataGridView1.CurrentCell.RowIndex;
            int kolicina = (int)numUP.Value;
            
                Proizvod pr = new Proizvod();
                pr.ID = proizvodi[red].ID;
                pr.Cena = proizvodi[red].Cena;
                pr.Naziv = proizvodi[red].Naziv;
                pr.ID_kat = proizvodi[red].iD_kat;
                pr.kolicina = kolicina;

            
                
                proizvodiIzLB.Add(pr);

            
                listBox1.DataSource = proizvodiIzLB;
                foreach (Proizvod p in proizvodiIzLB)
                {
                    racun += p.Cena * p.Kolicina;
                }

                lblRacun.Text = racun.ToString() + "RSD";
                numUP.Value = 1;

                if (!(kolicine.Contains(proizvodi[red])) || kolicine.Count() == 0)
                {
                    proizvodi[red].u_korpi = kolicina;
                    kolicine.Add(proizvodi[red]);
                }
                else
                {
                    foreach (Proizvod p in kolicine)
                    {
                        if (p.ID == proizvodi[red].ID)
                            p.u_korpi += kolicina;
                    }
                }
            


        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
        }

        private void btnPlati_Click(object sender, EventArgs e)
        {
            
            if (proizvodiIzLB.Count() == 0)
            {
                MessageBox.Show("Niste popunili korpu");
            }
            else
            {
                Form2 form_kasa = new Form2(proizvodiIzLB, listBox1, lblRacun, kolicine);
                form_kasa.Show();
            }
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            List<Proizvod> pretraga = new List<Proizvod>();
            pretraga_pom = new List<Proizvod>();
            int kategorijaID_Pom = -1;
            baza.zatvoriKonekciju();

            if (rbNaziv.Checked)
            {
                try
                {
                    baza.otvoriKonekciju();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = $"SELECT * FROM Proizvodi";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Proizvod pom = new Proizvod();

                        pom.ID = int.Parse(reader["ID"].ToString());
                        pom.Naziv = reader["Proizvod"].ToString();
                        pom.Cena = int.Parse(reader["Cena"].ToString());
                        pom.iD_kat = int.Parse(reader["ID_kategorija"].ToString());

                        pretraga.Add(pom);
                    }

                    pretraga.Sort(((x, y) => string.Compare(x.Naziv, y.Naziv)));


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    baza.zatvoriKonekciju();
                }

                foreach (Proizvod x in pretraga)
                {
                    if (x.Naziv.ToLower().Contains(txtPretraga.Text.ToLower()))
                    {
                        pretraga_pom.Add(x);
                    }
                }
            }

           if (rbKat.Checked)
            {
                try
                {
                    //UNOSENJE U LISTU PROIZVODA
                    baza.otvoriKonekciju();

                    OleDbCommand cmd_proizvodi = new OleDbCommand();
                    cmd_proizvodi.Connection = baza.Conn;
                    cmd_proizvodi.CommandText = $"SELECT * FROM Proizvodi";
                    OleDbDataReader reader_proizvodi = cmd_proizvodi.ExecuteReader();

                    pretraga.Clear();
                    while (reader_proizvodi.Read())
                    {
                        Proizvod pom = new Proizvod();

                        pom.ID = int.Parse(reader_proizvodi["ID"].ToString());
                        pom.Naziv = reader_proizvodi["Proizvod"].ToString();
                        pom.Cena = int.Parse(reader_proizvodi["Cena"].ToString());
                        pom.ID_kat = int.Parse(reader_proizvodi["ID_kategorija"].ToString());

                        pretraga.Add(pom);
                    }

                    pretraga.Sort(((x, y) => string.Compare(x.Naziv, y.Naziv)));


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    baza.zatvoriKonekciju();
                }

                try
                {
                    //UNOSENJE U LISTU KATEGORIJA
                    baza.otvoriKonekciju();
                    OleDbCommand cmd_kategorije = new OleDbCommand();
                    cmd_kategorije.Connection = baza.Conn;
                    cmd_kategorije.CommandText = $"SELECT * FROM Kategorija";
                    OleDbDataReader reader_kategorije = cmd_kategorije.ExecuteReader();

                    lista.Clear();
                    while (reader_kategorije.Read())
                    {
                        Kategorija pom = new Kategorija();

                        pom.Id = int.Parse(reader_kategorije["ID"].ToString());
                        pom.Naziv = reader_kategorije["Naziv"].ToString();

                        lista.Add(pom);
                    }

                    lista.Sort(((x, y) => string.Compare(x.Naziv, y.Naziv)));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    baza.zatvoriKonekciju();
                }
                foreach (Kategorija x in lista)
                {
                    if (x.Naziv.ToLower().StartsWith(txtPretraga.Text.ToLower()))
                    {
                        kategorijaID_Pom = x.Id;
                    }
                    
                }
                foreach (Proizvod x in pretraga)
                {
                    if (x.ID_kat == kategorijaID_Pom)
                    {
                        pretraga_pom.Add(x);
                    }
                }

            }
            if (txtPretraga.Text == "")
            {
                listBox2.DataSource = null;
            }
            else
                listBox2.DataSource = pretraga_pom;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (listBox2.Items.Count > 0)
            {
                racun = 0;
                listBox1.DataSource = null;
                int kolicina = (int)numUP.Value;
                Proizvod pr = new Proizvod();
                pr.ID = pretraga_pom[listBox2.SelectedIndex].ID;
                pr.Cena = pretraga_pom[listBox2.SelectedIndex].Cena;
                pr.Naziv = pretraga_pom[listBox2.SelectedIndex].Naziv;
                pr.ID_kat = pretraga_pom[listBox2.SelectedIndex].iD_kat;
                pr.kolicina = kolicina;

                proizvodiIzLB.Add(pr);
                listBox1.DataSource = proizvodiIzLB;
                foreach (Proizvod p in proizvodiIzLB)
                {
                    racun += p.Cena * p.Kolicina;
                }

                lblRacun.Text = racun.ToString() + "RSD";
                numUP.Value = 1;

            }
            else
            {
                MessageBox.Show("Niste izabrali nista");
            }
        }

        private void btnBaza_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void btnPregledaj_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

        private void btnStatistika_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
        }


    }
   }

