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
        /// <summary>
        /// Costruttore della form
        /// </summary>
        /// <param name="list">Lista contenente i veicoli</param>
        /// <param name="f">FormMain (parametro necessario per accedere ai controlli della form principale)</param>
        public FormVisualizzazioneVolantino(BindingList<Veicolo> list, FormMain f)
        {
            this.f = f;
            listVeicoli = list;
            InitializeComponent();
        }

        /// <summary>
        /// Crea i controlli sulla form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVisualizzazioneVolantino_Load(object sender, EventArgs e)
        {
            toolStripComboBoxMarca.Items.Add("Tutti");
            toolStripComboBoxColore.Items.Add("Tutti");
            toolStripComboBoxMarca.SelectedIndex = 0;
            toolStripComboBoxColore.SelectedIndex = 0;
            dgvPictures.RowTemplate.Height = 150;
            dgvPictures.RowHeadersVisible = false;
            for (int i = 0; i < clsVariabili.listaMarche.Count; i++)
            {
                toolStripComboBoxMarca.Items.Add(clsVariabili.listaMarche[i]);
            }
            for (int i = 0; i < clsVariabili.listaColori.Count; i++)
            {
                toolStripComboBoxColore.Items.Add(clsVariabili.listaColori[i]);
            }
            for (int i = 0; i < listVeicoli.Count; i++)
            {
                dgvPictures.Rows.Add();
                dgvPictures.Rows[i].Cells["colPicture"].Value = Image.FromFile(listVeicoli[i].Path);
                dgvPictures.Columns["colPicture"].Width = 200;
            }
            dgvPictures.AutoResizeRows();
        }

        /// <summary>
        /// Attraverso un'istanza di FormDettagliVeicolo, visualizza i dettagli relativi al veicolo selezionato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPictures_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormDettagliVeicolo fd = new FormDettagliVeicolo(e.RowIndex, listVeicoli);
            fd.ShowDialog();
        }
    }
}
