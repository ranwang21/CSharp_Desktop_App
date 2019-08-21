using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controler
{
    class BLL
    {
        private StudentServices objStudentServices = new StudentServices();

        public List<Student> GetallStudent()
        {
            List<Student> listStu = objStudentServices.GetAllStudent();
            return listStu;
        }

        public int CountTotal()
        {
            return objStudentServices.GetStudentTotal();
        }

        public Student LoadStudent(string ID)
        {
            return objStudentServices.GetCurrentStudent(ID);
        }
        public List<Student> GetStudentByID(string ID)
        {
            return objStudentServices.GetStudentByID(ID);
        }
        public List<Student> GetStudentByF_Name(string firstName)
        {
            return objStudentServices.GetStudentByFirstName(firstName);
        }
        public List<Student> GetStudentByL_Name(string lastName)
        {
            return objStudentServices.GetStudentByLastName(lastName);
        }
        public List<Student> GetStudentByMobile(string mobile)
        {
            return objStudentServices.GetStudentByMobile(mobile);
        }
        public List<Student> GetStudentByEmail(string email)
        {
            return objStudentServices.GetStudentByEmail(email);
        }

    }
}
