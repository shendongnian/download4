    internal class Program
    {
        private static void Main(string[] args)
        {
            var myClass = new Visitor();
            myClass.OnNewFileFound +=Progress;
            myClass.CountTmpFiles();
            Console.Read();
        }
        private static void Progress(int i)
        {
            Console.WriteLine(i); //update textbox here
        }
    }
    public class Visitor
    {
        public event Action<int> OnNewFileFound;
        private int count = 0;
        public int CountTmpFiles()
        {
            var path = Environment.ExpandEnvironmentVariables(@"c:\windows");
            VisitDir(path);
            return count;
        }
        private void VisitDir(string path)
        {
            try
            {
                foreach (var directory in Directory.GetDirectories(path))
                {
                    VisitDir(directory); //recursive call here
                }
                foreach (var filePath in Directory.GetFiles(path, "*.tmp", SearchOption.TopDirectoryOnly))
                {
                    count++;
                    if (OnNewFileFound != null)
                    {
                        OnNewFileFound(count);
                    }
                }
            }
            catch (System.Exception excpt)
            {
                //Console.WriteLine(excpt.Message);
            }
        }
    }
