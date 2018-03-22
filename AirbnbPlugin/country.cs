using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbPlugin
{
    class Country
    {
        //Medlemsvariabler
        private string name;
        private int citizens;
        private int bnp;
        private List<City> cityList = new List<City>();


        //Konstruktor
        public Country
            (
            string CntryNamn,
            int CntryCitizens,
            int CntryBNP,
            List<City> CityList
            )
        {
            name = CntryNamn;
            citizens = CntryCitizens;
            bnp = CntryBNP;
            cityList = CityList;
        }

        //Getters and Setters

        public string CntryName
        {
            get { return name; }
            set { name = value; }
        }

        public int CntryCitizens
        {
            get { return citizens; }
            set { citizens = value; }
        }

        public int CntryBNP
        {
            get { return bnp; }
            set { bnp = value; }
        }

        public List<City> CityList
        {
            get { return cityList; }
            set { cityList = value; }
        }

    }
}
