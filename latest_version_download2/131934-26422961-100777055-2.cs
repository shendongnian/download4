    void Main()
    {
        var rootNode = new Node();
    
        //probably a bad idea, better to await in an async method
        LoadNode(rootNode).Wait(); 
    
        //let's search a few times to get meaningful timings    
        for(var i = 0; i < 5; ++i)
        {
            //"acres" in text-ese (specifically chosen for ambiguity)
            var searchTerm = "22737";
            var sw = Stopwatch.StartNew();
            var wordList = rootNode.Search(searchTerm);
            Console.WriteLine("Search complete in {0} ms", 
                            sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("Search for {0}:", searchTerm);
            foreach(var word in wordList)
            {
                Console.WriteLine("Found {0}", word);
            }   
        }
        GC.Collect();
        var bytesAllocated = GC.GetTotalMemory(true);
        Console.WriteLine("Allocated {0} bytes", bytesAllocated);
    }
    
    async Task LoadNode(Node rootNode)
    {
        var wordListUrl = 
        "http://www-01.sil.org/linguistics/wordlists/english/wordlist/wordsEn.txt";
        Console.WriteLine("Loading words from {0}", wordListUrl);
        using(var httpClient = new HttpClient())
        using(var stream = await httpClient.GetStreamAsync(wordListUrl))
        using(var reader = new StreamReader(stream))
        {
            var wordCount = 0;
            string word;
            while( (word = await reader.ReadLineAsync()) != null )
            {
                word = word.ToLowerInvariant();
                if(!Regex.IsMatch(word,@"^[a-z]+$"))
                {
                    continue;
                }
                rootNode.Add(word);
                wordCount++;
            }   
            Console.WriteLine("Loaded {0} words", wordCount);
        }
    }
    
    class Node
    {
        static Dictionary<int, string> digitMap = new Dictionary<int, string>() {
            { 1, "" },
            { 2, "abcABC" },
            { 3, "defDEF" },
            { 4, "ghiGHI" },
            { 5, "jklJKL" },
            { 6, "mnoMNO" },
            { 7, "pqrsPQRS" },
            { 8, "tuvTUV" },
            { 9, "wxyzWXYZ" },
            { 0, "" }};
        static Dictionary<char,int> letterMap;
        static Node()
        {
            letterMap = digitMap
                .SelectMany(m => m.Value.Select(c=>new {ch = c, num = m.Key}))
                .ToDictionary(x => x.ch, x => x.num);
        }
    
        List<string> words = new List<string>();
    
        //the edges collection has exactly 10 
        //slots which represent the numbers [0-9]
        Node[] edges = new Node[10];
    
        public IEnumerable<string> Words{get{
            return words;
        }}
    
        public void Add(string word, int pos = 0)
        {
            if(pos == word.Length)
            {
                if(word.Length > 0)
    			{
    				words.Add(word);
    			}
                return;
            }
            var currentChar = word[pos];
            int edgeIndex = letterMap[currentChar];
            if(edges[edgeIndex] == null)
            {
                edges[edgeIndex] = new Node();
            }
            var nextNode = edges[edgeIndex];
            nextNode.Add(word, pos+1);
        }
    
        public Node FindMostPopulatedNode()
        {
            Stack<Node> stk = new Stack<Node>();
            stk.Push(this);
            Node biggest = null;
            while(stk.Any())
            {
                var node = stk.Pop();
                biggest = biggest == null
                   ? node
                   : (node.words.Count > biggest.words.Count
                       ? node
                       : biggest);
                foreach(var next in node.edges.Where(e=>e != null))
                {
                    stk.Push(next);
                }
            }
            return biggest;
        }
    
        public IEnumerable<string> Search(string numberSequenceString)
        {
            var numberSequence = numberSequenceString
                                   .Select(n => int.Parse(n.ToString()));
            return Search(numberSequence);
        }
        private IEnumerable<string> Search(IEnumerable<int> numberSequence)
        {
            if(!numberSequence.Any())
            {
                return words;
            }
            var first = numberSequence.First();
            var remaining = numberSequence.Skip(1);
            var nextNode = edges[first];
            if(nextNode == null)
            {
                return Enumerable.Empty<string>();
            }
            return nextNode.Search(remaining);
        }
    }
