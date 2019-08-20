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
using Controler;

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

        // flag to check if its add or edit operation. 1 --> add; 2 --> edit
        private int actionFlag = 0;

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

            // enable buttons
            EnableButton();
        }

        private void LoadStudentDetail(string ID)
        {
            // instantialize a Student by calling the helper method
            Student objStudent = objStudentServices.GetCurrentStudent(ID);

            // show details
            txtDetailID.Text = objStudent.ID.ToString();
            txtDetailEmail.Text = objStudent.email.ToString();
            txtDetailAddress.Text = objStudent.adress.ToString();
            txtDetailFirstName.Text = objStudent.firstName.ToString();
            txtDetailLastName.Text = objStudent.lastName.ToString();
            dpBirthday.Text = objStudent.birthday.ToString("MM-dd-yyyy");
            txtDetailMobile.Text = objStudent.mobile.ToString();
            if (objStudent.gender.ToString().Trim() == "H")
            {
                rbMale.IsChecked = true;
            }
            else
            {
                rbFemale.IsChecked = true;
            }

        }

        private void DgStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgStudent.Items.Count == 0)
            {
                return;
            }
            else
            {
                // downcase the current selected student (line in the table) to Student
                Student selectedStu = (Student)dgStudent.SelectedItem;

                // obtain the ID of the current student
                string ID = selectedStu.ID.ToString();

                // call the load detail method with the ID
                LoadStudentDetail(ID);
                
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

        // load student list into DataGrid
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
                dgStudent.ItemsSource = objList;

                // show current student detail information (default the first row) 
                dgStudent.SelectedIndex = 0;

            }
        }

        // enable CRUD buttons
        private void EnableButton()
        {
            // Enable
            btnAdd.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;

            // disable
            txtDetailAddress.IsEnabled = false;
            txtDetailEmail.IsEnabled = false;
            txtDetailFirstName.IsEnabled = false;
            txtDetailID.IsEnabled = false;
            txtDetailLastName.IsEnabled = false;
            txtDetailMobile.IsEnabled = false;
            dpBirthday.IsEnabled = false;

        }

        // disable CRUD buttons
        public void DisableButton()
        {
            // disable
            btnAdd.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;

            // enable
            txtDetailAddress.IsEnabled = true;
            txtDetailEmail.IsEnabled = true;
            txtDetailFirstName.IsEnabled = true;
            txtDetailID.IsEnabled = true;
            txtDetailLastName.IsEnabled = true;
            txtDetailMobile.IsEnabled = true;
            dpBirthday.IsEnabled = true;

        }

        // add a student (preparation for adding)
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // disable all CRUD buttons
            DisableButton();

            // vide the detail input fields
            txtDetailAddress.Text = string.Empty;
            txtDetailEmail.Text = string.Empty;
            txtDetailFirstName.Text = string.Empty;
            txtDetailID.Text = string.Empty;
            txtDetailLastName.Text = string.Empty;
            txtDetailMobile.Text = string.Empty;
            rbMale.IsChecked = true; // default as male

            // focus on student ID input
            txtDetailID.Focus();

            // change action flag
            actionFlag = 1;
        }

        // edit a student info
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // disable all CRUD buttons
            DisableButton();

            // change action flag
            actionFlag = 2;
        }

        // cancel button
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            // enable buttons
            EnableButton();

            // reload the table
            if (actionFlag == 1)
            {
                objListStudent = objStudentServices.GetAllStudent(); // refresh from server
                LoadStudent(objListStudent); 
            }
        }

        // submit button
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // validation of the entries
            if (!CheckInput())
            {
                return;
            } 

            switch (actionFlag)
            {
                case 1: 
                    // Add

                    break;
                case 2:
                    // Edit

                    break;
            }
        }

        // data validation
        private bool CheckInput()
        {
            // check student id is not empty
            if (string.IsNullOrWhiteSpace(txtDetailID.Text))
            {
                MessageBox.Show("Student ID cannot be empty!", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            // check if student id is repetitive (only when adding a student)
            if (actionFlag == 1)
            {
                if (objStudentServices.IsExistSNO(txtDetailID.Text.Trim()))
                {
                    MessageBox.Show("Student ID already exists!", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
            }

            // check if student id is an int
            if (!txtDetailID.ToString().All(char.IsDigit)) // credit to: https://stackoverflow.com/questions/1752499/c-sharp-testing-to-see-if-a-string-is-an-integer
            {
                MessageBox.Show("Student ID should be Integer!", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            // check if email is valid
            if (!Validate.ValidateEmail(txtDetailEmail.Text.Trim()))
            {
                MessageBox.Show("Invalid Email!", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            // check if mobile number is valid
            if (!Validate.ValidateMobile(txtDetailMobile.Text.Trim()))
            {
                MessageBox.Show("Invalid mobile number!", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }
    }
}
