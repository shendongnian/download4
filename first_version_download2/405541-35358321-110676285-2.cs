    public partial class Cuisine
    {
        public int Id { get; set; }
        [Display(Name="Cuisine Name")]
        public string Name { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
    }
