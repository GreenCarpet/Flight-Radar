using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ASTERIX
{
    public partial class Connect : Form
    {
        bool UserClose = true;

        public static string ServerName;
        public static string UserName;
        public static string Password;

        /// <summary>
        /// Загружает настройки подключения к серверу.
        /// </summary>
        void GetConnect()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Settings.xml");

            ServerName = doc.GetElementsByTagName("ServerName")[0].FirstChild.Value;
            UserName = doc.GetElementsByTagName("Name")[0].FirstChild.Value;
            Password = doc.GetElementsByTagName("Password")[0].FirstChild.Value;

            ServerNameTextBox.TextField = ServerName;
            NameTextBox.TextField = UserName;
            PasswordTextBox.TextField = Password;
        }
        /// <summary>
        /// Выгружает настройки подключения к серверу.
        /// </summary>
        void SetConnect()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Settings.xml");

            doc.GetElementsByTagName("ServerName")[0].FirstChild.Value = ServerNameTextBox.TextField;
            doc.GetElementsByTagName("Name")[0].FirstChild.Value = NameTextBox.TextField;
            doc.GetElementsByTagName("Password")[0].FirstChild.Value = PasswordTextBox.TextField;

            doc.Save("Settings.xml");
        }

        /// <summary>
        /// Подключает к серверу.
        /// </summary>
        /// <returns></returns>
        public bool Connecting()
        {
            GetConnect();

            SQL.Server = ServerName;
            SQL.User = UserName;
            SQL.Password = Password;

            if (SQL.Connect())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Connect()
        {
            InitializeComponent();
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            UserClose = false;
            SetConnect();
            Close();
        }

        private void Connect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UserClose)
            {
                Environment.Exit(0);
            }
        }
    }
}
