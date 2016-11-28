using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_Mission_3
{
    class GestionDate
    {
        public string getMoisCourant()
        {
            DateTime date = DateTime.Now;
            int mois = date.Month;
            return (mois.ToString());

        }

        public string getAnneeMoisPrecedent()
        {
            DateTime date = DateTime.Now.AddMonths(-1);
            String mois = (date.Month).ToString();
            String annee = (date.Year).ToString();
            return (annee+mois);

        }

        public string getMoisSuivant()
        {
            DateTime date = DateTime.Now.AddMonths(1);
            int mois = date.Month;
            return (mois.ToString());

        }

    }
}
