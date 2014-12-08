using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSV_RealEstate
{
    class Program
    {
        static void Main(string[] args)
        {
            //create new list of real estate type
            List<RealEstateData> RealEstateData = new List<RealEstateData>();
            //set bool flag to skip first line
            bool skipFirstLine = true;
            //use steam reader to read in file, making note that it is two folders up
            using (StreamReader reader = new StreamReader("../../realestatedata.csv"))
            {
                //while true keep reading in lines
                while (true)
                {
                    //set var to hold a line from stream reader
                    string line = reader.ReadLine();
                    //if empty break out of loop
                    if (line == null)
                    {
                        break;
                    }
                    //if first line
                    if (skipFirstLine)
                    {
                        //set it as false an repeat, skipping first line
                        skipFirstLine = false;
                    }
                    //otherwise add line to out list, creating a new object of the real estate data type for each line
                    else 
                    {
                        RealEstateData.Add(new RealEstateData(line));
                    }
                    
                   
                    
                }
            //read in the realestatedata.csv file.  As you process each row, you'll add a new 
            // RealEstateData object to the list for each row of the document, excluding the first.       
            
            //Display the average square footage of a Condo sold in the city of Sacramento, 
            // round to 2 decimal points
            Console.WriteLine(RealEstateData.Where(x=> x.City.ToLower() == "sacramento" && x.ResidentType == RealEstateType.MultiFamily).Average(x=> x.Sqft));
           
            //Display the total sales of all residential homes in Elk Grove, display in dollars
            Console.WriteLine(RealEstateData.Where(x => x.City.ToLower() == "elk grove" && x.ResidentType == RealEstateType.Residential).Sum(x => x.Price).ToString("C"));

            //Display the total number of residential homes sold in the following  
            // zip codes: 95842, 95825, 95815
            Console.WriteLine(RealEstateData.Where(x => "95842 95825 95815".Contains(x.ZIP) && x.ResidentType == RealEstateType.Residential).Count());

            //Display the average sale price of a lot in Sacramento, display in dollars
            Console.WriteLine(RealEstateData.Where(x => x.City.ToLower() == "sacramento" && x.ResidentType == RealEstateType.RawLand).Average(x => x.Price).ToString("C"));


            //Display the average price per square foot for a condo in Sacramento, display in dollars
            Console.WriteLine(Math.Round(RealEstateData.Where(x => x.City.ToLower() == "sacramento" && x.ResidentType == RealEstateType.Condo).Average(x => x.Price / x.Sqft), 2));

            //Display the number of all sales that were completed on a Wednesday
            Console.WriteLine(RealEstateData.Count(x => x.SalesDates.DayOfWeek == DayOfWeek.Wednesday));
            
            //Display the average number of bedrooms for a residential home in Sacramento when the 
            // price is greater than 300000, round to 2 decimal points
            Console.WriteLine(Math.Round(RealEstateData.Where(x => x.City.ToLower() == "sacramento" && x.ResidentType == RealEstateType.Residential && x.Price > 300000).Average(x => x.Beds), 2));

            //Extra Credit:
            //Display top 5 cities and the number of homes sold (using the GroupBy extension)
            Console.WriteLine(string.Join("\n", RealEstateData.GroupBy(x => x.City).OrderByDescending(x => x.Count()).Take(5).Select(x => (x.Key + " " + x.Count()).ToString())));

            Console.ReadKey();
        }

    }
}
    //new enums for types of real estate
   public enum RealEstateType
   {
      RawLand, Residential, Condo, MultiFamily
   }
     

   //class of real estate 

    public class RealEstateData
    {
        //street is string
        private string _street;
        public string Street
        {
            get {return _street ;}
            set {_street = value ;}
        }
        //city is string
        private string _city;
        public string City 
        {
            get { return _city; }
            set { _city = value; }
        }
        //zip is string
        private string _zip;
        public string ZIP
        {
            get {return _zip;}
            set {_zip = value;}

        }
        //state is string
        private string _state;
        public string State
        {
            get{return _state;}
            set{_state = value;}

        }
        //beds is int so we can manipulate data
        private int _beds;
        public int Beds
        {
            get {return _beds;}
            set {_beds = value;}

        }
        //same for baths
        private int _baths;
        public int Baths
        {
            get{return _baths;}
            set {_baths = value;}
        }
        //same for square footage
        private int _sqft;
        public int Sqft 
        {
            get{return _sqft;}
            set{_sqft = value;}
        }
        //realestatetype so we can use enums
        private RealEstateType _residentType;
        public RealEstateType ResidentType 
        { 
            get{ return _residentType;}
            set{ _residentType = value;} 
        }

        //date time so we can search by date criteria
        private DateTime _saleDate;
        public DateTime SalesDates
        {
            get { return _saleDate; }
            set { _saleDate = value; }
        }
        //int so we can mannipulate price
        private int _price;
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        //string for latitude
        private string _lat;
        public string Lat
        {
            get { return _lat; }
            set { _lat = value; }
        }
        //string for longitude
        private string _long;
        public string Long
        {
            get { return _long; }
            set { _long = value; }
        }

        
        //constructor that splits data from input string
        public RealEstateData(string dataFromLine) 
        {
            //split data on comma and add it to array
            var dataSplit = dataFromLine.Split(',');
            //assign array index to different 
            this.Street = dataSplit[0];
            this.City = dataSplit[1];
            this.ZIP = dataSplit[2];
            this.State = dataSplit[3];
            this.Beds = int.Parse(dataSplit[4]);
            this.Baths = int.Parse(dataSplit[5]);
            this.Sqft = int.Parse(dataSplit[6]);
            //set resident type by criteria
            if (this.Sqft == 0)
            {
                this.ResidentType = RealEstateType.RawLand;
            }
            else if (dataSplit[7] == "Residential") 
            { 
                this.ResidentType = CSV_RealEstate.RealEstateType.Residential; 
            }
            else if (dataSplit[7] == "Condo") 
            { 
                this.ResidentType = CSV_RealEstate.RealEstateType.Condo; 
            }
            else if (dataSplit[7] == "Multi-Family") 
            { 
                this.ResidentType = CSV_RealEstate.RealEstateType.MultiFamily;
            }
            this.SalesDates = Convert.ToDateTime(dataSplit[8]);
            this.Price = int.Parse(dataSplit[9]);
            this.Lat = dataSplit[10];
            this.Long = dataSplit[11];
        
        }

       


        //The constructor will take a single string arguement.  This string will be one line of the real estate data.this
        // Inside the constructor, you will seperate the values into their corrosponding properties, and do the necessary conversions

        //When computing the RealEstateType, if the square footage is 0, then it is of the Lot type, otherwise, use the string
        // value of the "Type" column to determine its corresponding enumeration type.
    }
}
