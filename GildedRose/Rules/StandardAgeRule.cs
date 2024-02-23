namespace GildedRoseKata.Rules;

public class StandardAgeRule : IAgeRule
{
    public void ApplyTo(Item item)
    {
        item.SellIn--;
    }
}