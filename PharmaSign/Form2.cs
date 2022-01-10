using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
// Appel de CAfficheur
using PharmaSign.Serial; // Espace de nom pour la liaison série
// Appel de la classe CBase et CSock ainsi que leurs compositions
using PharmaSign.MySQL;         // Espace de nom SQL
using MySql.Data.MySqlClient;   // Directive MySQL pour la base de données
using PharmaSign.TCPConnection;       // Espace de nom Socket
using System.Net.Sockets;       // Directive socket pour la connexion TCP

namespace PharmaSign
{
    public partial class Form2 : Form
    {
        // Initialisation des classes

        CBase maBase = new CBase();
        CSock maSock = new CSock();

        public Form2()
        {
            InitializeComponent();
        }
        #region Options du menu
        private void quitterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void àProposDePharmaSignToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog(); // Réalise l'affichage de la boîte 'À propos'
        }

        
        private void connecterBaseDeDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                maBase.connexion();    // Réalise la connection à la base de données

                // Activation des options suite à la connection
                déconnecterBaseDeDonnéesToolStripMenuItem.Enabled = true;
                rechargerLesDonnéesToolStripMenuItem.Enabled = true;
                textBox1.Enabled = true;
                OkBtn.Enabled = true;
                DelBtn.Enabled = true;
                connectionPasserelleToolStripMenuItem.Enabled = true;
				chargementCouleur();
                listBox4.Items.Add(" > Connection réussie");

                dataGridView1.DataSource = maBase.chargerPromos();  // Chargement des promotions 
                dataGridView1.AutoResizeColumns();                  // Adaptation automatique de la taille des colonnes en fonction du contenu
                comboBox1.Items.Add(maBase.chargerCouleur()); // Chargement des couleurs

            }
            catch (Exception ex)
            {
                // Affichage d'une fenêtre d'erreur avec les détails
                WindowDetails.Show(ex);
            }
        }
        private void déconnecterBaseDeDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                maBase.deconnexion(); // Réalise la déconnection à la base de données

                // Désactivation des options suite à la connection
                déconnecterBaseDeDonnéesToolStripMenuItem.Enabled = false;
                rechargerLesDonnéesToolStripMenuItem.Enabled = false;
                textBox1.Enabled = false;
                sendBtn.Enabled = false;
                OkBtn.Enabled = false;
                DelBtn.Enabled = false;
                comboBox1.Items.Clear();
                listBox4.Items.Add(" > Déconnection réussie");
            }
            catch (Exception ex)
            {
                // Affichage d'une fenêtre d'erreur avec les détails
                WindowDetails.Show(ex);
            }
        }
        private void siteWebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://10.129.100.210");
        }

        private void rechargerLesDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = maBase.chargerPromos();  // Chargement des promotions
            dataGridView1.AutoResizeColumns();                  // Adaptation automatique de la taille des colonnes en fonction du contenu
            listBox4.Items.Add(" > Données mises à jour");
        }

        #endregion

        // Fonction permettant la recherche d'un tuple selon ce qui est écrit dans la TextBox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT Promotions, noPromotion FROM `Promotions` Where Promotions Like '%" + textBox1.Text + "%'", maBase.cabler());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string donnees = Convert.ToString(dataGridView1.CurrentRow.Cells["Promotions"].Value);
                listBox4.Items.Add(" > Promotion choisi : " + donnees + " \r\n");
                string data = maBase.recupPromo(donnees);
            }
            catch (Exception ex)
            {
                // Affichage d'une fenêtre d'erreur avec les détails
                WindowDetails.Show(ex);
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int valeur = (int)dataGridView1.CurrentRow.Cells["noPromotion"].Value;
                maBase.supprimerPromotion(valeur);
                dataGridView1.DataSource = maBase.chargerPromos();
                listBox4.Items.Add(" > Promotion supprimée \r\n");
            }
            catch (Exception ex)
            {
                // Affichage d'une fenêtre d'erreur avec les détails
                WindowDetails.Show(ex);
            }
        }

        private void UpBtn_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                // Affichage d'une fenêtre d'erreur avec les détails
                WindowDetails.Show(ex);
            }
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
        private string comparer(string choix)
        {
            choix = Convert.ToString(comboBox1.SelectedItem);
            dataGridView2.DataSource = maBase.comparerCouleur("SELECT Couleur_Journal FROM `Couleur` WHERE `Couleur_carac_C` IN('" + choix + "')");
            string couleur = Convert.ToString(dataGridView2.CurrentRow.Cells["Couleur_Journal"].Value);
            return couleur;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string donnees = Convert.ToString(dataGridView1.CurrentRow.Cells["Promotions"].Value);
            char noPage = Convert.ToChar(textBox3.Text);
            string choix = Convert.ToString(comboBox1.SelectedItem);
            string couleur = comparer(choix);
          //  string data = Cafficheur.calculCRC(donnees, noPage, couleur);
          //  maSock.ecriture(data, 0, data.Length);
        }

        private void connectionPasserelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                maSock.demarrer();    // Réalise la connection socket
                if (maSock.estConnectee() == true)
                {
                    listBox4.Items.Add(" > Passerelle connectée \r\n");
                    déconnectionPasserelleToolStripMenuItem.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                // Affichage d'une fenêtre d'erreur avec les détails
                WindowDetails.Show(ex);
            }
        }

        private void déconnectionPasserelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                maSock.arreter();    // Supprime la connection socket
                listBox4.Items.Add(" > Passerelle déconnectée \r\n");
                connectionPasserelleToolStripMenuItem.Enabled = true;
                déconnectionPasserelleToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                // Affichage d'une fenêtre d'erreur avec les détails
                WindowDetails.Show(ex);
            }
            
        }
    }
}
