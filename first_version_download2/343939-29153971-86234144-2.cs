    var vehicles = new Stack<Vehicle>();
    var veh = new Vehicle {Class = "A", Speed = 280, Active = true};
    vehicles.Push(veh);
    veh = new Vehicle {Class = "C", Speed = 200, Active = false};
    vehicles.Push(veh);
    veh = new Vehicle {Class = "B", Speed = 160, Active = true};
    vehicles.Push(veh);
    veh = new Vehicle {Class = "AAA", Speed = 320, Active = false};
    vehicles.Push(veh);
        
    foreach (var v in vehicles)
    {
        Console.WriteLine();
        Console.WriteLine(v.Class);
        Console.WriteLine(v.Speed);
        Console.WriteLine(v.Active);
    }
