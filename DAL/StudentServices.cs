using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using DBUtility;

namespace DAL
{
    /// <summary>
    /// To access student info
    /// </summary>
    public class StudentServices
    {
        // show all student info in the table
        public List<Student> GetAllStudent()
        {
            // instantialize the list of student to return
            List<Student> objList = new List<Student>();
            // prepare the sql code to call the GetReader method
            string sql = "SELECT Id_Student, Gender, FirstName, LastName, Birthday, Adress, Phone, Email FROM Student";
            // call the GetReader method (of DBHelper) with the sql above as parameter
            try
            {
                SqlDataReader objReader = SqlHelper.GetReader(sql);
                // if no data retrieved, return null
                if (!objReader.HasRows)
                {
                    return null;
                }
                else
                {
                    // while there reads a line, add a student (according to the line info) to the list
                    while (objReader.Read())
                    {
                        objList.Add(
                            new Student
                            {
                                    ID = Convert.ToInt32(objReader["Id_Student"]),
                                    gender = objReader["Gender"].ToString(),
                                    firstName = objReader["FirstName"].ToString(),
                                    lastName = objReader["LastName"].ToString(),
                                    birthday = Convert.ToDateTime(objReader["Birthday"]),
                                    adress = objReader["Adress"].ToString(),
                                    mobile = objReader["Phone"].ToString(),
                                    email = objReader["Email"].ToString()
                            }
                            );
                    }
                    objReader.Close();  // close objReader, connection to server is closed as well
                    return objList;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // get current student info
        public Student GetCurrentStudent(string ID)
        {

            // prepare the sql code to call the GetReader method
            string sql = "SELECT Id_Student, Gender, FirstName, LastName, Birthday, Adress, Phone, Email FROM Student WHERE Id_Student={0}";
            sql = string.Format(sql, ID);
            // call the GetReader method (of DBHelper) with the sql above as parameter
            try
            {
                SqlDataReader objReader = SqlHelper.GetReader(sql);
                // if no data retrieved, return null
                if (!objReader.HasRows)
                {
                    return null;
                }
                else
                {
                    // instantialize a new student
                    Student objStudent = new Student();
                    // while there reads a line, add a student (according to the line info) to the list
                    if (objReader.Read())
                    {

                        objStudent = new Student
                        {
                            ID = Convert.ToInt32(objReader["Id_Student"]),
                            gender = objReader["Gender"].ToString(),
                            firstName = objReader["FirstName"].ToString(),
                            lastName = objReader["LastName"].ToString(),
                            birthday = Convert.ToDateTime(objReader["Birthday"]),
                            adress = objReader["adress"].ToString(),
                            mobile = objReader["Phone"].ToString(),
                            email = objReader["Email"].ToString()
                        };

                    }
                    objReader.Close();  // close objReader, connection to server is closed as well
                    return objStudent;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // get total student count
        public int GetStudentTotal()
        {
            string sql = "SELECT COUNT(*) FROM student";

            try
            {
                return Convert.ToInt32(SqlHelper.GetOneResult(sql));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // get student(s) by ID
        public List<Student> GetStudentByID(string ID)
        {
            // prepare the sql code to call the GetReader method
            string sql = "SELECT Id_Student, Gender, FirstName, LastName, Birthday, Adress, Phone, Email FROM Student";
            sql += " WHERE Id_Student LIKE '{0}%'";
            sql = string.Format(sql, ID);
            // call the GetReader method (of DBHelper) with the sql above as parameter
            try
            {
                SqlDataReader objReader = SqlHelper.GetReader(sql);
                // if no data retrieved, return null
                if (!objReader.HasRows)
                {
                    return null;
                }
                else
                {
                    List<Student> objList = new List<Student>();

                    // read data
                    while (objReader.Read())
                    {
                        objList.Add(
                                new Student
                                {
                                    ID = Convert.ToInt32(objReader["Id_Student"]),
                                    gender = objReader["Gender"].ToString(),
                                    firstName = objReader["FirstName"].ToString(),
                                    lastName = objReader["LastName"].ToString(),
                                    birthday = Convert.ToDateTime(objReader["Birthday"]),
                                    adress = objReader["adress"].ToString(),
                                    mobile = objReader["Phone"].ToString(),
                                    email = objReader["Email"].ToString()
                                }
                            );
                    }
                    objReader.Close();
                    return objList;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // get student(s) by firstName
        public List<Student> GetStudentByFirstName(string firstName)
        {
            // prepare the sql code to call the GetReader method
            string sql = "SELECT Id_Student, Gender, FirstName, LastName, Birthday, Adress, Phone, Email FROM Student";
            sql += " WHERE FirstName LIKE '{0}%'";
            sql = string.Format(sql, firstName);
            // call the GetReader method (of DBHelper) with the sql above as parameter
            try
            {
                SqlDataReader objReader = SqlHelper.GetReader(sql);
                // if no data retrieved, return null
                if (!objReader.HasRows)
                {
                    return null;
                }
                else
                {
                    List<Student> objList = new List<Student>();

                    // read data
                    while (objReader.Read())
                    {
                        objList.Add(
                                new Student
                                {
                                    ID = Convert.ToInt32(objReader["Id_Student"]),
                                    gender = objReader["Gender"].ToString(),
                                    firstName = objReader["FirstName"].ToString(),
                                    lastName = objReader["LastName"].ToString(),
                                    birthday = Convert.ToDateTime(objReader["Birthday"]),
                                    adress = objReader["adress"].ToString(),
                                    mobile = objReader["Phone"].ToString(),
                                    email = objReader["Email"].ToString()
                                }
                            );
                    }
                    objReader.Close();
                    return objList;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // get student(s) by lastName
        public List<Student> GetStudentByLastName(string lastName)
        {
            // prepare the sql code to call the GetReader method
            string sql = "SELECT Id_Student, Gender, FirstName, LastName, Birthday, Adress, Phone, Email FROM Student";
            sql += " WHERE LastName LIKE '{0}%'";
            sql = string.Format(sql, lastName);
            // call the GetReader method (of DBHelper) with the sql above as parameter
            try
            {
                SqlDataReader objReader = SqlHelper.GetReader(sql);
                // if no data retrieved, return null
                if (!objReader.HasRows)
                {
                    return null;
                }
                else
                {
                    List<Student> objList = new List<Student>();

                    // read data
                    while (objReader.Read())
                    {
                        objList.Add(
                                new Student
                                {
                                    ID = Convert.ToInt32(objReader["Id_Student"]),
                                    gender = objReader["Gender"].ToString(),
                                    firstName = objReader["FirstName"].ToString(),
                                    lastName = objReader["LastName"].ToString(),
                                    birthday = Convert.ToDateTime(objReader["Birthday"]),
                                    adress = objReader["adress"].ToString(),
                                    mobile = objReader["Phone"].ToString(),
                                    email = objReader["Email"].ToString()
                                }
                            );
                    }
                    objReader.Close();
                    return objList;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // get student(s) by lastName
        public List<Student> GetStudentByMobile(string mobile)
        {
            // prepare the sql code to call the GetReader method
            string sql = "SELECT Id_Student, Gender, FirstName, LastName, Birthday, Adress, Phone, Email FROM Student";
            sql += " WHERE Phone LIKE '{0}%'";
            sql = string.Format(sql, mobile);
            // call the GetReader method (of DBHelper) with the sql above as parameter
            try
            {
                SqlDataReader objReader = SqlHelper.GetReader(sql);
                // if no data retrieved, return null
                if (!objReader.HasRows)
                {
                    return null;
                }
                else
                {
                    List<Student> objList = new List<Student>();

                    // read data
                    while (objReader.Read())
                    {
                        objList.Add(
                                new Student
                                {
                                    ID = Convert.ToInt32(objReader["Id_Student"]),
                                    gender = objReader["Gender"].ToString(),
                                    firstName = objReader["FirstName"].ToString(),
                                    lastName = objReader["LastName"].ToString(),
                                    birthday = Convert.ToDateTime(objReader["Birthday"]),
                                    adress = objReader["adress"].ToString(),
                                    mobile = objReader["Phone"].ToString(),
                                    email = objReader["Email"].ToString()
                                }
                            );
                    }
                    objReader.Close();
                    return objList;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // get student(s) by lastName
        public List<Student> GetStudentByEmail(string mobile)
        {
            // prepare the sql code to call the GetReader method
            string sql = "SELECT Id_Student, Gender, FirstName, LastName, Birthday, Adress, Phone, Email FROM Student";
            sql += " WHERE Email LIKE '{0}%'";
            sql = string.Format(sql, mobile);
            // call the GetReader method (of DBHelper) with the sql above as parameter
            try
            {
                SqlDataReader objReader = SqlHelper.GetReader(sql);
                // if no data retrieved, return null
                if (!objReader.HasRows)
                {
                    return null;
                }
                else
                {
                    List<Student> objList = new List<Student>();

                    // read data
                    while (objReader.Read())
                    {
                        objList.Add(
                                new Student
                                {
                                    ID = Convert.ToInt32(objReader["Id_Student"]),
                                    gender = objReader["Gender"].ToString(),
                                    firstName = objReader["FirstName"].ToString(),
                                    lastName = objReader["LastName"].ToString(),
                                    birthday = Convert.ToDateTime(objReader["Birthday"]),
                                    adress = objReader["adress"].ToString(),
                                    mobile = objReader["Phone"].ToString(),
                                    email = objReader["Email"].ToString()
                                }
                            );
                    }
                    objReader.Close();
                    return objList;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // check if a student id already exists
        public bool IsExistSNO(string ID)
        {
            string sql = "SELECT FirstName FROM STUDENT WHERE Id_Student={0}";
            sql = string.Format(sql, ID);

            try
            {
                SqlDataReader objReader = SqlHelper.GetReader(sql);

                // if the returned reader has data, then id already exists, return false, else return true
                if (!objReader.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
