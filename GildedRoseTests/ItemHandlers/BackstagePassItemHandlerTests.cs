using GildedRoseKata;
using GildedRoseKata.ItemHandlers;
using Xunit;

namespace GildedRoseTests.ItemHandlers
{
    public class BackstagePassItemHandlerTests
    {
        private readonly BackstagePassItemHandler _handler;

        public BackstagePassItemHandlerTests()
        {
            _handler = new BackstagePassItemHandler();
        }

        [Fact]
        public void Update_ItemWithNonMaxQualityAndSellInBeforeFirstBoost_IncresesQualityBy1()
        {
            // arrange
            var sellIn = BackstagePassItemHandler.FirstQualityBoostSellIn + 2;
            var item = new Item { Name = "foo", SellIn = sellIn, Quality = 1 };

            // act
            var result = _handler.Update(item);

            // assert
            Assert.Equal(2, result.Quality);
            Assert.Equal(sellIn - 1, result.SellIn);
        }

        [Fact]
        public void Update_ItemWithNonMaxQualityAndSellInBetweenFirstAndSecondBoost_IncresesQualityWithFirstBoostBonus()
        {
            // arrange
            var sellIn = BackstagePassItemHandler.FirstQualityBoostSellIn;
            var item = new Item { Name = "foo", SellIn = sellIn, Quality = 1 };

            // act
            var result = _handler.Update(item);

            // assert
            Assert.Equal(2 + BackstagePassItemHandler.FirstQualityBoostStepIncrease, result.Quality);
            Assert.Equal(sellIn - 1, result.SellIn);
        }

        [Fact]
        public void Update_ItemWithNonMaxQualityAndPositiveSellInAfterSecondBoost_IncresesQualityWithSecondBoostBonus()
        {
            // arrange
            var sellIn = BackstagePassItemHandler.SecondQualityBoostSellIn;
            var item = new Item { Name = "foo", SellIn = sellIn, Quality = 1 };
            var expectedBoost = BackstagePassItemHandler.FirstQualityBoostStepIncrease + BackstagePassItemHandler.SecondQualityBoostStepIncrease;

            // act
            var result = _handler.Update(item);

            // assert
            Assert.Equal(2 + expectedBoost, result.Quality);
            Assert.Equal(sellIn - 1, result.SellIn);
        }

        [Fact]
        public void Update_ItemWithNonPositiveSellIn_QualityDropsTo0()
        {
            // arrange
            var item = new Item { Name = "foo", SellIn = 0, Quality = 1 };

            // act
            var result = _handler.Update(item);

            // assert
            Assert.Equal(0, result.Quality);
            Assert.Equal(-1, result.SellIn);
        }

        [Theory]
        [InlineData(BackstagePassItemHandler.SecondQualityBoostSellIn)]
        [InlineData(BackstagePassItemHandler.FirstQualityBoostSellIn)]
        [InlineData(BackstagePassItemHandler.FirstQualityBoostSellIn + 2)]
        public void Update_ItemWithMaxQualityAndPositiveSellIn_QualityRemainsMax(int sellIn)
        {
            // arrange
            var item = new Item { Name = "foo", SellIn = sellIn, Quality = ItemConstants.MaxNonLegendaryItemQuality };

            // act
            var result = _handler.Update(item);

            // assert
            Assert.Equal(ItemConstants.MaxNonLegendaryItemQuality, result.Quality);
            Assert.Equal(sellIn - 1, result.SellIn);
        }
    }
}
