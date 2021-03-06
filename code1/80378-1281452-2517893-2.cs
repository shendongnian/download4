        var assemblyName = new AssemblyName("tmp");
        var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        var module = assembly.DefineDynamicModule("tmp");
        var foo = module.DefineType("Foo");
        var bar = module.DefineType("Bar");
        var barOnFoo = foo.DefineField("bar", bar, FieldAttributes.Private);
        var fooOnBar = bar.DefineField("foo", foo, FieldAttributes.Private);
        var barCtor = bar.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis, new Type[] { foo });
        var il = barCtor.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Stfld, fooOnBar);
        il.Emit(OpCodes.Ret);
        var fooCtor = foo.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis, Type.EmptyTypes);
        il = fooCtor.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Newobj, barCtor);
        il.Emit(OpCodes.Stfld, barOnFoo);
        il.Emit(OpCodes.Ret);
        // create the actual types and test object creation
        Type fooType = foo.CreateType(), barType = bar.CreateType();
        object obj = Activator.CreateInstance(fooType);
