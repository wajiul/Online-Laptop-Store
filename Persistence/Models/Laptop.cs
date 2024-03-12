using System.ComponentModel.DataAnnotations;

namespace LaptopStoreAPI.Persistence.Models
{
    public class Laptop
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Brand { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Battery { get;set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Bluetooth { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Camera { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Color { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Dimension { get; set;} = string.Empty;
        [Required]
        public double WeightKg { get; set; }
        [Required]
        [MaxLength(100)]
        public string Wifi { get; set;} = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Warranty { get; set; } = string.Empty;
        [Required]
        public int ProcessorId { get; set; }
        [Required]
        public int RamId { get; set; }
        [Required]
        public int DriveId { get; set; }
        [Required]
        public int DisplayId { get; set; }
        [Required]
        public int GraphicsCardId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Price { get; set; }
        public Processor Processor { get; set; }
        public Ram Ram { get; set; }
        public Drive Drive { get; set; }
        public Display Display { get; set; }
        public GraphicsCard GraphicsCard { get; set; }

    }
}
