    decimal sellingPrice;
    if (!decimal.TryParse(txtSellingPrice.Text, out sellingPrice))
    {
       // Not a valid decimal, do something.
    }
    decimal purchasePrice;
    if (!decimal.TryParse(txtPurchasePrice.Text, out purchasePrice))
    {
       // Not a valid decimal, do something.
    }
    
    if (sellingPrice >= purchasePrice)
    {
       // stuff
    }
