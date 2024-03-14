

using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Extensions
{
    public static class AdapterExtensions
    {
        public static AddressDb ToAddressDb(this Address address)
        {
            return new AddressDb
            {
                City = address.City,
                State = address.State,
                Complement = address.Complement,
                Country = address.Country,
                NeighboardHood = address.NeighboardHood,
                Number = address.Number,
                Street = address.Street,
                ZipCode = address.ZipCode,
                Id = address.Id,
                Orders = address.Orders.Select(p => p.ToOrderDb()).ToList(),
                User = address.User.ToUserDb(),
                UserId = address.User.Id,
            };
        }

        public static CartDb ToCartDb(this Cart cart)
        {
            return new CartDb
            {
                CartItems = cart.CartItems.Select(p => p.ToCartItemDb()).ToList(),
                User = cart.User.ToUserDb(),
                UserId = cart.User.Id,
                Id = cart.Id
            };
        }

        public static CartItemDb ToCartItemDb(this CartItem cartItem)
        {
            return new CartItemDb
            {
                Product = cartItem.Product.ToProductDb(),
                ProductId = cartItem.Product.Id,
                Quantity = cartItem.Quantity,
                Id = cartItem.Id
            };
        }

        public static CommentDb ToCommentDb(this Comment comment)
        {
            return new CommentDb
            {
                Product = comment.Product.ToProductDb(),
                ProductId = comment.Product.Id,
                Text = comment.Text,
                Title = comment.Title,
                User = comment.User.ToUserDb(),
                UserId = comment.User.Id,
                Id = comment.Id
            };
        }
        public static BrandDb ToBrandDb(this Brand brand)
        {
            return new BrandDb
            {
                Description = brand.Description,
                Name = brand.Name,
                Products = brand.Products.Select(p => p.ToProductDb()).ToList(),
                Id = brand.Id
            };
        }
        public static OrderDb ToOrderDb(this Order order)
        {
            return new OrderDb
            {
                Address = order.Address.ToAddressDb(),
                AddressId = order.Address.Id,
                OrdersStatus = order.OrdersStatus.Select(p => p.ToOrderStatusDb()).ToList(),
                Payment = order.Payment.ToPaymentDb(),
                PaymentId = order.Payment.Id,
                ProductOrders = order.ProductOrders.Select(p => p.ToProductOrder()).ToList(),
                User = order.User.ToUserDb(),
                UserId = order.User.Id,
                Id = order.Id,
            };
        }
        public static OrderStatusDb ToOrderStatusDb(this OrderStatus orderStatus)
        {
            return new OrderStatusDb
            {
                CreatedAt = orderStatus.CreatedAt,
                Notifier = orderStatus.Notifier,
                OrderId = orderStatus.Order.Id,
                StatusProcessEnum = orderStatus.StatusProcessEnum,
                Order = orderStatus.Order.ToOrderDb(),
                Id = orderStatus.Id,
            };
        }
        public static PaymentDb ToPaymentDb(this Payment payment)
        {
            return new PaymentDb
            {
                Order = payment.Order.ToOrderDb(),
                Installments = payment.Installments,
                InstallmentsPayed = payment.InstallmentsPayed,
                PaymentType = payment.PaymentType,
                Value = payment.Value,
                Id = payment.Id
            };
        }
        public static ProductDb ToProductDb(this Product product)
        {
            return new ProductDb
            {
                Brand = product.Brand.ToBrandDb(),
                BrandId = product.Brand.Id,
                CartItems = product.CartItems.Select(p => p.ToCartItemDb()).ToList(),
                Category = product.Category,
                Comments = product.Comments.Select(p => p.ToCommentDb()).ToList(),
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,  
                ProductOrders = product.ProductOrders.Select(p => p.ToProductOrder()).ToList(),
                Quantity = product.Quantity,
                Id = product.Id,    
            };
        }
        public static ProductOrderDb ToProductOrder(this ProductOrder productOrder)
        {
            return new ProductOrderDb
            {
                Order =  productOrder.Order.ToOrderDb(),
                OrderId = productOrder.Order.Id,
                Price = productOrder.Price,
                Product = productOrder.Product.ToProductDb(),
                ProductId = productOrder.Product.Id,
                Quantity = productOrder.Quantity,
                Id = productOrder.Id    
            };
        }
        public static ReceiptPurchaseDb ToReceiptPurchase(this ReceiptPurchase receiptPurchase)
        {
            return new ReceiptPurchaseDb
            {
                Approved = receiptPurchase.Approved,
                ApprovedBy = receiptPurchase.ApprovedBy,
                Code = receiptPurchase.Code,
                IssuerDocument = receiptPurchase.IssuerDocument,    
                Order = receiptPurchase.Order.ToOrderDb(),
                OrderGuid = receiptPurchase.Order.Id,
                Value = receiptPurchase.Value,
                Id = receiptPurchase.Id
            };
        }
        public static UserDb ToUserDb(this User user)
        {
            return new UserDb
            {
                Addresses = user.Addresses.Select(p => p.ToAddressDb()).ToList(),
                BirthDate = user.BirthDate,
                Cart = user.Cart.ToCartDb(),
                Comments = user.Comments.Select(p => p.ToCommentDb()).ToList(),
                DocumentNumber = user.Document,
                Fax = user.Fax,
                MailAddress = user.Mail,
                Name = user.Name,
                Orders = user.Orders.Select(p => p.ToOrderDb()).ToList(),
                Phone = user.Phone,
                Id = user.Id,   
            };
        }
    }
}
