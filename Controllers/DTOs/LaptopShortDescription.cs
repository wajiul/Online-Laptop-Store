namespace LaptopStoreAPI.Controllers.DTOs
{
    public class LaptopShortDescription
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Processor { get; set; } = string.Empty;
        public string Ram { get; set; } = string.Empty;
        public string Storage { get; set; } = string.Empty;
        public string Display { get; set;} = string.Empty;
        public int Price { get; set; }


    }
}
