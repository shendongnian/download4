    public static class ArrayExtensions
    {
    	public static T[] GetColumn<T>(this T[,] array, int columnNum)
    	{
    		var result = new T[array.GetLength(0)];
    		
    		for (int i = 0; i < array.GetLength(0); i++)
    		{
    			result[i] = array[i, columnNum];
    		}
    		return result;
    	}
    }
