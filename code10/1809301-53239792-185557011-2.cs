    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Stars { get; set; }
        [Required]
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        [Required]
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
    productService.AddReview(1,
        new Review
        {
            CustomerId = 1,
            ProductId = XXX,
            Stars = 2,
            Text = "It's a good camera",
        })
