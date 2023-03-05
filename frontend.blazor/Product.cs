using System.ComponentModel.DataAnnotations;

namespace frontend.blazor;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 5)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string Description { get; set; } = null!;

    [Required]
    [Range(10, double.MaxValue)]
    public decimal Price { get; set; }
}
