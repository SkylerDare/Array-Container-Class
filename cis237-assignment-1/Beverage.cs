using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_1
{
    class Beverage
    {
        //*******************
        // Attributes/Variables/Backing Fields
        //*******************
        string _bevID;
        string _bevName;
        string _bevPack;
        decimal _bevPrice;
        bool _bevActive;
        
        //*******************
        // Properties
        //*******************
        public string BevID
        {
            set { _bevID = value; }
            get { return _bevID; }
        }

        public string BevName
        {
            get { return _bevName; }
            set { _bevName = value; }
        }

        public string BevPack
        {
            get { return _bevPack; }
            set { _bevPack = value; }
        }

        public decimal BevPrice
        {
            get { return _bevPrice; }
            set { _bevPrice = value; }
        }

        public bool BevActive
        {
            get { return _bevActive; }
            set { _bevActive = value; }
        }

        //*******************
        // Methods
        //*******************
        public override string ToString()
        {
            return _bevID + " " + _bevName + " " + _bevPack + " " + _bevPrice + " " + _bevActive;
        }

        //*******************
        // Constructors
        //*******************
        public Beverage(string ID, string Name, string Pack, decimal Price, bool Active)
        {
            this._bevID = ID;
            this._bevName = Name;
            this._bevPack = Pack;
            this._bevPrice = Price;
            this._bevActive = Active;
        }

        public Beverage()
        {

        }
    }
}
