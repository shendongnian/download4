        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 1, 4, 5, 1, 2, 2, 2 };
            int occurrenceLimit = 2;
            var intList = arr.ToList();
            for (int i = 0; i < intList.Count; i++)
            {
                // Find the number of times the item at index `i` occurs
                int occursintegerOccurrence = intList.Count(n => n == intList[i]); ;
                // If `occursintegerOccurrence` is greater than `occurenceLimit`
                // then remove all but the first one
                while (occursintegerOccurrence > occurrenceLimit)
                {
                    // We are not enumerating the list, so we can remove items at will.
                    for (var ii = 0; ii < occursintegerOccurrence - occurrenceLimit; ii++)
                    {
                        var index = intList.LastIndexOf(intList[i]);
                        intList.RemoveAt(index);
                    }
                    occursintegerOccurrence = intList.Count(n => n == intList[i]);
                }
            }
            // Verify the results
            foreach (var item in intList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(Environment.NewLine + "Done");
            Console.ReadLine();
        }
