using System;
using System.Data.OleDb;
using System.IO;
using System.Threading;

using VenditaVeicoliDllProject;

namespace CarShopConsoleProject
{
    public class Program
    {
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Utilities\\Veicoli.accdb";
        static string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;

        static void Main(string[] args)
        {
            if (!((Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Utilities"))))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Utilities");
            }
            if (!(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Utilities\\Veicoli.accdb")))
            {
                var cat = new ADOX.Catalog();
                cat.Create(connStr);
            }

            char scelta;
            do
            {
                menu();
                Console.Write("Scegli un'operazione da eseguire: ");
                scelta = Console.ReadKey().KeyChar;
                switch (scelta)
                {
                    case '1':
                        {
                            creaTabella();
                            break;
                        }
                    case '2':
                        {
                            visualizzaListaVeicoli();
                            break;
                        }
                    case '3':
                        {
                            Utils.esportaInWord();
                            break;
                        }
                    case '4':
                        {
                            cancellaRecords();
                            break;
                        }
                    case '5':
                        {
                            cancellaTabellaVeicoli();
                            break;
                        }
                }
            }
            while (scelta != 'X' && scelta != 'x');
        }


        private static void menu()
        {
            Console.Clear();
            Console.WriteLine("\t*** CAR SHOP - DB MANAGEMENT ***\n");
            Console.WriteLine("1 - Crea tabella 'Veicoli' ");
            Console.WriteLine("2 - Visualizza l'elenco completo dei veicoli");
            Console.WriteLine("3 - Esporta i dati in un file .docx");
            Console.WriteLine("4 - Cancella tutti i record della tabella veicoli");
            Console.WriteLine("5 - Cancella la tabella veicoli");
            Console.WriteLine("\nX - ESCI\n");
        }

        public static void creaTabella()
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;

                    try
                    {
                        cmd.CommandText = @"CREATE TABLE Veicoli(
                                            CodVeicolo INT NOT NULL PRIMARY KEY, 
                                            Tipologia VARCHAR(255) NOT NULL, 
                                            Marca VARCHAR(255) NOT NULL, 
                                            Modello VARCHAR(255) NOT NULL, 
                                            Colore VARCHAR(255) NOT NULL, 
                                            Cilindrata INT NOT NULL, 
                                            PotenzaKw INT NOT NULL, 
                                            Immatricolazione DATE NOT NULL, 
                                            IsUsato BIT NOT NULL, 
                                            IsKmZero BIT NOT NULL, 
                                            KmPercorsi INT NOT NULL, 
                                            Informazioni VARCHAR(255) NOT NULL, 
                                            Immagine VARCHAR(255) NOT NULL)";
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Console.WriteLine("\n\n" + exc.Message);
                        Thread.Sleep(3000);
                        return;
                    }

                    Console.WriteLine("\n\nTabella creata correttamente");
                    Thread.Sleep(1500);
                }
            }
        }

        private static void visualizzaListaVeicoli()
        {
            if (connStr != null)
            {
                OleDbConnection connection = new OleDbConnection(connStr);
                using (connection)
                {
                    connection.Open();

                    OleDbCommand command = new OleDbCommand("SELECT * FROM Veicoli", connection);

                    try
                    {
                        OleDbDataReader rdr = command.ExecuteReader();

                        if (rdr.HasRows)
                        {
                            Console.WriteLine("\n");
                            while (rdr.Read())
                            {
                                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} | {11} | {12}",
                                    rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetInt32(5), rdr.GetInt32(6),
                                    rdr.GetDateTime(7).ToShortDateString(), rdr.GetBoolean(8), rdr.GetBoolean(9), rdr.GetInt32(10), rdr.GetString(11),
                                    rdr.GetString(12));
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\nNel DB non sono presenti veicoli");
                        }
                        rdr.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\n{ex.Message}");
                    }
                }
                Thread.Sleep(7000);
            }
        }

        private static void cancellaRecords()
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand com = new OleDbCommand("DELETE FROM Veicoli", con);
                    try
                    {
                        com.ExecuteNonQuery();
                        Console.WriteLine("\nRecord eliminati correttamente");
                        Thread.Sleep(3000);
                        cancellaFiles();

                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine("\n\n" + exc.Message);
                        Thread.Sleep(3000);
                        return;
                    }
                }
            }
        }

        private static void cancellaTabellaVeicoli()
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand com = new OleDbCommand("DROP TABLE Veicoli", con);

                    try
                    {
                        com.ExecuteNonQuery();
                        Console.WriteLine("\nTabella eliminata correttamente");
                        Thread.Sleep(3000);
                        cancellaFiles();
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine("\n\n" + exc.Message);
                        Thread.Sleep(3000);
                        return;
                    }
                }
            }
        }

        private static void cancellaFiles()
        {
            DirectoryInfo di = new DirectoryInfo($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\WindowsFormsAppProject\\bin\\Debug\\img");

            foreach (FileInfo file in di.GetFiles())
            {
                if (file.Name != "NoImage.jpg")
                {
                    file.Delete();
                }
            }
            Console.WriteLine("\nFiles eliminati correttamente");
            Thread.Sleep(3000);
        }
    }
}
