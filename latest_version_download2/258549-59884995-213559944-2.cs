    public class Entity
    {
        public string SpaceFunction { get; set; }
        public string Category { get; set; }
    }
    public class LightingEquipment : Entity
    {
        public LightingSource LightingSource { get; set; }
    }
    public class LightingSource
    {
        public string Name { get; set; }
    }
 
