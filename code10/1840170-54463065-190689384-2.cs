        public static bool init_access(string file_path)
        {
            if (File.Exists(file_path))
            {
                int counter = 0;
                List<string> lines = File.ReadAllLines(file_path).ToList();
                foreach (string line in lines)
                {
                    counter++;
                    Console.WriteLine(counter + " " + line);
                }
    
                return (true);
            }
    
            return false;
        }
