    public class OwnerViewModel
    {
        public Owner Owner{ get; set; }
        public bool HasPets{ get { return this.Owner.Pets.Count > 0; } }
    }  
    var ownervms = new List<OwnerViewModel>();
    foreach (var owner in context.Owners)
    {
        ownervms.Add(new OwnerViewModel() {Owner= owner});
    }
