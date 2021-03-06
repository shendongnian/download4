        private List<string> splitIntoChunks(string toSplit, int chunkSize)
        {
            List<string> splittedLines = new List<string>();
            string [] toSplitAr = toSplit.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < toSplitAr.Length; )
            {
                string line = "";
                string prefix = "";
                for (int linesize = 0; linesize <= chunkSize;)
                {
                    if (i >= toSplitAr.Length) break; //i should not exceed splited array
                    prefix = (line == "" ? "" : " ");
                    linesize += toSplitAr[i].Length;
                    if (linesize > chunkSize) break; //line size dould not exceed chuksize
                    line += (prefix  + toSplitAr[i]);
                    i++;
                }
                splittedLines.Add(line);
            }
            return splittedLines;
        }
