namespace WindowsFormsAppProject
{
    partial class FormDialogAggiungiVeicolo
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
            this.cmbTipoVeicolo = new System.Windows.Forms.ComboBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.groupBoxCaratteristicheVeicolo = new System.Windows.Forms.GroupBox();
            this.nudCilindrata = new System.Windows.Forms.NumericUpDown();
            this.nudKmPercorsi = new System.Windows.Forms.NumericUpDown();
            this.lblKmPercorsi = new System.Windows.Forms.Label();
            this.groupBoxKmZero = new System.Windows.Forms.GroupBox();
            this.rdbKmZeroSì = new System.Windows.Forms.RadioButton();
            this.radrdbKmZeroNo = new System.Windows.Forms.RadioButton();
            this.groupBoxUsato = new System.Windows.Forms.GroupBox();
            this.rdbUsatoSì = new System.Windows.Forms.RadioButton();
            this.rdbUsatoNo = new System.Windows.Forms.RadioButton();
            this.dtpImmatricolazione = new System.Windows.Forms.DateTimePicker();
            this.lblImmatricolazione = new System.Windows.Forms.Label();
            this.txtPotenzakW = new System.Windows.Forms.TextBox();
            this.lblPotenzakW = new System.Windows.Forms.Label();
            this.cmbColore = new System.Windows.Forms.ComboBox();
            this.lblCilindrata = new System.Windows.Forms.Label();
            this.lblColore = new System.Windows.Forms.Label();
            this.txtModello = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lblModello = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.groupBoxCaratteristicheAuto = new System.Windows.Forms.GroupBox();
            this.nudNumeroAirbag = new System.Windows.Forms.NumericUpDown();
            this.lblNumeroAirbag = new System.Windows.Forms.Label();
            this.groupBoxCaratteristicheMoto = new System.Windows.Forms.GroupBox();
            this.txtSella = new System.Windows.Forms.TextBox();
            this.lblSella = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnScegliFile = new System.Windows.Forms.Button();
            this.groupBoxCaratteristicheVeicolo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCilindrata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKmPercorsi)).BeginInit();
            this.groupBoxKmZero.SuspendLayout();
            this.groupBoxUsato.SuspendLayout();
            this.groupBoxCaratteristicheAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroAirbag)).BeginInit();
            this.groupBoxCaratteristicheMoto.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTipoVeicolo
            // 
            this.cmbTipoVeicolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoVeicolo.FormattingEnabled = true;
            this.cmbTipoVeicolo.Items.AddRange(new object[] {
            "AUTO",
            "MOTO"});
            this.cmbTipoVeicolo.Location = new System.Drawing.Point(80, 12);
            this.cmbTipoVeicolo.Name = "cmbTipoVeicolo";
            this.cmbTipoVeicolo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoVeicolo.TabIndex = 0;
            this.cmbTipoVeicolo.SelectedIndexChanged += new System.EventHandler(this.cmbTipoVeicolo_SelectedIndexChanged);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(116, 485);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 1;
            this.btnAnnulla.Text = "ANNULLA";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.Location = new System.Drawing.Point(197, 485);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(75, 23);
            this.btnAggiungi.TabIndex = 2;
            this.btnAggiungi.Text = "AGGIUNGI";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // groupBoxCaratteristicheVeicolo
            // 
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.nudCilindrata);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.nudKmPercorsi);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.lblKmPercorsi);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.groupBoxKmZero);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.groupBoxUsato);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.dtpImmatricolazione);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.lblImmatricolazione);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.txtPotenzakW);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.lblPotenzakW);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.cmbColore);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.lblCilindrata);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.lblColore);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.txtModello);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.txtMarca);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.lblModello);
            this.groupBoxCaratteristicheVeicolo.Controls.Add(this.lblMarca);
            this.groupBoxCaratteristicheVeicolo.Location = new System.Drawing.Point(12, 51);
            this.groupBoxCaratteristicheVeicolo.Name = "groupBoxCaratteristicheVeicolo";
            this.groupBoxCaratteristicheVeicolo.Size = new System.Drawing.Size(260, 253);
            this.groupBoxCaratteristicheVeicolo.TabIndex = 3;
            this.groupBoxCaratteristicheVeicolo.TabStop = false;
            this.groupBoxCaratteristicheVeicolo.Text = "Caratteristiche veicolo";
            // 
            // nudCilindrata
            // 
            this.nudCilindrata.Location = new System.Drawing.Point(104, 89);
            this.nudCilindrata.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudCilindrata.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudCilindrata.Name = "nudCilindrata";
            this.nudCilindrata.Size = new System.Drawing.Size(100, 20);
            this.nudCilindrata.TabIndex = 25;
            this.nudCilindrata.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // nudKmPercorsi
            // 
            this.nudKmPercorsi.Location = new System.Drawing.Point(104, 221);
            this.nudKmPercorsi.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudKmPercorsi.Name = "nudKmPercorsi";
            this.nudKmPercorsi.Size = new System.Drawing.Size(100, 20);
            this.nudKmPercorsi.TabIndex = 24;
            // 
            // lblKmPercorsi
            // 
            this.lblKmPercorsi.AutoSize = true;
            this.lblKmPercorsi.Location = new System.Drawing.Point(6, 221);
            this.lblKmPercorsi.Name = "lblKmPercorsi";
            this.lblKmPercorsi.Size = new System.Drawing.Size(62, 13);
            this.lblKmPercorsi.TabIndex = 23;
            this.lblKmPercorsi.Text = "Km percorsi";
            // 
            // groupBoxKmZero
            // 
            this.groupBoxKmZero.Controls.Add(this.rdbKmZeroSì);
            this.groupBoxKmZero.Controls.Add(this.radrdbKmZeroNo);
            this.groupBoxKmZero.Location = new System.Drawing.Point(111, 161);
            this.groupBoxKmZero.Name = "groupBoxKmZero";
            this.groupBoxKmZero.Size = new System.Drawing.Size(93, 45);
            this.groupBoxKmZero.TabIndex = 22;
            this.groupBoxKmZero.TabStop = false;
            this.groupBoxKmZero.Text = "KmZero";
            // 
            // rdbKmZeroSì
            // 
            this.rdbKmZeroSì.AutoSize = true;
            this.rdbKmZeroSì.Checked = true;
            this.rdbKmZeroSì.Location = new System.Drawing.Point(6, 19);
            this.rdbKmZeroSì.Name = "rdbKmZeroSì";
            this.rdbKmZeroSì.Size = new System.Drawing.Size(34, 17);
            this.rdbKmZeroSì.TabIndex = 18;
            this.rdbKmZeroSì.TabStop = true;
            this.rdbKmZeroSì.Text = "Sì";
            this.rdbKmZeroSì.UseVisualStyleBackColor = true;
            this.rdbKmZeroSì.CheckedChanged += new System.EventHandler(this.rdbKmZeroSì_CheckedChanged);
            // 
            // radrdbKmZeroNo
            // 
            this.radrdbKmZeroNo.AutoSize = true;
            this.radrdbKmZeroNo.Location = new System.Drawing.Point(46, 19);
            this.radrdbKmZeroNo.Name = "radrdbKmZeroNo";
            this.radrdbKmZeroNo.Size = new System.Drawing.Size(39, 17);
            this.radrdbKmZeroNo.TabIndex = 19;
            this.radrdbKmZeroNo.TabStop = true;
            this.radrdbKmZeroNo.Text = "No";
            this.radrdbKmZeroNo.UseVisualStyleBackColor = true;
            // 
            // groupBoxUsato
            // 
            this.groupBoxUsato.Controls.Add(this.rdbUsatoSì);
            this.groupBoxUsato.Controls.Add(this.rdbUsatoNo);
            this.groupBoxUsato.Location = new System.Drawing.Point(9, 161);
            this.groupBoxUsato.Name = "groupBoxUsato";
            this.groupBoxUsato.Size = new System.Drawing.Size(93, 45);
            this.groupBoxUsato.TabIndex = 21;
            this.groupBoxUsato.TabStop = false;
            this.groupBoxUsato.Text = "Usato";
            // 
            // rdbUsatoSì
            // 
            this.rdbUsatoSì.AutoSize = true;
            this.rdbUsatoSì.Location = new System.Drawing.Point(6, 19);
            this.rdbUsatoSì.Name = "rdbUsatoSì";
            this.rdbUsatoSì.Size = new System.Drawing.Size(34, 17);
            this.rdbUsatoSì.TabIndex = 18;
            this.rdbUsatoSì.TabStop = true;
            this.rdbUsatoSì.Text = "Sì";
            this.rdbUsatoSì.UseVisualStyleBackColor = true;
            this.rdbUsatoSì.CheckedChanged += new System.EventHandler(this.rdbUsatoSì_CheckedChanged);
            // 
            // rdbUsatoNo
            // 
            this.rdbUsatoNo.AutoSize = true;
            this.rdbUsatoNo.Checked = true;
            this.rdbUsatoNo.Location = new System.Drawing.Point(46, 19);
            this.rdbUsatoNo.Name = "rdbUsatoNo";
            this.rdbUsatoNo.Size = new System.Drawing.Size(39, 17);
            this.rdbUsatoNo.TabIndex = 19;
            this.rdbUsatoNo.TabStop = true;
            this.rdbUsatoNo.Text = "No";
            this.rdbUsatoNo.UseVisualStyleBackColor = true;
            // 
            // dtpImmatricolazione
            // 
            this.dtpImmatricolazione.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpImmatricolazione.Location = new System.Drawing.Point(104, 135);
            this.dtpImmatricolazione.Name = "dtpImmatricolazione";
            this.dtpImmatricolazione.Size = new System.Drawing.Size(100, 20);
            this.dtpImmatricolazione.TabIndex = 16;
            // 
            // lblImmatricolazione
            // 
            this.lblImmatricolazione.AutoSize = true;
            this.lblImmatricolazione.Location = new System.Drawing.Point(6, 141);
            this.lblImmatricolazione.Name = "lblImmatricolazione";
            this.lblImmatricolazione.Size = new System.Drawing.Size(85, 13);
            this.lblImmatricolazione.TabIndex = 15;
            this.lblImmatricolazione.Text = "Immatricolazione";
            // 
            // txtPotenzakW
            // 
            this.txtPotenzakW.Location = new System.Drawing.Point(104, 109);
            this.txtPotenzakW.Name = "txtPotenzakW";
            this.txtPotenzakW.Size = new System.Drawing.Size(100, 20);
            this.txtPotenzakW.TabIndex = 14;
            // 
            // lblPotenzakW
            // 
            this.lblPotenzakW.AutoSize = true;
            this.lblPotenzakW.Location = new System.Drawing.Point(6, 112);
            this.lblPotenzakW.Name = "lblPotenzakW";
            this.lblPotenzakW.Size = new System.Drawing.Size(66, 13);
            this.lblPotenzakW.TabIndex = 13;
            this.lblPotenzakW.Text = "Potenza kW";
            // 
            // cmbColore
            // 
            this.cmbColore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColore.FormattingEnabled = true;
            this.cmbColore.Items.AddRange(new object[] {
            "Bianco",
            "Nero",
            "Rosso",
            "Grigio",
            "Beige",
            "Blu"});
            this.cmbColore.Location = new System.Drawing.Point(104, 66);
            this.cmbColore.Name = "cmbColore";
            this.cmbColore.Size = new System.Drawing.Size(100, 21);
            this.cmbColore.TabIndex = 12;
            // 
            // lblCilindrata
            // 
            this.lblCilindrata.AutoSize = true;
            this.lblCilindrata.Location = new System.Drawing.Point(6, 91);
            this.lblCilindrata.Name = "lblCilindrata";
            this.lblCilindrata.Size = new System.Drawing.Size(50, 13);
            this.lblCilindrata.TabIndex = 9;
            this.lblCilindrata.Text = "Cilindrata";
            // 
            // lblColore
            // 
            this.lblColore.AutoSize = true;
            this.lblColore.Location = new System.Drawing.Point(6, 69);
            this.lblColore.Name = "lblColore";
            this.lblColore.Size = new System.Drawing.Size(37, 13);
            this.lblColore.TabIndex = 8;
            this.lblColore.Text = "Colore";
            // 
            // txtModello
            // 
            this.txtModello.Location = new System.Drawing.Point(104, 44);
            this.txtModello.Name = "txtModello";
            this.txtModello.Size = new System.Drawing.Size(100, 20);
            this.txtModello.TabIndex = 7;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(104, 22);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(100, 20);
            this.txtMarca.TabIndex = 6;
            // 
            // lblModello
            // 
            this.lblModello.AutoSize = true;
            this.lblModello.Location = new System.Drawing.Point(6, 47);
            this.lblModello.Name = "lblModello";
            this.lblModello.Size = new System.Drawing.Size(44, 13);
            this.lblModello.TabIndex = 5;
            this.lblModello.Text = "Modello";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(6, 25);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(37, 13);
            this.lblMarca.TabIndex = 4;
            this.lblMarca.Text = "Marca";
            // 
            // groupBoxCaratteristicheAuto
            // 
            this.groupBoxCaratteristicheAuto.Controls.Add(this.nudNumeroAirbag);
            this.groupBoxCaratteristicheAuto.Controls.Add(this.lblNumeroAirbag);
            this.groupBoxCaratteristicheAuto.Location = new System.Drawing.Point(12, 310);
            this.groupBoxCaratteristicheAuto.Name = "groupBoxCaratteristicheAuto";
            this.groupBoxCaratteristicheAuto.Size = new System.Drawing.Size(260, 58);
            this.groupBoxCaratteristicheAuto.TabIndex = 4;
            this.groupBoxCaratteristicheAuto.TabStop = false;
            this.groupBoxCaratteristicheAuto.Text = "Auto";
            // 
            // nudNumeroAirbag
            // 
            this.nudNumeroAirbag.Location = new System.Drawing.Point(104, 25);
            this.nudNumeroAirbag.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumeroAirbag.Name = "nudNumeroAirbag";
            this.nudNumeroAirbag.Size = new System.Drawing.Size(100, 20);
            this.nudNumeroAirbag.TabIndex = 26;
            this.nudNumeroAirbag.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNumeroAirbag
            // 
            this.lblNumeroAirbag.AutoSize = true;
            this.lblNumeroAirbag.Location = new System.Drawing.Point(6, 27);
            this.lblNumeroAirbag.Name = "lblNumeroAirbag";
            this.lblNumeroAirbag.Size = new System.Drawing.Size(87, 13);
            this.lblNumeroAirbag.TabIndex = 0;
            this.lblNumeroAirbag.Text = "Numero di airbag";
            // 
            // groupBoxCaratteristicheMoto
            // 
            this.groupBoxCaratteristicheMoto.Controls.Add(this.txtSella);
            this.groupBoxCaratteristicheMoto.Controls.Add(this.lblSella);
            this.groupBoxCaratteristicheMoto.Location = new System.Drawing.Point(12, 310);
            this.groupBoxCaratteristicheMoto.Name = "groupBoxCaratteristicheMoto";
            this.groupBoxCaratteristicheMoto.Size = new System.Drawing.Size(260, 58);
            this.groupBoxCaratteristicheMoto.TabIndex = 27;
            this.groupBoxCaratteristicheMoto.TabStop = false;
            this.groupBoxCaratteristicheMoto.Text = "Moto";
            this.groupBoxCaratteristicheMoto.Visible = false;
            // 
            // txtSella
            // 
            this.txtSella.Location = new System.Drawing.Point(104, 25);
            this.txtSella.Name = "txtSella";
            this.txtSella.Size = new System.Drawing.Size(100, 20);
            this.txtSella.TabIndex = 8;
            // 
            // lblSella
            // 
            this.lblSella.AutoSize = true;
            this.lblSella.Location = new System.Drawing.Point(6, 28);
            this.lblSella.Name = "lblSella";
            this.lblSella.Size = new System.Drawing.Size(30, 13);
            this.lblSella.TabIndex = 7;
            this.lblSella.Text = "Sella";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Image Files(*.JPG)|*.JPG";
            // 
            // btnScegliFile
            // 
            this.btnScegliFile.Location = new System.Drawing.Point(12, 374);
            this.btnScegliFile.Name = "btnScegliFile";
            this.btnScegliFile.Size = new System.Drawing.Size(260, 23);
            this.btnScegliFile.TabIndex = 9;
            this.btnScegliFile.Text = "SCEGLI FILE";
            this.btnScegliFile.UseVisualStyleBackColor = true;
            this.btnScegliFile.Click += new System.EventHandler(this.btnScegliFile_Click);
            // 
            // FormDialogAggiungiVeicolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(284, 524);
            this.Controls.Add(this.btnScegliFile);
            this.Controls.Add(this.groupBoxCaratteristicheMoto);
            this.Controls.Add(this.groupBoxCaratteristicheAuto);
            this.Controls.Add(this.groupBoxCaratteristicheVeicolo);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.cmbTipoVeicolo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormDialogAggiungiVeicolo";
            this.Text = "AGGIUNGI VEICOLO";
            this.Load += new System.EventHandler(this.FormDialogAggiungiVeicolo_Load);
            this.groupBoxCaratteristicheVeicolo.ResumeLayout(false);
            this.groupBoxCaratteristicheVeicolo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCilindrata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKmPercorsi)).EndInit();
            this.groupBoxKmZero.ResumeLayout(false);
            this.groupBoxKmZero.PerformLayout();
            this.groupBoxUsato.ResumeLayout(false);
            this.groupBoxUsato.PerformLayout();
            this.groupBoxCaratteristicheAuto.ResumeLayout(false);
            this.groupBoxCaratteristicheAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroAirbag)).EndInit();
            this.groupBoxCaratteristicheMoto.ResumeLayout(false);
            this.groupBoxCaratteristicheMoto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipoVeicolo;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.GroupBox groupBoxCaratteristicheVeicolo;
        private System.Windows.Forms.Label lblCilindrata;
        private System.Windows.Forms.Label lblColore;
        private System.Windows.Forms.TextBox txtModello;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lblModello;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblPotenzakW;
        private System.Windows.Forms.ComboBox cmbColore;
        private System.Windows.Forms.TextBox txtPotenzakW;
        private System.Windows.Forms.DateTimePicker dtpImmatricolazione;
        private System.Windows.Forms.Label lblImmatricolazione;
        private System.Windows.Forms.RadioButton rdbUsatoNo;
        private System.Windows.Forms.RadioButton rdbUsatoSì;
        private System.Windows.Forms.GroupBox groupBoxKmZero;
        private System.Windows.Forms.RadioButton rdbKmZeroSì;
        private System.Windows.Forms.RadioButton radrdbKmZeroNo;
        private System.Windows.Forms.GroupBox groupBoxUsato;
        private System.Windows.Forms.NumericUpDown nudKmPercorsi;
        private System.Windows.Forms.Label lblKmPercorsi;
        private System.Windows.Forms.NumericUpDown nudCilindrata;
        private System.Windows.Forms.GroupBox groupBoxCaratteristicheAuto;
        private System.Windows.Forms.NumericUpDown nudNumeroAirbag;
        private System.Windows.Forms.Label lblNumeroAirbag;
        private System.Windows.Forms.GroupBox groupBoxCaratteristicheMoto;
        private System.Windows.Forms.TextBox txtSella;
        private System.Windows.Forms.Label lblSella;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnScegliFile;
    }
}