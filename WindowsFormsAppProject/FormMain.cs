//VERNETTI EMANUELE
using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

using ADOX;

using Microsoft.VisualBasic;

using VenditaVeicoliDllProject;

namespace WindowsFormsAppProject
{
    public partial class FormMain : Form
    {
        private string connStr;

        BindingList<Veicolo> bindingListVeicoli;

        string path;
        OleDbConnection connection;

        public FormMain()
        {
            InitializeComponent();
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Utilities\\Veicoli.accdb";
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;

            if (!((Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Utilities"))))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Utilities");

            }
            if (!((Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Utilities\\img"))))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Utilities\\img");
                Bitmap bmp = new Bitmap(200, 200);
                bmp.Save((Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Utilities\\img/NoImage.jpg"), ImageFormat.Jpeg);
            }
            if (!(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Utilities\\Veicoli.accdb")))
            {
                var cat = new Catalog();
                cat.Create(connStr);
                DialogResult dg = MessageBox.Show("Database creato correttamente.\nSi desidera creare anche la tabella 'Veicoli' (necessaria per il corretto funzionamento del programma", "DB", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        CarShopConsoleProject.Program.creaTabella();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }

            bindingListVeicoli = new BindingList<Veicolo>();

            clsMetodi.settaDgv(dgvVeicoli);
            connection = new OleDbConnection(connStr);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (connStr != null)
            {
                try
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
                                while (reader.Read())
                                {

                                    if (reader.GetString(1) == "MOTO")
                                    {
                                        Moto m = new Moto(reader.GetInt32(0), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), Convert.ToDouble(reader.GetInt32(6)), reader.GetDateTime(7), reader.GetBoolean(8), reader.GetBoolean(9), reader.GetInt32(10), reader.GetString(11), reader.GetString(12));
                                        bindingListVeicoli.Add(m);
                                    }
                                    else
                                    {
                                        Auto a = new Auto(reader.GetInt32(0), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), Convert.ToDouble(reader.GetInt32(6)), reader.GetDateTime(7), reader.GetBoolean(8), reader.GetBoolean(9), reader.GetInt32(10), Convert.ToInt32(reader.GetString(11)), reader.GetString(12));
                                        bindingListVeicoli.Add(a);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("No rows found");
                            }
                            clsMetodi.ordinaListaVeicoli(bindingListVeicoli, "CodVeicolo");
                            clsMetodi.caricaDgv(bindingListVeicoli, dgvVeicoli);
                            object[] vet = { "CodVeicolo", "Marca", "Modello", "Colore", "Cilindrata", "PotenzaKw", "Immatricolazione", "IsUsato", "IsKmZero", "KmPercorsi" };
                            toolStripComboBoxFiltro.Items.AddRange(vet);
                            toolStripComboBoxFiltro.SelectedIndex = 0;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Impostare la stringa di connessione");
            }
        }

        private void nuovoToolStripButton_Click(object sender, EventArgs e)
        {
            FormAggiungiVeicolo dialogAggiungi = new FormAggiungiVeicolo(bindingListVeicoli, this);
            dialogAggiungi.ShowDialog();
        }

        private void salvaToolStripButton_Click(object sender, EventArgs e)
        {
            salva();
        }

        public void salva()
        {
            if (bindingListVeicoli.Count != 0)
            {
                clsMetodi.ordinaListaVeicoli(bindingListVeicoli, "CodVeicolo");
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Utilities\\Veicoli.dat";
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    string s = null;
                    for (int i = 0; i < bindingListVeicoli.Count; i++)
                    {
                        if (bindingListVeicoli[i].GetType().ToString().Contains("Auto"))
                        {
                            s = "AUTO|" + bindingListVeicoli[i].CodVeicolo + "|" + bindingListVeicoli[i].Marca + "|" + bindingListVeicoli[i].Modello + "|" + bindingListVeicoli[i].Colore + "|" + bindingListVeicoli[i].Cilindrata + "|" + bindingListVeicoli[i].PotenzaKw + "|" + bindingListVeicoli[i].Immatricolazione.ToShortDateString() + "|" + bindingListVeicoli[i].IsUsato + "|" + bindingListVeicoli[i].IsKmZero + "|" + bindingListVeicoli[i].KmPercorsi + "|" + (bindingListVeicoli[i] as Auto).NumAirbag + "|" + bindingListVeicoli[i].Path;
                            sw.WriteLine(s);
                        }
                        else
                        {
                            s = "MOTO|" + bindingListVeicoli[i].CodVeicolo + "|" + bindingListVeicoli[i].Marca + "|" + bindingListVeicoli[i].Modello + "|" + bindingListVeicoli[i].Colore + "|" + bindingListVeicoli[i].Cilindrata + "|" + bindingListVeicoli[i].PotenzaKw + "|" + bindingListVeicoli[i].Immatricolazione.ToShortDateString() + "|" + bindingListVeicoli[i].IsUsato + "|" + bindingListVeicoli[i].IsKmZero + "|" + bindingListVeicoli[i].KmPercorsi + "|" + (bindingListVeicoli[i] as Moto).MarcaSella + "|" + bindingListVeicoli[i].Path;
                            sw.WriteLine(s);
                        }
                    }
                }
            }
        }

        private void modificaToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                int cod = Convert.ToInt32(Interaction.InputBox("Inserisci il codice univoco del veicolo da modificare", "Modifica veicolo", "Codice del veicolo da modificare"));
                FormModificaVeicolo fmv = new FormModificaVeicolo(this, bindingListVeicoli, cod);
                fmv.ShowDialog();
                clsMetodi.caricaDgv(bindingListVeicoli, dgvVeicoli);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void eliminaToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                int pos = Convert.ToInt32(Interaction.InputBox("Inserisci il codice univoco del veicolo da eliminare", "Elimina veicolo", "Codice del veicolo da eliminare"));
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    if (bindingListVeicoli[i].Path == Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Utilities\\img/NoImage.jpg")
                    {
                        bindingListVeicoli.RemoveAt(i);
                        return true;
                    }
                    else
                    {
                        File.Delete(bindingListVeicoli[i].Path);
                        bindingListVeicoli.RemoveAt(i);
                        return true;
                    }
                }
                else
                {
                    i++;
                }
            }
            return false;
        }

        private void stampaToolStripButton_Click(object sender, EventArgs e)
        {
            clsMetodi.ordinaListaVeicoli(bindingListVeicoli, "CodVeicolo");
            FormVisualizzazioneVolantino fv = new FormVisualizzazioneVolantino(bindingListVeicoli, this);
            fv.Show();
        }

        private void JsonToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                clsMetodi.ordinaListaVeicoli(bindingListVeicoli, "CodVeicolo");
                string filepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Utilities\\Veicoli.json";
                Utils.SerializeToJson(bindingListVeicoli, filepath);
                DialogResult dg = MessageBox.Show("Documento creato correttamente, desideri aprirlo?", "JSON", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dg == DialogResult.Yes)
                {
                    Process.Start(filepath);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void HTMLToolStripButton_Click(object sender, EventArgs e)
        {
            clsMetodi.ordinaListaVeicoli(bindingListVeicoli, "CodVeicolo");
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
            DialogResult dg = MessageBox.Show("Sei sicuro di voler uscire?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.Yes)
            {
                salva();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void toolStripComboBoxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = toolStripComboBoxFiltro.Text;
            clsMetodi.ordinaListaVeicoli(bindingListVeicoli, s);
            clsMetodi.caricaDgv(bindingListVeicoli, dgvVeicoli);
        }

        private void WordToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Utils.esportaInWord();
                DialogResult dg = MessageBox.Show("Documento creato correttamente, desideri aprirlo?", "Word", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dg == DialogResult.Yes)
                {
                    string filepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Utilities\\Veicoli.docx";
                    Process.Start(filepath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void ExcelToolStripButton_Click(object sender, EventArgs e)
        {
            clsMetodi.ordinaListaVeicoli(bindingListVeicoli, "CodVeicolo");
            try
            {
                string filepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Utilities\\Veicoli.csv";
                Utils.SerializeToCsv(bindingListVeicoli, filepath);
                DialogResult dg = MessageBox.Show("Documento creato correttamente, desideri aprirlo?", "CSV", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dg == DialogResult.Yes)
                {
                    Process.Start(filepath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
