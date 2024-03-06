using System.ComponentModel.DataAnnotations;

namespace LaptopStoreAPI.Persistence.Models
{
    public class GraphicsCard
    {
        public int Id { get; set; }
        [Required]
        public string Model { get; set; } = string.Empty;
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
    }
}
