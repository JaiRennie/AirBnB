using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AirbnbPlugin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Skapar Accomodation Listor
            List<Accomodation> amsterdamList = GetAccomList("Select * From Amsterdam", "Amsterdam");
            List<Accomodation> barcelonaList = GetAccomList("Select * From Barcelona", "Barcelona");
            List<Accomodation> bostonList = GetAccomList("Select * From Boston", "Boston");
            List<Accomodation> FullList = amsterdamList.Concat(barcelonaList).Concat(bostonList).ToList();
            //skapar Stad Objekt
            City amsterdam = new City("Amsterdam", 851573, 45950, 15854, amsterdamList.Count, GetAvgCost(amsterdamList),amsterdamList);
            City barcelona = new City("Barcelona", 1604555, 15816, 3200000, barcelonaList.Count, GetAvgCost(barcelonaList),barcelonaList);
            City boston = new City("Boston", 687584, 46669, 2047116, bostonList.Count, GetAvgCost(bostonList),bostonList);
            //Skapar Land Listor
            List<City> hollandCtyList = new List<City>() { amsterdam };
            List<City> spainCtyList = new List<City>() { barcelona };
            List<City> usaCtyList = new List<City>() { boston };
            //Skapar Land objekt
            Country holland = new Country("Netherlands", 1700000, 4529478, hollandCtyList);
            Country spain = new Country("Spain", 4656000, 2652849, spainCtyList);
            Country usa = new Country("USA", 32500000, 5746679, usaCtyList);



            //CHARTING-Histogram
            //Amsterdam

            foreach(Accomodation a in amsterdamList)
            {
                if (a.Room_type == "private room"|| a.Room_type == "Private Room"|| a.Room_type == "Private room")
                {
                    chart1.Series["Series1"].Points.AddY(a.Price);
                }                   
            }

            chart1.Series["Series1"].ChartType = SeriesChartType.Column;
            chart1.ChartAreas[0].AxisY.Title = "Price";
            chart1.Titles.Add("Spridning av Price");
            chart1.Series["Series1"].Name = "Amsterdam";
            

            //Barcelona

            foreach (Accomodation a in barcelonaList)
            {
                if (a.Room_type == "private room" || a.Room_type == "Private Room" || a.Room_type == "Private room")
                {
                    chart2.Series["Series1"].Points.AddY(a.Price);
                }                        
            }

            chart2.Series["Series1"].ChartType = SeriesChartType.Column;
            chart2.ChartAreas[0].AxisY.Title = "Price";
            chart2.Titles.Add("Spridning av Price");
            chart2.Series["Series1"].Name = "Barcelona";

            //Boston

            foreach (Accomodation a in bostonList)
            {
                if (a.Room_type == "private room" || a.Room_type == "Private Room" || a.Room_type == "Private room"|| a.Room_type == "private Room")
                {
                    chart3.Series["Series1"].Points.AddY(a.Price);
                }                
            }

            chart3.Series["Series1"].ChartType = SeriesChartType.Column;
            //chart3.ChartAreas[0].AxisX.Title = "Private Rooms";
            chart3.ChartAreas[0].AxisY.Title = "Price";
            chart3.Titles.Add("Spridning av Price");
            chart3.Series["Series1"].Name = "Boston";

            //SCATTER CHARTS
            //Amsterdam
            foreach (Accomodation a in amsterdamList)
            {
                if (a.Overall_satisfaction < 4.5)
                {
                    chart4.Series["Series1"].Points.AddXY(a.Price,a.Overall_satisfaction);
                }
            }

            chart4.Series["Series1"].ChartType = SeriesChartType.Point;
            chart4.ChartAreas[0].AxisX.Title = "Price";
            chart4.ChartAreas[0].AxisY.Title = "Satisfaction";
            chart4.Titles.Add("Spridning av Price VS Satisfaction");
            chart4.Series["Series1"].Name = "Amsterdam";
            

            //Barcelona
            foreach (Accomodation a in barcelonaList)
            {
                if (a.Overall_satisfaction < 4.5)
                {
                    chart5.Series["Series1"].Points.AddXY(a.Price, a.Overall_satisfaction);
                }
            }

            chart5.Series["Series1"].ChartType = SeriesChartType.Point;
            chart5.ChartAreas[0].AxisX.Title = "Price";
            chart5.ChartAreas[0].AxisY.Title = "Satisfaction";
            chart5.Titles.Add("Spridning av Price VS Satisfaction");
            chart5.Series["Series1"].Name = "Barcelona";

            //Boston
            foreach (Accomodation a in bostonList)
            {
                if (a.Overall_satisfaction < 4.5)
                {
                    chart6.Series["Series1"].Points.AddXY(a.Price, a.Overall_satisfaction);
                }
            }

            chart6.Series["Series1"].ChartType = SeriesChartType.Point;
            chart6.ChartAreas[0].AxisX.Title = "Price";
            chart6.ChartAreas[0].AxisY.Title = "Satisfaction";
            chart6.Titles.Add("Spridning av Price VS Satisfaction");
            chart6.Series["Series1"].Name = "Boston";



        }

        //Metod som fylla accommadations listor
        private List<Accomodation> GetAccomList(string myQuery, string city)
        {
            List<Accomodation> accomList = new List<Accomodation>();
            string sConnectionString = "Data Source =LAPTOP2\\TESTSQL; Initial Catalog =AirBnbTest; Integrated Security =True;";
            SqlConnection sqlConnection = new SqlConnection(sConnectionString);

            try
            {
                sqlConnection.Open();
                MessageBox.Show("Connection successful");
                SqlDataAdapter adapter = new SqlDataAdapter(myQuery, sqlConnection);
                DataSet dataSet = new DataSet(city);
                adapter.Fill(dataSet);

                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    int Room_id = Convert.ToInt32(dr["room_id"]);
                    int Host_id = Convert.ToInt32(dr["host_id"]);
                    string Room_type = Convert.ToString(dr["room_type"]);
                    string Borough = Convert.ToString(dr["borough"]);
                    string Neighbourhood = Convert.ToString(dr["neighborhood"]);
                    int Reviews = Convert.ToInt32(dr["reviews"]);
                    double Overall_satisfaction = Convert.ToDouble(dr["overall_satisfaction"]);
                    int Accomodates = Convert.ToInt32(dr["accommodates"]);
                    int Bedrooms = Convert.ToInt32(dr["bedrooms"]);
                    int Price = Convert.ToInt32(dr["price"]);

                    bool Minstaytest = int.TryParse(Convert.ToString(dr["minstay"]), out int Minstay);
                    if (Minstaytest == false)
                    {
                        Minstay = 0;
                    };

                    double Latitude = Convert.ToDouble(dr["latitude"]);
                    double Longitude = Convert.ToDouble(dr["longitude"]);
                    string Last_modified = Convert.ToString(dr["last_modified"]);

                    Accomodation listRow = new Accomodation(
                                            Room_id, Host_id, Room_type, Borough, Neighbourhood, Reviews,
                                            Overall_satisfaction, Accomodates, Bedrooms, Price, Minstay,
                                            Latitude, Longitude, Last_modified);

                    accomList.Add(listRow);
                }
            }
            catch (Exception ex)
            {
                //Exception
                MessageBox.Show("Connection unsuccessful");
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();

            }
            return accomList;
        }
        //Metod som räkna medelkostnad
        private double GetAvgCost(List<Accomodation> inputList)
        {
            int avgPrice = 0;
            int totalPrice = 0;

            for (int i = 0; i < inputList.Count; i++)
            {

                totalPrice = totalPrice + inputList[i].Price;
            }
            return avgPrice = totalPrice / inputList.Count;
        }

        //metod som fylla en list med priser
        private List<int> GetAxisPrivate(List<Accomodation> inputList)
        {
            List<int> axisOut = new List<int>();  
           
            foreach (Accomodation currentAccom in inputList)
            {
                if (currentAccom.Room_type == "Private room"|| currentAccom.Room_type == "private room"|| currentAccom.Room_type == "private Room")
                {
                    axisOut.Add(currentAccom.Price);
                }              
            }
            return axisOut;
        }

        //metod som fylla xaxis
        private List<int> GetYaxis(List<Accomodation> inputList)
        {
            List<int> axisOut = new List<int>();
            int counter = 1;

            foreach(Accomodation currentAccom in inputList)
            {
                if (currentAccom.Room_type == "Private room" || currentAccom.Room_type == "private room" || currentAccom.Room_type == "private Room")
                {
                    axisOut.Add(counter);
                    counter++;
                }
            }
            return axisOut;
        }
        
    }
}
