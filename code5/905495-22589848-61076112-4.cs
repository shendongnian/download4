    class GenericSpaceShip
    {
        public virtual void Visit(GenericPlanet planet)
        {
            Console.WriteLine("Generic");
        }
    }
    
    class SpaceShip : GenericSpaceShip
    {
        public override void Visit(GenericPlanet planet)
        {
            Console.WriteLine("Specific");
        }
    }
