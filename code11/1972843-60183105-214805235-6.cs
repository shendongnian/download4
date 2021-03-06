Server-side.
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:21011");
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MessageEncoding = WSMessageEncoding.Mtom;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
            using (ServiceHost sh = new ServiceHost(typeof(MyService), uri))
            {
                sh.AddServiceEndpoint(typeof(IService), binding,"");
                ServiceMetadataBehavior smb;
                smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (smb == null)
                {
                    smb = new ServiceMetadataBehavior()
                    {
                        HttpGetEnabled = true
                    };
                    sh.Description.Behaviors.Add(smb);
                }
                Binding mexbinding = MetadataExchangeBindings.CreateMexHttpBinding();
                sh.AddServiceEndpoint(typeof(IMetadataExchange), mexbinding, "mex");
    
    
                sh.Opened += delegate
                {
                    Console.WriteLine("Service is ready");
                };
                sh.Closed += delegate
                {
                    Console.WriteLine("Service is clsoed");
                };
                sh.Open();
                Console.ReadLine();
                //pause
                sh.Close();
                Console.ReadLine();
            }
        }
    }
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string Test();
    
    }
    public class MyService : IService
    {
        public string Test()
        {
            return DateTime.Now.ToLongTimeString();
        }
    }
