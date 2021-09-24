using System.ComponentModel.DataAnnotations;

namespace CatelogVS.Dtos
{
    public record CreateItemDto
    {
        [Required]
        public string Name {get; init;}//User set
        
        [Required]
        [Range(1,1000)]
        public decimal Price {get; init;}//User set
    }
}