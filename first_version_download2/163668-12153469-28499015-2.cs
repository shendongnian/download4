    string hex = "0a0b0c0d";
    byte[] raw = new byte[hex.Length / 2];
    for (int i = 0; i < raw.Length; i++)
    {
        raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
    }
    float f = BitConverter.ToSingle(raw, 0);
