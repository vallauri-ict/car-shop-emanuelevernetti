using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

using VenditaVeicoliDllProject;

namespace WindowsFormsAppProject
{
    public partial class FormMain : Form
    {
        private string connStr;

        BindingList<Veicolo> bindingListVeicoli; //Lista contenente i veicoli
        PageSettings pageSettings = new PageSettings(); //Impostazioni per la stampa
        bool docModified = false; //variabile booleana per controllare se vengono apportate delle modifiche o meno
        OleDbConnection connection;

        /// <summary>
        /// Costruttore della form che provvede a settare il DataGridView
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            bindingListVeicoli = new BindingList<Veicolo>();
            clsMetodi.settaDgv(dgvVeicoli);
            string path = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName + "\\Utilities\\Veicoli.accdb";
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
            connection = new OleDbConnection(connStr);
        }

        /// <summary>
        /// Caricamento di dati contenuti nel file veicoli.dat all'interno della lista
        /// Controlla se serve aggiungere delle marche o dei colori alle due ComboBox presenti in FormVisualizzazioneVolantino
        /// Ordinamento della lista in base alla marca dei veicoli
        /// Caricamento del DataGridView
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
                                    Moto m = new Moto(reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), Convert.ToDouble(reader.GetInt32(6)), reader.GetDateTime(7),
                                        reader.GetBoolean(8), reader.GetBoolean(9), reader.GetInt32(10), reader.GetString(11), reader.GetString(12));
                                    bindingListVeicoli.Add(m);

                                    clsMetodi.checkMarca(reader.GetString(2));
                                    clsMetodi.checkColore(reader.GetString(4));
                                }
                                else
                                {
                                    Auto a = new Auto(reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), Convert.ToDouble(reader.GetInt32(6)), reader.GetDateTime(7),
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
                        dgvVeicoli.CellClick += DgvVeicoli_CellClick;
                        object[] vet = { "Marca", "Modello", "Colore", "Cilindrata", "PotenzaKw", "Immatricolazione", "IsUsato", "IsKmZero", "KmPercorsi" };
                        toolStripComboBoxFiltro.Items.AddRange(vet);
                        toolStripComboBoxFiltro.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Set connection string first");
            }

            #region Caricamento tramite file
            /*
                //using (StreamReader sr = new StreamReader("veicoli.dat"))
                //{
                //    string s = null;
                //    bool usato, kmZero;
                //    object[] array = new object[20];
                //    if (sr != null)
                //    {
                //        while (sr.Peek() != -1)
                //        {
                //            s = sr.ReadLine();
                //            array = s.Split('|');
                //            if (array[0].ToString() == "MOTO")
                //            {
                //                //MOTO
                //                if ((array[7].ToString() == "False") || (array[7].ToString() == "false") || (array[7].ToString() == "f") || (array[7].ToString() == "F"))
                //                {
                //                    usato = false;
                //                }
                //                else
                //                {
                //                    usato = true;
                //                }
                //                if ((array[8].ToString() == "False") || (array[8].ToString() == "false") || (array[8].ToString() == "f") || (array[8].ToString() == "F"))
                //                {
                //                    kmZero = false;
                //                }
                //                else
                //                {
                //                    kmZero = true;
                //                }
                //                Moto m = new Moto(array[1].ToString(), array[2].ToString(), array[3].ToString(), Convert.ToInt32(array[4]), Convert.ToDouble(array[5]), Convert.ToDateTime(array[6]), usato, kmZero, Convert.ToInt32(array[9]), array[10].ToString(), array[11].ToString());
                //                bindingListVeicoli.Add(m);
                //                clsMetodi.checkMarca(array[1].ToString());
                //                clsMetodi.checkColore(array[3].ToString());
                //            }
                //            else
                //            {
                //                //AUTO
                //                if ((array[7].ToString() == "False") || (array[7].ToString() == "false") || (array[7].ToString() == "f") || (array[7].ToString() == "F"))
                //                {
                //                    usato = false;
                //                }
                //                else
                //                {
                //                    usato = true;
                //                }
                //                if ((array[8].ToString() == "False") || (array[8].ToString() == "false") || (array[8].ToString() == "f") || (array[8].ToString() == "F"))
                //                {
                //                    kmZero = false;
                //                }
                //                else
                //                {
                //                    kmZero = true;
                //                }
                //                Auto a = new Auto(array[1].ToString(), array[2].ToString(), array[3].ToString(), Convert.ToInt32(array[4]), Convert.ToDouble(array[5]), Convert.ToDateTime(array[6]), usato, kmZero, Convert.ToInt32(array[9]), Convert.ToInt32(array[10]), array[11].ToString());
                //                bindingListVeicoli.Add(a);
                //                clsMetodi.checkMarca(array[1].ToString());
                //                clsMetodi.checkColore(array[3].ToString());
                //            }
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("File non trovato");
                //    }
                //    dgvVeicoli.CellClick += DgvVeicoli_CellClick;
                //    object[] vet = { "Marca", "Modello", "Colore", "Cilindrata", "PotenzaKw", "Immatricolazione", "IsUsato", "IsKmZero", "KmPercorsi" };
                //    toolStripComboBoxFiltro.Items.AddRange(vet);
                //    toolStripComboBoxFiltro.SelectedIndex = 0;
                //}
                */
            #endregion
        }

        /// <summary>
        /// Evento generato in corrispondenza del click su uno dei pulsanti "Elimina" contenuti nell'ultima colonna di ogni riga del DataGridView
        /// </summary>
        private void DgvVeicoli_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                DialogResult dg = MessageBox.Show("Si è sicuri di voler eliminare il veicolo? (questa operazione non può essere annullata)", "Cancellazione veicolo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg == DialogResult.Yes)
                {
                    int pos = e.RowIndex;
                    File.Delete(bindingListVeicoli[pos].Path);
                    using (connection)
                    {
                        connection = new OleDbConnection(connStr);
                        connection.Open();
                        OleDbCommand deleteRecord = new OleDbCommand("DELETE FROM Veicoli AS v WHERE v.Immagine='" + bindingListVeicoli[pos].Path + "';", connection);
                        deleteRecord.ExecuteNonQuery();
                    }
                    bindingListVeicoli.RemoveAt(pos);
                    clsMetodi.caricaDgv(bindingListVeicoli, dgvVeicoli);
                    docModified = true;
                    salva();
                }
            }
        }


        /// <summary>
        /// Crea un'istanza di FormDialogAggiungiVeicolo, la mostra e poi controlla se il veicolo è stato aggiunto o meno, in modo che, sulla generazione del evento Closing
        /// legato a FormMain, si possa sapere se chiedere all'utente di salvare i dati o meno. 
        /// Se non vengono apportate modifiche, la variabile docModified è false e quindi, non si va a chiedere all'utente se desidera salvare i dati.
        /// </summary>
        private void nuovoToolStripButton_Click(object sender, EventArgs e)
        {
            int prevCount = bindingListVeicoli.Count;
            FormDialogAggiungiVeicolo dialogAggiungi = new FormDialogAggiungiVeicolo(bindingListVeicoli, this);
            dialogAggiungi.ShowDialog();
        }

        /// <summary>
        /// Cerca il file veicoli.dat nella cartella bin/Debug e, se viene trovato, viene fatta una Peek che scorre il file e carica la lista contenente i veicoli
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void apriToolStripButton_Click(object sender, EventArgs e)
        {
            bindingListVeicoli.Clear();
            using (StreamReader sr = new StreamReader("veicoli.dat"))
            {
                if (sr == null)
                {
                    MessageBox.Show("Il file non è stato trovato");
                }
                else
                {
                    while (sr.Peek() != -1)
                    {
                        string s = sr.ReadLine();
                        string[] aus = s.Split('|');
                        if (aus[0] == "MOTO")
                        {
                            Moto m = new Moto(aus[1].ToString(), aus[2].ToString(), aus[3].ToString(), Convert.ToInt32(aus[4]), Convert.ToDouble(aus[5]), DateTime.Now, Convert.ToBoolean(aus[7]), Convert.ToBoolean(aus[8]), Convert.ToInt32(aus[9]), aus[10].ToString(), aus[11].ToString());
                            bindingListVeicoli.Add(m);
                        }
                        else
                        {
                            Auto a = new Auto(aus[1].ToString(), aus[2].ToString(), aus[3].ToString(), Convert.ToInt32(aus[4]), Convert.ToDouble(aus[5]), DateTime.Now, Convert.ToBoolean(aus[7]), Convert.ToBoolean(aus[8]), Convert.ToInt32(aus[9]), Convert.ToInt32(aus[10]), aus[11].ToString());
                            bindingListVeicoli.Add(a);
                        }
                    }
                }
            }
            clsMetodi.caricaDgv(bindingListVeicoli, dgvVeicoli);
        }

        /// <summary>
        /// Richiama la funzione salva() che provvede a salvare i dati contenuti nella lista all'interno del file veicoli.dat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salvaToolStripButton_Click(object sender, EventArgs e)
        {
            salva();
        }

        public void salva()
        {
            using (StreamWriter sw = new StreamWriter("veicoli.dat", false))
            {
                string s = null;
                for (int i = 0; i < bindingListVeicoli.Count; i++)
                {
                    if (bindingListVeicoli[i].GetType().ToString().Contains("Auto"))
                    {
                        s = "AUTO|" + bindingListVeicoli[i].Marca + "|" + bindingListVeicoli[i].Modello + "|" + bindingListVeicoli[i].Colore + "|" + bindingListVeicoli[i].Cilindrata + "|" + bindingListVeicoli[i].PotenzaKw + "|" + bindingListVeicoli[i].Immatricolazione + "|" + bindingListVeicoli[i].IsUsato + "|" + bindingListVeicoli[i].IsKmZero + "|" + bindingListVeicoli[i].KmPercorsi + "|" + (bindingListVeicoli[i] as Auto).NumAirbag + "|" + bindingListVeicoli[i].Path;
                        sw.WriteLine(s);
                    }
                    else
                    {
                        s = "MOTO|" + bindingListVeicoli[i].Marca + "|" + bindingListVeicoli[i].Modello + "|" + bindingListVeicoli[i].Colore + "|" + bindingListVeicoli[i].Cilindrata + "|" + bindingListVeicoli[i].PotenzaKw + "|" + bindingListVeicoli[i].Immatricolazione + "|" + bindingListVeicoli[i].IsUsato + "|" + bindingListVeicoli[i].IsKmZero + "|" + bindingListVeicoli[i].KmPercorsi + "|" + (bindingListVeicoli[i] as Moto).MarcaSella + "|" + bindingListVeicoli[i].Path;
                        sw.WriteLine(s);
                    }
                }
            }
            docModified = false;
        }

        /// <summary>
        /// Crea un'istanza di FormVisualizzazioneVolantino che contiene i vari veicoli contenute nella lista con le varie immagini e la mostra;
        /// inoltre, provvede a serializzare in Json la lista e a salvare il file veicoli.json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stampaToolStripButton_Click(object sender, EventArgs e)
        {
            clsMetodi.ordinaListaVeicoli(bindingListVeicoli, "Marca");
            FormVisualizzazioneVolantino fv = new FormVisualizzazioneVolantino(bindingListVeicoli, this);
            fv.Show();
            Utils.SerializeToJson(bindingListVeicoli, "veicoli.json");
        }

        /// <summary>
        /// Genera la pagina HTML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// A seconda del valore della variabile docModified, chiede all'utente se salvare i dati o meno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Provvede a ordinare la lista in base al filtro scelto dalla ComboBox e poi a caricare il DataGridView con la lista ordinata.
        /// I DATI VENGONO RICAVATI DA UN'ORIGINE DATI, IMPOSTATA DAL Designer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBoxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = toolStripComboBoxFiltro.Text;
            clsMetodi.ordinaListaVeicoli(bindingListVeicoli, s);
            clsMetodi.caricaDgv(bindingListVeicoli, dgvVeicoli);
        }
    }
}
