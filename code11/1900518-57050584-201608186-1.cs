    var result = (from product in SampleProductTable
                  join sale in SampleSalesTable on product.Id == sale.ProductId into subSales
                  from subSale in subSales.DefaultIfEmpty()
                  group new sale by new { product.Id, product.TotalSales } into gr
                  select new 
                  {
                      gr.Key.Id,
                      gr.Sum(x => x == null ? 0 : x.Amount) + gr.Key.TotalSales
                  }).ToList();
