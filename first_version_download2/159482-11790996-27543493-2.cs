        var listOfAs = new List<double>();
            var listOfBs = new List<int>();
            while (!sStreamReader.EndOfStream)
            {
               string sLine = sStreamReader.ReadLine();
               // make sure we have something to work with
               if (String.IsNullOrEmpty(sLine)) continue;
                
                                string[] cols = sLine.Split(',');
                                // make sure we have the minimum number of columns to process
                                if (cols.Length > 4)
                                {
                                    double a = Convert.ToDouble(cols[1]);
                                    listOfAs.Add(a);
                                    Console.Write(a);
                                    int b = Convert.ToInt32(cols[3]);
                                    listOfAs.Add(b);
                                    Console.WriteLine(b);
                                    Console.WriteLine();
                                }
                            }
        }
    MyClass.DoSomething(listOfAs,listOfBs);
