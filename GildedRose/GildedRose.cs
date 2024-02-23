﻿using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            UpdateItem(item);
        }
    }

    private static void UpdateItem(Item item)
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
                        IncreaseQuality(item);
                    }

                    if (item.SellIn < 6)
                    {
                        IncreaseQuality(item);
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
                IncreaseQuality(item);
            }
        }
    }

    private static void IncreaseQuality(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality++;
        }
    }
}