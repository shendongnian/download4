    using System.Runtime.InteropServices;
    [StructLayout(LayoutKind.Explicit)]
    struct Color
    {
      [FieldOffset(0)]
      public byte R;
      [FieldOffset(1)]
      public byte G;
      [FieldOffset(2)]
      public byte B;
      [FieldOffset(3)]
      public byte A;
      [FieldOffset(0)]
      public uint value;
    }
