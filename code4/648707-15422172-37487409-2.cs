                private static readonly SortedDictionary<string, List<string>> synonymList = new SortedDictionary<string, List<string>>
    {
        {"but", new List<string> { "however" }},
        {"take", new List<string> { "abduct", "abstract", "accroach"}},
        {"beat", new List<string> {"hit", "lash", "punch", "shake"}},
        {"end",  new List<string> {"butt", "confine", "cusp"}}
    };
        public static IEnumerable<string> AlternativesOf(string arg)
        {
            var words = arg.Split(' ').ToList();
            var options = new List<List<string>>();
            foreach (var word in words)
            {
                if (synonymList.ContainsKey(word))
                {
                    options.Add(synonymList[word]);
                }
                else
                {
                    options.Add(new List<string> { word });
                }
            }
            return AllPermutationsOf("", options, 0);
        }
        public static IEnumerable<string> AllPermutationsOf(string sentence, List<List<string>> options, int count)
        {
            if (count == options.Count)
            {
                yield return sentence;
            }
            else
            {
                foreach (string option in options[count])
                {
                    AllPermutationsOf(sentence + option, options, count + 1);
                }
            }
        }
