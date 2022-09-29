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
    public partial class Form4 : Form
    {
        List<Racun> racuni;
        Baza baza;
        public Form4()
        {
            InitializeComponent();
            racuni = new List<Racun>();
            baza = new Baza();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)
            {
                dataGridView1.DataSource = null;
                try
                {
                    baza.otvoriKonekciju();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = "SELECT * FROM Račun WHERE month(Vreme)=1 ";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    racuni.Clear();
                    while (reader.Read())
                    {
                        Racun r = new Racun();
                        r.RacunID = int.Parse(reader["ID"].ToString());
                        r.Cena =int.Parse( reader["Cena"].ToString());
                        r.Vreme= DateTime.Parse(reader["Vreme"].ToString());
                        racuni.Add(r);
                    }

                    dataGridView1.DataSource = racuni;

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
            else if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.DataSource = null;
                try
                {
                    baza.otvoriKonekciju();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = "SELECT * FROM Račun WHERE month(Vreme)=2 ";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    racuni.Clear();
                    while (reader.Read())
                    {
                        Racun r = new Racun();
                        r.RacunID = int.Parse(reader["ID"].ToString());
                        r.Cena = int.Parse(reader["Cena"].ToString());
                        r.Vreme = DateTime.Parse(reader["Vreme"].ToString());
                        racuni.Add(r);
                    }

                    dataGridView1.DataSource = racuni;

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
            else if (comboBox1.SelectedIndex == 2)
            {
                dataGridView1.DataSource = null;
                try
                {
                    baza.otvoriKonekciju();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = "SELECT * FROM Račun WHERE month(Vreme)=3 ";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    racuni.Clear();
                    while (reader.Read())
                    {
                        Racun r = new Racun();
                        r.RacunID = int.Parse(reader["ID"].ToString());
                        r.Cena = int.Parse(reader["Cena"].ToString());
                        r.Vreme = DateTime.Parse(reader["Vreme"].ToString());
                        racuni.Add(r);
                    }

                    dataGridView1.DataSource = racuni;

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
            else if (comboBox1.SelectedIndex == 3)
            {
                dataGridView1.DataSource = null;
                try
                {
                    baza.otvoriKonekciju();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = "SELECT * FROM Račun WHERE month(Vreme)=4 ";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    racuni.Clear();
                    while (reader.Read())
                    {
                        Racun r = new Racun();
                        r.RacunID = int.Parse(reader["ID"].ToString());
                        r.Cena = int.Parse(reader["Cena"].ToString());
                        r.Vreme = DateTime.Parse(reader["Vreme"].ToString());
                        racuni.Add(r);
                    }

                    dataGridView1.DataSource = racuni;

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
            else if (comboBox1.SelectedIndex == 4)
            {
                dataGridView1.DataSource = null;
                try
                {
                    baza.otvoriKonekciju();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = "SELECT * FROM Račun WHERE month(Vreme)=5 ";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    racuni.Clear();
                    while (reader.Read())
                    {
                        Racun r = new Racun();
                        r.RacunID = int.Parse(reader["ID"].ToString());
                        r.Cena = int.Parse(reader["Cena"].ToString());
                        r.Vreme = DateTime.Parse(reader["Vreme"].ToString());
                        racuni.Add(r);
                    }

                    dataGridView1.DataSource = racuni;

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

            else  if (comboBox1.SelectedIndex == 5)
            {
                dataGridView1.DataSource = null;
                try
                {
                    baza.otvoriKonekciju();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = "SELECT * FROM Račun WHERE month(Vreme)=6 ";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    racuni.Clear();
                    while (reader.Read())
                    {
                        Racun r = new Racun();
                        r.RacunID = int.Parse(reader["ID"].ToString());
                        r.Cena = int.Parse(reader["Cena"].ToString());
                        r.Vreme = DateTime.Parse(reader["Vreme"].ToString());
                        racuni.Add(r);
                    }

                    dataGridView1.DataSource = racuni;

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
            else if (comboBox1.SelectedIndex == 6)
            {
                dataGridView1.DataSource = null;
                try
                {
                    baza.otvoriKonekciju();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = "SELECT * FROM Račun WHERE month(Vreme)=7 ";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    racuni.Clear();
                    while (reader.Read())
                    {
                        Racun r = new Racun();
                        r.RacunID = int.Parse(reader["ID"].ToString());
                        r.Cena = int.Parse(reader["Cena"].ToString());
                        r.Vreme = DateTime.Parse(reader["Vreme"].ToString());
                        racuni.Add(r);
                    }

                    dataGridView1.DataSource = racuni;

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
            else if (comboBox1.SelectedIndex == 7)
            {
                dataGridView1.DataSource = null;
                try
                {
                    baza.otvoriKonekciju();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = "SELECT * FROM Račun WHERE month(Vreme)=8 ";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    racuni.Clear();
                    while (reader.Read())
                    {
                        Racun r = new Racun();
                        r.RacunID = int.Parse(reader["ID"].ToString());
                        r.Cena = int.Parse(reader["Cena"].ToString());
                        r.Vreme = DateTime.Parse(reader["Vreme"].ToString());
                        racuni.Add(r);
                    }

                    dataGridView1.DataSource = racuni;

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
            else if (comboBox1.SelectedIndex == 8)
            {
                dataGridView1.DataSource = null;
                try
                {
                    baza.otvoriKonekciju();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = "SELECT * FROM Račun WHERE month(Vreme)=9 ";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    racuni.Clear();
                    while (reader.Read())
                    {
                        Racun r = new Racun();
                        r.RacunID = int.Parse(reader["ID"].ToString());
                        r.Cena = int.Parse(reader["Cena"].ToString());
                        r.Vreme = DateTime.Parse(reader["Vreme"].ToString());
                        racuni.Add(r);
                    }

                    dataGridView1.DataSource = racuni;

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
            else if (comboBox1.SelectedIndex == 9)
            {
                dataGridView1.DataSource = null;
                try
                {
                    baza.otvoriKonekciju();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = "SELECT * FROM Račun WHERE month(Vreme)=10";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    racuni.Clear();
                    while (reader.Read())
                    {
                        Racun r = new Racun();
                        r.RacunID = int.Parse(reader["ID"].ToString());
                        r.Cena = int.Parse(reader["Cena"].ToString());
                        r.Vreme = DateTime.Parse(reader["Vreme"].ToString());
                        racuni.Add(r);
                    }

                    dataGridView1.DataSource = racuni;

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
            else if (comboBox1.SelectedIndex == 10)
            {
                dataGridView1.DataSource = null;
                try
                {
                    baza.otvoriKonekciju();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = "SELECT * FROM Račun WHERE month(Vreme)=11 ";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    racuni.Clear();
                    while (reader.Read())
                    {
                        Racun r = new Racun();
                        r.RacunID = int.Parse(reader["ID"].ToString());
                        r.Cena = int.Parse(reader["Cena"].ToString());
                        r.Vreme = DateTime.Parse(reader["Vreme"].ToString());
                        racuni.Add(r);
                    }

                    dataGridView1.DataSource = racuni;

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
            else if (comboBox1.SelectedIndex == 11)
            {
                dataGridView1.DataSource = null;
                try
                {
                    baza.otvoriKonekciju();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = "SELECT * FROM Račun WHERE month(Vreme)=12 ";
                    OleDbDataReader reader = cmd.ExecuteReader();

                    racuni.Clear();
                    while (reader.Read())
                    {
                        Racun r = new Racun();
                        r.RacunID = int.Parse(reader["ID"].ToString());
                        r.Cena = int.Parse(reader["Cena"].ToString());
                        r.Vreme = DateTime.Parse(reader["Vreme"].ToString());
                        racuni.Add(r);
                    }

                    dataGridView1.DataSource = racuni;

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
        }
    }
}
