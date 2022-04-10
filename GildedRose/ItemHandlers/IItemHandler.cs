namespace GildedRoseKata.ItemHandlers
{
    public interface IItemHandler
    {
        public const int MaxNonLegendaryItemQuality = 50;

        Item Update(Item item);
    }
}
