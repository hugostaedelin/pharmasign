using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Appel de CAfficheur
using PharmaSign.Serial; // Espace de nom pour la liaison série
// Appel de la classe CBase et CSock ainsi que leurs compositions
using PharmaSign.MySQL;         // Espace de nom SQL
using MySql.Data.MySqlClient;   // Directive MySQL pour la base de données
using PharmaSign.TCPConnection;       // Espace de nom Socket
using System.Net.Sockets;       // Directive socket pour la connexion TCP
using System.Threading;

namespace PharmaSign
{
    public partial class UC1DB : UserControl
    {
        // Initialisation de la classe SQL
        CBase maBase = new CBase();
        CSock maSock = new CSock();
        public UC1DB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maSock.demarrer();
            maBase.connexion();
            dataGridView1.DataSource = maBase.chargerPromos(); // Chargement des promotions ici
            dataGridView1.AutoResizeColumns(); // On réadapte la forme du tableau selon la longueur des promotions
            chargementPage();
            comboBox1.Items.Add(maBase.chargerPages()); 
            progressBar1.Value = 1; // Signifie visuellement à l'utilisateur que la connexion est réussie
            button2.Enabled = true; // Permet la déconnexion de la base de données
            button1.Enabled = false;// Empêche de redemander une connexion à la base de données
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Fonction de selection des promotions pour une accessibilité plus agréable pour l'utilisateur final
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT Promotions, noPromotion FROM `Promotions` Where Promotions Like '%" + textBox1.Text + "%'", maBase.cabler());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maSock.arreter();
            maBase.deconnexion();
            comboBox1.Items.Clear();
            progressBar1.Value = 0; // Signifie visuellement à l'utilisateur que la déconnexion est réussie
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            button2.Enabled = false; // Empêche de redemander une déconnexion
            button1.Enabled = true;  // Permet la reconnexion à la base de données
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }
        private void chargementPage()
        {
            // Fonction complémentaire en plus de la fonction chargerPage de CBase
            DataSet m_data = new DataSet();
            string m_query = "SELECT noPage FROM `Pages` ORDER BY `noPage`";
            MySqlDataAdapter m_adapter = new MySqlDataAdapter(m_query, maBase.cabler());
            m_adapter.Fill(m_data, "Pages");
            for (int i = 0; i < m_data.Tables["Pages"].Rows.Count; i++)
            {
                comboBox1.Items.Add(m_data.Tables["Pages"].Rows[i][0]);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int valeur = (int)dataGridView1.CurrentRow.Cells["noPromotion"].Value;
                maBase.supprimerPromotion(valeur);
                dataGridView1.DataSource = maBase.chargerPromos();
            }
            catch (Exception ex)
            {
                // Affichage d'une fenêtre d'erreur avec les détails
                WindowDetails.Show(ex);
            }
        }
        private string comparer()
        {
            dataGridView2.DataSource = maBase.comparerCouleur("SELECT Couleur_Journal FROM `Couleur` WHERE `Couleur_carac_C` IN('vert')");
            string couleur = Convert.ToString(dataGridView2.CurrentRow.Cells["Couleur_Journal"].Value);
            return couleur;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string promotion = (string)dataGridView1.CurrentRow.Cells["Promotions"].Value;
            string couleur = comparer();
            char noPage = Convert.ToChar(comboBox1.SelectedItem);
            string data = Cafficheur.calculCRC(promotion, noPage, couleur);
            maSock.ecriture(data, 0, data.Length);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            // Ouvre une fenêtre pour planifier l'affichage des pages
            //AboutBox2 scheduling = new AboutBox2();
            //scheduling.Show();
            panel1.BringToFront();
            dataGridView3.DataSource = maBase.chargerScheduling();
            dataGridView3.AutoResizeColumns();
            dataGridView3.AutoResizeRows();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (maSock.estConnectee() == true)
            {
                try
                {
                    // Récupération du numéro du scheduling utilisé
                    int valeur = (int)dataGridView3.CurrentRow.Cells["noScheduling"].Value;
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
            panel1.SendToBack();
        }
    }
}
