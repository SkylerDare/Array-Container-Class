//Skyler Dare
//CIS237
//9/28/21
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_1
{
    class UserInterface
    {
        // No Variables
        // No Properties
        // No Constructors
        //*******************************
        //Methods
        //*******************************
        /// <summary>
        /// writes the menu to the console, prompts the user for input and collects input
        /// </summary>
        /// <returns>int value for choice comparison</returns>
        public int GetUserInput()
        {
            this.PrintMenu();

            string input = Console.ReadLine();

            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5")
            {
                this.PrintErrorMessage();
                this.PrintMenu();
                input = Console.ReadLine();
            }
            return Int32.Parse(input);
        }
        /// <summary>
        /// outputs the menu for the user to choose from
        /// </summary>
        private void PrintMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Load File");
            Console.WriteLine("2. Print List");
            Console.WriteLine("3. Search List");
            Console.WriteLine("4. Add New Beverage");
            Console.WriteLine("5. Exit");
        }
        /// <summary>
        /// if the file was already loaded, informs the user
        /// </summary>
        public void FileLoaded()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("File Was Already Loaded");
            Console.WriteLine("Please Choose Another Option");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// outputs headings for the beverage array contents in a string format
        /// </summary>
        /// <param name="outputList">holds the contents of the array from the CSV</param>
        public void PrintList(string outputList)
        {
            Console.WriteLine("Printing the List");
            Console.WriteLine("ID \t Name \t Pack \t Price \t Active");
            Console.WriteLine(outputList);
        }
        /// <summary>
        /// prompts the user for an ID value to be searched in the array
        /// </summary>
        /// <returns>the input ID value</returns>
        public string PromptSearch()
        {
            Console.WriteLine("Please Input a Beverage ID");
            string searchString = Console.ReadLine().ToUpper();
            return searchString;
        }
        /// <summary>
        /// if the search was successful, informs the user, also outputs the contents of the array at the index that was found
        /// </summary>
        /// <param name="beverageString">holds the contents of the array at the found index</param>
        public void SearchSuccessful(string beverageString)
        {
            Console.WriteLine();
            Console.WriteLine("Beverage Was Found");
            Console.WriteLine(beverageString);
            Console.WriteLine();
        }
        /// <summary>
        /// if the search was unsuccessful, inform the user
        /// </summary>
        public void FailedSearch()
        {
            Console.WriteLine();
            Console.WriteLine("Beverage Was Not Found");
            Console.WriteLine();
        }
        /// <summary>
        /// prompts the user for input for beverage name
        /// </summary>
        /// <returns>the string value from user input</returns>
        public string CollectName()
        {
            Console.WriteLine("Please Input a Beverage Name");
            string name = Console.ReadLine();
            return name;
        }
        /// <summary>
        /// prompts the user for input for beverage pack
        /// </summary>
        /// <returns>the string value from user input</returns>
        public string CollectPack()
        {
            Console.WriteLine("Please Input a Beverage Pack");
            string pack = Console.ReadLine();
            return pack;
        }
        /// <summary>
        /// if there was no input, inform the user
        /// </summary>
        public void BadString()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please Input a String Value");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// if the ID was found in the aray during the search, inform the user
        /// </summary>
        public void BadID()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please Input a Unique Beverage ID");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// prompt the user for decimal input for the beverage price
        /// </summary>
        /// <returns>price input</returns>
        public string CollectPrice()
        {
            Console.WriteLine("Please Input a Beverage Price");
            string price = Console.ReadLine();
            return price;
        }
        /// <summary>
        /// if the input was not positive/numeric/blank, inform the user
        /// </summary>
        public void BadPrice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please Input a Positive Decimal Beverage Price");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// prompts the user for active input, takes in a string and sets it ToUpper for validation
        /// </summary>
        /// <returns>the string input from user</returns>
        public string CollectActive()
        {
            Console.WriteLine("Input TRUE or FALSE for Beverage Active");
            string active = Console.ReadLine().ToUpper();
            return active;
        }
        /// <summary>
        /// if the string was not "true" or "false", or was blank, inform the user
        /// </summary>
        public void BadActive()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please Input TRUE or FALSE");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// basic output for invalid menu inputs
        /// </summary>
        private void PrintErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is not a valid entry");
            Console.WriteLine("Please make a valid choice");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
