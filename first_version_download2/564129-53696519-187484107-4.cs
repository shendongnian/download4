    internal class Movement : ISystem
    {
        public void Update()
        {
            foreach (Entity entity in EntityPool.activeEntities.Values) // Loop through all entities
            {
                var posComponent = entity.Components.TryGetValue<Position>();
                if (posComponent != null)
                {
                    // some code
                }
            }
        }
    }
