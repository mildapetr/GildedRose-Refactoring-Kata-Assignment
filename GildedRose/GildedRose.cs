using GildedRoseKata.ItemHandlers;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;

        // I wasn't sure I could add an additional field to this class, but this was for the purpose of mocking.
        // This solution would function properly if factory was instantiated in UpdateQuality method in case I couldn't
        // edit this class's fields and constructors (obviously, tests would be affected as mocking would be difficult,
        // but the flow would work the same way).
        private readonly IItemHandlerFactory _itemHandlerFactory;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            _itemHandlerFactory = new ItemHandlerFactory();
        }

        public GildedRose(IList<Item> Items, IItemHandlerFactory itemHandlerFactory)
        {
            this.Items = Items;
            _itemHandlerFactory = itemHandlerFactory;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var handler = _itemHandlerFactory.GetHandler(item.Name);
                handler.Update(item);
            }
        }
    }
}
