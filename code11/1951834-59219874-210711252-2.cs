using Kusto.Data.Net.Client;
namespace ConsoleApp2
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var client = KustoClientFactory.CreateCslQueryProvider("https://help.kusto.windows.net/Samples");
            var reader = client.ExecuteQuery("StormEvents | count");
        }
    }
}
