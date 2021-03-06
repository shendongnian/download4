    public static object GetTypedString(List<byte> varBytes, string varType) {
      if (null == varBytes)
        throw new ArgumentNullException(nameof(varBytes));
      else if (null == varType)
        throw new ArgumentNullException(nameof(varType));
      Type type = null;
      if (!s_Types.TryGetValue(varType, out type))
        throw new ArgumentException(
          $"Type name {varType} is not a valid type name.", 
            nameof(varBytes));
      int size = System.Runtime.InteropServices.Marshal.SizeOf(type);
      byte[] data = (size >= varBytes.Count)
        ? BitConverter.IsLittleEndian
           ? varBytes.Concat(new byte[size - varBytes.Count]).ToArray()
           : new byte[size - varBytes.Count].Concat(varBytes).ToArray()
        : varBytes.ToArray();
      var mi = typeof(BitConverter).GetMethod($"To{type.Name}");
      
      if (null == mi)
        throw new InvalidOperationException(
          $"Type {type.Name} (name: {varType}) can't be converted");
      else
        return mi.Invoke(null, new object[] { data, 0 }); // data.Length - size
    }
