namespace BusinessLib
{
    public class City
    {
        public City(string cityName)
        {
            this.CityName = cityName;
        }

        public string CityName { get; private set; }
    }
}