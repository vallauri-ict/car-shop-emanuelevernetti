using System;
using System.Data.OleDb;
using System.IO;
using System.Threading;
using VenditaVeicoliDllProject;

namespace CarShopConsoleProject
{
    public class Program
    {
        public static string path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Utilities\\Veicoli.accdb";
        public static string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;

        static void Main(string[] args)
        {
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
                            aggiungiEsempioAuto();
                            break;
                        }
                    case '3':
                        {
                            aggiungiEsempioMoto();
                            break;
                        }
                    case '4':
                        {
                            visualizzaListaVeicoli();
                            break;
                        }
                    default:
                        {
                     
                        }
                        break;
                }
            }
            while (scelta != 'X' && scelta != 'x');
        }

        private static void menu()
        {
            Console.Clear();
            Console.WriteLine("\t*** CAR SHOP - DB MANAGEMENT ***\n");
            Console.WriteLine("1 - Crea tabella 'Veicoli' ");
            Console.WriteLine("2 - Aggiungi elemento di esempio (Auto)");
            Console.WriteLine("3 - Aggiungi elemento di esempio (Moto)");
            Console.WriteLine("4 - Visualizza l'elenco completo dei veicoli");
            Console.WriteLine("5 - ...");
            Console.WriteLine("6 - ...");
            Console.WriteLine("\nX - ESCI\n");
        }

        private static void creaTabella()
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
                                            CodVeicolo AUTOINCREMENT NOT NULL PRIMARY KEY, 
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

        private static void aggiungiEsempioAuto()
        {
            OleDbConnection connection = new OleDbConnection(connStr);

            using (connection)
            {
                OleDbCommand command = new OleDbCommand();
                connection.Open();
                command.Connection = connection;

                command.CommandText = "INSERT INTO Veicoli (Tipologia, Marca, Modello, Colore, Cilindrata, PotenzaKw, Immatricolazione, IsUsato, IsKmZero, KmPercorsi, Informazioni, Immagine) VALUES" +
                    "(@tipologia, @marca, @modello, @colore, @cilindrata, @potenzakw, @immatricolazione, @isusato, @iskmzero, @iskmpercorsi, @informazioni, @immagine)";

                command.Parameters.Add(new OleDbParameter("@tipologia", OleDbType.VarChar, 255)).Value = "AUTO";
                command.Parameters.Add("@marca", OleDbType.VarChar, 255).Value = "marcaTest";
                command.Parameters.Add("@modello", OleDbType.VarChar, 255).Value = "modelloTest";
                command.Parameters.Add("@colore", OleDbType.VarChar, 255).Value = "Nero";
                command.Parameters.Add("@cilindrata", OleDbType.Integer).Value = 500;
                command.Parameters.Add("@potenzakw", OleDbType.Integer).Value = 100;
                command.Parameters.Add("@immatricolazione", OleDbType.Date).Value = (DateTime.Now).ToShortDateString();
                command.Parameters.Add("@isusato", OleDbType.Boolean).Value = false;
                command.Parameters.Add("@iskmzero", OleDbType.Boolean).Value = true;
                command.Parameters.Add("@kmpercorsi", OleDbType.Integer).Value = 0;
                command.Parameters.Add("@informazioni", OleDbType.VarChar, 255).Value = "4";
                command.Parameters.Add("@immagine", OleDbType.VarChar, 255).Value = "test.jpg";

                command.Prepare();

                try
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("\nVeicolo di prova(Auto) aggiunto correttamente");
                    Thread.Sleep(3000);
                }
                catch (OleDbException exc)
                {
                    Console.WriteLine("\n\n" + exc.Message);
                    Thread.Sleep(3000);
                    return;
                }
            }
        }

        private static void aggiungiEsempioMoto()
        {
            OleDbConnection connection = new OleDbConnection(connStr);

            using (connection)
            {
                OleDbCommand command = new OleDbCommand();
                connection.Open();
                command.Connection = connection;

                command.CommandText = "INSERT INTO Veicoli (Tipologia, Marca, Modello, Colore, Cilindrata, PotenzaKw, Immatricolazione, IsUsato, IsKmZero, KmPercorsi, Informazioni, Immagine) VALUES" +
                    "(@tipologia, @marca, @modello, @colore, @cilindrata, @potenzakw, @immatricolazione, @isusato, @iskmzero, @iskmpercorsi, @informazioni, @immagine)";

                command.Parameters.Add(new OleDbParameter("@tipologia", OleDbType.VarChar, 255)).Value = "MOTO";
                command.Parameters.Add("@marca", OleDbType.VarChar, 255).Value = "marcaTest";
                command.Parameters.Add("@modello", OleDbType.VarChar, 255).Value = "modelloTest";
                command.Parameters.Add("@colore", OleDbType.VarChar, 255).Value = "Nero";
                command.Parameters.Add("@cilindrata", OleDbType.Integer).Value = 500;
                command.Parameters.Add("@potenzakw", OleDbType.Integer).Value = 100;
                command.Parameters.Add("@immatricolazione", OleDbType.Date).Value = (DateTime.Now).ToShortDateString();
                command.Parameters.Add("@isusato", OleDbType.Boolean).Value = false;
                command.Parameters.Add("@iskmzero", OleDbType.Boolean).Value = true;
                command.Parameters.Add("@kmpercorsi", OleDbType.Integer).Value = 0;
                command.Parameters.Add("@informazioni", OleDbType.VarChar, 255).Value = "sellaTest";
                command.Parameters.Add("@immagine", OleDbType.VarChar, 255).Value = "test.jpg";

                command.Prepare();

                try
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("\nVeicolo di prova(Moto) aggiunto correttamente");
                    Thread.Sleep(3000);
                }
                catch (OleDbException exc)
                {
                    Console.WriteLine("\n\n" + exc.Message);
                    Thread.Sleep(3000);
                    return;
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
    }
}
