namespace GildedRoseKata.ItemHandlers
{
    public class LegendaryItemHandler : IItemHandler
    {
        public Item Update(Item item)
        {
            item.Quality = ItemConstants.LegendaryItemQuality;

            return item;
        }
    }
}
