	IAnimal anyTypeOfAnimal = new Cat();
	IAnimal anotherAnimal = new Fish();
    public void TestInterface(IAnimal obj)
    {
         Console.Log(obj.HasFur);
    }
    TestInterface(anyTypeOfAnimal.HasFur); //True
    TestInterface(anotherAnimal.HasFur); //False
