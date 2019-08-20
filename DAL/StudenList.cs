using DBUtility;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class StudentList
    {


        public static List<Student> getListStu()
        {
            List<Student> stuList = new List<Student>();
            string sql = "SELECT * FROM Student";

            try
            {
                SqlDataReader reader = SqlHelper.GetReader(sql);
                if (!reader.HasRows)
                {
                    stuList = null;
                }
                else
                {
                    while (reader.Read())
                    {
                        stuList.Add(
                         new Student
                         {
                             ID = Convert.ToInt32(reader["Id_Student"]),
                             gender = reader["Gender"].ToString(),
                             firstName = reader["FirstName"].ToString(),
                             lastName = reader["LastName"].ToString(),
                             birthday = Convert.ToDateTime(reader["Birthday"]),
                             address = reader["Adress"].ToString(),
                             mobile = reader["Phone"].ToString(),
                             email = reader["Email"].ToString(),
                         }
                         );

                    }
                    reader.Close();
                }
                return stuList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
