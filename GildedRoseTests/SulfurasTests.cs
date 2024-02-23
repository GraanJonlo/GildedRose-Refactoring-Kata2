using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class SulfurasTests
{
    [Test]
    public void ItShouldNotDecreaseSellIn()
    {
        Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.SellIn, Is.EqualTo(1));
    }

    [Test]
    public void ItShouldNotDecreaseQuality()
    {
        Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(80));
    }
}