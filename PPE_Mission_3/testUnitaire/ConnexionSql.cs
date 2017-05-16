using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_Mission_3
{
    class ConnexionSql
    {
        private static MySqlConnection SqlCo = null;



        //Constructor
        private ConnexionSql(string serveur, string bdd, string user, string mdp)
        {
            string connectionString;
            connectionString = "SERVER =" + serveur + ";DATABASE=" + bdd + ";UID=" + user + ";PASSWORD=" + mdp + "";

            SqlCo = new MySqlConnection(connectionString);
        }


        public static MySqlConnection getInstance(string serveur, string bdd, string user, string mdp)
        {
            if (null == SqlCo)
            { // Premier appel
              //  ConnexionSql.Initialize(unProvider, uneDataBase);

                new ConnexionSql(serveur, bdd, user, mdp);

            }
            return SqlCo;
        }




        //open connection to database
        public static void OpenConnection()
        {
            SqlCo.Open();
        }

        //Close connection
        public static void CloseConnection()
        {
            SqlCo.Close();
        }

    }
}
