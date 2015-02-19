using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            # region Ask the user to enter date of birth
            // *****************************************
            Console.Write("Enter your birth date (After 1900) [YYYYMMDD]:");
            string BirthDate = Console.ReadLine();
            #endregion 

            #region Validate user entry with regular expression
            //****************************************************
            Regex BirthDateExp = new Regex(@"[12][90]\d{2}[10][012][0123]\d");
            while (!BirthDateExp.IsMatch(BirthDate))
            {
                Console.Write("Wrong, Enter your birth date again (After 1900) [YYYYMMDD]:");
                BirthDate = Console.ReadLine();
            }
            #endregion

            #region Store user entry into seperate int values. Initiate a Datetime value with stored int values.
            //**********************************************
            // Datetime only accept int as arguement for initiation
            int BirthYear = Convert.ToInt32(BirthDate.Substring(0, 4));
            int BirthMonth = Convert.ToInt32(BirthDate.Substring(4, 2));
            int BirthDay = Convert.ToInt32(BirthDate.Substring(6, 2));
            DateTime UserBirthDate = new DateTime(BirthYear, BirthMonth, BirthDay);
            #endregion

            #region Subtract UserBirthDate from current date. Divide the total days passed by 365.2425 to get years passed.
            //*************************************************************************************************************
            int UserAge = Convert.ToInt32(DateTime.Now.Subtract(UserBirthDate).TotalDays / 365.2425);
            #endregion

            #region Display "Happy Birthday" the number of times the years have passed
            //************************************************************************
            for (int i = 0; i < UserAge; i++)
                Console.WriteLine("{0} Happy Birthday", i+1);
            #endregion

        }
    }
}
