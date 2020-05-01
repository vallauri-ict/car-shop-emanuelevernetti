namespace WindowsFormsAppProject
{
    partial class FormMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuovoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.apriToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.salvaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stampaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonHtml = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxFiltro = new System.Windows.Forms.ToolStripComboBox();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.dgvVeicoli = new System.Windows.Forms.DataGridView();
            this.veicoloBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnEliminaVeicolo = new System.Windows.Forms.ToolStripButton();
            this.marcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coloreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cilindrataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.potenzaKwDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.immatricolazioneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isUsatoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isKmZeroDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kmPercorsiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeicoli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veicoloBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoToolStripButton,
            this.apriToolStripButton,
            this.salvaToolStripButton,
            this.stampaToolStripButton,
            this.toolStripSeparator,
            this.toolStripButtonHtml,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripComboBoxFiltro,
            this.btnEliminaVeicolo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(952, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuovoToolStripButton
            // 
            this.nuovoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuovoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuovoToolStripButton.Image")));
            this.nuovoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuovoToolStripButton.Name = "nuovoToolStripButton";
            this.nuovoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.nuovoToolStripButton.Text = "&Nuovo";
            this.nuovoToolStripButton.Click += new System.EventHandler(this.nuovoToolStripButton_Click);
            // 
            // apriToolStripButton
            // 
            this.apriToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.apriToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("apriToolStripButton.Image")));
            this.apriToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.apriToolStripButton.Name = "apriToolStripButton";
            this.apriToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.apriToolStripButton.Text = "&Apri";
            this.apriToolStripButton.Click += new System.EventHandler(this.apriToolStripButton_Click);
            // 
            // salvaToolStripButton
            // 
            this.salvaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.salvaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("salvaToolStripButton.Image")));
            this.salvaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salvaToolStripButton.Name = "salvaToolStripButton";
            this.salvaToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.salvaToolStripButton.Text = "&Salva";
            this.salvaToolStripButton.Click += new System.EventHandler(this.salvaToolStripButton_Click);
            // 
            // stampaToolStripButton
            // 
            this.stampaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stampaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("stampaToolStripButton.Image")));
            this.stampaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stampaToolStripButton.Name = "stampaToolStripButton";
            this.stampaToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.stampaToolStripButton.Text = "&Stampa";
            this.stampaToolStripButton.Click += new System.EventHandler(this.stampaToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonHtml
            // 
            this.toolStripButtonHtml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonHtml.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHtml.Image")));
            this.toolStripButtonHtml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHtml.Name = "toolStripButtonHtml";
            this.toolStripButtonHtml.Size = new System.Drawing.Size(125, 22);
            this.toolStripButtonHtml.Text = "Visualizza pagina web";
            this.toolStripButtonHtml.Click += new System.EventHandler(this.toolStripButtonHtml_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel1.Text = "Ordina per";
            // 
            // toolStripComboBoxFiltro
            // 
            this.toolStripComboBoxFiltro.Name = "toolStripComboBoxFiltro";
            this.toolStripComboBoxFiltro.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxFiltro.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxFiltro_SelectedIndexChanged);
            // 
            // dgvVeicoli
            // 
            this.dgvVeicoli.AllowUserToAddRows = false;
            this.dgvVeicoli.AutoGenerateColumns = false;
            this.dgvVeicoli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeicoli.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.marcaDataGridViewTextBoxColumn,
            this.modelloDataGridViewTextBoxColumn,
            this.coloreDataGridViewTextBoxColumn,
            this.cilindrataDataGridViewTextBoxColumn,
            this.potenzaKwDataGridViewTextBoxColumn,
            this.immatricolazioneDataGridViewTextBoxColumn,
            this.isUsatoDataGridViewCheckBoxColumn,
            this.isKmZeroDataGridViewCheckBoxColumn,
            this.kmPercorsiDataGridViewTextBoxColumn,
            this.colInfo,
            this.pathDataGridViewTextBoxColumn});
            this.dgvVeicoli.DataSource = this.veicoloBindingSource1;
            this.dgvVeicoli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVeicoli.Location = new System.Drawing.Point(0, 25);
            this.dgvVeicoli.Name = "dgvVeicoli";
            this.dgvVeicoli.RowHeadersWidth = 40;
            this.dgvVeicoli.Size = new System.Drawing.Size(952, 362);
            this.dgvVeicoli.TabIndex = 2;
            // 
            // veicoloBindingSource1
            // 
            this.veicoloBindingSource1.DataSource = typeof(VenditaVeicoliDllProject.Veicolo);
            // 
            // btnEliminaVeicolo
            // 
            this.btnEliminaVeicolo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEliminaVeicolo.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminaVeicolo.Image")));
            this.btnEliminaVeicolo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminaVeicolo.Name = "btnEliminaVeicolo";
            this.btnEliminaVeicolo.Size = new System.Drawing.Size(91, 22);
            this.btnEliminaVeicolo.Text = "Elimina veicolo";
            this.btnEliminaVeicolo.Click += new System.EventHandler(this.btnEliminaVeicolo_Click);
            // 
            // marcaDataGridViewTextBoxColumn
            // 
            this.marcaDataGridViewTextBoxColumn.DataPropertyName = "Marca";
            this.marcaDataGridViewTextBoxColumn.HeaderText = "Marca";
            this.marcaDataGridViewTextBoxColumn.Name = "marcaDataGridViewTextBoxColumn";
            // 
            // modelloDataGridViewTextBoxColumn
            // 
            this.modelloDataGridViewTextBoxColumn.DataPropertyName = "Modello";
            this.modelloDataGridViewTextBoxColumn.HeaderText = "Modello";
            this.modelloDataGridViewTextBoxColumn.Name = "modelloDataGridViewTextBoxColumn";
            // 
            // coloreDataGridViewTextBoxColumn
            // 
            this.coloreDataGridViewTextBoxColumn.DataPropertyName = "Colore";
            this.coloreDataGridViewTextBoxColumn.HeaderText = "Colore";
            this.coloreDataGridViewTextBoxColumn.Name = "coloreDataGridViewTextBoxColumn";
            // 
            // cilindrataDataGridViewTextBoxColumn
            // 
            this.cilindrataDataGridViewTextBoxColumn.DataPropertyName = "Cilindrata";
            this.cilindrataDataGridViewTextBoxColumn.HeaderText = "Cilindrata";
            this.cilindrataDataGridViewTextBoxColumn.Name = "cilindrataDataGridViewTextBoxColumn";
            // 
            // potenzaKwDataGridViewTextBoxColumn
            // 
            this.potenzaKwDataGridViewTextBoxColumn.DataPropertyName = "PotenzaKw";
            this.potenzaKwDataGridViewTextBoxColumn.HeaderText = "PotenzaKw";
            this.potenzaKwDataGridViewTextBoxColumn.Name = "potenzaKwDataGridViewTextBoxColumn";
            // 
            // immatricolazioneDataGridViewTextBoxColumn
            // 
            this.immatricolazioneDataGridViewTextBoxColumn.DataPropertyName = "Immatricolazione";
            this.immatricolazioneDataGridViewTextBoxColumn.HeaderText = "Immatricolazione";
            this.immatricolazioneDataGridViewTextBoxColumn.Name = "immatricolazioneDataGridViewTextBoxColumn";
            // 
            // isUsatoDataGridViewCheckBoxColumn
            // 
            this.isUsatoDataGridViewCheckBoxColumn.DataPropertyName = "IsUsato";
            this.isUsatoDataGridViewCheckBoxColumn.HeaderText = "IsUsato";
            this.isUsatoDataGridViewCheckBoxColumn.Name = "isUsatoDataGridViewCheckBoxColumn";
            // 
            // isKmZeroDataGridViewCheckBoxColumn
            // 
            this.isKmZeroDataGridViewCheckBoxColumn.DataPropertyName = "IsKmZero";
            this.isKmZeroDataGridViewCheckBoxColumn.HeaderText = "IsKmZero";
            this.isKmZeroDataGridViewCheckBoxColumn.Name = "isKmZeroDataGridViewCheckBoxColumn";
            // 
            // kmPercorsiDataGridViewTextBoxColumn
            // 
            this.kmPercorsiDataGridViewTextBoxColumn.DataPropertyName = "KmPercorsi";
            this.kmPercorsiDataGridViewTextBoxColumn.HeaderText = "KmPercorsi";
            this.kmPercorsiDataGridViewTextBoxColumn.Name = "kmPercorsiDataGridViewTextBoxColumn";
            // 
            // colInfo
            // 
            this.colInfo.HeaderText = "Informazioni";
            this.colInfo.Name = "colInfo";
            this.colInfo.ReadOnly = true;
            this.colInfo.ToolTipText = "Informazioni sul veicolo";
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 387);
            this.Controls.Add(this.dgvVeicoli);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormMain";
            this.Text = "SALONE VENDITA VEICOLI NUOVI E USATI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeicoli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veicoloBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nuovoToolStripButton;
        private System.Windows.Forms.ToolStripButton apriToolStripButton;
        private System.Windows.Forms.ToolStripButton salvaToolStripButton;
        private System.Windows.Forms.ToolStripButton stampaToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.ToolStripButton toolStripButtonHtml;
        private System.Windows.Forms.DataGridView dgvVeicoli;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.BindingSource veicoloBindingSource1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxFiltro;
        private System.Windows.Forms.ToolStripButton btnEliminaVeicolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coloreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cilindrataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn potenzaKwDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn immatricolazioneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUsatoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isKmZeroDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kmPercorsiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
    }
}

