    public class ShippingStrategyProxy : IShippingStrategy
    {
        private readonly DHLShippingStrategy _dhl;
        private readonly DHLShippingStrategy _ups;
        ...
        public DHLShippingStrategy(DHLShippingStrategy dhl, UPS ShippingStrategy ups, ...)
        {
            _dhl = dhl;
            _ups = ups;
            ...
        }
        public int CalculateShippingCost(Order order) => 
            GetStrategy(order.Method).CalculateShippingCost(order);
        
        private IShippingStrategy GetStrategy(string method)
        {
            switch (method)
            {
                case "DHL": return dhl;
                case "UPS": return ups:
                ...
                default: throw InvalidOperationException(method);
            }
        }
    }
    
