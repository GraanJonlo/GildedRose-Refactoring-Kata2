namespace GildedRoseKata;

public class WrappedItem(Item item)
{
    public void UpdateItem()
    {
        if (item.Name == "Aged Brie")
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                IncreaseQuality();
            }
        }
        else
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
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
            else
            {
                if (item.Quality > 0)
                {
                    if (item.Name == "Sulfuras, Hand of Ragnaros")
                    {
                    }
                    else
                    {
                        item.Quality--;
                    }
                }
            }

            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
            }
            else
            {
                item.SellIn--;
            }

            if (item.SellIn < 0)
            {
                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    item.Quality -= item.Quality;
                }
                else
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name == "Sulfuras, Hand of Ragnaros") return;
                        item.Quality--;
                    }
                }
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