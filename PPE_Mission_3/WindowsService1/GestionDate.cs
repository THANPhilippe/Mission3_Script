using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1

{
    /// <summary>
    /// Classe contenant les méthodes relatif à la manipulation des dates
    /// </summary>
    public class GestionDate
    {
        /// <summary>
        /// Retourne le mois courant
        /// </summary>
        /// <returns></returns>
        public string getMoisCourant()
        {
            DateTime date = DateTime.Now;
            int mois = date.Month;
            return (mois.ToString());

        }

        /// <summary>
        /// Retourne le mois précédent sous le format annee+mois
        /// </summary>
        /// <returns></returns>
        public string getAnneeMoisPrecedent()
        {
            DateTime date = DateTime.Now.AddMonths(-1);
            String mois = (date.Month).ToString();
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
            int mois = date.Month;
            return (mois.ToString());

        }

        /// <summary>
        /// Vérifie si le jour courant est compris entre deux jours
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Vérifie si le jour courant se situe après le 20ème jour du mois courant
        /// </summary>
        /// <returns></returns>
        public static bool majFicheMoisPrecedent()
        {
            if (DateTime.Now.Day >= 20)
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
