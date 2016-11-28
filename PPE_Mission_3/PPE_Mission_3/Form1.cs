using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_Mission_3
{
    public partial class Form1 : Form
    {
        private MySqlDataReader SqlRea;
        private MySqlConnection SqlCo = ConnexionSql.getInstance("SERVER = 127.0.0.1; DATABASE=pthan;UID=root;PASSWORD=");

        public Form1()
        {
            InitializeComponent();
            afficherDonnées();
        }

        public void afficherDonnées()
        {

            // Ouverture de la connexion
            SqlCo.Open();

            // Instanciation de l’objet Command
            MySqlCommand SqlCom = new MySqlCommand("Select * from Employé", SqlCo);

        }
    }
}
