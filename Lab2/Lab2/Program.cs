using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Initiate List, Regex and string for user entry as Global Variables
            //****************************************************
            List<int> UserInputNumbers = new List<int>();
            Regex NumExp = new Regex(@"^\d+$");
            string UserEntry = "";
            #endregion

            while (UserEntry.ToLower() != "x")
            {
                #region Ask user to enter as many numbers as they wish. Enter X when done
                //***********************************************************************
                Console.Write("Enter any number or Enter X to End: ");
                UserEntry = Console.ReadLine();
                #endregion

                #region Validate entry with Regular Expression. If wrong, or X is not entered, loop.
                //*******************************************************************************
                while (!NumExp.IsMatch(UserEntry) && UserEntry.ToLower() != "x")
                {
                    Console.Write("Wrong. Enter only number or Enter X to End:");
                    UserEntry = Console.ReadLine();
                }
                #endregion

                #region Save entry to List, if the entry is not X
                //***********************************************
                if (UserEntry.ToLower() != "x")
                    UserInputNumbers.Add(Convert.ToInt32(UserEntry));
                #endregion
            }

            #region Ask user what they would like to do with the numbers. Provide Options: SUM, HIGHEST or SORT.
            //*****************************************************************************

            Console.WriteLine("\nYou have entered {0} numbers. \nWhat would like do with these numbers? \nSelect one of three options:" , UserInputNumbers.Count);
            Console.WriteLine("\nEnter 1 to see the SUM of all numbers.");
            Console.WriteLine("Enter 2 to see the HIGHEST of all numbers.");
            Console.WriteLine("Enter 3 to see the SORTED list of all numbers.");
            Console.Write("\nEnter your selection [1, 2 or 3]: ");
            UserEntry = Console.ReadLine();
            #endregion

            #region Validate entry with Regular Expression.
            //*********************************************
            Regex OptNum = new Regex(@"^[123]{1}$");
            while (!OptNum.IsMatch(UserEntry))
            {
                Console.Write("Wrong. Enter only one of three numbers [1, 2 or 3]: ");
                UserEntry = Console.ReadLine();
            }
            #endregion

            // Display Result based on the user entry. End program after display.

            #region Display SUM of the List
            //************************
            if (UserEntry == "1")
                Console.WriteLine("\nSum of the numbers you entered is {0}.\n", UserInputNumbers.Sum());
            #endregion

            #region Display HIGHEST number of the List
            //********************************
            if (UserEntry == "2")
                Console.WriteLine("\nHighest number you entered is {0}.\n", UserInputNumbers.Max());
            #endregion

            #region Display SORTED list of number
            //********************************
            UserInputNumbers.Sort();
            if (UserEntry == "3")
            {
                Console.WriteLine("\nSorted List of numbers entered:\n", UserInputNumbers.Max());
                foreach (int i in UserInputNumbers)
                    Console.WriteLine(i);

                Console.WriteLine("\n");
            }
            #endregion
        }
    }
}
