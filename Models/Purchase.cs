namespace dotnet_excel.Models;
using System.ComponentModel.DataAnnotations;

public class Purchase
{
  public int Id { get; set; }

  [Url]
  public string? Image { get; set; }

  [Required]
  public string? Name { get; set; }

  [Required]
  public DateTime? OrderDate { get; set; }

  [Required]
  public decimal? Price { get; set; }

  [Required]
  public decimal? DiscountedPrice { get; set; }
}
