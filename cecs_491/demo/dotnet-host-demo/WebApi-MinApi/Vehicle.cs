
namespace WebApi_MinApi
{
    public class Vehicle
    {
        public Vehicle(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }


        public string Make { get; set; } = String.Empty;
        public string Model { get; set; } = String.Empty;
        public int Year { get; set; }
    }
}

