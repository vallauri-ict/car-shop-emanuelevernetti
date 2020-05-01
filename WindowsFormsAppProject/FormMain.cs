using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

using Microsoft.VisualBasic;

using VenditaVeicoliDllProject;

namespace WindowsFormsAppProject
{
    public partial class FormMain : Form
    {
        private string connStr;

        BindingList<Veicolo> bindingListVeicoli;
        PageSettings pageSettings = new PageSettings();
        bool docModified = false;
        string path;
        OleDbConnection connection;

        public FormMain()
        {
            InitializeComponent();
            bindingListVeicoli = new BindingList<Veicolo>();
            clsMetodi.settaDgv(dgvVeicoli);
            path = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName + "\\Utilities\\Veicoli.accdb";
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
            connection = new OleDbConnection(connStr);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (connStr != null)
            {
                using (connection)
                {
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Veicoli", connection);
                    connection.Open();
                    try
                    {
                        OleDbDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read()) //restituisce true finchè ci sono ancora delle righe
                            {
                                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12}",
                                    reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5),
                                    reader.GetInt32(6), reader.GetDateTime(7), reader.GetBoolean(8), reader.GetBoolean(9), reader.GetInt32(10),
                                    reader.GetString(11), reader.GetString(12));

                                if (reader.GetString(1) == "MOTO")
                                {
                                    Moto m = new Moto(reader.GetInt32(0), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), Convert.ToDouble(reader.GetInt32(6)), reader.GetDateTime(7),
                                        reader.GetBoolean(8), reader.GetBoolean(9), reader.GetInt32(10), reader.GetString(11), reader.GetString(12));
                                    bindingListVeicoli.Add(m);

                                    clsMetodi.checkMarca(reader.GetString(2));
                                    clsMetodi.checkColore(reader.GetString(4));
                                }
                                else
                                {
                                    Auto a = new Auto(reader.GetInt32(0), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), Convert.ToDouble(reader.GetInt32(6)), reader.GetDateTime(7),
                                        reader.GetBoolean(8), reader.GetBoolean(9), reader.GetInt32(10), Convert.ToInt32(reader.GetString(11)), reader.GetString(12));
                                    bindingListVeicoli.Add(a);

                                    clsMetodi.checkMarca(reader.GetString(2));
                                    clsMetodi.checkColore(reader.GetString(4));
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found");
                        }
                        clsMetodi.ordinaListaVeicoli(bindingListVeicoli, "Marca");
                        clsMetodi.caricaDgv(bindingListVeicoli, dgvVeicoli);
                        object[] vet = { "Marca", "Modello", "Colore", "Cilindrata", "PotenzaKw", "Immatricolazione", "IsUsato", "IsKmZero", "KmPercorsi" };
                        toolStripComboBoxFiltro.Items.AddRange(vet);
                        toolStripComboBoxFiltro.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Application.Exit();
                    }
                }
            }
            else
            {
                MessageBox.Show("Set connection string first");
            }
        }

        private void nuovoToolStripButton_Click(object sender, EventArgs e)
        {
            int prevCount = bindingListVeicoli.Count;
            FormDialogAggiungiVeicolo dialogAggiungi = new FormDialogAggiungiVeicolo(bindingListVeicoli, this);
            dialogAggiungi.ShowDialog();
        }

        private void apriToolStripButton_Click(object sender, EventArgs e)
        {
            //bindingListVeicoli.Clear();
            //using (StreamReader sr = new StreamReader("veicoli.dat"))
            //{
            //    if (sr == null)
            //    {
            //        MessageBox.Show("Il file non è stato trovato");
            //    }
            //    else
            //    {
            //        while (sr.Peek() != -1)
            //        {
            //            string s = sr.ReadLine();
            //            string[] aus = s.Split('|');
            //            if (aus[0] == "MOTO")
            //            {
            //                Moto m = new Moto(aus[1].ToString(), aus[2].ToString(), aus[3].ToString(), Convert.ToInt32(aus[4]), Convert.ToDouble(aus[5]), DateTime.Now, Convert.ToBoolean(aus[7]), Convert.ToBoolean(aus[8]), Convert.ToInt32(aus[9]), aus[10].ToString(), aus[11].ToString());
            //                bindingListVeicoli.Add(m);
            //            }
            //            else
            //            {
            //                Auto a = new Auto(aus[1].ToString(), aus[2].ToString(), aus[3].ToString(), Convert.ToInt32(aus[4]), Convert.ToDouble(aus[5]), DateTime.Now, Convert.ToBoolean(aus[7]), Convert.ToBoolean(aus[8]), Convert.ToInt32(aus[9]), Convert.ToInt32(aus[10]), aus[11].ToString());
            //                bindingListVeicoli.Add(a);
            //            }
            //        }
            //    }
            //}
            //clsMetodi.caricaDgv(bindingListVeicoli, dgvVeicoli);
        }

        private void salvaToolStripButton_Click(object sender, EventArgs e)
        {
            salva();
        }

        public void salva()
        {
            //using (StreamWriter sw = new StreamWriter("veicoli.dat", false))
            //{
            //    string s = null;
            //    for (int i = 0; i < bindingListVeicoli.Count; i++)
            //    {
            //        if (bindingListVeicoli[i].GetType().ToString().Contains("Auto"))
            //        {
            //            s = "AUTO|" + bindingListVeicoli[i].Marca + "|" + bindingListVeicoli[i].Modello + "|" + bindingListVeicoli[i].Colore + "|" + bindingListVeicoli[i].Cilindrata + "|" + bindingListVeicoli[i].PotenzaKw + "|" + bindingListVeicoli[i].Immatricolazione + "|" + bindingListVeicoli[i].IsUsato + "|" + bindingListVeicoli[i].IsKmZero + "|" + bindingListVeicoli[i].KmPercorsi + "|" + (bindingListVeicoli[i] as Auto).NumAirbag + "|" + bindingListVeicoli[i].Path;
            //            sw.WriteLine(s);
            //        }
            //        else
            //        {
            //            s = "MOTO|" + bindingListVeicoli[i].Marca + "|" + bindingListVeicoli[i].Modello + "|" + bindingListVeicoli[i].Colore + "|" + bindingListVeicoli[i].Cilindrata + "|" + bindingListVeicoli[i].PotenzaKw + "|" + bindingListVeicoli[i].Immatricolazione + "|" + bindingListVeicoli[i].IsUsato + "|" + bindingListVeicoli[i].IsKmZero + "|" + bindingListVeicoli[i].KmPercorsi + "|" + (bindingListVeicoli[i] as Moto).MarcaSella + "|" + bindingListVeicoli[i].Path;
            //            sw.WriteLine(s);
            //        }
            //    }
            //}
            //docModified = false;
        }

        private void stampaToolStripButton_Click(object sender, EventArgs e)
        {
            clsMetodi.ordinaListaVeicoli(bindingListVeicoli, "Marca");
            FormVisualizzazioneVolantino fv = new FormVisualizzazioneVolantino(bindingListVeicoli, this);
            fv.Show();
            Utils.SerializeToJson(bindingListVeicoli, "veicoli.json");
        }

        private void toolStripButtonHtml_Click(object sender, EventArgs e)
        {
            string html = File.ReadAllText(".\\www\\index-skeleton.html");
            string s = "";
            int index = 0;
            for (int i = 0; i < bindingListVeicoli.Count; i++)
            {
                if (bindingListVeicoli[i] is Auto)
                {
                    s += "<div class='auto' id=" + index + ">" + bindingListVeicoli[i].Marca + " " + bindingListVeicoli[i].Modello + "</div>";
                    index++;
                }
                else
                {
                    s += "<div class='moto' id=" + index + ">" + bindingListVeicoli[i].Marca + " " + bindingListVeicoli[i].Modello + "</div>";
                    index++;
                }
            }
            html = html.Replace("{{mainContent}}", s);
            File.WriteAllText(".\\www\\index.html", html);
            Process.Start(".\\www\\index.html");
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (docModified)
            {
                DialogResult dg = MessageBox.Show("Sono state apportate delle modifiche, si desidera salvarle?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dg == DialogResult.Yes)
                {
                    salva();
                }
                else if (dg == DialogResult.No)
                {
                    MessageBox.Show("Le modifiche non sono state salvate.", "Uscita");
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void toolStripComboBoxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = toolStripComboBoxFiltro.Text;
            clsMetodi.ordinaListaVeicoli(bindingListVeicoli, s);
            clsMetodi.caricaDgv(bindingListVeicoli, dgvVeicoli);
        }

        private void btnEliminaVeicolo_Click(object sender, EventArgs e)
        {
            int pos = Convert.ToInt32(Interaction.InputBox("Inserisci il codice univoco del veicolo da eliminare"));
            OleDbConnection con = new OleDbConnection(connStr);
            using (con)
            {
                OleDbCommand command = new OleDbCommand("DELETE FROM Veicoli WHERE CodVeicolo=@pos", con);
                con.Open();
                command.Parameters.Add("@pos", OleDbType.Integer).Value = pos;
                try
                {
                    command.ExecuteNonQuery();
                    bool state = deleteItem(pos);
                    if (state)
                    {
                        MessageBox.Show("Veicolo eliminato correttamente");
                    }
                    else
                    {
                        MessageBox.Show("Codice errato");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool deleteItem(int pos)
        {
            int i = 0;
            bool trovato = false;
            while ((!trovato) && (i < bindingListVeicoli.Count))
            {
                if (bindingListVeicoli[i].CodVeicolo == pos)
                {
                    return true;
                }
                else
                {
                    i++;
                }
            }
            return false;
        }
    }
}
