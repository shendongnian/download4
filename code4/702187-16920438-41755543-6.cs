    public void Exec() 
        {
            string code = @"
                namespace CodeInjection
                {
                    public class MyDynConcatenateString : IDynConcatenateString 
                    {
                        public string Concatenate(string s1, string s2){
                            return s1 + "" ! "" + s2;
                        }
                    }
                }";
            IDynConcatenateString writer = GetInstanceOf<IDynConcatenateString>(
                code, "CodeInjection.MyDynConcatenateString");
            var s1 = Console.ReadLine();
            var s2 = Console.ReadLine();
            var result = writer.Concatenate(s1, s2);
            Console.WriteLine(result);
        }
