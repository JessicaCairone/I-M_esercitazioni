using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_biblioteca.Models.DAL
{
    internal class PrestitoDAO : IDaoLettura<Prestiti>, IDaoScrittura<Prestiti>
    {
        private static PrestitoDAO? instance;


        public static PrestitoDAO GetInstance()
        {
            if (instance is null)
                instance = new PrestitoDAO();

            return instance;
        }

        private PrestitoDAO() { }

        public List<Prestiti> GetAll()
        {
            List<Prestiti> elencoPrestiti = new List<Prestiti>();

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT prestitoID, data_prestito, data_ritorno, utenteRIF, libroRIF FROM Prestiti";

               // DbBibliotecaContext db = new DbBibliotecaContext();
                //List<Prestiti>  result2 = db.Prestitis.ToList();
               
                

                try
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Prestiti prestito = new Prestiti()
                        {
                            PrestitoId = reader.GetInt32(0),
                            DataPrestito = reader.GetDateTime(1),
                            DataRitorno = reader.GetDateTime(2),
                            UtenteRif = reader.GetInt32(3),
                            LibroRif = reader.GetInt32(4),
                        };
                        elencoPrestiti.Add(prestito);
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

                return elencoPrestiti;
            }
        }

        public Prestiti GetById(int id)
        {
            Prestiti? prestitoTrovato = null;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT prestitoID, data_prestito, data_ritorno, utenteRIF, libroRIF FROM Prestiti WHERE prestitoID = @varId";
                cmd.Parameters.AddWithValue("@varId", id);

                try
                {
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        prestitoTrovato = new Prestiti()
                        {
                            PrestitoId = reader.GetInt32(0),
                            DataPrestito = reader.GetDateTime(1),
                            DataRitorno = reader.GetDateTime(2),
                            UtenteRif = reader.GetInt32(3),
                            LibroRif = reader.GetInt32(4)
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
                return prestitoTrovato;
            }
        }

        public bool Insert(Prestiti obj)
        {
            bool prestitoInserito = false;
            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO (data_prestito, data_ritorno, utenteRIF, libroRIF) VALUES (@pres, @rit, @uRIF, @lRIF)";
                cmd.Parameters.AddWithValue("@tit", obj.DataPrestito);
                cmd.Parameters.AddWithValue("@ann", obj.DataRitorno);
                cmd.Parameters.AddWithValue("@dis", obj.UtenteRif);
                cmd.Parameters.AddWithValue("@dis", obj.LibroRif);

                try
                {
                    connection.Open();

                    int affRows = cmd.ExecuteNonQuery();

                    if (affRows > 0)
                    {
                        prestitoInserito = true;
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

                return prestitoInserito;
            }
        }

        public bool Update(Prestiti obj)
        {
            bool prestitoModificato = false;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE Prestiti SET data_prestito = @pres, " +
                    "data_ritorno = @rit, " +
                    "utenteRIF = @uRIF," +
                    "libroRIF = @lRIF" +
                    " WHERE prestitoID = @varId";

                cmd.Parameters.AddWithValue("@pres", obj.DataPrestito);
                cmd.Parameters.AddWithValue("@rit", obj.DataRitorno);
                cmd.Parameters.AddWithValue("@uRIF", obj.UtenteRif);
                cmd.Parameters.AddWithValue("@lRIF", obj.LibroRif);

                try
                {
                    connection.Open();

                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                        prestitoModificato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return prestitoModificato;
            }
        }

        public bool Delete(int id)
        {
            bool prestitoEliminato = false;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM Prestiti WHERE prestitoID = @varId";
                cmd.Parameters.AddWithValue("@varId", id);


                try
                {
                    connection.Open();
                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                        prestitoEliminato = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return prestitoEliminato;
            }
        }

        //metodo che restituisce i prestiti in corso
        public List<Prestiti> GetCurrentLoans(string varNome, string varCognome)
        {
            DbBibliotecaContext db = new DbBibliotecaContext();

            // var result = "select Prestiti.* from Prestiti " +
            //   "join Utenti on Prestiti.utenteRIF = Utente.utenteID where nome = @nom and cognome = @cogn";

            var result = (from prestito in db.Prestitis
                         join utente in db.Utentis on prestito.UtenteRif equals utente.UtenteId
                         where utente.Nome == varNome && utente.Cognome == varCognome
                         && prestito.DataRitorno > DateTime.Now
                         select prestito).ToList();

            //var result2 = db.Utentis.First(u => u.Nome == varNome && u.Cognome == varCognome).Prestitis.ToList();
            
                       
            return result;
                        
        }

    }
}
