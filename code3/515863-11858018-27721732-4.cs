        static void Main()
        {
            CoinPurse purse = new CoinPurse();
            purse.AddPenny(3);
            purse.AddNickel(4);
            purse.AddDime(2);
            purse.AddQuarter(1);
            purse.CountMoney();
            purse.TakeNickels(4);
            double total;
            purse.CountMoney(out total);
            Console.WriteLine(total);
            Console.ReadLine();
        }
