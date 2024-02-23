using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class BackstagePassesTests
{
    [TestCase(2, 1)]
    [TestCase(1, 0)]
    [TestCase(0, -1)]
    public void ItShouldDecreaseSellIn(int initialSellIn, int expectedSellIn)
    {
        Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = initialSellIn, Quality = 0 };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.SellIn, Is.EqualTo(expectedSellIn));
    }

    [TestCase(48, 49)]
    [TestCase(49, 50)]
    public void ItShouldIncreaseQuality(int initialQuality, int expectedQuality)
    {
        Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = initialQuality };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(10)]
    [TestCase(6)]
    public void ItShouldIncreaseQualityByTwoWhenSellInIsTenOrLess(int initialSellIn)
    {
        Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = initialSellIn, Quality = 0 };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(2));
    }

    [TestCase(5)]
    [TestCase(1)]
    public void ItShouldIncreaseQualityByThreeWhenSellInIsFiveOrLess(int initialSellIn)
    {
        Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = initialSellIn, Quality = 0 };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(3));
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void ItShouldDropQualityToZeroAfterTheConcert(int initialSellIn)
    {
        Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = initialSellIn, Quality = 50 };

        GildedRose gildedRose = new GildedRose(new List<Item> { item });
        gildedRose.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(0));
    }
}