var person = new Person();
var people = new List<Person> { person };
var cousins = person.Parents().Siblings().Children();
// Or
var cousins = people.Parents().Siblings().Children();
Since you want to start chaining on a person/people, this person needs to be aware of the FamilyGraph they belong to.
public class Person {
    public FamilyGraph FamilyGraph { get; set; }
    IEnumerable<Person> Parents() => FamilyGraph.Get(person).Parents;
    IEnumerable<Person> Children() => 
        FamilyGraph.Get(person).Edges
          .Where(m => m.RelationshipType == RelationshipType.Parent)
          .Select(m => m.Target)
          .ToList();
    IEnumerable<Person> Siblings() => FamilyGraph.Get(person)./* your logic here */;
}
public static class PeopleExtensions 
{
    public static IEnumerable<Person> Parents(this IEnumerable<Person> people) =>
        people.SelectMany(person => person.Parents()).ToList();
    public static IEnumerable<Person> Siblings(this IEnumerable<Person> people) =>
        people.SelectMany(person => person.Siblings()).ToList();
    public static IEnumerable<Person> Children(this IEnumerable<Person> people) =>
        people.SelectMany(person => person.Children()).ToList();
}
If you want to make a Person non-aware of the FamilyGraph, you can provide the graph as a dependency to the extension methods.
public static class PersonExtensions
{
    public static IEnumerable<Person> Parents(this Person person, FamilyGraph graph) => 
       graph.get(person).Parents;
    public static IEnumerable<Person> Children(this Person person, FamilyGraph graph) =>
        graph.get(person).Edges
          .Where(m => m.RelationshipType == RelationshipType.Parent)
          .Select(m => m.Target)
          .ToList();
}
The enumerable extension methods need to be extended in the above manner as well. Usage,
var cousins = person.Parents(familygraph).Siblings(familygraph).Children(familyGraph);
Edit: If you would prefer not passing the FamilyGraph as a dependency, the query has to begin on the graph as opposed to on the person.
var cousins = FamilGraph.get(person).Parents().Children().
