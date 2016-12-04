using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService1
{
    public partial class WindowsService1 : ServiceBase
    {
        private Timer timer = null;
        private MySqlConnection SqlCo = ConnexionSql.getInstance("127.0.0.1", "pthan", "root", "");
        GestionDate gd = new GestionDate();

        public WindowsService1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Timer de 30 secondes
            timer = new Timer(30000);

            // Execute timer_Elapsed toute les 30 secondes
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);

            // Activation du timer
            timer.Start();
        }

        protected override void OnStop()
        {

            // Arrêt du timer
            timer.Stop();
        }

        protected void timer_Elapsed(object sender, EventArgs e)
        {
            // Ouverture de la connexion
            SqlCo.Open();

            if (GestionDate.verifIntervalle(1, 10))
            {
                String date = gd.getAnneeMoisPrecedent();
                MySqlCommand SqlCom = new MySqlCommand("Update fichefrais set idEtat='CL' where mois= '" + date + "'", SqlCo);
                MySqlDataReader reader = SqlCom.ExecuteReader();

            }

            if (GestionDate.majFicheMoisPrecedent())
            {
                String date = gd.getAnneeMoisPrecedent();
                MySqlCommand SqlCom = new MySqlCommand("Update fichefrais set idEtat='RB' where mois= '" + date + "' and idEtat='VA'", SqlCo);
                MySqlDataReader reader = SqlCom.ExecuteReader();
            }
            // Fermeture de la connexion
            SqlCo.Close();
        }


    }


}
