using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

using VenditaVeicoliDllProject;

namespace WindowsFormsAppProject
{
    public partial class FormDialogAggiungiVeicolo : Form
    {
        private string connStr;
        BindingList<Veicolo> bindingListVeicoli;
        FormMain formMain;
        bool filePicked = false;
        string DBPath = "";
        string path = "";
        string f = "";

        public FormDialogAggiungiVeicolo(BindingList<Veicolo> list, FormMain f)
        {
            InitializeComponent();
            bindingListVeicoli = list;
            this.formMain = f;
            DBPath = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName + "\\Utilities\\Veicoli.accdb";
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DBPath;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            string s = "";
            int i = 0; //per immagine
            int j = 0; //per codice
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
                    OleDbConnection con = new OleDbConnection(connStr);
                    con.Open();
                    OleDbCommand c = new OleDbCommand();
                    c.Connection = con;
                    c.CommandText = "SELECT * FROM Veicoli";

                    OleDbDataReader r = c.ExecuteReader();

                    if (r.HasRows)
                    {
                        while (r.Read())
                        {
                            i++;
                        }
                    }
                    path = i + ".jpg";


                    using (con)
                    {
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = con;

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
                        con.Close();

                        OleDbCommand command2 = new OleDbCommand();
                        command2.Connection = con;
                        con.Open();
                        command2.CommandText = "SELECT CodVeicolo FROM Veicoli";

                        OleDbDataReader r2 = command2.ExecuteReader();

                        if (r2.HasRows)
                        {
                            while (r2.Read())
                            {
                                j = r2.GetInt32(0);
                            }
                        }
                    }

                    bindingListVeicoli.Add(new Auto(j, txtMarca.Text, txtModello.Text, cmbColore.Text, Convert.ToInt32(nudCilindrata.Value), Convert.ToDouble(txtPotenzakW.Text), Convert.ToDateTime(dtpImmatricolazione.Value.ToShortDateString()), usato, kmZero, Convert.ToInt32(nudKmPercorsi.Value), Convert.ToInt32(nudNumeroAirbag.Value), (i + ".jpg")));
                    clsMetodi.caricaDgv(bindingListVeicoli, ((DataGridView)formMain.Controls["dgvVeicoli"]));
                    clsMetodi.checkMarca(txtMarca.Text);
                    clsMetodi.checkColore(cmbColore.Text);
                    File.Copy(f, "img/" + i + ".jpg");
                    formMain.salva();
                    con.Close();
                    this.Close();
                }
                else
                {
                    OleDbConnection con = new OleDbConnection(connStr);
                    con.Open();
                    OleDbCommand c = new OleDbCommand();
                    c.Connection = con;
                    c.CommandText = "SELECT * FROM Veicoli";

                    OleDbDataReader r = c.ExecuteReader();

                    if (r.HasRows)
                    {
                        while (r.Read())
                        {
                            i++;
                        }
                    }
                    path = i + ".jpg";

                    using (con)
                    {
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = con;

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
                        command.Parameters.Add("@informazioni", OleDbType.VarChar, 255).Value = txtSella.Text;
                        command.Parameters.Add("@immagine", OleDbType.VarChar, 255).Value = path;

                        command.Prepare();

                        command.ExecuteNonQuery();
                        con.Close();

                        OleDbCommand command2 = new OleDbCommand();
                        command2.Connection = con;
                        con.Open();
                        command2.CommandText = "SELECT CodVeicolo FROM Veicoli";

                        OleDbDataReader r2 = command2.ExecuteReader();

                        if (r2.HasRows)
                        {
                            while (r2.Read())
                            {
                                j = r2.GetInt32(0);
                            }
                        }
                    }

                    bindingListVeicoli.Add(new Moto(j, txtMarca.Text, txtModello.Text, cmbColore.Text, Convert.ToInt32(nudCilindrata.Value), Convert.ToDouble(txtPotenzakW.Text), Convert.ToDateTime(dtpImmatricolazione.Value.ToShortDateString()), usato, kmZero, Convert.ToInt32(nudKmPercorsi.Value), txtSella.Text, (i + ".jpg")));
                    clsMetodi.caricaDgv(bindingListVeicoli, ((DataGridView)formMain.Controls["dgvVeicoli"]));
                    clsMetodi.checkMarca(txtMarca.Text);
                    clsMetodi.checkColore(cmbColore.Text);
                    File.Copy(f, "img/" + i + ".jpg");
                    formMain.salva();
                    con.Close();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Non è stata selezionata l'immagine da associare al veicolo");
            }
        }

        private void FormDialogAggiungiVeicolo_Load(object sender, EventArgs e)
        {
            cmbTipoVeicolo.SelectedIndex = 0;
            cmbColore.SelectedIndex = 0;
        }

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

        private void btnScegliFile_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            f = openFileDialog.FileName;
            if ((f != "openFileDialog1") && (f != ""))
            {
                filePicked = true;
                path = f;
            }
            else
            {
                filePicked = false;
            }
        }
    }
}


