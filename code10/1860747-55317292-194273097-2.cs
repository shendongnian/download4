    public class Property
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public User User { get; set; }
        public int UserId {get; set; }
    }
    public class User : IdentityUser<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
        // This must be a collection
        public ICollection<Property> Properties { get; set; }
    }
