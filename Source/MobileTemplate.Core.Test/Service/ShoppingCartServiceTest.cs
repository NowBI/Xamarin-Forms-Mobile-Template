using System;
using MobileTemplate.Core.Model.Shopping;
using MobileTemplate.Core.Services.Shopping;
using Xunit;

namespace MobileTemplate.Core.Test.Service
{
    public class ShoppingCartServiceTest
    {
        private readonly IShoppingCartService _shoppingCartService;

        private readonly ShoppingItemModel _shoppingItemA;
        private readonly ShoppingItemModel _shoppingItemB;

        public ShoppingCartServiceTest()
        {
            _shoppingCartService = new ShoppingCartService();

            _shoppingItemA = new ShoppingItemModel { Id = Guid.NewGuid(), Name = "Item A", Description = "Description A", Price = 5.0 };
            _shoppingItemB = new ShoppingItemModel { Id = Guid.NewGuid(), Name = "Item B", Description = "Description B", Price = 250.0 };
        }

        [Fact]
        public void AddItem_WithNoQuantity_ShouldAddOneItem()
        {
            Assert.Empty(_shoppingCartService.Items.Value);
            _shoppingCartService.AddItem(_shoppingItemA);
            Assert.NotEmpty(_shoppingCartService.Items.Value);
            Assert.Equal(1, _shoppingCartService.Items.Value[_shoppingItemA]);
        }

        [Fact]
        public void AddItem_WithQuantity_ShouldAddThatManyItems()
        {
            var quantity = 56;
            Assert.Empty(_shoppingCartService.Items.Value);
            _shoppingCartService.AddItem(_shoppingItemA, quantity);
            Assert.NotEmpty(_shoppingCartService.Items.Value);
            Assert.Equal(quantity, _shoppingCartService.Items.Value[_shoppingItemA]);
        }

        [Fact]
        public void AddItem_MultipleTimes_ShouldBeCumulative()
        {
            var quantityA = 56;

            Assert.Empty(_shoppingCartService.Items.Value);
            _shoppingCartService.AddItem(_shoppingItemA, quantityA);
            Assert.NotEmpty(_shoppingCartService.Items.Value);
            Assert.Equal(quantityA, _shoppingCartService.Items.Value[_shoppingItemA]);

            var quantityB = 23;
            _shoppingCartService.AddItem(_shoppingItemA, quantityB);

            var quantityC = quantityA + quantityB;
            Assert.Equal(quantityC, _shoppingCartService.Items.Value[_shoppingItemA]);
        }

        [Fact]
        public void RemoveItem_WithNoQuantity_ShouldRemoveAllItems()
        {
            var quantityA = 75;

            Assert.Empty(_shoppingCartService.Items.Value);
            _shoppingCartService.AddItem(_shoppingItemA, quantityA);
            Assert.NotEmpty(_shoppingCartService.Items.Value);
            Assert.Equal(quantityA, _shoppingCartService.Items.Value[_shoppingItemA]);

            _shoppingCartService.RemoveItem(_shoppingItemA);
            Assert.Empty(_shoppingCartService.Items.Value);
        }

        [Fact]
        public void RemoveItem_WithQuantity_ShouldAddThatManyItems()
        {
            var quantityA = 56;

            Assert.Empty(_shoppingCartService.Items.Value);
            _shoppingCartService.AddItem(_shoppingItemA, quantityA);
            Assert.NotEmpty(_shoppingCartService.Items.Value);
            Assert.Equal(quantityA, _shoppingCartService.Items.Value[_shoppingItemA]);

            var quantityB = 46;
            _shoppingCartService.RemoveItem(_shoppingItemA, quantityB);
            Assert.NotEmpty(_shoppingCartService.Items.Value);

            var quantityC = quantityA - quantityB;
            Assert.Equal(quantityC, _shoppingCartService.Items.Value[_shoppingItemA]);
        }

        [Fact]
        public void RemoveItem_MultipleTimes_ShouldBeCumulative()
        {
            var quantityA = 56;

            Assert.Empty(_shoppingCartService.Items.Value);
            _shoppingCartService.AddItem(_shoppingItemA, quantityA);
            Assert.NotEmpty(_shoppingCartService.Items.Value);
            Assert.Equal(quantityA, _shoppingCartService.Items.Value[_shoppingItemA]);

            var quantityB = 14;
            _shoppingCartService.RemoveItem(_shoppingItemA, quantityB);
            Assert.NotEmpty(_shoppingCartService.Items.Value);
            var quantityC = quantityA - quantityB;
            Assert.Equal(quantityC, _shoppingCartService.Items.Value[_shoppingItemA]);

            var quantityD = 17;
            _shoppingCartService.RemoveItem(_shoppingItemA, quantityD);
            Assert.NotEmpty(_shoppingCartService.Items.Value);

            var quantityE = quantityC - quantityD;
            Assert.Equal(quantityE, _shoppingCartService.Items.Value[_shoppingItemA]);
        }

        [Fact]
        public void RemoveItem_WithGreaterQuantity_ShouldRemoveTheItemEntirely()
        {
            var quantityA = 56;

            Assert.Empty(_shoppingCartService.Items.Value);
            _shoppingCartService.AddItem(_shoppingItemA, quantityA);
            Assert.NotEmpty(_shoppingCartService.Items.Value);
            Assert.Equal(quantityA, _shoppingCartService.Items.Value[_shoppingItemA]);

            var quantityB = 888;
            _shoppingCartService.RemoveItem(_shoppingItemA, quantityB);
            Assert.Empty(_shoppingCartService.Items.Value);
        }

        [Fact]
        public void ClearCart_ShouldRemoveAllItems()
        {
            Assert.Empty(_shoppingCartService.Items.Value);
            var quantityA = 57;
            _shoppingCartService.AddItem(_shoppingItemA, quantityA);

            var quantityB = 69;
            _shoppingCartService.AddItem(_shoppingItemB, quantityB);

            Assert.NotEmpty(_shoppingCartService.Items.Value);
            Assert.Equal(quantityA, _shoppingCartService.Items.Value[_shoppingItemA]);
            Assert.Equal(quantityB, _shoppingCartService.Items.Value[_shoppingItemB]);

            _shoppingCartService.ClearCart();

            Assert.Empty(_shoppingCartService.Items.Value);
        }

        [Fact]
        public void MultipleItems_ShouldBeIndividuallyTracked()
        {
            var quantityAA = 56;

            Assert.Empty(_shoppingCartService.Items.Value);
            _shoppingCartService.AddItem(_shoppingItemA, quantityAA);
            Assert.NotEmpty(_shoppingCartService.Items.Value);
            Assert.Equal(quantityAA, _shoppingCartService.Items.Value[_shoppingItemA]);

            var quantityBA = 76;
            
            _shoppingCartService.AddItem(_shoppingItemB, quantityBA);
            Assert.NotEmpty(_shoppingCartService.Items.Value);
            Assert.Equal(quantityBA, _shoppingCartService.Items.Value[_shoppingItemB]);

            var quantityAB = 14;
            _shoppingCartService.RemoveItem(_shoppingItemA, quantityAB);
            Assert.NotEmpty(_shoppingCartService.Items.Value);
            var quantityAC = quantityAA - quantityAB;
            Assert.Equal(quantityAC, _shoppingCartService.Items.Value[_shoppingItemA]);
            
            var quantityBB = 32;
            _shoppingCartService.RemoveItem(_shoppingItemB, quantityBB);
            Assert.NotEmpty(_shoppingCartService.Items.Value);
            var quantityBC = quantityBA - quantityBB;
            Assert.Equal(quantityBC, _shoppingCartService.Items.Value[_shoppingItemB]);

            var quantityAD = 17;
            _shoppingCartService.RemoveItem(_shoppingItemA, quantityAD);
            Assert.NotEmpty(_shoppingCartService.Items.Value);

            var quantityAE = quantityAC - quantityAD;
            Assert.Equal(quantityAE, _shoppingCartService.Items.Value[_shoppingItemA]);

            var quantityBD = 5;
            _shoppingCartService.AddItem(_shoppingItemB, quantityBD);
            Assert.NotEmpty(_shoppingCartService.Items.Value);
            
            var quantityBE = quantityBC + quantityBD;
            Assert.Equal(quantityBE, _shoppingCartService.Items.Value[_shoppingItemB]);

            _shoppingCartService.ClearCart();
            Assert.Empty(_shoppingCartService.Items.Value);
        }
    }
}
