using System;

namespace GildedRoseKata;

public abstract class ShopItem(Item item)
{
    public static ShopItem From(Item item)
    {
        return item.Name switch
        {
            "Aged Brie" => new AgedBrie(item),
            "Backstage passes to a TAFKAL80ETC concert" => new BackstagePasses(item),
            "Sulfuras, Hand of Ragnaros" => new Sulfuras(item),
            "Conjured" => new ConjuredItem(item),
            _ => new DefaultItem(item)
        };
    }

    public abstract void UpdateItem();

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

public class AgedBrie(Item item) : ShopItem(item)
{
    public override void UpdateItem()
    {
        Item.SellIn--;

        IncreaseQuality(Item.SellIn >= 0 ? 1 : 2);
    }
}

public class BackstagePasses(Item item) : ShopItem(item)
{
    public override void UpdateItem()
    {
        Item.SellIn--;

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

public class Sulfuras(Item item) : ShopItem(item)
{
    public override void UpdateItem()
    {
    }
}

public class ConjuredItem(Item item) : ShopItem(item)
{
    public override void UpdateItem()
    {
        Item.SellIn--;

        DecreaseQuality(2);
    }
}

public class DefaultItem(Item item) : ShopItem(item)
{
    public override void UpdateItem()
    {
        Item.SellIn--;

        DecreaseQuality(Item.SellIn < 0 ? 2 : 1);
    }
}