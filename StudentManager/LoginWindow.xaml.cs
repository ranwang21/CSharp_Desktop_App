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
using System.Data;
using Controler;


namespace StudentManager
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BouttonDeConnexion_Click(object sender, RoutedEventArgs e)
        {
            // instantiate a new connection to store user input
            Connexion connUser = new Connexion();
            connUser.Username = BoxUsername.Text.ToString();
            connUser.MotDePasse = BoxPassword.Password.ToString();

            // acquire correct username and password from server
            Connexion connServer = BLL.GetConnexions();

            if (connUser.Username.ToString() == connServer.Username.ToString() && connUser.MotDePasse.ToString() == connServer.MotDePasse.ToString())
            {
                this.Visibility = Visibility.Hidden;
                MainWindow window = new MainWindow();
            }
            else
            {
                MessageBox.Show("Login failed, please check your input");
            }
        }
    }
}
