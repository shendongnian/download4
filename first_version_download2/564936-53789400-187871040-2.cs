    namespace Test.Helpers
    {
        public class PaymentMethodList
        {
            List<PaymentMethodDetials> paymentList = new List<PaymentMethodDetials>();
            paymentList.Add(new PaymentMethodDetials
            {
              Id=1,
              Name="xyz"
            } );
        }
        public class PaymentMethodDetials
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
