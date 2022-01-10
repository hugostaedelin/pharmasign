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
using System.Xml;
using System.Diagnostics;

namespace PharmaSign
{
    public partial class UC2CONF : UserControl
    {
        CBase maBase = new CBase();
        CSock maSock = new CSock();
        public UC2CONF()
        {
            InitializeComponent();
            string ipBDD = maBase.getIP();
            string ipRPI = maSock.getIP();
            ValeurIPBDD.Text = ipBDD;
            ValeurIPRPI.Text = ipRPI;
        }

        private void UC2CONF_Load(object sender, EventArgs e)
        {

        }

        private void ModifierValeurIpBDD_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                string file = "config.xml";
                xmlDoc.Load(file);
                xmlDoc.SelectSingleNode("/AuthentInfos/serveur").InnerText = "" + ValeurIPBDD.Text + "";
                xmlDoc.Save(file);
            }
            catch (Exception ex)
            {
                WindowDetails.Show(ex);
            }
        }

        private void ModifierValeurIpRPI_Click(object sender, EventArgs e)
        {
            try
            { 
            XmlDocument xmlDoc = new XmlDocument();
            string file = "raspberry.xml";
            xmlDoc.Load(file);
            xmlDoc.SelectSingleNode("/RaspberryInfos/serveur").InnerText = "" + ValeurIPRPI.Text + "";
            xmlDoc.Save(file);
            }
            catch (Exception ex)
            {
                WindowDetails.Show(ex);
            }
}

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Program Files (x86)\\Interface\\PharmaSign");
        }
    }
}
