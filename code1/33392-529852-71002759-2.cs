    public static class ShortCodes
    {
        private static Random rand = new Random();
        // You may change the "shortcode_Keyspace" variable to contain as many or as few characters as you
        // please.  The more characters that aer included in the "shortcode_Keyspace" constant, the shorter
        // the codes you can produce for a given long.
    const string shortcode_Keyspace = "abcdefghijklmnopqrstuvwxyz0123456789";
        // Arbitrary constant for the maximum length of ShortCodes generated by the application.
    const int shortcode_maxLen = 12;
        public static string LongToShortCode(long number)
        {
            int ks_len = shortcode_Keyspace.Length;
            string sc_result = "";
            long num_to_encode = number;
            long i = 0;
            do
            {
                i++;
                sc_result = shortcode_Keyspace[(int)(num_to_encode % ks_len)] + sc_result;
                num_to_encode = ((num_to_encode - (num_to_encode % ks_len)) / ks_len);
            }
            while (num_to_encode != 0);
            return sc_result;
        }
        public static long ShortCodeToLong(string shortcode)
        {
            int ks_len = shortcode_Keyspace.Length;
            long sc_result = 0;
            int sc_length = shortcode.Length;
            string code_to_decode = shortcode;
            for (int i = 0; i < code_to_decode.Length; i++)
            {
                sc_length--;
                char code_char = code_to_decode[i];
                sc_result += shortcode_Keyspace.IndexOf(code_char) * (long)(Math.Pow((double)ks_len, (double)sc_length));
            }
            return sc_result;
        }
    }
