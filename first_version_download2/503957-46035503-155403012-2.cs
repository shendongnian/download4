    Mock<IMongoQueryable<ConcreteType>> _mongoQueryableMock;
    public ReviseMeasureRepository() {    
        var queryableList = _data.AsQueryable();
    
        _mongoQueryableMock = new Mock<IMongoQueryable<ConcreteType>>();
        _mongoQueryableMock.As<IQueryable<TItem>>().Setup(x => x.Provider).Returns(queryableList.Provider);
        _mongoQueryableMock.As<IQueryable<TItem>>().Setup(x => x.Expression).Returns(queryableList.Expression);
        _mongoQueryableMock.As<IQueryable<TItem>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
        _mongoQueryableMock.As<IQueryable<TItem>>().Setup(x => x.GetEnumerator()).Returns(() => queryableList.GetEnumerator());    
    }
