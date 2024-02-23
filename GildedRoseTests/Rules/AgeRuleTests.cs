using GildedRose.Rules;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests.Rules;

public class AgeRuleTests
{
    [TestCase(1, 0)]
    [TestCase(0, -1)]
    [TestCase(-1, -2)]
    public void StandardAgeRuleShouldDecreaseSellIn(int initialSellIn, int expectedSellIn)
    {
        Item item = new Item { Name = "foo", SellIn = initialSellIn, Quality = 0 };

        IAgeRule ageRule = new StandardAgeRule();
        ageRule.ApplyTo(item);

        Assert.That(item.SellIn, Is.EqualTo(expectedSellIn));
    }

    [TestCase(1)]
    [TestCase(0)]
    [TestCase(-1)]
    public void DoesNotAgeRuleShouldNotDecreaseSellIn(int initialSellIn)
    {
        Item item = new Item { Name = "bar", SellIn = initialSellIn, Quality = 0 };

        IAgeRule ageRule = new DoesNotAgeRule();
        ageRule.ApplyTo(item);

        Assert.That(item.SellIn, Is.EqualTo(initialSellIn));
    }
}