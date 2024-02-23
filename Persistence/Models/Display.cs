using System.ComponentModel.DataAnnotations;

namespace LaptopStoreAPI.Persistence.Models
{
    public class Display
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Type { get; set; } = string.Empty;
        [Required]
        [Range(1.0, 100.0)]
        public float Size { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Resolution { get; set; } = string.Empty;
        [Required]
        public bool TouchScreen { get; set; }
    }
}
