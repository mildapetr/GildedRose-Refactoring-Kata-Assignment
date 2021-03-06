using GildedRoseKata;
using GildedRoseKata.ItemHandlers;
using Xunit;

namespace GildedRoseTests.ItemHandlers
{
    public class ConjuredItemHandlerTests
    {
        private readonly ConjuredItemHandler _handler;

        public ConjuredItemHandlerTests()
        {
            _handler = new ConjuredItemHandler();
        }

        [Fact]
        public void Update_ItemWithPositiveQualityAndSellIn_DecresesQualityByDefaultStep()
        {
            // arrange
            var item = new Item { Name = "foo", SellIn = 1, Quality = 2 };

            // act
            var result = _handler.Update(item);

            // assert
            Assert.Equal(2 - CommonItemHandler.DefaultQualityDecreaseStep * ConjuredItemHandler.QualityDecreaseStepMultiplier, 
                result.Quality);
            Assert.Equal(0, result.SellIn);
        }

        [Fact]
        public void Update_ItemWithNonPositiveSellInAndPositiveQuality_DecresesQualityByDoubleStep()
        {
            // arrange
            var item = new Item { Name = "foo", SellIn = 0, Quality = 4 };

            // act
            var result = _handler.Update(item);

            // assert
            Assert.Equal(4 - CommonItemHandler.DefaultQualityDecreaseStep * ConjuredItemHandler.QualityDecreaseStepMultiplier * 2, 
                result.Quality);
            Assert.Equal(-1, result.SellIn);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public void Update_ItemWith0Quality_QualityRemains0(int sellIn)
        {
            // arrange
            var item = new Item { Name = "foo", SellIn = sellIn, Quality = 0 };

            // act
            var result = _handler.Update(item);

            // assert
            Assert.Equal(0, result.Quality);
            Assert.Equal(sellIn - 1, result.SellIn);
        }
    }
}
