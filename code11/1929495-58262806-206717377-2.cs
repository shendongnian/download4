public class Project
{
    [Key]
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    ...
    public ICollection<ProjectTechnologyLink> ProjectTechnologyLink
}
public class Technology
{ 
    public Technology()
    {
        ProjectTechnologyLink = new HashSet<ProjectTechnologyLink>();
    }
    [Key]
    public int TechnologyId { get; set; }
    public string TechnologyName { get; set; }
    ...
    public ICollection<ProjectTechnologyLink> ProjectTechnologyLink { get; set; }
 }
public class ProjectTechnologyLink 
{
    [Key, Column(Order = 0)]
    public int ProjectId { get; set; }
    [Key, Column(Order = 0)]
    public int TechnologyId { get; set; }
    ...
    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; }
    [ForeignKey(nameof(TechnologyId))]
    public Technology Technology { get; set; }
}
> __Conventions:__
The previous example demonstrates pure attribute notation. It is very possible to replace the default _Conventions_ with your own for defining primary and foreign keys. Meaning it is theoretically possible to not have any attributes or Fluent notation at all. I try to discourage a pure convention based approach because it makes it a bit harder to find the configuration in a large or distributed schema definition, which is also the same argument I use to discourage a pure Fluent API approach, attributes are the logical place  to document the expected usage of a table or field.
