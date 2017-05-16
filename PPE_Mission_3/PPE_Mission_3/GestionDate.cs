using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_Mission_3
{
    public class GestionDate
    {
            /// <summary>
            /// Retourne le mois courant
            /// </summary>
            /// <returns></returns>
            public string getMoisCourant()
            {
                DateTime date = DateTime.Now;
                String mois = (date.Month).ToString().PadLeft(2, '0');
                return (mois.ToString());

            }

            /// <summary>
            /// Retourne le mois précédent sous le format annee+mois
            /// </summary>
            /// <returns></returns>
            public string getAnneeMoisPrecedent()
            {
                DateTime date = DateTime.Now.AddMonths(-1);
                String mois = (date.Month).ToString().PadLeft(2, '0');
                String annee = (date.Year).ToString();
                return (annee + mois);

            }

            /// <summary>
            /// Retourne le mois suivant
            /// </summary>
            /// <returns></returns>
            public string getMoisSuivant()
            {
                DateTime date = DateTime.Now.AddMonths(1);
                String mois = (date.Month).ToString().PadLeft(2, '0');
                return (mois);

            }

            public static bool verifIntervalle(int min, int max)
        {
            if (DateTime.Now.Day >= min && DateTime.Now.Day <= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool majFicheMoisPrecedent()
        {
            if (DateTime.Now.Day <20)
            //if (DateTime.Now.Day >= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
