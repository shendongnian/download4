      //These lines are fine
       //IEnumerable<string> names = new List<string>(); removed this as not really needed
       var excel = new Excel.ExcelQueryFactory(_excelFilePath);
    
       //This line shows a syntax error starting from c[0]
       var names = from c in excel.WorksheetRange("A1", "AI1", headerName)
                    where  c[0] == "IN"
                    select c;
