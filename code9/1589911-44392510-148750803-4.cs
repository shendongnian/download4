    public void GetFormItemsByFormNumber() {
        using (var mock = AutoMock.GetLoose()) {
            // Arrange.
            var formNumber = 3392;
            var items = new List<FormItemsByFormNumber> {
                new FormItemsByFormNumber { 
                    //Populate as needed 
                },
                new FormItemsByFormNumber { 
                    //Populate as needed 
                },
                //...etc
            };
            var serviceMock = mock.Mock<IWebScrapSprocService>();
            serviceMock.Setup(x => x.GetFormItemsByFormNumber(formNumber)) // Calling this...
                .Returns(items) // should return some value...
                .Verifiable();  // and I want to verify that it was called.
            var sut = mock.Create<InScrapController>();
            // Act.   
            var response = sut.GetFormItemsByFormNumber(formNumber) as OkNegotiatedContentResult<TWhatEverTypeService>();
            // Assert.
            serviceMock.Verify(); //verify setups were exercised as expected.
            Assert.IsNotNull(response);
        }
    }
