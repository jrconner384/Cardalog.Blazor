using System.ComponentModel.DataAnnotations;

namespace Cardalog.Models
{
  public class Card
  {
    [Required]
    [StringLength(50, ErrorMessage = "{0} may not exceed {1] characters.")]
    public string Title { get; set; }

    [Required]
    [StringLength(25, ErrorMessage = "{0} may not exceed {1] characters.")]
    public string Type { get; set; }

    [StringLength(50, ErrorMessage = "{0} may not exceed {1] characters.")]
    public string Subtype { get; set; }

    [StringLength(25, ErrorMessage = "{0} may not exceed {1] characters.")]
    public string Rarity { get; set; }

    [StringLength(15, ErrorMessage = "{0} may not exceed {1] characters.")]
    public string Cost { get; set; }

    [Required]
    [Range(0, 20, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int? ConvertedCost { get; set; }

    [StringLength(250, ErrorMessage = "{0} may not exceed {1] characters.")]
    public string Text { get; set; }

    [StringLength(250, ErrorMessage = "{0} may not exceed {1] characters.")]
    public string FlavorText { get; set; }

    [Range(0, 20, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int? Power { get; set; }

    [Range(0, 20, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int? Toughness { get; set; }

    [Required]
    public Expansion Expansion { get; set; }

    [Range(0, 500, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int? CardNumber { get; set; }

    [StringLength(250, ErrorMessage = "{0} may not exceed {1] characters.")]
    public string Artist { get; set; }
  }

  public class Expansion
  {
    [Required]
    [StringLength(250, ErrorMessage = "{0} may not exceed {1] characters.")]
    public string Name { get; set; }

    [Range(0, 500, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int? TotalCards { get; set; }

    [StringLength(250, ErrorMessage = "{0} may not exceed {1] characters.")]
    public string Abbreviation { get; set; }

    [StringLength(250, ErrorMessage = "{0} may not exceed {1] characters.")]
    public string Copyright { get; set; }
  }
}