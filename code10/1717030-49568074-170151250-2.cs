    class Program
    {
        static void Main(string[] args)
        {
            var dataTable = ReadCSV.GetDataTabletFromCSVFile(path);
    
            //Now do something with dataTable...
        }
    }
    
    //It would be a good idea to declare the class as static also.
    public static class ReadCSV
    {
        //reading data from CSV files
        public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            //You will also need to return something here.
        }
    }
