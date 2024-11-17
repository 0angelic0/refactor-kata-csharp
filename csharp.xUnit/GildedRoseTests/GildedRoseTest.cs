using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
    }

    [Fact]
    public void TestBasicQualityAndSellInDegradation()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
        Assert.Equal(9, Items[0].SellIn);
        Assert.Equal(9, Items[0].Quality);
    }

    [Fact]
    public void TestBasicQualityNeverNegative()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 2, Quality = 2 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
        Assert.Equal(1, Items[0].SellIn);
        Assert.Equal(1, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(0, Items[0].SellIn);
        Assert.Equal(0, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(-1, Items[0].SellIn);
        Assert.Equal(0, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(-2, Items[0].SellIn);
        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void TestSellInHasPassedQualityDegradeDouble()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
        Assert.Equal(0, Items[0].SellIn);
        Assert.Equal(19, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(-1, Items[0].SellIn);
        Assert.Equal(17, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(-2, Items[0].SellIn);
        Assert.Equal(15, Items[0].Quality);
    }

    [Fact]
    public void TestQualityShouldNotBeNegative()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 2 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
        Assert.Equal(9, Items[0].SellIn);
        Assert.Equal(1, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(8, Items[0].SellIn);
        Assert.Equal(0, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(7, Items[0].SellIn);
        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void TestAgedBrieQualityWillGoUp()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 3, Quality = 2 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();
        Assert.Equal("Aged Brie", Items[0].Name);
        Assert.Equal(2, Items[0].SellIn);
        Assert.Equal(3, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(1, Items[0].SellIn);
        Assert.Equal(4, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(0, Items[0].SellIn);
        Assert.Equal(5, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(-1, Items[0].SellIn);
        Assert.Equal(7, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(-2, Items[0].SellIn);
        Assert.Equal(9, Items[0].Quality);
    }

     [Fact]
    public void TestItemShouldNotHaveQualityAbove50()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 52 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
        Assert.Equal(9, Items[0].SellIn);
        Assert.Equal(51, Items[0].Quality);
    }

    [Fact]
    public void TestAgedBrieQualityWillGoUpAndShouldNotAbove50()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 48 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();
        Assert.Equal("Aged Brie", Items[0].Name);
        Assert.Equal(9, Items[0].SellIn);
        Assert.Equal(49, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(8, Items[0].SellIn);
        Assert.Equal(50, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(7, Items[0].SellIn);
        Assert.Equal(50, Items[0].Quality);
    }

    [Fact]
    public void TestBackstagePassesQualityWillGoUpAndShouldNotAbove50()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 48 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();
        Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
        Assert.Equal(9, Items[0].SellIn);
        Assert.Equal(50, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(8, Items[0].SellIn);
        Assert.Equal(50, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(7, Items[0].SellIn);
        Assert.Equal(50, Items[0].Quality);
    }

    [Fact]
    public void TestSulfurasQualityWillNeverChange()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();
        Assert.Equal("Sulfuras, Hand of Ragnaros", Items[0].Name);
        Assert.Equal(10, Items[0].SellIn);
        Assert.Equal(10, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(10, Items[0].SellIn);
        Assert.Equal(10, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(10, Items[0].SellIn);
        Assert.Equal(10, Items[0].Quality);
    }

    [Fact]
    public void TestBackstagePassesQualityWillGoUp()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 10 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();
        Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
        Assert.Equal(11, Items[0].SellIn);
        Assert.Equal(11, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(10, Items[0].SellIn);
        Assert.Equal(12, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(9, Items[0].SellIn);
        Assert.Equal(14, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(8, Items[0].SellIn);
        Assert.Equal(16, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(7, Items[0].SellIn);
        Assert.Equal(18, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(6, Items[0].SellIn);
        Assert.Equal(20, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(5, Items[0].SellIn);
        Assert.Equal(22, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(4, Items[0].SellIn);
        Assert.Equal(25, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(3, Items[0].SellIn);
        Assert.Equal(28, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(2, Items[0].SellIn);
        Assert.Equal(31, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(1, Items[0].SellIn);
        Assert.Equal(34, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(0, Items[0].SellIn);
        Assert.Equal(37, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(-1, Items[0].SellIn);
        Assert.Equal(0, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(-2, Items[0].SellIn);
        Assert.Equal(0, Items[0].Quality);
    }
    [Fact]
    public void TestConjuredDecreaseQualityTwice() {
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 10 } };
        GildedRose app = new GildedRose(Items);

        app.UpdateQuality();
        Assert.Equal("Conjured Mana Cake", Items[0].Name);
        Assert.Equal(9, Items[0].SellIn);
        Assert.Equal(8, Items[0].Quality);
    }

    [Fact]
    public void TestConjuredSellInHasPassedQualityDegradeDouble()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 1, Quality = 10 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("Conjured Mana Cake", Items[0].Name);
        Assert.Equal(0, Items[0].SellIn);
        Assert.Equal(8, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(-1, Items[0].SellIn);
        Assert.Equal(4, Items[0].Quality);

        app.UpdateQuality();
        Assert.Equal(-2, Items[0].SellIn);
        Assert.Equal(0, Items[0].Quality);
    }
}