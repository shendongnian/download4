Person person;
List<Person> people;
# Solution
BTW. @fubo was first but I think this is more complete
var searchName = Console.ReadLine();
var results = PeopleList
    .Where(x => x.Name.Contains(searchName, StringComparison.InvariantCultureIgnoreCase))
    .ToList();
if (results.Any())
{
    foreach (var person in results)
    {
        Console.WriteLine($"Found: {person.Name}");
    }
}
else
{
    Console.WriteLine("Name not found");
}
----
# Test
## Code
class Person { public string Name { get; set; } }
public static void Main(string[] args)
{
    var PeopleList = new[] { new Person { Name = "marneee" }, new Person { Name = "Mark" } };
    while (true)
    {
        var searchName = Console.ReadLine();
        var results = PeopleList
            .Where(x => x.Name.Contains(searchName, StringComparison.InvariantCultureIgnoreCase))
            .ToList();
        if (results.Any())
        {
            foreach (var person in results)
            {
                Console.WriteLine($"Found: {person.Name}");
            }
        }
        else
        {
            Console.WriteLine("Name not found");
        }
    }
}
## Output
// .NETCoreApp,Version=v3.0
mar
Found: marneee
Found: Mark
marn
Found: marneee
