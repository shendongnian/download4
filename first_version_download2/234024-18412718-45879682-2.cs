    static string Encr(string plainText, string key)
    {
        byte[] chars = new byte[plainText.Length];
        int h = 0;
        for (int i = 0; i < plainText.Length; i++)
        {
            if (h == key.Length)
                h = 0;
            int j = plainText[i] + key[h];
            chars[i] = (byte)j;
            h++;
        }
        using (var stream = File.Create(FILE_NAME);
        {
            stream.Write(chars, 0, chars.Length);
        }
        return System.Text.Encoding.UTF8.GetString(chars);
    }
