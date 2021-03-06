csharp
public class User
{
    [Key, Column(Order = 0)]
    public Guid Id { get; set; }
    public string FullName { get; set; }
}
public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<User> Users { get; set; }
}
public class MyTests
{
    [Fact]
    public void Test()
    {
        var initialEntities = new[]
        {
            new User { Id = Guid.NewGuid(), FullName = "Eric Cartoon" },
            new User { Id = Guid.NewGuid(), FullName = "Billy Jewel" },
        };
        
        var dbContextMock = new DbContextMock<TestDbContext>(DummyOptions);
        var usersDbSetMock = dbContextMock.CreateDbSetMock(x => x.Users, initialEntities);
    
        // Pass dbContextMock.Object to the class/method you want to test
    
        // Query dbContextMock.Object.Users to see if certain users were added or removed
        // or use Mock Verify functionality to verify if certain methods were called: usersDbSetMock.Verify(x => x.Add(...), Times.Once);
   }
    public DbContextOptions<TestDbContext> DummyOptions { get; } = new DbContextOptionsBuilder<TestDbContext>().Options;
}
