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
            this.dgvPictures = new System.Windows.Forms.DataGridView();
            this.colPicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.veicoloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPictures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veicoloBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // colPicture
            // 
            this.colPicture.HeaderText = "Immagine";
            this.colPicture.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colPicture.Name = "colPicture";
            // 
            // veicoloBindingSource
            // 
            this.veicoloBindingSource.DataSource = typeof(VenditaVeicoliDllProject.Veicolo);
            // 
            // FormVisualizzazioneVolantino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPictures);
            this.Name = "FormVisualizzazioneVolantino";
            this.Text = "Volantino";
            this.Load += new System.EventHandler(this.FormVisualizzazioneVolantino_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPictures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veicoloBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource veicoloBindingSource;
        private System.Windows.Forms.DataGridView dgvPictures;
        private System.Windows.Forms.DataGridViewImageColumn colPicture;
    }
}