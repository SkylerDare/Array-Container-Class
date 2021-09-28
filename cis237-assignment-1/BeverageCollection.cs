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
    class BeverageCollection
    {
        //****************************
        //Variables
        //****************************
        Beverage[] beverages = new Beverage[4000];

        //No Properties
        //No Constructors
        //****************************
        //Methods
        //****************************
        /// <summary>
        /// Calls the CSVProcessor to populate the beverage array
        /// </summary>
        /// <param name="cSVProcessor">Instance of the CSVProcessor class</param>
        /// <param name="pathToCsv">The path to the CSV file</param>
        public void LoadList(CSVProcessor cSVProcessor, string pathToCsv)
        {
            cSVProcessor.ImportCSV(pathToCsv, beverages);
        }
        /// <summary>
        /// Prints out the contents of the beverage array
        /// </summary>
        /// <param name="ui">Instance of the UserInterface Class</param>
        /// <param name="outputString">String that will contain the beverage array for output</param>
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
        /// <summary>
        /// Search the array based on the beverage ID string value
        /// </summary>
        /// <param name="ui">Instance of the UserInterface class</param>
        /// <param name="found">boolean value that will determine if the ID was found in the array</param>
        public void SearchList(UserInterface ui, bool found)
        {
            string searchString = ui.PromptSearch();
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
        /// <summary>
        /// Add a beverage to the array, check to see if ID is unique, also validates all other inputs
        /// </summary>
        /// <param name="ui">Instance of UserInterface class</param>
        /// <param name="found">boolean to determine if the ID was found in the array</param>
        public void AddBeverage(UserInterface ui, bool found)
        {
            int index = 0;
            string searchString = "";
            while (searchString == "")
            {
                searchString = ui.PromptSearch();

                if (searchString == "")
                {
                    ui.BadString();
                }
            }

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
            //if the ID was unique, prompt and accept the rest of the input
            if (found == false)
            {
                string tempName = "";
                string tempPack = "";
                decimal tempPrice = 0.00m;
                bool tempActive = false;
                bool validateActive = false;
                string tempID = searchString;

                //while there is no input from user
                while (tempName == "")
                {
                    tempName = ui.CollectName();
                    //check for input, if no input, inform the user
                    if (tempName == "")
                    {
                        ui.BadString();
                    }
                }
                //while there is no input from user
                while (tempPack == "")
                {
                    tempPack = ui.CollectPack();
                    //check for input, if no input, inform the user
                    if (tempPack == "")
                    {
                        ui.BadString();
                    }
                }
                //while there is a non-positive/non-numeric input from user
                while (tempPrice <= 0.00m)
                {
                    string priceTest = ui.CollectPrice();
                    tempPrice = ValidatePrice(priceTest);
                    //checks for positive/numeric input, if bad input, inform the user
                    if (tempPrice <= 0.00m)
                    {
                        ui.BadPrice();
                    }
                }
                //while boolean validation is false, accepts input from user and checks for "true" or "false"
                while (validateActive != true)
                {
                    string tempActiveString = ui.CollectActive();
                    validateActive = ValidateActive(tempActiveString);
                    if (validateActive == true)
                    {
                        tempActive = bool.Parse(tempActiveString);
                    }
                    else
                    {
                        ui.BadActive();
                    }
                }
                //if all input is validated, input data into the array
                beverages[index] = new Beverage(tempID, tempName, tempPack, tempPrice, tempActive);
            }
        }
        /// <summary>
        /// validates the decimal input for positive-numeric input
        /// </summary>
        /// <param name="priceTest">stores the user input for validation</param>
        /// <returns>price decimal after validation, either 0.00 or the actual input price if validation was successful</returns>
        private decimal ValidatePrice(string priceTest)
        {
            try
            {
                decimal price = decimal.Parse(priceTest);
                return price;
            }
            catch
            {
                decimal price = 0.00m;
                return price;
            }
        }
        /// <summary>
        /// validates the string for the active bool value, checks for "true" or "false" input from user
        /// </summary>
        /// <param name="activeString">stores the user input for validation</param>
        /// <returns>true or false</returns>
        private bool ValidateActive(string activeString)
        {
            if (activeString == "TRUE" || activeString == "FALSE")
            {
                bool validate = true;
                return validate;
            }
            else
            {
                bool validate = false;
                return validate;
            }
        }
    }
}
