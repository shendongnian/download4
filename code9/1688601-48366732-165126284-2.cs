    private async Task<ViewModelShoppingCart> GetCartAsync(int Id)
    {
        var VMCart = await _context.ShoppingCarts
                    .Where(c => c.Id == Id)
                    .Select(cart => new ViewModelShoppingCart
                    {
                        Id = cart.Id,
                        Title = cart.Title,
                        CreateDate = cart.CreateDate,
                        ShoppingCartItems = cart.ShoppingCartItems
                                            .Select(items => new ViewModelShoppingCartItem
                                            {
                                                ProductId = items.ProductId,
                                                ProductTitle = items.Product.Title,
                                                ProductPrice = items.Product.Price,
                                                Quantity = items.Quantity
                                            }).ToList()
                    }).FirstOrDefaultAsync();
        return VMCart;
    }
