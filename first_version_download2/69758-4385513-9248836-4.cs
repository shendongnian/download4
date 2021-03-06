        Type magicType = Type.GetType("MagicClass");
        ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
        object magicClassObject = magicConstructor.Invoke(new object[]{});
        // Get the ItsMagic method and invoke with a parameter value of single 3.45
        MethodInfo magicMethod = magicType.GetMethod("ItsMagic");
        object magicValue = magicMethod.Invoke(magicClassObject, new object[]{ single.Parse("3.45")});
