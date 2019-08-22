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


        // flag to check if its add or edit operation. 1 --> add; 2 --> edit
        private int actionFlag = 0;

        public MainWindow()
        {
            this.Visibility = Visibility.Visible;

            InitializeComponent();

            // (1) -- store all student info in List<Student>
            dgStudent.Items.Clear(); // first clear former collections in the items
            dgStudent.AutoGenerateColumns = false; // forbide table to auto-genrate columns

            // call StudentServices to access data
            objListStudent = BLL.GetallStudent();

            // load student info on table
            LoadStudent(objListStudent);

            // show total students count
            lblTotal.Text = BLL.CountTotal().ToString();

            // enable buttons
            EnableButton();
        }

        private void LoadStudentDetail(string ID)
        {
            // instantialize a Student by calling the helper method
            Student objStudent = BLL.LoadStudent(ID);

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
            objListStudent = BLL.GetStudentByID(txtSearchID.Text.Trim());

            // update datagrid view
            LoadStudent(objListStudent);

        }

        // search by firstName
        private void TxtSearchFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // retrieve query data
            objListStudent = BLL.GetStudentByF_Name(txtSearchFirstName.Text.Trim());

            // update datagrid view
            LoadStudent(objListStudent);
        }

        // search by lastName
        private void TxtSearchLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // retrieve query data
            objListStudent = BLL.GetStudentByL_Name(txtSearchLastName.Text.Trim());


            // update datagrid view
            LoadStudent(objListStudent);
        }

        // search by Mobile
        private void TxtSearchMobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            // retrieve query data
            objListStudent = BLL.GetStudentByMobile(txtSearchMobile.Text.Trim());

            // update datagrid view
            LoadStudent(objListStudent);
        }

        // search by Email
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // retrieve query data
            objListStudent = BLL.GetStudentByEmail(txtSearchEmail.Text.Trim());

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
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            rbFemale.IsEnabled = false;
            rbFemale.IsEnabled = false;

        }

        // disable CRUD buttons
        public void DisableButton()
        {
            // disable
            btnAdd.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;


            // Eable
            txtDetailAddress.IsEnabled = true;
            txtDetailEmail.IsEnabled = true;
            txtDetailFirstName.IsEnabled = true;
            txtDetailID.IsEnabled = true;
            txtDetailLastName.IsEnabled = true;
            txtDetailMobile.IsEnabled = true;
            dpBirthday.IsEnabled = true;
            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            rbFemale.IsEnabled = true;
            rbFemale.IsEnabled = true;
            //stackPanelGenderDp.IsEnabled = true;

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

            // diable change to ID
            txtDetailID.IsEnabled = false;

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
                objListStudent = BLL.GetallStudent(); // refresh from server
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

            // after passing the validation, do the encapsulation (form a new student obj)
            Student objStudent = new Student
            {
                ID = Convert.ToInt32(txtDetailID.Text.Trim()),
                firstName = txtDetailFirstName.Text.Trim(),
                lastName = txtDetailLastName.Text.Trim(),
                birthday = Convert.ToDateTime(dpBirthday.Text),
                gender = rbMale.IsChecked == true ? "H" : "F",
                mobile = txtDetailMobile.Text,
                adress = txtDetailAddress.Text,
                email = txtDetailEmail.Text
            };

            switch (actionFlag)
            {
                case 1:
                    // Add a student
                    try
                    {
                        // check if success
                        if (BLL.AddStudent(objStudent) == 1)
                        {
                            // refresh data on UI
                            LoadStudent(BLL.GetallStudent());

                            // button control
                            EnableButton();

                            // re-count total student number
                            lblTotal.Text = BLL.CountTotal().ToString();

                            // notify the user
                            MessageBox.Show("Successfully added", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Adding student error: " + ex.Message, "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    break;

                case 2:
                    // Edit a student
                    try
                    {
                        // check if success
                        if (BLL.UpdateStudent(objStudent) == 1)
                        {
                            // refresh data on UI
                            LoadStudent(BLL.GetallStudent());

                            // button control
                            EnableButton();
                            txtDetailID.IsEnabled = true;

                            // notify the user
                            MessageBox.Show("Successfully updated!", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Updating student failed: " + ex.Message, "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    break;
            }
        }

        // data validation
        private bool CheckInput()
        {
            // check if student id is an int
            int value;
            if (!int.TryParse(txtDetailID.Text.Trim().ToString(), out value)) // credit to: https://stackoverflow.com/questions/1752499/c-sharp-testing-to-see-if-a-string-is-an-integer
            {
                MessageBox.Show("Student ID should be Integer!", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            // check student id is not empty
            if (string.IsNullOrWhiteSpace(txtDetailID.Text))
            {
                MessageBox.Show("Student ID cannot be empty!", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            // check if student id is repetitive (only when adding a student)
            if (actionFlag == 1)
            {
                if (BLL.IsExistSNO(txtDetailID.Text.Trim()))
                {
                    MessageBox.Show("Student ID already exists!", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
            }

            // check if first name is empty
            if (string.IsNullOrWhiteSpace(txtDetailFirstName.Text))
            {
                MessageBox.Show("First Name cannot be empty!", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            // check if last name is empty
            if (string.IsNullOrWhiteSpace(txtDetailLastName.Text))
            {
                MessageBox.Show("Last Name cannot be empty!", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
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

        // Delete a student
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // downcase the current selected student (line in the table) to Student
            Student selectedStu = (Student)dgStudent.SelectedItem;

            // a line in table must be selected
            if (dgStudent.SelectedItem == null)
            {
                // notify user
                MessageBox.Show("You haven't selected a student", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // prepare the notification info before deleting
            string info = "Are you sure to delete student [" + selectedStu.ID + " - " + selectedStu.firstName + " " + selectedStu.lastName + "]?";

            // show a interactive dialog for user
            MessageBoxResult result = MessageBox.Show(info, "System Information", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // execute delete operation according to user's choice
            if (result == MessageBoxResult.Yes)
            {
                // execute delete
                try
                {
                    // check if success
                    if (BLL.DeleteStudent(selectedStu.ID.ToString()) == 1)
                    {
                        // refresh info
                        LoadStudent(BLL.GetallStudent());

                        // refresh count
                        lblTotal.Text = BLL.CountTotal().ToString();

                        // notify user
                        MessageBox.Show("Deletion successful!", "System Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Deletion failed!" + ex.Message, "System Information", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            else
            {
                return;
            }
        }

        // close program
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // disconnect
        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {

            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
