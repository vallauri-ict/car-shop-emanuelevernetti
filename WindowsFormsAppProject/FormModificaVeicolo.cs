using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Windows.Forms;

using VenditaVeicoliDllProject;

namespace WindowsFormsAppProject
{
    public partial class FormModificaVeicolo : Form
    {
        private string connStr;
        private BindingList<Veicolo> bindingListVeicoli;
        int cod;
        string path;
        OleDbConnection connection;
        string type;
        FormMain fm;

        public FormModificaVeicolo(FormMain formMain, BindingList<Veicolo> bindingListVeicoli, int cod)
        {
            InitializeComponent();
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Utilities\\Veicoli.accdb";
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
            connection = new OleDbConnection(connStr);
            this.bindingListVeicoli = bindingListVeicoli;
            this.cod = cod;
            this.fm = formMain;
        }

        private void FormModificaVeicolo_Load(object sender, EventArgs e)
        {
            if (connStr != null)
            {
                try
                {
                    using (connection)
                    {
                        OleDbCommand command = new OleDbCommand("SELECT * FROM Veicoli WHERE CodVeicolo=@codice", connection);
                        command.Parameters.Add("@codice", OleDbType.Integer).Value = cod;
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
                                        type = "moto";
                                        gpbAuto.Visible = false;
                                        gpbMoto.Visible = true;
                                        txtMarcaMoto.Text = reader.GetString(2);
                                        txtModelloMoto.Text = reader.GetString(3);
                                        txtColoreMoto.Text = reader.GetString(4);
                                        txtCilindrataMoto.Text = (Convert.ToString(reader.GetInt32(5)));
                                        txtPotenzaKwMoto.Text = (Convert.ToString(reader.GetInt32(6)));
                                        txtImmatricolazioneMoto.Text = (reader.GetDateTime(7).ToShortDateString());
                                        if (reader.GetBoolean(8))
                                        {
                                            chkUsatoMoto.Checked = true;
                                        }
                                        else
                                        {
                                            chkUsatoMoto.Checked = false;
                                        }
                                        if (reader.GetBoolean(9))
                                        {
                                            chkKm0Moto.Checked = true;
                                        }
                                        else
                                        {
                                            chkKm0Moto.Checked = false;
                                        }
                                        txtKmPercorsiMoto.Text = Convert.ToString(reader.GetInt32(10));
                                        txtMarcaSella.Text = reader.GetString(11);
                                    }
                                    else
                                    {
                                        type = "auto";
                                        gpbMoto.Visible = false;
                                        gpbAuto.Visible = true;
                                        txtMarcaAuto.Text = reader.GetString(2);
                                        txtModelloAuto.Text = reader.GetString(3);
                                        txtColoreAuto.Text = reader.GetString(4);
                                        txtCilindrataAuto.Text = (Convert.ToString(reader.GetInt32(5)));
                                        txtPotenzaKwAuto.Text = (Convert.ToString(reader.GetInt32(6)));
                                        txtImmatricolazioneAuto.Text = (reader.GetDateTime(7).ToShortDateString());
                                        if (reader.GetBoolean(8))
                                        {
                                            chkUsatoAuto.Checked = true;
                                        }
                                        else
                                        {
                                            chkUsatoAuto.Checked = false;
                                        }
                                        if (reader.GetBoolean(9))
                                        {
                                            chkKm0Auto.Checked = true;
                                        }
                                        else
                                        {
                                            chkKm0Auto.Checked = false;
                                        }
                                        txtKmPercorsiAuto.Text = Convert.ToString(reader.GetInt32(10));
                                        txtNumeroAirbag.Text = reader.GetString(11);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Veicolo non trovato");
                                this.Close();
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
            else
            {
                MessageBox.Show("Impostare la stringa di connessione");
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            OleDbConnection oledbcon2 = new OleDbConnection(connStr);
            if (connStr != null)
            {
                try
                {
                    using (oledbcon2)
                    {
                        if (type == "moto")
                        {
                            OleDbCommand command = new OleDbCommand("UPDATE Veicoli SET Marca=@marca, Modello=@modello, Colore=@colore, Cilindrata=@cilindrata, PotenzaKw=@potenzakw, Immatricolazione=@immatricolazione, IsUsato=@usato, IsKmZero=@kmzero, KmPercorsi=@kmpercorsi, Informazioni=@informazioni WHERE CodVeicolo=@codice", oledbcon2);
                            oledbcon2.Open();

                            command.Parameters.Add("@marca", OleDbType.VarChar, 255).Value = txtMarcaMoto.Text;
                            command.Parameters.Add("@modello", OleDbType.VarChar, 255).Value = txtModelloMoto.Text;
                            command.Parameters.Add("@colore", OleDbType.VarChar, 255).Value = txtColoreMoto.Text;
                            command.Parameters.Add("@cilindrata", OleDbType.Integer).Value = Convert.ToInt32(txtCilindrataMoto.Text);
                            command.Parameters.Add("@potenzakw", OleDbType.Integer).Value = Convert.ToInt32(txtPotenzaKwMoto.Text);
                            command.Parameters.Add("@immatricolazione", OleDbType.Date).Value = (Convert.ToDateTime(txtImmatricolazioneMoto.Text).ToShortDateString());
                            if (chkUsatoMoto.Checked)
                            {
                                command.Parameters.Add("@usato", OleDbType.Boolean).Value = true;
                            }
                            else
                            {
                                command.Parameters.Add("@usato", OleDbType.Boolean).Value = false;
                            }
                            if (chkKm0Moto.Checked)
                            {
                                command.Parameters.Add("@kmzero", OleDbType.Boolean).Value = true;
                            }
                            else
                            {
                                command.Parameters.Add("@kmzero", OleDbType.Boolean).Value = false;
                            }

                            command.Parameters.Add("@kmpercorsi", OleDbType.Integer).Value = Convert.ToInt32(txtKmPercorsiMoto.Text);
                            command.Parameters.Add("@informazioni", OleDbType.VarChar, 255).Value = txtMarcaSella.Text;
                            command.Parameters.Add("@codice", OleDbType.Integer).Value = cod;

                            try
                            {
                                command.ExecuteNonQuery();
                                MessageBox.Show("Veicolo modificato correttamente");
                                for (int i = 0; i < bindingListVeicoli.Count; i++)
                                {
                                    if (bindingListVeicoli[i].CodVeicolo == cod)
                                    {
                                        bindingListVeicoli[i].Marca = txtMarcaMoto.Text;
                                        bindingListVeicoli[i].Modello = txtModelloMoto.Text;
                                        bindingListVeicoli[i].Colore = txtColoreMoto.Text;
                                        bindingListVeicoli[i].Cilindrata = Convert.ToInt32(txtCilindrataMoto.Text);
                                        bindingListVeicoli[i].PotenzaKw = Convert.ToInt32(txtPotenzaKwMoto.Text);
                                        bindingListVeicoli[i].Immatricolazione = Convert.ToDateTime(txtImmatricolazioneMoto.Text);
                                        if (chkUsatoMoto.Checked)
                                        {
                                            bindingListVeicoli[i].IsUsato = true;
                                        }
                                        else
                                        {
                                            bindingListVeicoli[i].IsUsato = false;
                                        }
                                        if (chkKm0Moto.Checked)
                                        {
                                            bindingListVeicoli[i].IsKmZero = true;
                                        }
                                        else
                                        {
                                            bindingListVeicoli[i].IsKmZero = false;
                                        }
                                        (bindingListVeicoli[i] as Moto).MarcaSella = txtMarcaSella.Text;
                                    }
                                }
                                fm.salva();
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            OleDbCommand command = new OleDbCommand("UPDATE Veicoli SET Marca=@marca, Modello=@modello, Colore=@colore, Cilindrata=@cilindrata, PotenzaKw=@potenzakw, Immatricolazione=@immatricolazione, IsUsato=@usato, IsKmZero=@kmzero, KmPercorsi=@kmpercorsi, Informazioni=@informazioni WHERE CodVeicolo=@codice", oledbcon2);
                            oledbcon2.Open();

                            command.Parameters.Add("@marca", OleDbType.VarChar, 255).Value = txtMarcaAuto.Text;
                            command.Parameters.Add("@modello", OleDbType.VarChar, 255).Value = txtModelloAuto.Text;
                            command.Parameters.Add("@colore", OleDbType.VarChar, 255).Value = txtColoreAuto.Text;
                            command.Parameters.Add("@cilindrata", OleDbType.Integer).Value = Convert.ToInt32(txtCilindrataAuto.Text);
                            command.Parameters.Add("@potenzakw", OleDbType.Integer).Value = Convert.ToInt32(txtPotenzaKwAuto.Text);
                            command.Parameters.Add("@immatricolazione", OleDbType.Date).Value = Convert.ToDateTime(txtImmatricolazioneAuto.Text).ToShortDateString();
                            if (chkUsatoAuto.Checked)
                            {
                                command.Parameters.Add("@usato", OleDbType.Boolean).Value = true;
                            }
                            else
                            {
                                command.Parameters.Add("@usato", OleDbType.Boolean).Value = false;
                            }
                            if (chkKm0Auto.Checked)
                            {
                                command.Parameters.Add("@kmzero", OleDbType.Boolean).Value = true;
                            }
                            else
                            {
                                command.Parameters.Add("@kmzero", OleDbType.Boolean).Value = false;
                            }

                            command.Parameters.Add("@kmpercorsi", OleDbType.Integer).Value = Convert.ToInt32(txtKmPercorsiAuto.Text);
                            command.Parameters.Add("@informazioni", OleDbType.VarChar, 255).Value = txtNumeroAirbag.Text;
                            command.Parameters.Add("@codice", OleDbType.Integer).Value = cod;

                            try
                            {
                                command.ExecuteNonQuery();
                                MessageBox.Show("Veicolo modificato correttamente");
                                for (int i = 0; i < bindingListVeicoli.Count; i++)
                                {
                                    if (bindingListVeicoli[i].CodVeicolo == cod)
                                    {
                                        bindingListVeicoli[i].Marca = txtMarcaAuto.Text;
                                        bindingListVeicoli[i].Modello = txtModelloAuto.Text;
                                        bindingListVeicoli[i].Colore = txtColoreAuto.Text;
                                        bindingListVeicoli[i].Cilindrata = Convert.ToInt32(txtCilindrataAuto.Text);
                                        bindingListVeicoli[i].PotenzaKw = Convert.ToInt32(txtPotenzaKwAuto.Text);
                                        bindingListVeicoli[i].Immatricolazione = Convert.ToDateTime(txtImmatricolazioneAuto.Text);
                                        if (chkUsatoMoto.Checked)
                                        {
                                            bindingListVeicoli[i].IsUsato = true;
                                        }
                                        else
                                        {
                                            bindingListVeicoli[i].IsUsato = false;
                                        }
                                        if (chkKm0Moto.Checked)
                                        {
                                            bindingListVeicoli[i].IsKmZero = true;
                                        }
                                        else
                                        {
                                            bindingListVeicoli[i].IsKmZero = false;
                                        }
                                        (bindingListVeicoli[i] as Auto).NumAirbag = Convert.ToInt32(txtNumeroAirbag.Text);
                                    }
                                }
                                fm.salva();
                                this.Close();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
