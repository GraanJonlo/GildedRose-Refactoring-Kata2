namespace GildedRoseKata;

public class WrappedItem(Item item)
{
    public void UpdateItem()
    {
        if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
        {
            if (item.Quality > 0)
            {
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.Quality--;
                }
            }
        }
        else
        {
            if (item.Quality < 50)
            {
                item.Quality++;

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 11)
                    {
                        IncreaseQuality();
                    }

                    if (item.SellIn < 6)
                    {
                        IncreaseQuality();
                    }
                }
            }
        }

        if (item.Name != "Sulfuras, Hand of Ragnaros")
        {
            item.SellIn--;
        }

        if (item.SellIn < 0)
        {
            if (item.Name != "Aged Brie")
            {
                if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            item.Quality--;
                        }
                    }
                }
                else
                {
                    item.Quality -= item.Quality;
                }
            }
            else
            {
                IncreaseQuality();
            }
        }
    }

    private void IncreaseQuality()
    {
        if (item.Quality < 50)
        {
            item.Quality++;
        }
    }
}