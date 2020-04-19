using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

using VenditaVeicoliDllProject;

namespace WindowsFormsAppProject
{
    public partial class FormDialogAggiungiVeicolo : Form
    {
        private string connStr;
        BindingList<Veicolo> bindingListVeicoli;
        FormMain formMain;
        bool filePicked = false; //Controlla se il file è stato selezionato o meno
        string path = ""; //Path dell'immagine da associare al veicolo che viene inserito
        string f = "";
        int pos = Int32.MinValue;
        OleDbConnection connection;
        
        /// <summary>
        /// Costruttore della form
        /// </summary>
        /// <param name="list">Lista contenente i veicoli</param>
        /// <param name="f">FormMain (parametro necessario per accedere ai controlli della form principale)</param>
        public FormDialogAggiungiVeicolo(BindingList<Veicolo> list, FormMain f)
        {
            InitializeComponent();
            bindingListVeicoli = list;
            this.formMain = f;
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veicoli.accdb";
            connection = new OleDbConnection(connStr);
        }

        /// <summary>
        /// Chiude la FormDialogAggiungiVeicolo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Effettua dei controlli sulla correttezza dei dati nel caso in cui non ci siano errori, provvede ad aggiungere il veicolo alla lista 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            string s = "";
            if (filePicked)
            {
                bool usato;
                bool kmZero;
                if (rdbUsatoSì.Checked)
                {
                    usato = true;
                }
                else
                {
                    usato = false;
                }
                if (rdbKmZeroSì.Checked)
                {
                    kmZero = true;
                }
                else
                {
                    kmZero = false;
                }
                if (txtMarca.Text == "")
                {
                    s = "marca";
                }
                if (txtModello.Text == "")
                {
                    s += "\nmodello";
                }
                if (txtPotenzakW.Text == "")
                {
                    s += "\npotenzakW";
                }
                try
                {
                    int cilind = Convert.ToInt32(nudCilindrata.Value);
                }
                catch (Exception)
                {
                    s = "\ncilindrata";
                }
                try
                {
                    int kmp = Convert.ToInt32(nudKmPercorsi.Value);
                }
                catch (Exception)
                {
                    s += "\nnumero Km percorsi";
                }
                if (cmbTipoVeicolo.SelectedIndex == 0)
                {
                    //AUTO
                    try
                    {
                        int nAirbag = Convert.ToInt32(nudNumeroAirbag.Value);
                    }
                    catch (Exception)
                    {
                        s += "\nnumero di airbag";
                    }
                }
                else
                {
                    //MOTO
                    if (txtSella.Text == "")
                    {
                        s += "\nsella";
                    }
                }
                if (s != "")
                {
                    MessageBox.Show("Inserire i dati correttamente." +
                        "\nI dati da correggere sono:\n" + s);
                }
                else if (cmbTipoVeicolo.SelectedIndex == 0)
                {

                    bindingListVeicoli.Add(new Auto(txtMarca.Text, txtModello.Text, cmbColore.Text, Convert.ToInt32(nudCilindrata.Value), Convert.ToDouble(txtPotenzakW.Text), Convert.ToDateTime(dtpImmatricolazione.Value), usato, kmZero, Convert.ToInt32(nudKmPercorsi.Value), Convert.ToInt32(nudNumeroAirbag.Value), path));
                    clsMetodi.caricaDgv(bindingListVeicoli, ((DataGridView)formMain.Controls["dgvVeicoli"]));
                    clsMetodi.checkMarca(txtMarca.Text);
                    clsMetodi.checkColore(cmbColore.Text);
                    File.Copy(f, "img/" + f, true);
                    formMain.salva();

                    //Aggiunta al DB
                    using (connection)
                    {
                        OleDbCommand command = new OleDbCommand();
                        connection.Open();
                        command.Connection = connection;
                        #region badQuery
                        //command.CommandText = "INSERT INTO Veicoli (Tipologia, Marca, Modello, Colore, Cilindrata, PotenzaKw, Immatricolazione, IsUsato, IsKmZero, KmPercorsi, Informazioni, Immagine) " +
                        //    "VALUES ('" + cmbTipoVeicolo.Text.ToUpper() + "','" + txtMarca.Text + "','" + txtModello.Text + "','"
                        //    + cmbColore.Text + "'," + Convert.ToInt32(nudCilindrata.Value) + ","
                        //    + Convert.ToInt32(txtPotenzakW.Text) + ",#" + dtpImmatricolazione.Value.ToShortDateString()
                        //    + "#," + usato + "," + kmZero + "," + Convert.ToInt32(nudKmPercorsi.Value)
                        //    + ",'" + nudNumeroAirbag.Value.ToString() + "','" + path + "');"; 
                        #endregion

                        command.CommandText = "INSERT INTO Veicoli (Tipologia, Marca, Modello, Colore, Cilindrata, PotenzaKw, Immatricolazione, IsUsato, IsKmZero, KmPercorsi, Informazioni, Immagine) VALUES" +
                            "(@tipologia, @marca, @modello, @colore, @cilindrata, @potenzakw, @immatricolazione, @isusato, @iskmzero, @iskmpercorsi, @informazioni, @immagine)";

                        command.Parameters.Add(new OleDbParameter("@tipologia", OleDbType.VarChar, 255)).Value = cmbTipoVeicolo.Text;
                        command.Parameters.Add("@marca", OleDbType.VarChar, 255).Value = txtMarca.Text;
                        command.Parameters.Add("@modello", OleDbType.VarChar, 255).Value = txtModello.Text;
                        command.Parameters.Add("@colore", OleDbType.VarChar, 255).Value = cmbColore.Text;
                        command.Parameters.Add("@cilindrata", OleDbType.Integer).Value = Convert.ToInt32(nudCilindrata.Value);
                        command.Parameters.Add("@potenzakw", OleDbType.Integer).Value = Convert.ToInt32(txtPotenzakW.Text);
                        command.Parameters.Add("@immatricolazione", OleDbType.Date).Value = Convert.ToDateTime(dtpImmatricolazione.Value.ToShortDateString());
                        command.Parameters.Add("@isusato", OleDbType.Boolean).Value = usato;
                        command.Parameters.Add("@iskmzero", OleDbType.Boolean).Value = kmZero;
                        command.Parameters.Add("@kmpercorsi", OleDbType.Integer).Value = Convert.ToInt32(nudKmPercorsi.Value);
                        command.Parameters.Add("@informazioni", OleDbType.VarChar, 255).Value = nudNumeroAirbag.Value.ToString();
                        command.Parameters.Add("@immagine", OleDbType.VarChar, 255).Value = path;
                        
                        command.Prepare();

                        command.ExecuteNonQuery();
                    }
                    this.Close();
                }
                else
                {
                    bindingListVeicoli.Add(new Moto(txtMarca.Text, txtModello.Text, cmbColore.Text, Convert.ToInt32(nudCilindrata.Value), Convert.ToDouble(txtPotenzakW.Text), Convert.ToDateTime(dtpImmatricolazione.Value), usato, kmZero, Convert.ToInt32(nudKmPercorsi.Value), txtSella.Text, path));
                    clsMetodi.caricaDgv(bindingListVeicoli, ((DataGridView)formMain.Controls["dgvVeicoli"]));
                    clsMetodi.checkMarca(txtMarca.Text);
                    clsMetodi.checkColore(cmbColore.Text);
                    File.Copy(f, "img/" + f, true);
                    formMain.salva();

                    //Aggiunta al DB
                    using (connection)
                    {
                        OleDbCommand command = new OleDbCommand();
                        connection.Open();
                        command.Connection = connection;

                        command.CommandText= "INSERT INTO Veicoli (Tipologia, Marca, Modello, Colore, Cilindrata, PotenzaKw, Immatricolazione, IsUsato, IsKmZero, KmPercorsi, Informazioni, Immagine) VALUES" +
                            "(@tipologia, @marca, @modello, @colore, @cilindrata, @potenzakw, @immatricolazione, @isusato, @iskmzero, @iskmpercorsi, @informazioni, @immagine)";

                        command.Parameters.Add(new OleDbParameter("@tipologia", OleDbType.VarChar, 255)).Value = cmbTipoVeicolo.Text;
                        command.Parameters.Add("@marca", OleDbType.VarChar).Value = txtMarca.Text;
                        command.Parameters.Add("@modello", OleDbType.VarChar).Value = txtModello.Text;
                        command.Parameters.Add("@colore", OleDbType.VarChar).Value = cmbColore.Text;
                        command.Parameters.Add("@cilindrata", OleDbType.Integer).Value = Convert.ToInt32(nudCilindrata.Value);
                        command.Parameters.Add("@potenzakw", OleDbType.Integer).Value = Convert.ToInt32(txtPotenzakW.Text);
                        command.Parameters.Add("@immatricolazione", OleDbType.Date).Value = Convert.ToDateTime(dtpImmatricolazione.Value.ToShortDateString());
                        command.Parameters.Add("@isusato", OleDbType.Boolean).Value = usato;
                        command.Parameters.Add("@iskmzero", OleDbType.Boolean).Value = kmZero;
                        command.Parameters.Add("@kmpercorsi", OleDbType.Integer).Value = Convert.ToInt32(nudKmPercorsi.Value);
                        command.Parameters.Add("@informazioni", OleDbType.VarChar).Value = txtSella.Text;
                        command.Parameters.Add("@immagine", OleDbType.VarChar).Value = path;

                        command.Prepare();

                        command.ExecuteNonQuery();
                    }
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Non è stata selezionata l'immagine da associare al veicolo");
            }
        }

        /// <summary>
        /// Imposta i valori delle due ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDialogAggiungiVeicolo_Load(object sender, EventArgs e)
        {
            cmbTipoVeicolo.SelectedIndex = 0;
            cmbColore.SelectedIndex = 0;
        }

        /// <summary>
        /// Visualizza il GroupBox relativo al tipo di veicolo selezionato e nasconde l'altro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTipoVeicolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoVeicolo.SelectedIndex == 0)
            {
                groupBoxCaratteristicheAuto.Visible = true;
                groupBoxCaratteristicheMoto.Visible = false;
            }
            else
            {
                groupBoxCaratteristicheAuto.Visible = false;
                groupBoxCaratteristicheMoto.Visible = true;
            }
        }

        /// <summary>
        /// A seconda del fatto che il checkbox sia selezionato o meno, imposta di conseguenza il NumericUpDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbKmZeroSì_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbKmZeroSì.Checked)
            {
                nudKmPercorsi.Minimum = 0;
            }
            else
            {
                nudKmPercorsi.Minimum = 1;
            }
        }

        /// <summary>
        /// A seconda del fatto che il checkbox sia selezionato o meno, imposta di conseguenza il NumericUpDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbUsatoSì_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUsatoSì.Checked)
            {
                nudKmPercorsi.Minimum = 1;
            }
            else
            {
                nudKmPercorsi.Minimum = 0;
            }
        }

        /// <summary>
        /// Attraverso il controllo OpenFileDialog consente all'utente di selezionare il file contenente l'immagine da associare al veicolo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScegliFile_Click(object sender, EventArgs e)
        {
            pos = bindingListVeicoli.Count+1;
            openFileDialog.ShowDialog();
            f = openFileDialog.FileName;
            if ((f != "openFileDialog1") && (f != ""))
            {
                filePicked = true;
                path = "img/img" + pos + ".jpg";
            }
            else
            {
                filePicked = false;
            }
        }
    }
}


