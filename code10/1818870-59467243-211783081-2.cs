csharp
using System;
using System.Text;
using Nethereum.Hex.HexConvertors.Extensions;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
public class Program
{
    private static async Task Main(string[] args)
    {
        //First let's create an account with our private key for the account address 
        var privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
        var account = new Account(privateKey);
        Console.WriteLine("Our account: " + account.Address);
        //Now let's create an instance of Web3 using our account pointing to our nethereum testchain
        var web3 = new Web3(account, "http://testchain.nethereum.com:8545");
        // Check the balance of the account we are going to send the Ether
        var balance = await web3.Eth.GetBalance.SendRequestAsync("0x13f022d72158410433cbd66f5dd8bf6d2d129924");
        Console.WriteLine("Receiver account balance before sending Ether: " + balance.Value + " Wei");
        Console.WriteLine("Receiver account balance before sending Ether: " + Web3.Convert.FromWei(balance.Value) +
                          " Ether");
        // Lets transfer 1.11 Ether
        var transaction = await web3.Eth.GetEtherTransferService()
            .TransferEtherAndWaitForReceiptAsync("0x13f022d72158410433cbd66f5dd8bf6d2d129924", 1.11m);
        balance = await web3.Eth.GetBalance.SendRequestAsync("0x13f022d72158410433cbd66f5dd8bf6d2d129924");
        Console.WriteLine("Receiver account balance after sending Ether: " + balance.Value);
        Console.WriteLine("Receiver account balance after sending Ether: " + Web3.Convert.FromWei(balance.Value) +
                          " Ether");
    }
}
You have many samples of Ethereum wallets using Nethereum, they can be found here http://docs.nethereum.com/en/latest/nethereum-ui-wallets/
