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
            _ => new WrappedItem(item)
        };
    }

    public abstract void UpdateItem();

    protected readonly Item Item = item;

    protected void IncreaseQuality(int amount = 1)
    {
        Item.Quality = Math.Min(50, Item.Quality + amount);
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
        if (Item.Quality < 50)
        {
            Item.Quality++;

            if (Item.SellIn < 11)
            {
                IncreaseQuality();
            }

            if (Item.SellIn < 6)
            {
                IncreaseQuality();
            }
        }

        Item.SellIn--;

        if (Item.SellIn < 0)
        {
            Item.Quality -= Item.Quality;
        }
    }
}

public class WrappedItem(Item item) : ShopItem(item)
{
    public override void UpdateItem()
    {
        if (Item.Quality > 0)
        {
            if (Item.Name == "Sulfuras, Hand of Ragnaros")
            {
            }
            else
            {
                Item.Quality--;
            }
        }

        if (Item.Name == "Sulfuras, Hand of Ragnaros")
        {
        }
        else
        {
            Item.SellIn--;
        }

        if (Item.SellIn < 0)
        {
            if (Item.Quality > 0)
            {
                if (Item.Name == "Sulfuras, Hand of Ragnaros") return;
                Item.Quality--;
            }
        }
    }
}