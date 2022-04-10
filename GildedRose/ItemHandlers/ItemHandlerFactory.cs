namespace GildedRoseKata.ItemHandlers
{
    public class ItemHandlerFactory : IItemHandlerFactory
    {
        public IItemHandler GetHandler(string itemName)
        {
            return itemName switch
            {
                IItemHandlerFactory.AgedBrieItemName => new AgedBrieHandler(),
                IItemHandlerFactory.BackstagePassItemName => new BackstagePassItemHandler(),
                IItemHandlerFactory.ConjuredItemName => new ConjuredItemHandler(),
                IItemHandlerFactory.SulfurasItemName => new LegendaryItemHandler(),
                _ => new CommonItemHandler(),
            };
        }
    }
}
