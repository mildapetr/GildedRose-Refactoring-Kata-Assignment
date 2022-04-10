using System;

namespace GildedRoseKata.ItemHandlers
{
    public class AgedBrieHandler : IItemHandler
    {
        public Item Update(Item item)
        {
            item.SellIn--;

            var qualityIncreaseStep = item.SellIn < 0 ? 2 : 1;
            item.Quality = Math.Min(item.Quality + qualityIncreaseStep, ItemConstants.MaxNonLegendaryItemQuality);

            return item;
        }
    }
}
