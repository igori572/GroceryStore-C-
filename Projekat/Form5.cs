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
    //provera da li je prodato -1,ako je -1 izbaci poruku
    public partial class Form5 : Form
    {
        Baza baza;
        List<Proizvod> proizvodi;
        int prodato = 0;
        int ukupno = 0;

        public Form5()
        {
            InitializeComponent();
            baza = new Baza();
            proizvodi = new List<Proizvod>();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
            try
            {
                baza.otvoriKonekciju();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "SELECT * From Proizvodi";
                OleDbDataReader reader = cmd.ExecuteReader();


                while(reader.Read())
                {
                    Proizvod p = new Proizvod();
                    p.iD = int.Parse(reader["ID"].ToString());
                    p.naziv = reader["Proizvod"].ToString();
                    proizvodi.Add(p);
                }
                listBox1.DataSource = null;
                listBox1.DisplayMember = "naziv";
                listBox1.ValueMember = "iD";
                proizvodi.Sort(((x, y) => string.Compare(x.naziv.ToString(), y.naziv.ToString())));
                listBox1.DataSource = proizvodi;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                baza.zatvoriKonekciju();
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Refresh();
            prodato = 0;
            ukupno = 0;
            
            Proizvod pr = proizvodi[listBox1.SelectedIndex];
            
            try
            {
                baza.otvoriKonekciju();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = $"SELECT sum(s.Kolicina) as prodato FROM Račun r INNER JOIN Stavke s ON r.ID=s.ID_racuna WHERE month(Vreme)={comboBox1.SelectedIndex+1} and s.ID_proizvoda={pr.iD} GROUP BY s.ID_proizvoda";
                
                OleDbDataReader reader = cmd.ExecuteReader();

                

                while (reader.Read())
                {
                    prodato = int.Parse(reader["prodato"].ToString());
                }
              

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);

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
                cmd.CommandText = $"SELECT sum(s.Kolicina) as ukupno FROM Račun r INNER JOIN Stavke s ON r.ID=s.ID_racuna WHERE month(Vreme)={comboBox1.SelectedIndex + 1}";
                OleDbDataReader reader2 = cmd.ExecuteReader();


                while (reader2.Read())
                {
                    ukupno = int.Parse(reader2["ukupno"].ToString());
                }
              

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);

            }
            finally
            {
                baza.zatvoriKonekciju();
            }
            Graphics g = this.CreateGraphics();
            if ((prodato == 0 && ukupno == 0) || (prodato == 0 && ukupno != 0))
            {
                //MessageBox.Show("Ova stavka nije kupljena do sada");
                label3.Text = prodato.ToString();
                label4.Text = ukupno.ToString();
                Rectangle pravougaonik = new Rectangle(250, 120, 220, 220);
                g.FillPie(Brushes.Gray, pravougaonik, 0, 360);
            }

            else
            {
                label3.Text = prodato.ToString();
                label4.Text = ukupno.ToString();
                double procenat = ((double)prodato / ukupno) * 100;
                int procenat1 = 100 - (int)Math.Round(procenat);
                int procenat2 = 100 - procenat1;

                Rectangle pravougaonik = new Rectangle(250, 120, 220, 220);
                g.FillPie(Brushes.Blue, pravougaonik, 0, -((float)procenat2 / 100) * 360);
                g.FillPie(Brushes.Gray, pravougaonik, 0, ((float)procenat1 / 100) * 360);
            }
            
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Refresh();
            prodato = 0;
            ukupno = 0;

            Proizvod pr = proizvodi[listBox1.SelectedIndex];

            try
            {
                baza.otvoriKonekciju();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = $"SELECT sum(s.Kolicina) as prodato FROM Račun r INNER JOIN Stavke s ON r.ID=s.ID_racuna WHERE month(Vreme)={comboBox1.SelectedIndex + 1} and s.ID_proizvoda={pr.iD} GROUP BY s.ID_proizvoda";

                OleDbDataReader reader = cmd.ExecuteReader();



                while (reader.Read())
                {
                    prodato = int.Parse(reader["prodato"].ToString());
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);

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
                cmd.CommandText = $"SELECT sum(s.Kolicina) as ukupno FROM Račun r INNER JOIN Stavke s ON r.ID=s.ID_racuna WHERE month(Vreme)={comboBox1.SelectedIndex + 1}";
                OleDbDataReader reader2 = cmd.ExecuteReader();


                while (reader2.Read())
                {
                    ukupno = int.Parse(reader2["ukupno"].ToString());
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);

            }
            finally
            {
                baza.zatvoriKonekciju();
            }
            Graphics g = this.CreateGraphics();
            if ((prodato == 0 && ukupno == 0) || (prodato == 0 && ukupno != 0))
            {
                //MessageBox.Show("Ova stavka nije kupljena do sada");
                label3.Text = prodato.ToString();
                label4.Text = ukupno.ToString();
                Rectangle pravougaonik = new Rectangle(250, 120, 220, 220);
                g.FillPie(Brushes.Gray, pravougaonik, 0, 360);
            }

            else
            {
                label3.Text = prodato.ToString();
                label4.Text = ukupno.ToString();
                double procenat = ((double)prodato / ukupno) * 100;
                int procenat1 = 100 - (int)Math.Round(procenat);
                int procenat2 = 100 - procenat1;

                Rectangle pravougaonik = new Rectangle(250, 120, 220, 220);
                g.FillPie(Brushes.Blue, pravougaonik, 0, -((float)procenat2 / 100) * 360);
                g.FillPie(Brushes.Gray, pravougaonik, 0, ((float)procenat1 / 100) * 360);
            }
        }
    }
}
