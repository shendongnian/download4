    [Test]
    public void All_products_should_have_some_colors()
    {
        var products = GetProducts();
    
        foreach (var product in products)
        {
            Assert.IsNotEmpty(product.Colors);
        }
    }
