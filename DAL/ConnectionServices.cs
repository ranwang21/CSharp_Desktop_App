using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public static class ConnectionServices
    {

        // connection helper
        public static List<Connexion> GetConnexions()
        {
            // petit commentaire
            string login = "SELECT * FROM Connexion";

            try
            {
                SqlDataReader connexionReader = SqlHelper.GetReader(login);

                if (!connexionReader.HasRows)
                {

                    return null;
                }
                else
                {
                    List<Connexion> objListConn = new List<Connexion>();
                    while (connexionReader.Read())
                    {
                        objListConn.Add(
                                new Connexion
                                {
                                    Username = connexionReader["Username"].ToString(),
                                    MotDePasse = connexionReader["MotDePasse"].ToString()
                                }
                            );

                    }

                    connexionReader.Close();
                    return objListConn;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
