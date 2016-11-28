using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPE_Mission_3;

namespace testUnitaire
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            GestionDate gd = new GestionDate();

            // FONCTION MOIS PRECEDENT
            Assert.AreEqual("201610", gd.getAnneeMoisPrecedent());
            // Assert.AreEqual("11", gd.getMoisPrecedent());

            // FONCTION MOIS SUIVANT
            Assert.AreEqual("12", gd.getMoisSuivant());
            //Assert.AreEqual("11", gd.getMoisSuivant());

            // FONCTION MOIS COURANT
            Assert.AreEqual("11", gd.getMoisCourant());
            //Assert.AreEqual("12", gd.getMoisSuivant());
        }
    }
}