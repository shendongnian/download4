    using System;
    namespace ConsoleApplicationExpressionTree
    {
        public static class Extentions
        {
            static void Main() { }
            static void AMethod(string[] args)
            {
                SetValue(new Customer(), e => e.Name   /*type here */);
            }
            public static void SetValue<TEntity, TProperty>(TEntity instance, Func<TEntity, TProperty> expression)
            {
            }
        }
        public class Customer
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
