        public string[] Cutcup(string s, int l)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < s.Length; i += l)
            {
                result.Add(s.Substring(i, Math.Min(5, s.Substring(i).Length)));
            }
            return result.ToArray();
        }
