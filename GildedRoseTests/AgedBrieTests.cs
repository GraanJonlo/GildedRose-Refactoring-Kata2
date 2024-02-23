using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class AgedBrieTests
{
    [TestCase(2,1)]
    [TestCase(1,0)]
    [TestCase(0, -1)]
    public void ItShouldDecreaseSellIn(int initialSellIn, int expectedSellIn)
    {
        Item item = new Item { Name = "Aged Brie", SellIn = initialSellIn, Quality = 0 };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.SellIn, Is.EqualTo(expectedSellIn));
    }

    [TestCase(48, 49)]
    [TestCase(49, 50)]
    public void ItShouldIncreaseQuality(int initialQuality, int expectedQuality)
    {
        Item item = new Item { Name = "Aged Brie", SellIn = 1, Quality = initialQuality };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(expectedQuality));
    }

    [Test]
    public void ItShouldIncreaseInQualityTwiceAsFastWhenPastSellIn()
    {
        Item item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(2));
    }

    [Test]
    public void ItShouldNotIncreaseQualityAbove50()
    {
        Item item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(50));
    }
}