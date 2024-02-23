using GildedRoseKata;

namespace GildedRose.Rules;

public class StandardAgeRule : IAgeRule
{
    public void ApplyTo(Item item)
    {
        item.SellIn--;
    }
}