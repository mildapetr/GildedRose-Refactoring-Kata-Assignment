using GildedRoseKata;
using GildedRoseKata.ItemHandlers;
using Xunit;

namespace GildedRoseTests.ItemHandlers
{
    public class LegendaryItemHandlerTests
    {
        private readonly LegendaryItemHandler _handler;

        public LegendaryItemHandlerTests()
        {
            _handler = new LegendaryItemHandler();
        }

        [Fact]
        public void Update_ItemWithMaxQuality_QualityAndSellInRemainsTheSame()
        {
            // arrange
            var item = new Item { Name = "foo", SellIn = 1, Quality = LegendaryItemHandler.LegendaryItemQuality };

            // act
            var result = _handler.Update(item);

            // assert
            Assert.Equal(LegendaryItemHandler.LegendaryItemQuality, result.Quality);
            Assert.Equal(1, result.SellIn);
        }
    }
}
