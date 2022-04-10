using GildedRoseKata;
using GildedRoseKata.ItemHandlers;
using Xunit;

namespace GildedRoseTests.ItemHandlers
{
    public class AgedBrieHandlerTests
    {
        private readonly AgedBrieHandler _handler;

        public AgedBrieHandlerTests()
        {
            _handler = new AgedBrieHandler();
        }

        [Fact]
        public void Update_ItemWithNonMaxQualityAndPositiveSellIn_IncresesQualityByDefaultStep()
        {
            // arrange
            var item = new Item { Name = "foo", SellIn = 1, Quality = 1 };

            // act
            var result = _handler.Update(item);

            // assert
            Assert.Equal(1 + AgedBrieHandler.DefaultQualityIncreaseStep, result.Quality);
            Assert.Equal(0, result.SellIn);
        }

        [Fact]
        public void Update_ItemWithNonMaxQualityAndNonPositiveSellIn_IncresesQualityByDoubleStep()
        {
            // arrange
            var item = new Item { Name = "foo", SellIn = 0, Quality = 2 };

            // act
            var result = _handler.Update(item);

            // assert
            Assert.Equal(2 + AgedBrieHandler.DefaultQualityIncreaseStep * 2, result.Quality);
            Assert.Equal(-1, result.SellIn);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public void Update_ItemWithMaxQuality_QualityRemainsMax(int sellIn)
        {
            // arrange
            var item = new Item { Name = "foo", SellIn = sellIn, Quality = IItemHandler.MaxNonLegendaryItemQuality };

            // act
            var result = _handler.Update(item);

            // assert
            Assert.Equal(IItemHandler.MaxNonLegendaryItemQuality, result.Quality);
            Assert.Equal(sellIn - 1, result.SellIn);
        }
    }
}
