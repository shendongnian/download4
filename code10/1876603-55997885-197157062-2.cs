cs
public void Main()
{
	string filename = "Sales_person_2019-05-03.xlsx";
    // Get the Date part from the file name only
    string filedate = filename.Substring(filename.IndexOf('_',filename.IndexOf('_') + 1) + 1,10);
    DateTime dt = DateTime.ParseExact(filedate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None)
    Dts.TaskResult = (int)ScriptResults.Success;
}
