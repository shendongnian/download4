	Console.WriteLine("Type in grade to get stats!");
	int gradeScore = Convert.ToInt16(Console.ReadLine());
	Console.WriteLine("Grade Score: {0}", gradeScore);
	var isPassed = gradeScore > 50;
	Console.WriteLine("Passed: {0}", isPassed);
	var gradeStatus = GetGradeStatus(gradeScore);
	Console.WriteLine("Grade Status: {0}", gradeStatus);
