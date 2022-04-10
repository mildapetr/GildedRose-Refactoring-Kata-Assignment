using System;

namespace GildedRoseKata.ItemHandlers
{
    public class CommonItemHandler : IItemHandler
    {
        public Item Update(Item item)
        {
            item.SellIn--;

            var qualityDecreseStep = item.SellIn < 0 ? 2 : 1;
            item.Quality = Math.Max(item.Quality - qualityDecreseStep, 0);

            return item;
        }
    }
}
