using System.ComponentModel.DataAnnotations;

namespace LaptopStoreAPI.Controllers.DTOs
{
    public class GraphicsCardDto
    {
        [Required]
        public string Model { get; set; } = string.Empty;
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
    }
}
