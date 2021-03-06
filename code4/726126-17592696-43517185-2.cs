    public void SomeMethod() {
         // here you get your `list`
         var tree = GetTree(list, 0);
    }
    
    public List<Tree> GetTree(List<Personal> list, int parent) {
        return list.Where(x => x.ParentId == parent).Select(x => new Tree {
            Id = x.Id,
            Name = x.Name,
            List = GetTree(list, x.Id)
       }).ToList();
    }
