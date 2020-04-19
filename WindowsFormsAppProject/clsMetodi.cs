using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VenditaVeicoliDllProject;

namespace WindowsFormsAppProject
{
    public class clsMetodi
    {
        /// <summary>
        /// Controlla se il colore è già contenuto nella listaColori e in caso negativo lo aggiunge
        /// </summary>
        /// <param name="color">Colore</param>
        public static void checkColore(string color)
        {
            bool ok = false;
            for (int i = 0; i < clsVariabili.listaColori.Count; i++)
            {
                if (clsVariabili.listaColori[i] == color)
                {
                    ok = true;
                }
            }
            if (!ok)
            {
                clsVariabili.listaColori.Add(color);
                ordinaLista(clsVariabili.listaColori);
            }
        }

        internal static void caricaDgvAdmin(BindingList<Veicolo> lista, DataGridView dgv)
        {
            dgv.DataSource = lista;
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] is Auto)
                {
                    dgv.Rows[i].HeaderCell.Value = "AUTO";
                    dgv.Rows[i].Cells[9].Value = "N° airbag: " + (lista[i] as Auto).NumAirbag.ToString();
                }
                else
                {
                    dgv.Rows[i].HeaderCell.Value = "MOTO";
                    dgv.Rows[i].Cells[9].Value = "Marca sella: " + (lista[i] as Moto).MarcaSella;
                }
            }
            dgv.AutoResizeColumns();
            dgv.AutoResizeRows();
        }

        public static void settaDgv(DataGridView dgv)
        {
            dgv.RowHeadersWidth = 70;
            dgv.ReadOnly = true;
        }

        public static void caricaDgv(BindingList<Veicolo> lista, DataGridView dgv)
        {
            #region Codice commentato(caricamento manuale del DataGridView)
            //dgv.Rows.Clear();
            //for (int i = 0; i < lista.Count; i++)
            //{
            //    dgv.Rows.Add();
            //    if (lista[i] is Auto)
            //    {
            //        Auto a = lista[i] as Auto;
            //        dgv.Rows[i].HeaderCell.Value = "AUTO";
            //        dgv.Rows[i].Cells[0].Value = a.Marca;
            //        dgv.Rows[i].Cells[1].Value = a.Modello;
            //        dgv.Rows[i].Cells[2].Value = a.Colore;
            //        dgv.Rows[i].Cells[3].Value = a.Cilindrata.ToString();
            //        dgv.Rows[i].Cells[4].Value = a.PotenzaKw.ToString();
            //        dgv.Rows[i].Cells[5].Value = a.Immatricolazione.ToString();
            //        if (a.IsUsato)
            //        {
            //            dgv.Rows[i].Cells[6].Value = "Sì";
            //        }
            //        else
            //        {
            //            dgv.Rows[i].Cells[6].Value = "No";
            //        }
            //        if (a.IsKmZero)
            //        {
            //            dgv.Rows[i].Cells[7].Value = "Sì";
            //        }
            //        else
            //        {
            //            dgv.Rows[i].Cells[7].Value = "No";
            //        }
            //        if (a.IsKmZero)
            //        {
            //            dgv.Rows[i].Cells[8].Value = "0";
            //        }
            //        else
            //        {
            //            dgv.Rows[i].Cells[8].Value = a.KmPercorsi.ToString();
            //        }
            //        dgv.Rows[i].Cells[9].Value = "N° airbag: " + a.NumAirbag.ToString();

            //    }
            //    else
            //    {
            //        Moto m = lista[i] as Moto;
            //        dgv.Rows[i].HeaderCell.Value = "MOTO";
            //        dgv.Rows[i].Cells[0].Value = m.Marca;
            //        dgv.Rows[i].Cells[1].Value = m.Modello;
            //        dgv.Rows[i].Cells[2].Value = m.Colore;
            //        dgv.Rows[i].Cells[3].Value = m.Cilindrata.ToString();
            //        dgv.Rows[i].Cells[4].Value = m.PotenzaKw.ToString();
            //        dgv.Rows[i].Cells[5].Value = m.Immatricolazione.ToString();
            //        if (m.IsUsato)
            //        {
            //            dgv.Rows[i].Cells[6].Value = "Sì";
            //        }
            //        else
            //        {
            //            dgv.Rows[i].Cells[6].Value = "No";
            //        }
            //        if (m.IsKmZero)
            //        {
            //            dgv.Rows[i].Cells[7].Value = "Sì";
            //        }
            //        else
            //        {
            //            dgv.Rows[i].Cells[7].Value = "No";
            //        }
            //        if (m.IsKmZero)
            //        {
            //            dgv.Rows[i].Cells[8].Value = "0";
            //        }
            //        else
            //        {
            //            dgv.Rows[i].Cells[8].Value = m.KmPercorsi.ToString();
            //        }
            //        dgv.Rows[i].Cells[9].Value = "Sella: " + m.MarcaSella;
            //    }
            //}
            #endregion

            dgv.DataSource = lista;
            for (int i = 0; i < lista.Count; i++)
            {
                dgv.Rows[i].Cells[10].Value = "ELIMINA";
                if (lista[i] is Auto)
                {
                    dgv.Rows[i].HeaderCell.Value = "AUTO";
                    dgv.Rows[i].Cells[9].Value = "N° airbag: " + (lista[i] as Auto).NumAirbag.ToString();
                }
                else
                {
                    dgv.Rows[i].HeaderCell.Value = "MOTO";
                    dgv.Rows[i].Cells[9].Value = "Marca sella: " + (lista[i] as Moto).MarcaSella;
                }
            }
            dgv.AutoResizeColumns();
            dgv.AutoResizeRows();
        }

        /// <summary>
        /// Controlla se la marca è già contenuta nella listaColori e in caso negativo la aggiunge
        /// </summary>
        /// <param name="color">Colore</param>
        public static void checkMarca(string marca)
        {
            bool ok = false;
            for (int i = 0; i < clsVariabili.listaMarche.Count; i++)
            {
                if (clsVariabili.listaMarche[i] == marca)
                {
                    ok = true;
                }
            }
            if (!ok)
            {
                clsVariabili.listaMarche.Add(marca);
                ordinaLista(clsVariabili.listaMarche);
            }
        }

        /// <summary>
        /// Ordinamento della lista passata come parametro
        /// </summary>
        /// <param name="lista"></param>
        public static void ordinaLista(List<string> lista)
        {
            int posmin;
            string aus = "";
            for (int i = 0; i <= (lista.Count-2); i++)
            {
                posmin = i;
                for (int j = (i+1); j <=(lista.Count-1); j++)
                {
                    if (String.Compare(lista[posmin],lista[j])>0)
                    {
                        posmin = j;
                    }
                }
                if (posmin!=i)
                {
                    aus = lista[i];
                    lista[i] = lista[posmin];
                    lista[posmin] = aus;
                }
            }
        }

        /// <summary>
        /// Ordinamento della listaVeicoli, in base al tipo del secondo parametro
        /// </summary>
        /// <param name="lista">Lista contenente i veicoli</param>
        /// <param name="fil">Filtro</param>
        public static void ordinaListaVeicoli(BindingList<Veicolo> lista, string fil)
        {
            if (lista.Count!=0)
            {
                var type = lista.First().GetType().GetProperty(fil).PropertyType.Name;
                if (type == "Int32")
                {
                    int posmin;
                    for (int i = 0; i <= (lista.Count - 2); i++)
                    {
                        posmin = i;
                        for (int j = (i + 1); j <= (lista.Count - 1); j++)
                        {
                            if (Convert.ToInt32(lista[posmin].GetType().GetProperty(fil).GetValue(lista[posmin])) > Convert.ToInt32(lista[j].GetType().GetProperty(fil).GetValue(lista[j])))
                            {
                                posmin = j;
                            }
                        }
                        if (posmin != i)
                        {
                            if (lista[i] is Auto)
                            {
                                Auto a = (lista[i] as Auto);
                                lista[i] = lista[posmin];
                                lista[posmin] = a;
                            }
                            else
                            {
                                Moto m = (lista[i] as Moto);
                                lista[i] = lista[posmin];
                                lista[posmin] = m;
                            }
                        }
                    }
                }
                else if (type == "Double")
                {
                    int posmin;
                    for (int i = 0; i <= (lista.Count - 2); i++)
                    {
                        posmin = i;
                        for (int j = (i + 1); j <= (lista.Count - 1); j++)
                        {
                            if (Convert.ToDouble(lista[posmin].GetType().GetProperty(fil).GetValue(lista[posmin])) > Convert.ToDouble(lista[j].GetType().GetProperty(fil).GetValue(lista[j])))
                            {
                                posmin = j;
                            }
                        }
                        if (posmin != i)
                        {
                            if (lista[i] is Auto)
                            {
                                Auto a = (lista[i] as Auto);
                                lista[i] = lista[posmin];
                                lista[posmin] = a;
                            }
                            else
                            {
                                Moto m = (lista[i] as Moto);
                                lista[i] = lista[posmin];
                                lista[posmin] = m;
                            }
                        }
                    }
                }
                else if (type == "String")
                {
                    int posmin;
                    for (int i = 0; i <= (lista.Count - 2); i++)
                    {
                        posmin = i;
                        for (int j = (i + 1); j <= (lista.Count - 1); j++)
                        {
                            if (String.Compare(lista[posmin].GetType().GetProperty(fil).GetValue(lista[posmin]).ToString(), lista[j].GetType().GetProperty(fil).GetValue(lista[j]).ToString()) > 0)
                            {
                                posmin = j;
                            }
                        }
                        if (posmin != i)
                        {
                            if (lista[i] is Auto)
                            {
                                Auto a = (lista[i] as Auto);
                                lista[i] = lista[posmin];
                                lista[posmin] = a;
                            }
                            else
                            {
                                Moto m = (lista[i] as Moto);
                                lista[i] = lista[posmin];
                                lista[posmin] = m;
                            }
                        }
                    }
                }
                else if (type == "DateTime")
                {
                    int posmin;
                    for (int i = 0; i <= (lista.Count - 2); i++)
                    {
                        posmin = i;
                        for (int j = (i + 1); j <= (lista.Count - 1); j++)
                        {
                            if (Convert.ToDateTime(lista[posmin].GetType().GetProperty(fil).GetValue(lista[posmin])) > Convert.ToDateTime(lista[j].GetType().GetProperty(fil).GetValue(lista[j])))
                            {
                                posmin = j;
                            }
                        }
                        if (posmin != i)
                        {
                            if (lista[i] is Auto)
                            {
                                Auto a = (lista[i] as Auto);
                                lista[i] = lista[posmin];
                                lista[posmin] = a;
                            }
                            else
                            {
                                Moto m = (lista[i] as Moto);
                                lista[i] = lista[posmin];
                                lista[posmin] = m;
                            }
                        }
                    }
                }
                else
                {
                    int posmin;
                    for (int i = 0; i <= (lista.Count - 2); i++)
                    {
                        posmin = i;
                        for (int j = (i + 1); j <= (lista.Count - 1); j++)
                        {
                            if ((Convert.ToBoolean(lista[posmin].GetType().GetProperty(fil).GetValue(lista[posmin]))) && (!Convert.ToBoolean(lista[j].GetType().GetProperty(fil).GetValue(lista[j]))))
                            {
                                posmin = j;
                            }
                        }
                        if (posmin != i)
                        {
                            if (lista[i] is Auto)
                            {
                                Auto a = (lista[i] as Auto);
                                lista[i] = lista[posmin];
                                lista[posmin] = a;
                            }
                            else
                            {
                                Moto m = (lista[i] as Moto);
                                lista[i] = lista[posmin];
                                lista[posmin] = m;
                            }
                        }
                    }
                }
            }
            else
            {
                //MessageBox.Show("La lista è vuota");
            }
        }
    }
}
