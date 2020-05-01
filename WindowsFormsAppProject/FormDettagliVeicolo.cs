using System;
using System.ComponentModel;
using System.Windows.Forms;

using VenditaVeicoliDllProject;

namespace WindowsFormsAppProject
{
    public partial class FormDettagliVeicolo : Form
    {
        int ind;
        BindingList<Veicolo> lista;

        public FormDettagliVeicolo(int pos, BindingList<Veicolo> listVeicoli)
        {
            InitializeComponent();
            ind = pos;
            lista = listVeicoli;
        }

        private void FormDettagliVeicolo_Load(object sender, EventArgs e)
        {
            foreach (var control in gpbAuto.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).ReadOnly = true;
                }
            }
            foreach (var control in gpbMoto.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).ReadOnly = true;
                }
            }
            if (lista[ind] is Auto)
            {
                gpbMoto.Hide();
                gpbAuto.Show();
                assegnaControlliAuto();
            }
            else
            {
                gpbAuto.Hide();
                gpbMoto.Show();
                assegnaControlliMoto();
            }
        }

        private void assegnaControlliMoto()
        {
            txtMarcaMoto.Text = lista[ind].Marca;
            txtModelloMoto.Text = lista[ind].Modello;
            txtColoreMoto.Text = lista[ind].Colore;
            txtCilindrataMoto.Text = lista[ind].Cilindrata.ToString();
            txtPotenzaKwMoto.Text = lista[ind].PotenzaKw.ToString();
            txtImmatricolazioneMoto.Text = lista[ind].Immatricolazione.ToShortDateString().ToString();

            if (lista[ind].IsUsato)
            {
                txtUsatoMoto.Text = "Sì";
            }
            else
            {
                txtUsatoMoto.Text = "No";
            }
            if (lista[ind].IsKmZero)
            {
                txtKm0Moto.Text = "Sì";
            }
            else
            {
                txtKm0Moto.Text = "No";
            }

            if (lista[ind].IsKmZero)
            {
                txtKmPercorsiMoto.Text = "0";
            }
            else
            {
                txtKmPercorsiMoto.Text = lista[ind].KmPercorsi.ToString();
            }

            txtMarcaSella.Text = (lista[ind] as Moto).MarcaSella;
            gpbMoto.Select();
        }

        private void assegnaControlliAuto()
        {
            txtMarcaAuto.Text = lista[ind].Marca;
            txtModelloAuto.Text = lista[ind].Modello;
            txtColoreAuto.Text = lista[ind].Colore;
            txtCilindrataAuto.Text = lista[ind].Cilindrata.ToString();
            txtPotenzaKwAuto.Text = lista[ind].PotenzaKw.ToString();
            txtImmatricolazioneAuto.Text = lista[ind].Immatricolazione.ToShortDateString().ToString();

            if (lista[ind].IsUsato)
            {
                txtUsatoAuto.Text = "Sì";
            }
            else
            {
                txtUsatoAuto.Text = "No";
            }
            if (lista[ind].IsKmZero)
            {
                txtKm0Auto.Text = "Sì";
            }
            else
            {
                txtKm0Auto.Text = "No";
            }

            if (lista[ind].IsKmZero)
            {
                txtKmPercorsiAuto.Text = "0";
            }
            else
            {
                txtKmPercorsiAuto.Text = lista[ind].KmPercorsi.ToString();
            }

            txtNumeroAirbag.Text = (lista[ind] as Auto).NumAirbag.ToString();
            gpbAuto.Select();
        }
    }
}
