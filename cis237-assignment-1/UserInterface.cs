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
        // Properties
        // No Constructors
        //*******************************
        //Methods
        //*******************************
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

        private void PrintMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Load File");
            Console.WriteLine("2. Print List");
            Console.WriteLine("3. Search List");
            Console.WriteLine("4. Add New Beverage");
            Console.WriteLine("5. Exit");
        }

        public void PrintList(string outputList)
        {
            Console.WriteLine("Printing the List");
            Console.WriteLine("ID \t Name \t Pack \t Price \t Active");
            Console.WriteLine(outputList);
        }

        public string PromptSearch(string searchString)
        {
            Console.WriteLine("Please Input a Beverage ID");
            searchString = Console.ReadLine();
            return searchString;
        }

        public void SearchSuccessful(string beverageString)
        {
            Console.WriteLine();
            Console.WriteLine("Beverage Was Found");
            Console.WriteLine(beverageString);
            Console.WriteLine();
        }

        public void FailedSearch()
        {
            Console.WriteLine();
            Console.WriteLine("Beverage Was Not Found");
            Console.WriteLine();
        }

        public void BadID()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please Input a Unique Beverage ID");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PromptInput()
        {
            Console.WriteLine();
            Console.WriteLine("");
        }

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
