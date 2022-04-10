using System;

namespace GildedRoseKata.ItemHandlers
{
    public class CommonItemHandler : IItemHandler
    {
        public const int DefaultQualityDecreaseStep = 1;

        public Item Update(Item item)
        {
            item.SellIn--;

            var qualityDecreseStep = item.SellIn < 0 ? DefaultQualityDecreaseStep * 2 : DefaultQualityDecreaseStep;
            item.Quality = Math.Max(item.Quality - qualityDecreseStep, 0);

            return item;
        }
    }
}
