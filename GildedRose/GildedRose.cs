using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            ShopItem shopItem = ShopItem.From(item);
            shopItem.UpdateItem();
        }
    }
}