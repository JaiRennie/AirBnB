using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AirbnbPlugin
{
    class Accomodation
    {
        //Medlemsvariabler
        private int roomId;
        private int hostId;
        private string roomType;
        private string borough;
        private string neighbourhood;
        private int reviews;
        private double overallSatisfaction;
        private int accomodates;
        private int bedrooms;
        private int price;
        private int minStay;
        private double latitude;
        private double longitude;
        private string lastModified;

        //Konstruktor
        public Accomodation
            (
            int Room_id,
            int Host_id,
            string Room_type,
            string Borough,
            string Neighbourhood,
            int Reviews,
            double Overall_satisfaction,
            int Accomodates,
            int Bedrooms,
            int Price,
            int Minstay,
            double Latitude,
            double Longitude,
            string Last_modified
            )
        {
            roomId = Room_id;
            hostId = Host_id;
            roomType = Room_type;
            borough = Borough;
            neighbourhood = Neighbourhood;
            reviews = Reviews;
            overallSatisfaction = Overall_satisfaction;
            accomodates = Accomodates;
            bedrooms = Bedrooms;
            price = Price;
            minStay = Minstay;
            latitude = Latitude;
            longitude = Longitude;
            lastModified = Last_modified;
        }

       
        public int Room_id { get => roomId; set => roomId = value; }
        public int Host_id { get => hostId; set => hostId = value; }
        public string Room_type { get => roomType; set => roomType = value; }
        public string Borough { get => borough; set => borough = value; }
        public string Neighbourhood { get => neighbourhood; set => neighbourhood = value; }
        public int Reviews { get => reviews; set => reviews = value; }
        public double Overall_satisfaction { get => overallSatisfaction; set => overallSatisfaction = value; }
        public int Accomodates { get => accomodates; set => accomodates = value; }
        public int Bedrooms { get => bedrooms; set => bedrooms = value; }
        public int Price { get => price; set => price = value; }
        public int Minstay { get => minStay; set => minStay = value; }
        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        public string Last_modified { get => lastModified; set => lastModified = value; }
    }
}
