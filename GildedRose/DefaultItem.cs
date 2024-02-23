using System;
using GildedRoseKata.Rules;

namespace GildedRoseKata;

public abstract class ShopItem(Item item, IAgeRule ageRule)
{
    public static ShopItem From(Item item)
    {
        return item.Name switch
        {
            "Aged Brie" => new AgedBrie(item, new StandardAgeRule()),
            "Backstage passes to a TAFKAL80ETC concert" => new BackstagePasses(item, new StandardAgeRule()),
            "Sulfuras, Hand of Ragnaros" => new Sulfuras(item, new DoesNotAgeRule()),
            "Conjured" => new ConjuredItem(item, new StandardAgeRule()),
            _ => new DefaultItem(item, new StandardAgeRule())
        };
    }

    public void UpdateItem()
    {
        ageRule.ApplyTo(Item);

        AdjustQuality();
    }

    protected abstract void AdjustQuality();

    protected readonly Item Item = item;

    protected void IncreaseQuality(int amount = 1)
    {
        Item.Quality = Math.Min(50, Item.Quality + amount);
    }

    protected void DecreaseQuality(int amount = 1)
    {
        Item.Quality = Math.Max(0, Item.Quality - amount);
    }
}

public class AgedBrie(Item item, IAgeRule ageRule) : ShopItem(item, ageRule)
{
    protected override void AdjustQuality()
    {
        IncreaseQuality(Item.SellIn >= 0 ? 1 : 2);
    }
}

public class BackstagePasses(Item item, IAgeRule ageRule) : ShopItem(item, ageRule)
{
    protected override void AdjustQuality()
    {
        if (Item.SellIn < 0)
        {
            Item.Quality = 0;
        }
        else
        {
            int amountToIncreaseQuality = Item.SellIn switch
            {
                < 5 => 3,
                < 10 => 2,
                _ => 1
            };

            IncreaseQuality(amountToIncreaseQuality);
        }
    }
}

public class Sulfuras(Item item, IAgeRule ageRule) : ShopItem(item, ageRule)
{
    protected override void AdjustQuality()
    {
    }
}

public class ConjuredItem(Item item, IAgeRule ageRule) : ShopItem(item, ageRule)
{
    protected override void AdjustQuality()
    {
        DecreaseQuality(Item.SellIn < 0 ? 4 : 2);
    }
}

public class DefaultItem(Item item, IAgeRule ageRule) : ShopItem(item, ageRule)
{
    protected override void AdjustQuality()
    {
        DecreaseQuality(Item.SellIn < 0 ? 2 : 1);
    }
}