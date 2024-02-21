using System.ComponentModel.DataAnnotations;

namespace LaptopStoreAPI.Controllers.DTOs
{
    public class ProcessorDto
    {
        [Required]
        [StringLength(50,MinimumLength = 1)]
        public string Model { get; set; } = string.Empty;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Clock speed must be greather than 0")]
        public float FrequencyGHz { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Brand { get; set; } = string.Empty;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Core must be greather than 0")]
        public int Core { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Thread must be greather than 0")]
        public int Thread { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Cache must be greather than 0")]
        public int Cache { get; set; }
    }
}

