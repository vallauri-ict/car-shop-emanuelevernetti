# VenditaVeicoliDatabase
Esercizio VenditaVeicoli utilizzando i Database come origine dati 

La soluzione si sviluppa su quattro progetti:
### ConsoleAppProject: utilizzata per le funzioni di amministrazione.

  #### 1- Crea tabella veicoli
  #### 2- Visualizzazione dei veicoli presenti all'interno del DB
  #### 3- Esporta i dati in Word
  #### 4- Cancella i record presenti nella tabella 'Veicoli' e le relative immagini
  #### 5- Cancella la tabella 'Veicoli' e le relative immagini
  
### VenditaVeicoliDLLProject: DLL contenente i metodi più utilizzati e le classi relative ai veicoli.

  #### Veicolo: classe generica di un veicolo 
  #### Auto:    classe specifica di un'auto che eredita dalla classe 'Veicolo'
  #### Moto:    classe specifica di una moto che eredita dalla classe 'Veicolo' 
  #### Utils:   classe contenente i metodi utilizzati per l'esportazione dei dati
  
### VeicoliDLL: DLL contenente alcuni metodi utilizzati meno.

### WindowsFormsAppProject: Cuore del programma. Form di gestione del database e di inserimento e manipolazione dati.

  #### FormMain: form principale del progetto.
  #### FormAggiungiVeicolo: form che consente di aggiungere un veicolo all'interno del database.
  #### FormDettagliVeicolo: form che consente di visualizzare i dettagli di un veicolo selezionandolo dal volantino.
  #### FormModificaVeicolo: form che consente di modificare un record all'interno del database.
  #### FormVisualizzazioneVolantino: form che consente di visualizzare una specie di volantino contenente i veicoli inseriti con le                                          relative immagini.

###### Codice che viene eseguito all'avvio della FormMain
```C#
private void FormMain_Load(object sender, EventArgs e)
        {
            if (connStr != null)
            {
                try
                {
                    using (connection)
                    {
                        OleDbCommand command = new OleDbCommand("SELECT * FROM Veicoli", connection);
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
                                        Moto m = new Moto(reader.GetInt32(0), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), Convert.ToDouble(reader.GetInt32(6)), reader.GetDateTime(7), reader.GetBoolean(8), reader.GetBoolean(9), reader.GetInt32(10), reader.GetString(11), reader.GetString(12));
                                        bindingListVeicoli.Add(m);
                                    }
                                    else
                                    {
                                        Auto a = new Auto(reader.GetInt32(0), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), Convert.ToDouble(reader.GetInt32(6)), reader.GetDateTime(7), reader.GetBoolean(8), reader.GetBoolean(9), reader.GetInt32(10), Convert.ToInt32(reader.GetString(11)), reader.GetString(12));
                                        bindingListVeicoli.Add(a);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("No rows found");
                            }
                            clsMetodi.ordinaListaVeicoli(bindingListVeicoli, "CodVeicolo");
                            clsMetodi.caricaDgv(bindingListVeicoli, dgvVeicoli);
                            object[] vet = { "CodVeicolo", "Marca", "Modello", "Colore", "Cilindrata", "PotenzaKw", "Immatricolazione", "IsUsato", "IsKmZero", "KmPercorsi" };
                            toolStripComboBoxFiltro.Items.AddRange(vet);
                            toolStripComboBoxFiltro.SelectedIndex = 0;
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
```

###### Sviluppato da Emanuele Vernetti (e.vernetti.1033@vallauri.edu)
       
