    using System;
    using System.Text.RegularExpressions;
    using Microsoft.CSharp;
    using System.CodeDom.Compiler;
    using System.Reflection;
    namespace ConsoleApplication52
    {
        static class MathEvaluator
        {
            private const string Begin = 
    @"using System;
    namespace MyNamespace
    {
        public static class LambdaCreator 
        {
            public static Func<double,double> Create()
            {
                return (x)=>";
            private const string End = @";
            }
        }
    }";
        public static Delegate Parse(string input)
        {
            string normalized = Normalize(input);
            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters {GenerateInMemory = true};
            parameters.ReferencedAssemblies.Add("System.dll");
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, Begin + normalized + End);
            var cls = results.CompiledAssembly.GetType("MyNamespace.LambdaCreator");
            var method = cls.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            return (method.Invoke(null, null) as Delegate);
        }
        public static string Normalize(string input)
        {
            return input.ReplaceMultipling().ReplacePow();
        }
        private static string ReplaceMultipling(this string input)
        {
            return Regex.Replace(input, @"(\d+)(x)", @"$1*$2");
        }
        private static string ReplacePow(this string input)
        {
            return Regex.Replace(input, @"(\(?\d*x\)?)\^(\d+)", "Math.Pow($1,$2)");
        }
    }
    
    class Program
    {
        private static void Main()
        {
            const string input = "2x^2+3x";
            var del = MathEvaluator.Parse(input);
            Console.WriteLine(del.DynamicInvoke(2));
            Console.ReadKey();
        }
    }
    }
