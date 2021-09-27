using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_1
{
    class CSVProcessor
    {
        public bool ImportCSV(string pathToCsv, Beverage[] beverages)
        {
            StreamReader streamReader = null;
            try
            {
                string line;

                streamReader = new StreamReader(pathToCsv);

                int counter = 0;

                while ((line = streamReader.ReadLine()) != null)
                {
                    ProcessLine(line, beverages, counter++);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);

                return false;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
        }

        private static void ProcessLine(string line, Beverage[] beverages, int index)
        {
            string[] parts = line.Split(',');

            string id = parts[0];
            string name = parts[1];
            string pack = parts[2];
            decimal price = decimal.Parse(parts[3]);
            bool active = bool.Parse(parts[4]);

            beverages[index] = new Beverage(id, name, pack, price, active);
        }
    }
}
