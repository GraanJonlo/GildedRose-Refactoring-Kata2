namespace GildedRoseKata;

public abstract class ShopItem(Item item)
{
    public static ShopItem From(Item item)
    {
        return item.Name switch
        {
            "Aged Brie" => new AgedBrie(item),
            _ => new WrappedItem(item)
        };
    }

    public abstract void UpdateItem();

    protected readonly Item Item = item;

    protected void IncreaseQuality()
    {
        if (Item.Quality < 50)
        {
            Item.Quality++;
        }
    }
}

public class AgedBrie(Item item) : ShopItem(item)
{
    public override void UpdateItem()
    {
        IncreaseQuality();

        Item.SellIn--;

        if (Item.SellIn < 0)
        {
            IncreaseQuality();
        }
    }
}

public class WrappedItem(Item item) : ShopItem(item)
{
    public override void UpdateItem()
    {
        if (Item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            if (Item.Quality < 50)
            {
                Item.Quality++;

                if (Item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Item.SellIn < 11)
                    {
                        IncreaseQuality();
                    }

                    if (Item.SellIn < 6)
                    {
                        IncreaseQuality();
                    }
                }
            }
        }
        else
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
            if (Item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                Item.Quality -= Item.Quality;
            }
            else
            {
                if (Item.Quality > 0)
                {
                    if (Item.Name == "Sulfuras, Hand of Ragnaros") return;
                    Item.Quality--;
                }
            }
        }
    }
}