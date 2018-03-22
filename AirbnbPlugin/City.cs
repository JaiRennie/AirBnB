using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbPlugin
{
    class City
    {
        //Medlemsvariabler
        private string name;
        private int citizens;
        private int avgIncome;
        private int tourists;
        private int accomodationAmount;
        private double abnbCost;
        private List<Accomodation> accomodations = new List<Accomodation>();
        
        //Konstruktor
        public City
            (
            string CtyName,
            int CtyCitizens,
            int CtyAvgIncome,
            int CtyTourists,
            int CtyAccomodationAmount,
            double CtyAbnbCost,
            List<Accomodation> Accomodations
            )
        {
            name = CtyName;
            citizens = CtyCitizens;
            avgIncome = CtyAvgIncome;
            tourists = CtyTourists;
            accomodationAmount = CtyAccomodationAmount;
            abnbCost = CtyAbnbCost;
            accomodations = Accomodations;
        }

        //Getters and Setters
        public string CtyName
        {
            get { return name; }
            set { name = value; }
        }

        public int CtyCitizens 
        {
            get { return citizens; }
            set { citizens = value; }
        }

        public int CtyAvgIncome
        {
            get { return avgIncome; }
            set { avgIncome = value; }
        }

        public int CtyTourists
        {
            get { return tourists; }
            set { tourists = value; }
        }

        public int CtyAccomodationAmount
        {
            get { return accomodationAmount; }
            set { accomodationAmount = value; }
        }

        public double CtyAbnbCost
        {
            get { return abnbCost; }
            set { abnbCost = value; }
        }
        public List<Accomodation> Accomodations
        {
            get { return accomodations; }
            set { accomodations = value; }
        }
    }
}
