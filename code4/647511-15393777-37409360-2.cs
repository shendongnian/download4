    //First lets pack the color
    Color color = new Color(155, 72, 98, 255);
    uint packedColor = color.PackedValue;
    //Now unpack it to get the original value.
    Color unpackedColor = new Color();
    unpackedColor.B = (byte)(packedColor);
    unpackedColor.G = (byte)(packedColor >> 8);
    unpackedColor.R = (byte)(packedColor >> 16);
    unpackedColor.A = (byte)(packedColor >> 24);
