    using (var context = new TestDbContext())
    {
      var child = new Child { Name = "test", ParentId = 10 };
      context.Children.Add(child);
      context.SaveChanges();
      Assert.IsNull(child.Parent);
      var parent = context.Parents.Find(10);
      Assert.IsNotNull(child.Parent); // Poof, Parent is now a proxy pointing to the Parent.
    }
