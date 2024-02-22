using System.ComponentModel.DataAnnotations;

namespace LaptopStoreAPI.Controllers.DTOs
{
    public class RamDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Model { get; set; } = string.Empty;
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Type { get; set; } = string.Empty;
        [Required]
        [Range(1.0, float.MaxValue)]
        public float FrequencyMHz { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
        [Required]
        [Range(1, 10)]
        public int Slot { get; set; }
    }
}
