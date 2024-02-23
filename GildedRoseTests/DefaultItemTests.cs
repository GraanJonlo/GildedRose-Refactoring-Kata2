using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class DefaultItemTests
{
    [TestCase(1, 0)]
    [TestCase(0, -1)]
    public void ItShouldDecreaseSellIn(int initialSellIn, int expectedSellIn)
    {
        Item item = new Item { Name = "foo", SellIn = initialSellIn, Quality = 0 };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.SellIn, Is.EqualTo(expectedSellIn));
    }

    [TestCase(2, 1)]
    [TestCase(1, 0)]
    public void ItShouldDecreaseQuality(int initialQuality, int expectedQuality)
    {
        Item item = new Item { Name = "foo", SellIn = 1, Quality = initialQuality };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(0, 0)]
    [TestCase(-1, 0)]
    public void ItShouldDecreaseQualityTwiceAsFastAfterSellIn(int initialSellIn, int expectedQuality)
    {
        Item item = new Item { Name = "foo", SellIn = initialSellIn, Quality = 2 };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(0, 0)]
    [TestCase(-1, 0)]
    public void ItShouldNotDecreaseQualityBelowZero(int initialSellIn, int expectedQuality)
    {
        Item item = new Item { Name = "foo", SellIn = initialSellIn, Quality = 0 };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(expectedQuality));
    }
}