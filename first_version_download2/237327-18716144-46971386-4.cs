    public class CalculateProductPrice
    {
        public int ProductId { get; set; }
    }
    public class CalculateProductPriceUseCase
        : IUseCase<CalculateProductPrice>
    {
        private ICalculateProductPriceService _calculatePriceService;
        private IUnitOfWork _unitOfWork;
        public CalculateProductPriceUseCase(
            ICalculateProductPriceService calculatePriceService,
            IUnitOfWork unitOfWork)
        {
            _calculatePriceService = _calculatePriceService;
            _unitOfWork = unitOfWork;
        }
        public void Handle(CalculateProductPrice command)
        {
            var product = _unitOfWork.Products.GetById(command.ProductId);
            
            product.Price = _calculatePriceService.Calculate();
        }
    }
