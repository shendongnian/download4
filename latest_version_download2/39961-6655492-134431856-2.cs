    static class ExtensionsForTextReader
    {
         public static IEnumerable<string> ReadLines (this TextReader reader, char delimiter)
         {
                List<char> chars = new List<char> ();
                while (reader.Peek() >= 0)
                {
                    char c = (char)reader.Read ();
                    if (c == delimiter) {
                        yield return new String(chars.ToArray());
                        chars.Clear ();
                        continue;
                    }
                    chars.Add(c);
                }
         }
    }
