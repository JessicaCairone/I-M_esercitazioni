using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_biblioteca.Models.DAL
{
    internal class UtenteDAO : IDaoLettura<Utenti>, IDaoScrittura<Utenti>
    {
        private static UtenteDAO instance;

        public static UtenteDAO GetInstance()
        {
            if (instance is null)
                instance = new UtenteDAO();

            return instance;
        }

        private UtenteDAO() { }

        public List<Utenti> GetAll()
        {
            List<Utenti> elencoUtenti = new List<Utenti>();

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT utenteID, nome, cognome, email FROM Utenti";

                try
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Utenti utente = new Utenti()
                        {
                           UtenteId = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Cognome = reader.GetString(2),
                            Email = reader.GetString(3)
                        };
                        elencoUtenti.Add(utente);
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

                return elencoUtenti;
            }
        }

        public Utenti GetById(int id)
        {
            Utenti? utenteTrovato = null;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT utenteID, nome, cognome, email FROM Utenti WHERE utenteID = @varId";
                cmd.Parameters.AddWithValue("@varId", id);

                try
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        utenteTrovato = new Utenti()
                        {
                            UtenteId = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Cognome = reader.GetString(2),
                            Email = reader.GetString(3)
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
                return utenteTrovato;
          
            }
        }

        public bool Insert(Utenti obj)
        {
            bool utenteInserito = false;
            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO (titolo, anno_pubblicazione, disponibilità) VALUES (@nome, @cogn, @email)";
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@cogn", obj.Cognome);
                cmd.Parameters.AddWithValue("@email", obj.Email);

                try
                {
                    connection.Open();

                    int affRows = cmd.ExecuteNonQuery();

                    if (affRows > 0)
                    {
                        utenteInserito = true;
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

                return utenteInserito;
            }
        }

        public bool Update(Utenti obj)
        {
            bool utenteModificato = false;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE Utenti SET nome = @nome," +
                    "cognome = @cogn," +
                    "email = @email" +
                    "WHERE utenteID = @varId";

                cmd.Parameters.AddWithValue("@tit", obj.Nome);
                cmd.Parameters.AddWithValue("@ann", obj.Cognome);
                cmd.Parameters.AddWithValue("@dis", obj.Email);

                try
                {
                    connection.Open();

                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                        utenteModificato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return utenteModificato;
            }
        }

        public bool Delete(int id)
        {
            bool utenteEliminato = false;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM Utenti WHERE utenteID = @varId";
                cmd.Parameters.AddWithValue("@varId", id);


                try
                {
                    connection.Open();
                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                       utenteEliminato = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return utenteEliminato;
            }
        }

        //metodo che restituisce gli utenti con il maggior numero di prestiti attivi
        public List<Utenti> GetUtenteWithMoreLoans()
        {
            DbBibliotecaContext db = new DbBibliotecaContext();

           

               int numMaxLoans = db.Prestitis.GroupBy(p => p.UtenteRif).Max(a => a.Count());

              List<Prestiti> result = db.Prestitis.GroupBy(p => p.UtenteRif).Where(a => a.Count() == numMaxLoans).ToList();

              return new List<Utenti>();  

        }
    }
}
