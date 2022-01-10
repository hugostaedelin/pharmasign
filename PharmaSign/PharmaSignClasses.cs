using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
// Directives SQL
using MySql.Data.MySqlClient;
// Directives séries
using System.IO;
using System.IO.Ports;
// Directives XML
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Net.Sockets;
using System.Net;
using System.Threading;

public static class WindowDetails
{
    public static void Show(Exception ex)
    {
        // Affiche une fenêtre d'erreur avec les détails de l'erreur
        var dialogTypeName = "System.Windows.Forms.PropertyGridInternal.GridErrorDlg";
        var dialogType = typeof(Form).Assembly.GetType(dialogTypeName);
        var dialog = (Form)Activator.CreateInstance(dialogType, new PropertyGrid());
        dialog.Text = "Erreur rencontrée";
        dialogType.GetProperty("Details").SetValue(dialog, ex.ToString(), null);
        dialogType.GetProperty("Message").SetValue(dialog, "Erreur rencontrée", null);
        var result = dialog.ShowDialog();
    }
}

namespace PharmaSign.MySQL
{
    public class AuthentInfos
    {
        public string serveur { get; set; }
        public string basedonnes { get; set; }
        public string utilisateur { get; set; }
        public string motdepasse { get; set; }
    }

    class CBase
    {
        #region Déclaration des attributs

        private MySqlConnection m_liaison;
        private DataTable m_table;
        private MySqlDataAdapter m_adapter;
        private XmlSerializer m_xs;
        private AuthentInfos m_infos;
        private StreamReader m_nomfichier;

        private string m_server;
        private string m_db;
        private string m_uid;
        private string m_pwd;
        private string m_path;
        private string m_query;
        private string m_data;
        private bool m_etat;

        #endregion Fin déclaration

        #region Constructeur
        public CBase()
        {
            m_xs = new XmlSerializer(typeof(AuthentInfos));

            {
                try
                {
                    using (m_nomfichier = new StreamReader("config.xml"))
                    {
                        m_infos = m_xs.Deserialize(m_nomfichier) as AuthentInfos;
                        m_server = m_infos.serveur;
                        m_db = m_infos.basedonnes;
                        m_uid = m_infos.utilisateur;
                        m_pwd = m_infos.motdepasse;
                    }
                }
                catch (Exception ex)
                {
                    WindowDetails.Show(ex);
                }
            }
            m_path = "SERVER=" + m_server + ";" + "DATABASE=" + m_db + ";" + "UID=" + m_uid + ";" + "PASSWORD=" + m_pwd + ";";
            m_liaison = new MySqlConnection(m_path);
        }
        #endregion Fin constructeur

        #region Méthodes
        public string getIP()
        {
            // Récupère IP pour affichage
            string ipBDD = Convert.ToString(m_server);
            return ipBDD;
        }
        public void connexion()
        {
            m_liaison.Open();
            m_etat = true;
        }

        public bool estConnectee()
        {
            return m_etat;
        }
        public string cabler()
        {
            return m_path;
        }
        public DataTable chargerPromos()
        {
            m_table = new DataTable();
            m_query = "SELECT Promotions, noPromotion FROM `Promotions` ORDER BY `noPromotion`";
            m_adapter = new MySqlDataAdapter(m_query, m_path);
            m_adapter.Fill(m_table);
            return m_table;
        }
        public DataTable chargerCouleur()
        {
            m_table = new DataTable();
            m_query = "SELECT Couleur_Carac_C FROM `Couleur`";
            m_adapter = new MySqlDataAdapter(m_query, m_path);
            m_adapter.Fill(m_table);
            return m_table;
        }
        public DataTable chargerCouleurParDefaut()
        {
            m_table = new DataTable();
            m_query = "SELECT Couleur_carac_C FROM Promotions ORDER BY Couleur_carac_C";
            m_adapter = new MySqlDataAdapter(m_query, m_path);
            m_adapter.Fill(m_table);
            return m_table;
        }
        public string recupPromo(string donnees)
        {
            m_data = donnees;
            return m_data;
        }
        public DataTable chargerPages()
        {
            m_table = new DataTable();
            m_query = "SELECT noPage FROM `Pages` ORDER BY `noPage`";
            m_adapter = new MySqlDataAdapter(m_query, m_path);
            m_adapter.Fill(m_table);
            return m_table;
        }
        public DataTable comparerCouleur(string rqt)
        {
            DataSet monData = new DataSet();
            m_table = new DataTable();
            m_query = rqt;
            m_adapter = new MySqlDataAdapter(m_query, m_path);
            m_adapter.Fill(m_table);
            return m_table;
        }
        public DataTable chargerScheduling()
        {
            m_table = new DataTable();
            m_query = "SELECT * FROM `Scheduling`";
            m_adapter = new MySqlDataAdapter(m_query, m_path);
            m_adapter.Fill(m_table);
            return m_table;
        }
        public DataTable realiserScheduling(int noSchedules)
        {
            m_table = new DataTable();
            m_query = "SELECT * FROM Scheduling WHERE noScheduling = " + noSchedules + ";"; ;
            m_adapter = new MySqlDataAdapter(m_query, m_path);
            m_adapter.Fill(m_table);
            return m_table;
        }
        public DataTable supprimerPromotion(int valeur)
        {
            m_table = new DataTable();
            m_query = "DELETE FROM `Promotions` WHERE  `noPromotion`='" + valeur + "'; ";
            m_adapter = new MySqlDataAdapter(m_query, m_path);
            m_adapter.Fill(m_table);
            return m_table;
        }
        public void deconnexion()
        {
            m_liaison.Close();
            m_etat = false;
        }
        #endregion Fin méthodes
    }

}

namespace PharmaSign.TCPConnection
{
    public class RaspberryInfos
    {
        public string serveur { get; set; }
        public int port { get; set; }
    }
    class CSock
    {
        #region Déclaration des attributs

            private string m_server;
            private bool m_stat;
            private int m_port;

            private TcpClient m_client;
            private XmlSerializer m_xs;
            private RaspberryInfos m_infos;
            private StreamReader m_nomfichier;
            private NetworkStream m_stream;
            private IPAddress m_adresse;
            private IPEndPoint m_point;

        #endregion Fin déclaration

        #region Constructeur

        public CSock()
        {
            m_xs = new XmlSerializer(typeof(RaspberryInfos));
            m_client = new TcpClient();
            try
            {
                using (m_nomfichier = new StreamReader("raspberry.xml"))    // Lecture du fichier de configuration
                {
                    m_infos = m_xs.Deserialize(m_nomfichier) as RaspberryInfos;
                    m_server = m_infos.serveur;                 // On récupère la valeur de l'adresse IP dans le fichier XML
                    m_port = m_infos.port;                      // On récupère la valeur du port dans le fichier XML
                }
            }
            catch (Exception ex)
            {
                WindowDetails.Show(ex);
            }
            m_adresse = IPAddress.Parse(m_server); // Méthode de conversion du type, de string à IPAddress
            m_point = new IPEndPoint(m_adresse, m_port);
        }
        #endregion Fin constructeur

        #region Méthodes
        public string getIP()
        {
            // Récupère IP pour affichage
            string ipRPI = Convert.ToString(m_server);
            return ipRPI;
        }
        public void demarrer()
        {
            // Utilise l'adresse IP et le numéro de port pour l'établissement de la connection
            try
            {
                m_client.Connect(m_point);
                m_stream = m_client.GetStream();
                
            }
            catch (Exception ex)
            {
                WindowDetails.Show(ex);
            }
            m_stat = true;
        }

        public void arreter()
        {
            try
            {
                if (m_stat == true)
                {
                    m_stream.Close();
                }
                m_stat = false;
            }
            catch (Exception ex)
            {
                WindowDetails.Show(ex);
            }
        }
        public bool estConnectee()
        {
            return m_stat;
        }
        public void ecriture(string data, int offset, int taille)
        {
            try
            {
                if (m_stat == true)
                {
                    Byte[] sendBytes = Encoding.UTF8.GetBytes(data);
                    m_stream.Write(sendBytes, 0, sendBytes.Length);
                }
            }
            catch (Exception ex)
            {
                WindowDetails.Show(ex);
            }
        }

        #endregion Fin méthodes
    }
}

namespace PharmaSign.Serial
{
    class Cafficheur
    {
        public static string calculCRC(string donnees, char noPage, string couleur)
        {
            char[] msg = new char[1000];
            string trame = "<ID00><L1><P" + noPage + "><FE><MA><WC><FE><C"+ couleur +">"+ donnees +"";
            msg = trame.ToCharArray();
            int crc = 0;
            for (int i = 6; i < msg.Length; i++)
            {
               crc = crc^msg[i];
            }
            string crc16 = crc.ToString("X");
            string ftrame = trame + crc16 + "<E>";
            return ftrame;
        }

        public static string calculCRCScheduling(string page)
        {
            char[] msg = new char[1000];
            string trame = "<ID00><TA>00010100009912302359"+page+"";
            msg = trame.ToCharArray();
            int crc = 0;
            for (int i = 6; i < msg.Length; i++)
            {
                crc = crc^msg[i];
            }
            string crc16 = crc.ToString("X");
            string ftrame = trame + crc16 + "<E>";
            return ftrame;
        }
    }
}
