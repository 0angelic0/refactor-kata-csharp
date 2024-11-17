using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;
    public static int MaximumQuality = 50;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQualityFormulaNormalItem(Item item)
    {
        if (item.SellIn <= 0)
        {
            item.Quality = item.Quality - 2;
        }
        else
        {
            item.Quality = item.Quality - 1;
        }
        ValidateMinimumQuality(item);
        item.SellIn = item.SellIn - 1;
    }

    public void UpdateQualityFormulaUpgradeItem(Item item)
    {
        if (item.Quality < MaximumQuality)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = item.Quality + 2;
            }
            else
            {
                item.Quality = item.Quality + 1;
            }
        }
        item.SellIn = item.SellIn - 1;
    }

    public void UpdateQualityFormulaLegendaryItem(Item item)
    {
        item.SellIn = item.SellIn;
        item.Quality = item.Quality;
    }

    public void UpdateQualityFormulaConcertTicketItem(Item item)
    {
        if (item.SellIn <= 5)
        {
            item.Quality = item.Quality + 3;
        }
        else if (item.SellIn <= 10)
        {
            item.Quality = item.Quality + 2;
        }
        else
        {
            item.Quality = item.Quality + 1;
        }
        if (item.Quality > MaximumQuality)
        {
            item.Quality = MaximumQuality;
        }
        if (item.SellIn <= 0)
        {
            item.Quality = 0;
        }
        item.SellIn = item.SellIn - 1;
    }

    public void UpdateQualityFormulaTwiceDegradeItem(Item item)
    {
        if (item.Quality > 0)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = item.Quality - 4;
            }
            else
            {
                item.Quality = item.Quality - 2;
            }
        }
        ValidateMinimumQuality(item);
        item.SellIn = item.SellIn - 1;
    }

    public void ValidateMinimumQuality(Item item)
    {
        if(item.Quality <0){
            item.Quality =0;
        }
    }



    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            switch (Items[i].Name)
            {
                case "Aged Brie":
                    UpdateQualityFormulaUpgradeItem(Items[i]);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateQualityFormulaConcertTicketItem(Items[i]);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    UpdateQualityFormulaLegendaryItem(Items[i]);
                    break;
                case "Conjured Mana Cake":
                    UpdateQualityFormulaTwiceDegradeItem(Items[i]);
                    break;
                default:
                    UpdateQualityFormulaNormalItem(Items[i]);
                    break;
            }
        }


        // for (var i = 0; i < Items.Count; i++)
        // {
        //     if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //     {
        //         if (Items[i].Quality > 0)
        //         {
        //             if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //             {
        //                 Items[i].Quality = Items[i].Quality - 1;
        //             }
        //         }
        //     }
        //     else
        //     {
        //         if (Items[i].Quality < 50)
        //         {
        //             Items[i].Quality = Items[i].Quality + 1;

        //             if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
        //             {
        //                 if (Items[i].SellIn < 11)
        //                 {
        //                     if (Items[i].Quality < 50)
        //                     {
        //                         Items[i].Quality = Items[i].Quality + 1;
        //                     }
        //                 }

        //                 if (Items[i].SellIn < 6)
        //                 {
        //                     if (Items[i].Quality < 50)
        //                     {
        //                         Items[i].Quality = Items[i].Quality + 1;
        //                     }
        //                 }
        //             }
        //         }
        //     }

        //     if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //     {
        //         Items[i].SellIn = Items[i].SellIn - 1;
        //     }

        //     if (Items[i].SellIn < 0)
        //     {
        //         if (Items[i].Name != "Aged Brie")
        //         {
        //             if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //             {
        //                 if (Items[i].Quality > 0)
        //                 {
        //                     if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //                     {
        //                         Items[i].Quality = Items[i].Quality - 1;
        //                     }
        //                 }
        //             }
        //             else
        //             {
        //                 Items[i].Quality = Items[i].Quality - Items[i].Quality;
        //             }
        //         }
        //         else
        //         {
        //             if (Items[i].Quality < 50)
        //             {
        //                 Items[i].Quality = Items[i].Quality + 1;
        //             }
        //         }
        //     }
        // }
    }
}