    string filename = openFileDialog1.FileName;
    string[] line = File.ReadAllLines(filename);
    var arrayTemp = new double[line.Length, 2];
    for (int i = 0; i < line.Length; i++)
    {
        var data = line[i].Split(',');
        arrayTemp[i, 0] = double.Parse(data[0]);
        arrayTemp[i, 1] = double.Parse(data[1]);
    }
    Array.Copy(arrayTemp, GlobalDataClass.dDataArray, line.Length); // now the error should go away.
