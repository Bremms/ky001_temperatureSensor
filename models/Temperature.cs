namespace Ky001.models
{
    public struct Temperature
    {
        public Temperature(double celsius)
        {
            Celsius = celsius;
        }
        public double Celsius { get; set; }
        public double Fahrenheit { get { return Celsius * 1.8 + 32;} }
    }
}
