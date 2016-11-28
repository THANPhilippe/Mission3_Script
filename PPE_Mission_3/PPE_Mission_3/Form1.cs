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
        private MySqlConnection SqlCo = ConnexionSql.getInstance("SERVER = 127.0.0.1; DATABASE=pthan;UID=root;PASSWORD=");
        GestionDate gd = new GestionDate();
        private DataTable dt;

        public Form1()
        {
            InitializeComponent();
            test();
        }

        public void test()
        {
            /*


            // Ouverture de la connexion
            SqlCo.Open();

            // Instanciation de l’objet Command
            MySqlCommand SqlCom = new MySqlCommand("Select * from fichefrais where mois= '"+date+"'", SqlCo);

            dt = new DataTable();
            dt.Columns.Add(reader.GetName(0));
            dt.Columns.Add(reader.GetName(1));
            dt.Columns.Add(reader.GetName(2));
            dt.Columns.Add(reader.GetName(3));
            dt.Columns.Add(reader.GetName(4));
            dt.Columns.Add(reader.GetName(5));


            while (reader.Read())

            {
                DataRow dr = dt.NewRow();
                dr[0] = reader.GetValue(0);
                dr[1] = reader.GetValue(1);
                dr[2] = reader.GetValue(2);
                dr[3] = reader.GetValue(3);
                dr[4] = reader.GetValue(4);
                dr[5] = reader.GetValue(5);
                dt.Rows.Add(dr);
            }
            datagrid.DataSource = dt;
                    */
        }


        private void timer1_Tick(object sender, EventArgs e)
        {


            if (GestionDate.verifIntervalle(1,10))
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

            SqlCo.Close();

        }
    }
}
