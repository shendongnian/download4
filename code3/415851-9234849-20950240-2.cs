    namespace StackOverflow.RegularExpressions
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var validString =
                    new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[@#$%^&+=])([a-z][^0-9A-Z])[^A-Z]*[^0-9A-Z]$",
                              RegexOptions.Compiled | RegexOptions.ECMAScript);
                var testsAndExpectedResults = new List<Tuple<string, bool>>
                                                  {
                                                      new Tuple<string, bool>("a1@aaaaa", true),
                                                      new Tuple<string, bool>("a1@aaaaaaa", true),
                                                      new Tuple<string, bool>("a1@aaaa", false),
                                                      new Tuple<string, bool>("1a1@aaaa", false),
                                                      new Tuple<string, bool>("aa1@aaaa", false),
                                                      new Tuple<string, bool>("Aa1@aaaa", false),
                                                      new Tuple<string, bool>("Aa1@aaaA", false),
                                                      new Tuple<string, bool>("aA1@aaaA", false),
                                                      new Tuple<string, bool>("#A@a1aaaaa", false)
                                                  };
                testsAndExpectedResults.ForEach(t =>
                                                Console.WriteLine("With '{0}' expected {1}, got {2}", t.Item1, t.Item2,
                                                                  validString.IsMatch(t.Item1))
                    );
                Console.ReadKey();
            }
        }
    }
