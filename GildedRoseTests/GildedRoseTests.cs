using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using Moq;
using GildedRoseKata.ItemHandlers;

namespace GildedRoseTests
{
    public class GildedRoseTests
    {
        [Fact]
        public void UpdateQuality_ListWithOneItem_HandlerUpdatesItem()
        {
            // arrange
            var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };

            var factoryMock = new Mock<IItemHandlerFactory>();
            var handlerMock = new Mock<IItemHandler>();
            factoryMock.Setup(f => f.GetHandler(items[0].Name)).Returns(handlerMock.Object);
            handlerMock.Setup(h => h.Update(items[0])).Returns(items[0]);

            var app = new GildedRose(items, factoryMock.Object);

            // act
            app.UpdateQuality();

            // assert
            factoryMock.Verify(f => f.GetHandler(items[0].Name), Times.Once);
            handlerMock.Verify(h => h.Update(items[0]), Times.Once);
            factoryMock.VerifyNoOtherCalls();
            handlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void UpdateQuality_ListWithMultipleItems_HandlersUpdateItems()
        {
            // arrange
            var items = new List<Item> 
            { 
                new Item { Name = "foo", SellIn = 0, Quality = 0 }, 
                new Item { Name = "foo2", SellIn = 1, Quality = 1 } 
            };

            var factoryMock = new Mock<IItemHandlerFactory>();
            var handlerMock = new Mock<IItemHandler>();
            factoryMock.Setup(f => f.GetHandler(items[0].Name)).Returns(handlerMock.Object);
            factoryMock.Setup(f => f.GetHandler(items[1].Name)).Returns(handlerMock.Object);
            handlerMock.Setup(h => h.Update(items[0])).Returns(items[0]);
            handlerMock.Setup(h => h.Update(items[1])).Returns(items[1]);

            var app = new GildedRose(items, factoryMock.Object);

            // act
            app.UpdateQuality();

            // assert
            factoryMock.Verify(f => f.GetHandler(items[0].Name), Times.Once);
            factoryMock.Verify(f => f.GetHandler(items[1].Name), Times.Once);
            handlerMock.Verify(h => h.Update(items[0]), Times.Once);
            handlerMock.Verify(h => h.Update(items[1]), Times.Once);
            factoryMock.VerifyNoOtherCalls();
            handlerMock.VerifyNoOtherCalls();
        }
    }
}
