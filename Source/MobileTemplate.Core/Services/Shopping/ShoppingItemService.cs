using System;
using System.Collections.Generic;
using MobileTemplate.Core.Model.Shopping;
using Reactive.Bindings;

namespace MobileTemplate.Core.Services.Shopping
{
    public interface IShoppingItemService
    {
        IReadOnlyReactiveProperty<IEnumerable<ShoppingItemModel>> Inventory { get; }
    }

    public class ShoppingItemService : IShoppingItemService
    {
        private readonly IReactiveProperty<IEnumerable<ShoppingItemModel>> _inventoryInternal;

        public IReadOnlyReactiveProperty<IEnumerable<ShoppingItemModel>> Inventory { get; }

        public ShoppingItemService()
        {
            var items = new[]
            {
                new ShoppingItemModel
                {
                    Id = Guid.Parse("c3c67711-d530-4131-a17c-6427f8f54fba"),
                    Name = "NBI Mug",
                    Description = "A fancy Now Business Intelligence mug that holds coffee. (Do not put non-cofee in the mug, as this will void the warranty.)",
                    Icon = "nbi_logo.png",
                    Price = 5.99
                },
                new ShoppingItemModel
                {
                    Id = Guid.Parse("6a5afb64-2bc6-4b77-8a7d-64908b20e9d8"),
                    Name = "NBI Sweater",
                    Description = "An ugly Now Business Intelligence sweater for the holidays. One-size fits most!",
                    Icon = "nbi_logo.png",
                    Price = 14.99
                },
                new ShoppingItemModel
                {
                    Id = Guid.Parse("8344c27c-78d7-4f86-a3fe-9322d9ae3942"),
                    Name = "NBI Wine Set",
                    Description = "A set of six wine glasses and a bottle opener made out of fine crystal. (Not the bottle opener, that's made from metal.)",
                    Icon = "nbi_logo.png",
                    Price = 49.99
                },
                new ShoppingItemModel
                {
                    Id = Guid.Parse("8532aa12-c90d-42fe-8ab5-af04314d6d2b"),
                    Name = "NBI Calendar",
                    Description = "A day-to-day calendar featuring 365 photos of Now Business Intelligence's employees.",
                    Icon = "nbi_logo.png",
                    Price = 7.99
                }
            };
            _inventoryInternal = new ReactiveProperty<IEnumerable<ShoppingItemModel>>(items);
            Inventory = _inventoryInternal.ToReadOnlyReactiveProperty();
        }
    }
}