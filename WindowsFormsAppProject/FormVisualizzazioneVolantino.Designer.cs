namespace WindowsFormsAppProject
{
    partial class FormVisualizzazioneVolantino
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxMarca = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxColore = new System.Windows.Forms.ToolStripComboBox();
            this.dgvPictures = new System.Windows.Forms.DataGridView();
            this.veicoloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colPicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPictures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veicoloBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxMarca,
            this.toolStripComboBoxColore});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripComboBoxMarca
            // 
            this.toolStripComboBoxMarca.Name = "toolStripComboBoxMarca";
            this.toolStripComboBoxMarca.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripComboBoxColore
            // 
            this.toolStripComboBoxColore.Name = "toolStripComboBoxColore";
            this.toolStripComboBoxColore.Size = new System.Drawing.Size(121, 25);
            // 
            // dgvPictures
            // 
            this.dgvPictures.AllowUserToAddRows = false;
            this.dgvPictures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPictures.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPicture});
            this.dgvPictures.Location = new System.Drawing.Point(12, 28);
            this.dgvPictures.Name = "dgvPictures";
            this.dgvPictures.Size = new System.Drawing.Size(776, 410);
            this.dgvPictures.TabIndex = 1;
            this.dgvPictures.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPictures_CellContentDoubleClick);
            // 
            // veicoloBindingSource
            // 
            this.veicoloBindingSource.DataSource = typeof(VenditaVeicoliDllProject.Veicolo);
            // 
            // colPicture
            // 
            this.colPicture.HeaderText = "Immagine";
            this.colPicture.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colPicture.Name = "colPicture";
            // 
            // FormVisualizzazioneVolantino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPictures);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormVisualizzazioneVolantino";
            this.Text = "Volantino";
            this.Load += new System.EventHandler(this.FormVisualizzazioneVolantino_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPictures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veicoloBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxMarca;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxColore;
        private System.Windows.Forms.BindingSource veicoloBindingSource;
        private System.Windows.Forms.DataGridView dgvPictures;
        private System.Windows.Forms.DataGridViewImageColumn colPicture;
    }
}