using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controler
{
    public static class Validate
    {
        public static void ValidateLogin(string username, string password)
        {

        }

        // check if its a valid email
        public static bool ValidateEmail(string email)
        {
            // credit to: https://stackoverflow.com/questions/5342375/regex-email-validation
            Regex objRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return objRegex.IsMatch(email);
        }

        // check if its a valid mobile number
        public static bool ValidateMobile(string mobile)
        {
            // credit to: http://www.harshbaid.in/2013/08/03/regular-expression-for-us-and-canada-phone-number/
            // The supported formats are 1234567890, 123-456-7890, 123.456.7890,  123 456 7890, (123) 456 7890
            Regex objRegex = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"); 
            return objRegex.IsMatch(mobile);
        }
    }
}
