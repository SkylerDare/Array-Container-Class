using System;

namespace cis237_assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage myBeverage = new Beverage();
            UserInterface ui = new UserInterface();
            CSVProcessor csvProcessor = new CSVProcessor();
            string pathToCsv = "../../../../datafiles/beverage_list.csv";
            BeverageCollection beverage = new BeverageCollection();
            int choice = ui.GetUserInput();

            while (choice != 5)
            {
                if (choice == 1)
                {
                    beverage.LoadList(csvProcessor, pathToCsv);
                }
                if (choice == 2)
                {
                    string outputString = "";
                    beverage.PrintList(ui, outputString);
                }
                if (choice == 3)
                {
                    string searchString = "";
                    bool found = false;
                    beverage.SearchList(ui, searchString, found);
                }
                if (choice == 4)
                {
                    string searchString = "";
                    bool found = false;
                    beverage.AddBeverage(ui, searchString, found);
                }
                choice = ui.GetUserInput();
            }
        }
    }
}
