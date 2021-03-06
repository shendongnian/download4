        public static Dictionary<string, int> Denominations(int amount)
        {
            Dictionary<string, int> denominations = new Dictionary<string, int>() { { "twenties", 0 }, { "tens", 0 }, { "fives", 0 }, { "ones", 0 } };
            int twenties, tens, fives, ones;
            if (amount >= 20)
            {
                twenties = amount/20;
                denominations["twenties"] = twenties;
                amount -= twenties * 20;
            }
            if (amount >= 10)
            {
                tens = amount/10;
                denominations["tens"] = tens;
                amount -= tens * 10;
            }
            if (amount >= 5)
            {
                fives = amount/5;
                denominations["fives"] = fives;
                amount -= fives * 5;
            }
            if (amount >= 1)
            {
                ones = amount;
                denominations["ones"] = ones;
            }
            return denominations;
        }
