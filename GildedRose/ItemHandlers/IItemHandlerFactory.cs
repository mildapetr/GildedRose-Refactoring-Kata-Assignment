namespace GildedRoseKata.ItemHandlers
{
    public interface IItemHandlerFactory
    {
        // Now concrete item handler is chosen based on item name, but most likely we'd want to have item types.
        // For example, Sulfuras may not necessarily be the only legendary item; other legendary items with 
        // different names could exist. Knowing that we can't edit Item class and add a type property there,
        // we could have a dedicated dictionary, which maps known item names to types (possibly have an enum for
        // types, too), and then choose the item handler based on the item type.

        public const string AgedBrieItemName = "Aged Brie";
        public const string SulfurasItemName = "Sulfuras, Hand of Ragnaros";
        public const string BackstagePassItemName = "Backstage passes to a TAFKAL80ETC concert";
        public const string ConjuredItemName = "Conjured Mana Cake";

        IItemHandler GetHandler(string itemName);
    }
}
