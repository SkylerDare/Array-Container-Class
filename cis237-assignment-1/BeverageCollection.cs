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
        //No Properties
        //****************************
        //****************************
        //No Constructors
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

                string tempID = "";

                string tempName = "";

                string tempPack = "";

                decimal tempPrice = 0.00m;
                string priceTest = "";

                bool tempActive = false;
                string tempActiveString = "";
                bool validateActive = false;

                tempID = searchString;
                tempName = ui.CollectName(tempName);
                tempPack = ui.CollectPack(tempPack);

                while (tempPrice <= 0.00m)
                {
                    priceTest = ui.CollectPrice(priceTest);
                    tempPrice = ValidatePrice(priceTest, tempPrice);
                    if (tempPrice <= 0.00m)
                    {
                        ui.BadPrice();
                    }
                }

                while (validateActive != true)
                {
                    tempActiveString = ui.CollectActive(tempActiveString);
                    validateActive = ValidateActive(tempActiveString, validateActive);
                    if (validateActive == true)
                    {
                        tempActive = bool.Parse(tempActiveString);
                    }
                    else
                    {
                        ui.BadActive();
                    }
                }

                beverages[index] = new Beverage(tempID, tempName, tempPack, tempPrice, tempActive);
            }
        }

        private decimal ValidatePrice(string priceTest, decimal price)
        {
            try
            {
                price = decimal.Parse(priceTest);
                return price;
            }
            catch
            {
                price = 0.00m;
                return price;
            }
        }

        private bool ValidateActive(string activeString, bool validate)
        {
            if (activeString == "TRUE" || activeString == "FALSE")
            {
                validate = true;
                return validate;
            }
            else
            {
                validate = false;
                return validate;
            }
        }
    }
}
