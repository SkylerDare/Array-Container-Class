using System;

namespace cis237_assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            CSVProcessor csvProcessor = new CSVProcessor();
            string pathToCsv = "../../../../datafiles/beverage_list.csv";
            BeverageCollection beverage = new BeverageCollection();
            bool fileLoaded = false;
            int choice = ui.GetUserInput();

            while (choice != 5)
            {
                if (choice == 1 && fileLoaded == true)
                {
                    ui.FileLoaded();
                }
                if (choice == 1 && fileLoaded == false)
                {
                    beverage.LoadList(csvProcessor, pathToCsv);
                    fileLoaded = true;
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
