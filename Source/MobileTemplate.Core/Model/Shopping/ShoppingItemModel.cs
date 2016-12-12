using System;

namespace MobileTemplate.Core.Model.Shopping
{
    public class ShoppingItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
