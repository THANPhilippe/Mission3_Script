using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPE_Mission_3;
using MySql.Data.MySqlClient;

namespace testUnitaire
{
    [TestClass]
    public class UnitTest1
    {
        private MySqlConnection SqlCo = ConnexionSql.getInstance("138.231.160.7", "pthan", "pthan", "Ti8eitho");
        private TestContext context;

        public TestContext TestContext
        {
            get
            {
                return context;
            }
            set
            {
                context = value;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {

        GestionDate gd = new GestionDate();

            // FONCTION MOIS PRECEDENT
            Assert.AreEqual("201704", gd.getAnneeMoisPrecedent());
            // Assert.AreEqual("11", gd.getMoisPrecedent());

            // FONCTION MOIS SUIVANT
            Assert.AreEqual("06", gd.getMoisSuivant());
            //Assert.AreEqual("11", gd.getMoisSuivant());

            // FONCTION MOIS COURANT
            Assert.AreEqual("05", gd.getMoisCourant());
            //Assert.AreEqual("12", gd.getMoisSuivant());

            // Test Etat VA en RB pour les fiches frais du mois précédent (>20eme jours mois actuel) pour le visiteur a131

            SqlCo.Open();
            String date = "201702"; //Mois précédent
            MySqlTransaction transaction;
            MySqlCommand command = new MySqlCommand("Update fichefrais set idEtat='RB' where idVisiteur ='a131' and mois= '" + date + "' and idEtat='VA'", SqlCo);

            // Start a local transaction.
            transaction = SqlCo.BeginTransaction();

            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            command.Connection = SqlCo;
            command.Transaction = transaction;

            command.ExecuteNonQuery();

            MySqlCommand command2 = new MySqlCommand("Select idEtat from fichefrais where idVisiteur ='a131' and mois =" + date + "", SqlCo);
            MySqlDataReader exec = command2.ExecuteReader();
            while (exec.Read())
            {
                TestContext.WriteLine(exec.GetString(0));
            }
            Assert.AreEqual("RB", exec.GetString(0));
            SqlCo.Close();

            /**
            SqlCo.Open();
            transaction.Rollback();
            SqlCo.Close();
            **/

            //Test Etat CL pour les fiches frais du mois précédent (1~10eme jour mois actuel) pour le visiteur b13
            SqlCo.Open();
            String date2 = "201606"; //Mois précédent
            MySqlTransaction transaction2;
            MySqlCommand command3 = new MySqlCommand("Update fichefrais set idEtat='CL' where mois= '" + date2 + "'", SqlCo);

            // Start a local transaction.
            transaction2 = SqlCo.BeginTransaction();

            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            command3.Connection = SqlCo;
            command3.Transaction = transaction2;

            command3.ExecuteNonQuery();

            MySqlCommand command4 = new MySqlCommand("Select idEtat from fichefrais where idVisiteur ='b13' and mois =" + date2 + "", SqlCo);
            MySqlDataReader exec2 = command4.ExecuteReader();
            while (exec2.Read())
            {
                TestContext.WriteLine(exec2.GetString(0));
            }
            Assert.AreEqual("CL", exec2.GetString(0));
            SqlCo.Close();

            /**
            SqlCo.Open();
            transaction.Rollback();
            SqlCo.Close();
            **/


        }
    }
}