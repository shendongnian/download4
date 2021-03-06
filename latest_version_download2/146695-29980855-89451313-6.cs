            public static string[] WORDS = new[]
        {
            "ANY","LIST","OF","WORDS"
        };
        private static ObsceneNode _root;
        static SmutBlocker()
        {
            //abbreviatedList can be omitted once an optimized list of
            //terms is set to WORDS.
            var abbreviatedList = new List<string>();
            _root = new ObsceneNode(new ObsceneValue(default(char), null));
            var iter = _root;
            foreach (var word in WORDS)
            {
                for(var i = 0; i < word.Length; i++)
                {
                    if (iter.Value.IsObscene)
                        break;
                    var isObscene = (word.Length - 1) == i;
                    iter = iter.SafeAddChild(new ObsceneValue(word[i], isObscene ? word : null));
                    //The below list is to capture the optimized list
                    if (isObscene)
                        abbreviatedList.Add(word.ToUpper());
                }
                iter = _root;
            }
            //Purely for fixing a non-optimized list
            //Remove once list is optimized
            var output = String.Empty;
            for (var i = 0; i < abbreviatedList.Count(); i += 10)
            {
                var segment = abbreviatedList.Skip(i).Take(10);
                output += "\"" + String.Join("\",\"", segment) + "\"," + Environment.NewLine;
            }
        }
        
        //Finally the actual IsObscene check that loops through the tree.
        public static bool IsObscene(string text)
        {
            var iters = new List<ObsceneNode>(text.Length);
            for (var i = 0; i < text.Length; i++)
            {
                iters.Add(_root);
                var c = text[i];
                for (int j = iters.Count() - 1; j >= 0; j--)
                {
                    if (iters[j].HasChild(c))
                    {
                        iters[j] = iters[j].GetChild(c);
                        if (iters[j].Value.IsObscene)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        iters.RemoveAt(j);
                    }
                }
            }
            return false;
        }
