namespace Cardalog.Models
{
  public class Card
  {
    public string Title { get; set; }
    public string Type { get; set; }
    public string Subtype { get; set; }
    public string Rarity { get; set; }
    public string Cost { get; set; }
    public int? ConvertedCost { get; set; }
    public string Text { get; set; }
    public string FlavorText { get; set; }
    public int? Power { get; set; }
    public int? Toughness { get; set; }
    public Expansion Expansion { get; set; }
    public int? CardNumber { get; set; }
    public string Artist { get; set; }
    public string Copyright { get; set; }
  }

  public class Expansion
  {
    public string Name { get; set; }
    public int? TotalCards { get; set; }
    public string Abbreviation { get; set; }
    public string Copyright { get; set; }
  }
}