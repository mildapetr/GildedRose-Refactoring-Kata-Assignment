using System;

namespace GildedRoseKata.ItemHandlers
{
    public class AgedBrieHandler : IItemHandler
    {
        public const int DefaultQualityIncreaseStep = 1;

        public Item Update(Item item)
        {
            item.SellIn--;

            var qualityIncreaseStep = item.SellIn < 0 ? DefaultQualityIncreaseStep * 2 : DefaultQualityIncreaseStep;
            item.Quality = Math.Min(item.Quality + qualityIncreaseStep, ItemConstants.MaxNonLegendaryItemQuality);

            return item;
        }
    }
}
