using System.ComponentModel.DataAnnotations;

namespace LaptopStoreAPI.Models
{
    public class Processor
    {
        public int Id { get; set; }
        [Required]
        public string Model { get; set; } = string.Empty;
        [Required]
        public float FrequencyGHz { get; set; }
        [Required]
        public string Brand { get; set; } = string.Empty;
        [Required]
        public int Core { get; set; }
        [Required]
        public int Thread { get; set; }
        [Required]
        public int Cache {  get; set; }

    }
}
