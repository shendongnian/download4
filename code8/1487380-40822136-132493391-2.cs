    private Mock<IMyItemInDatabase> MyItemInDatabaseModel { get; set; };
    [TestInitialize]
    public void Setup()
    {
        var mockSitecoreContext = new Mock<ISitecoreContext>();
        this.MyItemInDatabaseModel = new Mock<IMyItemInDatabase>();
        this.MyItemInDatabaseModel.SetupAllProperties();
        
        mockSitecoreContext.Setup(sc =>sc.GetItem<IMyItemInDatabase
            (It.IsAny<string>(), false, false)).
            Returns(this.MyItemInDatabaseModel.Object);
    }
    
    [TestMethod]
    public void MyItemInDatabaseModel_Should_Not_Be_Null()
    {
        //....perform unit test here
    }
