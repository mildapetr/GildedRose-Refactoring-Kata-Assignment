namespace GildedRoseKata.ItemHandlers
{
    public class LegendaryItemHandler : IItemHandler
    {
        public const int LegendaryItemQuality = 80;

        public Item Update(Item item)
        {
            item.Quality = LegendaryItemQuality;

            return item;
        }
    }
}
