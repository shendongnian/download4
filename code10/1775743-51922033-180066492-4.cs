    Employee Director = new Employee("John", "McDir");
    Employee SubDirector1 = new Employee("Jane", "Doe");
    Employee SubDirector2 = new Employee("Mary", "Fairchild");
    Employee CoSub1 = new Employee("Ted", "Smith");
    Employee CoSub2 = new Employee("Bob", "Jones");
    Employee CoSub3 = new Employee("J. B.", "Fletcher");
    Employee CoSub4 = new Employee("Larry", "VanLast");
    Employee Rookie1 = new Employee("Mick", "Fresh");
    Employee Rookie2 = new Employee("Hugh", "DeGreen");
    Director.Subordinates.AddRange(new[] { SubDirector1, SubDirector2} );
    SubDirector1.Subordinates.AddRange(new[] { CoSub1, CoSub2 });
    SubDirector2.Subordinates.AddRange(new[] { CoSub3, CoSub4 });
    CoSub3.Subordinates.Add(Rookie1);
    CoSub4.Subordinates.Add(Rookie2);
