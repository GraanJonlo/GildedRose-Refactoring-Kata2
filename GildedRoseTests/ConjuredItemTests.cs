using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class ConjuredItemTests
{
    [TestCase(2, 1)]
    [TestCase(1, 0)]
    [TestCase(0, -1)]
    public void ItShouldDecreaseSellIn(int initialSellIn, int expectedSellIn)
    {
        Item item = new Item { Name = "Conjured", SellIn = initialSellIn, Quality = 0 };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.SellIn, Is.EqualTo(expectedSellIn));
    }

    [TestCase(4, 2)]
    [TestCase(2, 0)]
    public void ItShouldDecreaseQualityTwiceAsFast(int initialQuality, int expectedQuality)
    {
        Item item = new Item { Name = "Conjured", SellIn = 1, Quality = initialQuality };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(expectedQuality));
    }

    [Test]
    public void ItShouldNotDecreaseQualityBelowZero()
    {
        Item item = new Item { Name = "Conjured", SellIn = 1, Quality = 1 };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(0));
    }

    [TestCase(8, 4)]
    [TestCase(4, 0)]
    public void ItShouldDecreaseQualityTwiceAsFastAfterSellIn(int initialQuality, int expectedQuality)
    {
        Item item = new Item { Name = "Conjured", SellIn = 0, Quality = initialQuality };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(expectedQuality));
    }
}