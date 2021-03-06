private List<string> SplitOnFullWords(string input, string split)
{
    List<string> result = new List<string>();
    int firstIndexOfSplit = input.IndexOf(split);
    // we have found an occurence of the split string, remove everything after this.
    if (firstIndexOfSplit >= 0)
    {
        string splitString = input.Substring(0, firstIndexOfSplit);
        // Find the last occurance of a space before this index; this will give us all full words before 
        int lastIndexOfSpace = splitString.LastIndexOf(' ');
        // If there are no more spaces just return
        if (lastIndexOfSpace >= 0)
        {
            // Add the words before the word containing the splitter string
            result.Add(splitString.Substring(0, lastIndexOfSpace));
            // Add the word contianing the splitter string
            string remainingString = input.Substring(lastIndexOfSpace + 1);
            int firstSpaceAfterWord = remainingString.IndexOf(' ');
            result.Add(remainingString.Substring(0, firstSpaceAfterWord));
            // Look for more after the word containing the splitter string
            string finalString = remainingString.Substring(firstSpaceAfterWord + 1);
            result.AddRange(SplitOnFullWords(finalString, split));
        }
        else
        {
            result.Add(splitString);
        }
    }
    else
    {
        // No occurences of the split string, just return the input
        result.Add(input);
    }
    return result;
}
And to use
foreach (string word in SplitOnFullWords(inputWord, "ar"))
    Console.WriteLine(word);
