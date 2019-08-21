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
        public static Connexion GetConnexions()
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
                   Connexion objConnexion = new Connexion();
                    if (connexionReader.Read())
                    {

                        objConnexion.Username = connexionReader["Username"].ToString();
                        objConnexion.MotDePasse = connexionReader["MotDePasse"].ToString();

                    }


                connexionReader.Close();
                return objConnexion;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
