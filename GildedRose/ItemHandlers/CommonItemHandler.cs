using System;

namespace GildedRoseKata.ItemHandlers
{
    public class CommonItemHandler : IItemHandler
    {
        public const int DefaultQualityDecreaseStep = 1;

        private readonly int _qualityDecreaseStep;

        public CommonItemHandler()
        {
            _qualityDecreaseStep = DefaultQualityDecreaseStep;
        }

        protected CommonItemHandler(int qualityDecreaseStep)
        {
            _qualityDecreaseStep = qualityDecreaseStep;
        }

        public Item Update(Item item)
        {
            item.SellIn--;

            var qualityDecreseStep = item.SellIn < 0 ? _qualityDecreaseStep * 2 : _qualityDecreaseStep;
            item.Quality = Math.Max(item.Quality - qualityDecreseStep, 0);

            return item;
        }
    }
}
