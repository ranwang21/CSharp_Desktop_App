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
        private bool loginCheck; // check if login success

        public LoginWindow()
        {
            InitializeComponent();
            this.Visibility = Visibility.Visible;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }

        private void BouttonDeConnexion_Click(object sender, RoutedEventArgs e)
        {
            // instantiate a new connection to store user input
            Connexion connUser = new Connexion();
            connUser.Username = BoxUsername.Text.ToString();
            connUser.MotDePasse = BoxPassword.Password.ToString();

            // acquire correct username and password from server
            List<Connexion> connListServer = BLL.GetConnexions();

            foreach (Connexion conn in connListServer)
            {
                if (connUser.Username.ToString() == conn.Username.ToString() && connUser.MotDePasse.ToString() == conn.MotDePasse.ToString())
                {
                    loginCheck = true;
                    break;
                }
            }

            if (loginCheck == true)
            {
                this.Visibility = Visibility.Hidden;
                // stock user who logins in
                BLL.Login(connUser.Username.ToString());

                // make appear main window
                MainWindow window = new MainWindow();
            }
            else
            {
                MessageBox.Show("Login failed, please check your input");
            }

        }
    }
}
