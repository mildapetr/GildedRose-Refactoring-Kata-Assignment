using GildedRoseKata.ItemHandlers;
using System;
using Xunit;

namespace GildedRoseTests.ItemHandlers
{
    public class ItemHandlerFactoryTests
    {
        private readonly ItemHandlerFactory _factory;

        public ItemHandlerFactoryTests()
        {
            _factory = new ItemHandlerFactory();
        }

        [Theory]
        [InlineData("Sulfuras, Hand of Ragnaros", typeof(LegendaryItemHandler))]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", typeof(BackstagePassItemHandler))]
        [InlineData("Conjured Mana Cake", typeof(ConjuredItemHandler))]
        [InlineData("Aged Brie", typeof(AgedBrieHandler))]
        [InlineData("foo", typeof(CommonItemHandler))]
        public void GetHandler_ItemName_ReturnsItemHandlerByName(string inputItemName, Type expectedType)
        {
            // act
            var result = _factory.GetHandler(inputItemName);

            // assert
            Assert.True(result.GetType() == expectedType);
        }
    }
}
