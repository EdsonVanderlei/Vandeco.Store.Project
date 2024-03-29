﻿using VandecoStore.Core;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Entities
{
    public class CartItemDb : Entity
    {
        public required Guid ProductId { get; init; }
        public required int Quantity { get; init; }

        // EF RELATIONS
        public required ProductDb Product { get; init; }

        public CartItemDb() { }

        public CartItem ToCartItem()
        {
            return new CartItem
            {
                Product = Product.ToProduct(),
                Quantity = Quantity,
                Id = Id
            };
        }
    }
}
