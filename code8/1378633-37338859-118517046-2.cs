    Random rnd = new Random(10000);
	public String RollRegex() {
		int roll = rnd.Next(1, 100000);
		if (Regex.IsMatch(roll.ToString(), @"(.)\1{1,}$")) {
			return "doubles";
		} else {
			return "none";
		}
	}
	public String RollEndsWith() {
		int roll = rnd.Next(1, 100000);
		if (roll.ToString().EndsWith("11") || roll.ToString().EndsWith("22") || roll.ToString().EndsWith("33") || roll.ToString().EndsWith("44") || roll.ToString().EndsWith("55") || roll.ToString().EndsWith("66") || roll.ToString().EndsWith("77") || roll.ToString().EndsWith("88") || roll.ToString().EndsWith("99") || roll.ToString().EndsWith("00")) {
			return "doubles";
		} else {
			return "none";
		}
	}
	
	public String RollSimple() {
		int roll = rnd.Next(1, 100000);
		string rollString = roll.ToString();
		return roll > 10 && rollString[rollString.Length - 1] == rollString[rollString.Length - 2] ?
			"doubles" : "none";
	}
	List<string> doubles = new List<string>() { "00", "11", "22", "33", "44", "55", "66", "77", "88", "99" };
	public String RollAnotherSimple() {
		int roll = rnd.Next(1, 100000);
		string rollString = roll.ToString();
		return rollString.Length > 1 && doubles.Contains(rollString.Substring(rollString.Length - 2)) ?
			"doubles" : "none";
	}
	HashSet<string> doublesHashset = new HashSet<string>() { "00", "11", "22", "33", "44", "55", "66", "77", "88", "99" };
	public String RollSimpleHashSet() {
		int roll = rnd.Next(1, 100000);
		string rollString = roll.ToString();
		return rollString.Length > 1 && doublesHashset.Contains(rollString.Substring(rollString.Length - 2)) ?
			"doubles" : "none";
	}
	private void Test() {
		int trial = 1000000;
		rnd = new Random(10000);
		logBox.GetTimeLapse();
		for (int i = 0; i < trial; ++i)
			RollRegex();			
		logBox.WriteTimedLogLine("Regex: " + logBox.GetTimeLapse());
		rnd = new Random(10000);
		logBox.GetTimeLapse();
		for (int i = 0; i < trial; ++i)
			RollEndsWith();
		logBox.WriteTimedLogLine("EndsWith: " + logBox.GetTimeLapse());
		rnd = new Random(10000);
		logBox.GetTimeLapse();
		for (int i = 0; i < trial; ++i)
			RollSimple();
		logBox.WriteTimedLogLine("Simple: " + logBox.GetTimeLapse());
		rnd = new Random(10000);
		logBox.GetTimeLapse();
		for (int i = 0; i < trial; ++i)
			RollAnotherSimple();
		logBox.WriteTimedLogLine("Another simple: " + logBox.GetTimeLapse());
		rnd = new Random(10000);
		logBox.GetTimeLapse();
		for (int i = 0; i < trial; ++i)
			RollSimpleHashSet();
		logBox.WriteTimedLogLine("Another simple with HashSet: " + logBox.GetTimeLapse());
	}
