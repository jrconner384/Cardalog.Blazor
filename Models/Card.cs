using System.ComponentModel.DataAnnotations;

namespace Cardalog.Models
{
  public class Card
  {
    public Card()
    {
      Title = Type = Subtype = Condition = Rarity = Text = FlavorText = Artist = string.Empty;
      Cost = new Cost();
      Power = Toughness = CardNumber = 0;
      Expansion = new Expansion();
    }

    private string title;
    [Required]
    [StringLength(50, ErrorMessage = "{0} may not exceed {1} characters.")]
    public string Title
    {
      get
      {
        return title ?? string.Empty;
      }
      set
      {
        title = value ?? string.Empty;
      }
    }

    public string TitleExpansion => $"{Title} || {Expansion.Name}";

    private string type;
    [Required]
    [StringLength(25, ErrorMessage = "{0} may not exceed {1} characters.")]
    public string Type
    {
      get
      {
        return type ?? string.Empty;
      }
      set
      {
        type = value ?? string.Empty;
      }
    }

    private string subtype;
    [StringLength(50, ErrorMessage = "{0} may not exceed {1} characters.")]
    public string Subtype
    {
      get
      {
        return subtype ?? string.Empty;
      }
      set
      {
        subtype = value ?? string.Empty;
      }
    }

    private string condition;
    [Required]
    [StringLength(15, ErrorMessage = "{0} may not exceed {1} characters.")]
    public string Condition
    {
      get
      {
        return condition ?? string.Empty;
      }
      set
      {
        condition = value ?? string.Empty;
      }
    }

    private string rarity;
    [StringLength(25, ErrorMessage = "{0} may not exceed {1} characters.")]
    public string Rarity
    {
      get
      {
        return rarity ?? string.Empty;
      }
      set
      {
        rarity = value ?? string.Empty;
      }
    }

    public Cost Cost { get; set; }

    private string text;
    [StringLength(250, ErrorMessage = "{0} may not exceed {1} characters.")]
    public string Text
    {
      get
      {
        return text ?? string.Empty;
      }
      set
      {
        text = value ?? string.Empty;
      }
    }

    private string flavorText;
    [StringLength(250, ErrorMessage = "{0} may not exceed {1} characters.")]
    public string FlavorText
    {
      get
      {
        return flavorText ?? string.Empty;
      }
      set
      {
        flavorText = value ?? string.Empty;
      }
    }

    private int? power;
    [Range(0, 20, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int? Power
    {
      get
      {
        return power ?? 0;
      }
      set
      {
        power = value ?? 0;
      }
    }

    private int? toughness;
    [Range(0, 20, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int? Toughness
    {
      get
      {
        return toughness ?? 0;
      }
      set
      {
        toughness = value ?? 0;
      }
    }

    [Required]
    public Expansion Expansion { get; set; }

    [Range(0, 500, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int CardNumber { get; set; }

    private string artist;
    [StringLength(250, ErrorMessage = "{0} may not exceed {1} characters.")]
    public string Artist
    {
      get
      {
        return artist ?? string.Empty;
      }
      set
      {
        artist = value ?? string.Empty;
      }
    }
  }

  public class Expansion
  {
    public Expansion()
    {
      Name = Abbreviation = Copyright = string.Empty;
    }

    private string name;
    [Required]
    [StringLength(250, ErrorMessage = "{0} may not exceed {1} characters.")]
    public string Name
    {
      get
      {
        return name ?? string.Empty;
      }
      set
      {
        name = value ?? string.Empty;
      }
    }

    [Range(0, 500, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int TotalCards { get; set; }

    private string abbreviation;
    [StringLength(250, ErrorMessage = "{0} may not exceed {1} characters.")]
    public string Abbreviation
    {
      get
      {
        return abbreviation ?? string.Empty;
      }
      set
      {
        abbreviation = value ?? string.Empty;
      }
    }

    private string copyright;
    [StringLength(250, ErrorMessage = "{0} may not exceed {1} characters.")]
    public string Copyright
    {
      get
      {
        return copyright ?? string.Empty;
      }
      set
      {
        copyright = value ?? string.Empty;
      }
    }
  }

  public class Cost
  {
    public Cost()
    {
      Black = Blue = Colorless = Green = Red = White = 0;
    }

    [Range(0, 15, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int Black { get; set; }

    [Range(0, 15, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int Blue { get; set; }

    [Range(0, 15, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int Colorless { get; set; }

    [Range(0, 90, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int Converted 
    {
      get
      {
        return Blue + Black + Colorless + Green + Red + White;
      }
      set { }
    }

    [Range(0, 15, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int Green { get; set; }

    [Range(0, 15, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int Red { get; set; }

    [Range(0, 15, ErrorMessage = "{0} must be between {1} and {2}.")]
    public int White { get; set; }
  }
}