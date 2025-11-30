namespace Models
{
    public class Airport
    {
        public string Code { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Airport(string code, string city, string country)
        {
            Code = code;
            City = city;
            Country = country;
        }
    }
}
