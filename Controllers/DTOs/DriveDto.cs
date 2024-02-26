using System.ComponentModel.DataAnnotations;

namespace LaptopStoreAPI.Controllers.DTOs
{
    public class DriveDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Type { get; set; } = string.Empty;
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Capacity { get; set; } = string.Empty;
    }
}
