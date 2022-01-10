using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PharmaSign.MySQL;
using PharmaSign.Serial;
using PharmaSign.TCPConnection;

namespace PharmaSign
{
    partial class AboutBox2 : Form
    {
        CBase maBase = new CBase();
        CSock maSock = new CSock();

        public AboutBox2()
        {
            InitializeComponent();
            // Chargement des scheduling et adaptation de la taille du GridView
            dataGridView1.DataSource = maBase.chargerScheduling();
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
            // Chargement des couleurs
            chargementCouleur();
            comboBox1.Items.Add(maBase.chargerCouleur());
        }

        private void chargementCouleur()
        {
            DataSet m_data = new DataSet();
            string m_query = "SELECT Couleur_carac_C FROM `Couleur`";
            MySqlDataAdapter m_adapter = new MySqlDataAdapter(m_query, maBase.cabler());
            m_adapter.Fill(m_data, "Couleur");
            for (int i = 0; i < m_data.Tables["Couleur"].Rows.Count; i++)
            {
                comboBox1.Items.Add(m_data.Tables["Couleur"].Rows[i][0]);
            }
        }

        private string comparer()
        {
            dataGridView3.DataSource = maBase.comparerCouleur("SELECT Couleur_Journal FROM `Couleur`");
            string couleur = Convert.ToString(dataGridView3.CurrentRow.Cells["Couleur_Journal"].Value);
            return couleur;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //comboBox1.SelectedItem == null
            if (maSock.estConnectee() == true)
            {
                try
                {
                    // Récupération du numéro du scheduling utilisé
                    int valeur = (int)dataGridView1.CurrentRow.Cells["noScheduling"].Value;
                    dataGridView2.DataSource = maBase.realiserScheduling(valeur);

                    // Récupération de la page du scheduling, ex : ABCD
                    string page = (string)dataGridView2.CurrentRow.Cells["Page"].Value;
                    //string couleur = comparer();
                    //string delai = textBox1.Text;
                    // Calcul du CRC et écriture des données sur le port 1471
                    string data = Cafficheur.calculCRCScheduling(page);
                    maSock.ecriture(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    // Affichage d'une fenêtre d'erreur avec les détails
                    WindowDetails.Show(ex);
                }
            }
            else MessageBox.Show("Pas de connexion", "Erreur");
            this.Hide();
        }
        private void AboutBox2_Load(object sender, EventArgs e)
        {
        }
    }
}
