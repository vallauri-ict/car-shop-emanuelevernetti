using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using VenditaVeicoliDllProject;

namespace WindowsFormsAppProject
{
    public partial class FormVisualizzazioneVolantino : Form
    {
        public static Random rnd = new Random();
        FormMain f;
        BindingList<Veicolo> listVeicoli;

        public FormVisualizzazioneVolantino(BindingList<Veicolo> list, FormMain f)
        {
            this.f = f;
            listVeicoli = list;
            InitializeComponent();
        }

        private void FormVisualizzazioneVolantino_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < listVeicoli.Count; i++)
            {
                dgvPictures.Rows.Add();
                dgvPictures.Rows[i].Cells["colPicture"].Value = Image.FromFile(listVeicoli[i].Path);
                dgvPictures.Columns["colPicture"].Width = 200;
            }
            dgvPictures.AutoResizeRows();
        }

        private void dgvPictures_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormDettagliVeicolo fd = new FormDettagliVeicolo(e.RowIndex, listVeicoli);
            fd.ShowDialog();
        }
    }
}
