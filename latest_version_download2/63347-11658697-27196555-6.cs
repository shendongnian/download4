    var asm = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("MyAsm"), AssemblyBuilderAccess.Run);
    var mod = asm.DefineDynamicModule("MyModule");
    TypeBuilder typeBuilder = mod.DefineType("TestWebService");
    MethodBuilder mb = typeBuilder.DefineMethod("Hello", MethodAttributes.Public, CallingConventions.Standard, typeof(string), new Type[] { typeof(string) });
    var cab = new CustomAttributeBuilder( typeof(WebMethodAttribute).GetConstructor(new Type[]{}), new object[]{} );
    mb.SetCustomAttribute(cab);
    mb.DefineParameter(1, ParameterAttributes.In, "namex");
    mb.GetILGenerator().Emit(OpCodes.Ret);
    Type type = typeBuilder.CreateType();
