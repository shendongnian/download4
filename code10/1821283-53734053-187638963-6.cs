            var myClass = new MyClass();
            var myList = new List<MyClass>();
                
            var myElement = new MyClass()
             {
                  prop1 = "A",
                  prop2 = "B",
                  anotherProp3 = "C",
                  prop4 = "D",
             };
                            
           var values = typeof(MyClass).GetProperties()
                        .OrderBy(p => Attribute.IsDefined(p, typeof(PositionAttribute)) ? p.GetCustomAttribute<PositionAttribute>().Position : int.MaxValue)
                        .Select(p => p.GetValue(myElement))
                        .ToArray();
        
           var result = string.Join("\t", values);
