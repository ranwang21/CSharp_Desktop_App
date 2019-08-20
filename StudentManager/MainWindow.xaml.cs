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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using DAL;
using System.Data;

namespace StudentManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Student> objListStudent = new List<Student>(); // a list to store all student info from Database
        private List<Student> objListQuery = new List<Student>(); // store the result of a search query
        private StudentServices objStudentServices = new StudentServices(); // instantialize the service in DAL to handle student info access

        public MainWindow()
        {
            InitializeComponent();

            // (1) -- store all student info in List<Student>
            dgStudent.Items.Clear(); // first clear former collections in the items
            dgStudent.AutoGenerateColumns = false; // forbide table to auto-genrate columns

            // call StudentServices to access data
            objListStudent = objStudentServices.GetAllStudent();

            // load student info on table
            LoadStudent(objListStudent);

            // show total students count
            lblTotal.Text = objStudentServices.GetStudentTotal().ToString();
        }

        private void LoadStudentDetail(string ID)
        {
            // test
            string text = string.Format("The string is: {0}", ID);
            //MessageBox.Show(text);


            // instantialize a Student by calling the helper method
            //Student objStudent = objStudentServices.GetCurrentStudent(ID);

            // show details
            //txtDetailID.Text = objStudent.ID.ToString();
            //txtDetailFirstName.Text = objStudent.firstName.ToString();
            //txtDetailLastName.Text = objStudent.lastName.ToString();
            //dpBirthday.Text = objStudent.birthday.ToString("MM-dd-yyyy");
            //txtDetailMobile.Text = objStudent.mobile.ToString();
            //if (objStudent.gender == "H")
            //{
            //    rbMale.IsChecked = true;
            //}
            //else
            //{
            //    rbFemale.IsChecked = true;
            //}

        }

        private void DgStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgStudent.Items.Count == 0)
            {
                return;
            }
            else
            {
                Array result = dgStudent.SelectedCells.ToArray();
                string str = result.GetValue(0).ToString();
                LoadStudentDetail(str);
            }
        }

        // search by ID
        private void TxtSearchID_TextChanged(object sender, TextChangedEventArgs e)
        {
            // retrieve query data
            objListStudent = objStudentServices.GetStudentByID(txtSearchID.Text.Trim());

            // update datagrid view
            LoadStudent(objListStudent);

        }

        // search by firstName
        private void TxtSearchFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // retrieve query data
            objListStudent = objStudentServices.GetStudentByFirstName(txtSearchFirstName.Text.Trim());

            // update datagrid view
            LoadStudent(objListStudent);
        }

        // search by lastName
        private void TxtSearchLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // retrieve query data
            objListStudent = objStudentServices.GetStudentByLastName(txtSearchLastName.Text.Trim());

            // update datagrid view
            LoadStudent(objListStudent);
        }

        // search by Mobile
        private void TxtSearchMobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            // retrieve query data
            objListStudent = objStudentServices.GetStudentByMobile(txtSearchMobile.Text.Trim());

            // update datagrid view
            LoadStudent(objListStudent);
        }

        // search by Email
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // retrieve query data
            objListStudent = objStudentServices.GetStudentByEmail(txtSearchEmail.Text.Trim());

            // update datagrid view
            LoadStudent(objListStudent);
        }

        //
        private void LoadStudent(List<Student> objList)
        {

            if (objList == null)
            {
                // if no data retrieved, prompt a messagebox to inform user
                MessageBox.Show("There is no Student data!", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                // add all students into the table
                dgStudent.ItemsSource = null;
                dgStudent.ItemsSource = objList;z

                // show current student detail information (default the first row) 
                dgStudent.SelectedIndex = 0;

            }
        }


        // when a row is selected by user, load detail of that student into detail window

    }
}
