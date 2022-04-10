using GildedRoseKata;
using GildedRoseKata.ItemHandlers;
using Xunit;

namespace GildedRoseTests.ItemHandlers
{
    public class CommonItemHandlerTests
    {
        private readonly CommonItemHandler _handler;

        public CommonItemHandlerTests()
        {
            _handler = new CommonItemHandler();
        }

        [Fact]
        public void Update_ItemWithPositiveQualityAndSellIn_DecresesQualityAndSellInBy1()
        {
            // arrange
            var item = new Item { Name = "foo", SellIn = 1, Quality = 1 };

            // act
            var result = _handler.Update(item);

            // assert
            Assert.Equal(0, result.Quality);
            Assert.Equal(0, result.SellIn);
        }

        [Fact]
        public void Update_ItemWithNonPositiveSellIn_DecresesQualityBy2()
        {
            // arrange
            var item = new Item { Name = "foo", SellIn = 0, Quality = 2 };

            // act
            var result = _handler.Update(item);

            // assert
            Assert.Equal(0, result.Quality);
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
