	public static List<int> RemoveSmallest(List<int> numbers)
	{
		var newList = new List<int>();
		var lowest = 0;
		for (var i = 0; i < numbers.Count; i++)
		{
			if (numbers[i] < lowest) {
				lowest = numbers[i]
			}
		}
		foreach (var num in numbers)
		{
			if (num != lowest)
			{
				newList.Add(num);
			}
		}
		return newList;
	}
