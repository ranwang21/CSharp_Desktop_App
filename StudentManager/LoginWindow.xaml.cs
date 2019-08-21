using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model;
using DAL;
using System.Data;
using Controler;
using System.Data.SqlClient;
using System.Configuration;
using DBUtility;

namespace StudentManager
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>


    public partial class LoginWindow : Window
    {
    
        private Connexion ObjListConnexion = new Connexion();
        private ConnectionServices objConnectionServices = new ConnectionServices();
        public LoginWindow()
        {
            InitializeComponent();

            ObjListConnexion = objConnectionServices.GetConnexions();

            


            

            


        }

        private void BouttonDeConnexion_Click(object sender, RoutedEventArgs e)
        {
            SqlDataReader objReader = SqlHelper.connexionLogin();

            Connexion conn = ConnectionServices.GetConnexions();
            //MessageBox.Show("Clicked");

            if (BoxUsername.ToString() == conn.Username && BoxPassword.ToString() == conn.MotDePasse)
            {
                
                this.Visibility = Visibility.Hidden;
            }

            

        }
    }
}
