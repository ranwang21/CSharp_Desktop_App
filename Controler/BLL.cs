using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controler
{
    public static class BLL
    {
        public static List<Student> GetallStudent()
        {
            List<Student> listStu = StudentServices.GetAllStudent();
            return listStu;
        }

        public static int CountTotal()
        {
            return StudentServices.GetStudentTotal();
        }

        public static Student LoadStudent(string ID)
        {
            return StudentServices.GetCurrentStudent(ID);
        }
        public static List<Student> GetStudentByID(string ID)
        {
            return StudentServices.GetStudentByID(ID);
        }
        public static List<Student> GetStudentByF_Name(string firstName)
        {
            return StudentServices.GetStudentByFirstName(firstName);
        }
        public static List<Student> GetStudentByL_Name(string lastName)
        {
            return StudentServices.GetStudentByLastName(lastName);
        }
        public static List<Student> GetStudentByMobile(string mobile)
        {
            return StudentServices.GetStudentByMobile(mobile);
        }
        public static List<Student> GetStudentByEmail(string email)
        {
            return StudentServices.GetStudentByEmail(email);
        }
        public static int AddStudent(Student stu)
        {
            return StudentServices.AddStudent(stu);
        }
        public static int DeleteStudent(string ID)
        {
            return StudentServices.DeleteStudent(ID);
        }
        public static int UpdateStudent(Student stu)
        {
            return StudentServices.UpdateStudent(stu);
        }
        public static bool IsExistSNO(string txt)
        {
            return StudentServices.IsExistSNO(txt);
        }
        public static Connexion GetConnexions()
        {
            return ConnectionServices.GetConnexions();
        }
    }
}
