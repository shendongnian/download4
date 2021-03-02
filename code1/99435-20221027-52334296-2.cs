	public class LibDesPasswordConvertor
	{
		public byte[] PasswordToKey(string password)
		{
			if (password == null)
				throw new ArgumentNullException("password");
			if (password == "")
				throw new ArgumentException("password");
			
			var key = new byte[8];
			for (int i = 0; i < password.Length; i++)
			{
				var c = (int)password[i];
				if ((i % 16) < 8)
				{
					key[i % 8] ^= (byte)(c << 1);
				}
				else
				{
					// reverse bits e.g. 11010010 -> 01001011
					c = (((c << 4) & 0xf0) | ((c >> 4) & 0x0f));
					c = (((c << 2) & 0xcc) | ((c >> 2) & 0x33));
					c = (((c << 1) & 0xaa) | ((c >> 1) & 0x55));
					key[7 - (i % 8)] ^= (byte)c;
				}
			}
			AddOddParity(key);
			var target = new byte[8];
			var passwordBuffer =
				Encoding.ASCII.GetBytes(password).Concat(new byte[8]).Take(password.Length + (8 - (password.Length % 8)) % 8).ToArray();
			var des = DES.Create();
			var encryptor = des.CreateEncryptor(key, key);
			for (int x = 0; x < passwordBuffer.Length / 8; ++x)
			{
				encryptor.TransformBlock(passwordBuffer, 8 * x, 8, target, 0);
			}
			AddOddParity(target);
			return target;
		}
		private void AddOddParity(byte[] buffer)
		{
			for (int i = 0; i < buffer.Length; ++i)
			{
				buffer[i] = _oddParityTable[buffer[i]];
			}
		}
		private static byte[] _oddParityTable = {
			  1,  1,  2,  2,  4,  4,  7,  7,  8,  8, 11, 11, 13, 13, 14, 14,
			 16, 16, 19, 19, 21, 21, 22, 22, 25, 25, 26, 26, 28, 28, 31, 31,
			 32, 32, 35, 35, 37, 37, 38, 38, 41, 41, 42, 42, 44, 44, 47, 47,
			 49, 49, 50, 50, 52, 52, 55, 55, 56, 56, 59, 59, 61, 61, 62, 62,
			 64, 64, 67, 67, 69, 69, 70, 70, 73, 73, 74, 74, 76, 76, 79, 79,
			 81, 81, 82, 82, 84, 84, 87, 87, 88, 88, 91, 91, 93, 93, 94, 94,
			 97, 97, 98, 98,100,100,103,103,104,104,107,107,109,109,110,110,
			112,112,115,115,117,117,118,118,121,121,122,122,124,124,127,127,
			128,128,131,131,133,133,134,134,137,137,138,138,140,140,143,143,
			145,145,146,146,148,148,151,151,152,152,155,155,157,157,158,158,
			161,161,162,162,164,164,167,167,168,168,171,171,173,173,174,174,
			176,176,179,179,181,181,182,182,185,185,186,186,188,188,191,191,
			193,193,194,194,196,196,199,199,200,200,203,203,205,205,206,206,
			208,208,211,211,213,213,214,214,217,217,218,218,220,220,223,223,
			224,224,227,227,229,229,230,230,233,233,234,234,236,236,239,239,
			241,241,242,242,244,244,247,247,248,248,251,251,253,253,254,254};
	}
