	mockClient
		.Setup(ec => ec.DoWork(
			It.Is<List<IParamInterface>>(el => el[0] is ParamClass<ParamClassA> && ((ParamClass<ParamClassA>)el[0]).ParamData.ParamClassAVar == 123)
		))
		.Returns("123");
	mockClient
		.Setup(ec => ec.DoWork(
			It.Is<List<IParamInterface>>(el => el[0] is ParamClass<ParamClassB> && ((ParamClass<ParamClassB>)el[0]).ParamData.ParamClassBVar == "not 123")
		))
		.Returns("not 123");
