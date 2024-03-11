using System.ComponentModel.DataAnnotations;

namespace LaptopStoreAPI.Controllers.DTOs
{
    public class LaptopDto
    {
        public string Model { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Brand { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Battery { get; set; } = string.Empty;
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
        public string Dimension { get; set; } = string.Empty;
        [Required]
        [Range(0.2, double.MaxValue)]
        public double WeightKg { get; set; }
        [Required]
        [MaxLength(100)]
        public string Wifi { get; set; } = string.Empty;
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


    }
}
