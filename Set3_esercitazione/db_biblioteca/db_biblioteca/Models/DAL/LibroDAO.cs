using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_biblioteca.Models.DAL
{
    internal class LibroDAO : IDaoLettura<Libri>, IDaoScrittura<Libri>
    {
        #region singleton
        private static LibroDAO? instance;

        public static LibroDAO GetInstance()
        {
            if (instance is null)
                instance = new LibroDAO();

            return instance;
        }

        private LibroDAO() { }
        #endregion

        #region getAll
        public List<Libri> GetAll()
        {
            List<Libri> elencoLibri = new List<Libri>();

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT libroID, titolo, anno_pubblicazione, disponibilità FROM Libri";

                try
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Libri libro = new Libri()
                        {
                            LibroId = reader.GetInt32(0),
                            Titolo = reader.GetString(1),
                            AnnoPubblicazione = reader.GetInt32(2),
                            Disponibilita = reader.GetBoolean(3)
                        };
                        elencoLibri.Add(libro);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return elencoLibri;
            }
        }
        #endregion

        #region getById
        public Libri? GetById(int id)
        {
            Libri? libroTrovato = null;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT libroID, titolo, anno_pubblicazione, disponibilita FROM Libri WHERE libroID = @varId";
                cmd.Parameters.AddWithValue("@varId", id);

                try
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        libroTrovato = new Libri()
                        {
                            LibroId = reader.GetInt32(0),
                            Titolo = reader.GetString(1),
                            AnnoPubblicazione = (int)reader.GetInt32(2),
                            Disponibilita = reader.GetBoolean(3)
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return libroTrovato;
            }
        }
        #endregion

        #region Insert
        public bool Insert(Libri obj)
        {
            bool libroInserito = false;
            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO (titolo, anno_pubblicazione, disponibilità) VALUES (@tit, @ann, @dis)";
                cmd.Parameters.AddWithValue("@tit", obj.Titolo);
                cmd.Parameters.AddWithValue("@ann", obj.AnnoPubblicazione);
                cmd.Parameters.AddWithValue("@dis", obj.Disponibilita);

                try
                {
                    connection.Open();

                    int affRows = cmd.ExecuteNonQuery();

                    if (affRows > 0)
                    {
                        libroInserito = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return libroInserito;
            }
        }

        #endregion

        #region Update 
        public bool Update(Libri obj)
        {
            bool libroModificato = false;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE Libri SET titolo = @tit," +
                    "anno_pubblicazione = @ann," +
                    "disponibilita = @dis" +
                    "WHERE libroID = @varId";

                cmd.Parameters.AddWithValue("@tit", obj.Titolo);
                cmd.Parameters.AddWithValue("@ann", obj.AnnoPubblicazione);
                cmd.Parameters.AddWithValue("@dis", obj.Disponibilita);

                try
                {
                    connection.Open();

                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                        libroModificato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return libroModificato;
            }
        }
        #endregion

        #region Delete
        public bool Delete(int id)
        {
            bool libroEliminato = false;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM Libri WHERE libroID = @varId";
                cmd.Parameters.AddWithValue("@varId", id);


                try
                {
                    connection.Open();
                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                        libroEliminato = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return libroEliminato;
            }
        }

        #endregion

        #region Ricerche avanzate 

        //metodo che ricerca i libri disponibili
        public List<Libri> GetAvailableBooks()

        {
            try
            {
                //istanzio il contesto
                DbBibliotecaContext db = new DbBibliotecaContext();
                //function like
                List<Libri> result = db.Libris.Where(l => l.Disponibilita == true).ToList();

                //query like
                //var libriDisponibili = "select * from libri where disponibilita = 1 ";

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.InnerException);
                return new List<Libri>();
            }
        }
        #endregion

            
    }
}
        
  
