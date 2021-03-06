	static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
	{
		// Check arguments.
		if (plainText == null || plainText.Length <= 0)
			throw new ArgumentNullException("plainText");
		if (Key == null || Key.Length <= 0)
			throw new ArgumentNullException("Key");
		if (IV == null || IV.Length <= 0)
			throw new ArgumentNullException("Key");
		byte[] encrypted;
		// Create an Rijndael object
		// with the specified key and IV.
		using (Rijndael rijAlg = Rijndael.Create())
		{
			rijAlg.Key = Key;
			rijAlg.IV = IV;
			// Create a decrytor to perform the stream transform.
			ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
			// Create the streams used for encryption.
			using (MemoryStream msEncrypt = new MemoryStream())
			{
				using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
				{
					using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
					{
						//Write all data to the stream.
						swEncrypt.Write(plainText);
					}
					encrypted = msEncrypt.ToArray();
				}
				using (FileStream file = new FileStream("file.bin", FileMode.Create, System.IO.FileAccess.Write))
				{
					file.Write(encrypted, 0, encrypted.Length);
				}
			}
		}
	}
