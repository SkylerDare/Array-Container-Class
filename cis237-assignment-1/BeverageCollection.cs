using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_1
{
    class BeverageCollection
    {
        //****************************
        //Variables
        //****************************
        Beverage[] beverages = new Beverage[4000];

        //****************************
        //Properties
        //****************************
        public Beverage[] GetArray
        {
            get { return beverages; }
        }
        //****************************
        //Constructors
        //****************************

        //****************************
        //Methods
        //****************************
        public void LoadList(CSVProcessor cSVProcessor, string pathToCsv)
        {
            cSVProcessor.ImportCSV(pathToCsv, beverages);
        }

        public void PrintList(UserInterface ui, string outputString)
        {
            foreach (Beverage beverage in beverages)
            {
                if (beverage != null)
                {
                    outputString += beverage.ToString() + Environment.NewLine;
                }
            }
            ui.PrintList(outputString);
        }

        public void SearchList(UserInterface ui, string searchString, bool found)
        {
            searchString = ui.PromptSearch(searchString);
            string beverageString = "";
            foreach (Beverage beverage in beverages)
            {
                if (beverage != null)
                {
                    if (searchString == beverage.BevID)
                    {
                        beverageString = beverage.ToString();
                        found = true;
                    }
                }
            }
            if (found == true)
            {
                ui.SearchSuccessful(beverageString);
            }
            else
            {
                ui.FailedSearch();
            }
        }

        public void AddBeverage(UserInterface ui, string searchString, bool found)
        {
            int index = 0;
            searchString = ui.PromptSearch(searchString);
            foreach (Beverage beverage in beverages)
            {
                if (beverage != null)
                {
                    index++;
                    if (searchString == beverage.BevID)
                    {
                        found = true;
                        ui.BadID();
                    }
                }
            }
            if (found == false)
            {

            }
        }
    }
}
