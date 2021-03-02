    public static class IntExtensions
    {
        public static IEnumerable<int> Split(this int number, int parts)
        {
            var slots = Enumerable.Repeat(0, parts).ToList();
            var random = new Random();
            while (number > 0)
            {
                var slot = random.Next(0, parts);
                slots[slot]++;
                number--;
            }
            return slots;
        }
    }
