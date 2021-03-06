    var ordersWithTheirProducts = ...
        .Select(... => new Order
        {
             // some Order properties:
             Id = ...
             OrderDate = ...
             ClientId = ...
             // Products of this Order:
             Products = ...
                .Select( product => new Product
                {
                    // Several Product properties
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ...
                },
        };
