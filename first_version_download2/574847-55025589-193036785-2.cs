    var indices = new List<int>();
    int max = int.MinValue;
    for(int i = 0; i < array.Length; i++)
    {
        if(array[i] > max)
        {
            max = array[i];
            indices.Clear();
            indices.Add(i);
        }
        else if(array[i] == max)
        {
            indices.Add(i);
        }
    }
