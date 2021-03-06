using System;

namespace GildedRoseKata.ItemHandlers
{
    public class BackstagePassItemHandler : IItemHandler
    {
        public const int DefaultQualityIncreaseStep = 1;
        // first period when backstage pass increases in quality
        public const int FirstQualityBoostSellIn = 10;
        public const int FirstQualityBoostStepIncrease = 1;
        // second period when backstage pass increases in quality
        public const int SecondQualityBoostSellIn = 5;
        public const int SecondQualityBoostStepIncrease = 1;

        public Item Update(Item item)
        {
            int qualityIncreaseStep = DefaultQualityIncreaseStep;
            if (item.SellIn <= FirstQualityBoostSellIn)
            {
                qualityIncreaseStep += FirstQualityBoostStepIncrease;
            }
            if (item.SellIn <= SecondQualityBoostSellIn)
            {
                qualityIncreaseStep += SecondQualityBoostStepIncrease;
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
            else
            {
                item.Quality = Math.Min(item.Quality + qualityIncreaseStep, IItemHandler.MaxNonLegendaryItemQuality);
            }

            return item;
        }
    }
}
