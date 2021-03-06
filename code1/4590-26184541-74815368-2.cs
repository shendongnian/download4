        /// <summary>
        /// Reads Line from console with timeout. 
        /// </summary>
        /// <exception cref="System.TimeoutException">If user does not enter line in the specified time.</exception>
        /// <param name="timeout">Time to wait in milliseconds. Negative value will wait forever.</param>        
        /// <returns></returns>        
        public static string ReadLine(int timeout = -1)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            StringBuilder sb = new StringBuilder();
            // if user does not want to spesify a timeout
            if (timeout < 0)
                return Console.ReadLine();
            int counter = 0;
            while (true)
            {
                while (Console.KeyAvailable == false)
                {
                    counter++;
                    Thread.Sleep(1);
                    if (counter > timeout)
                        throw new System.TimeoutException("Line was not entered in timeout specified");
                }
                cki = Console.ReadKey(false);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return sb.ToString();
                }
                else
                    sb.Append(cki.KeyChar);                
            }            
        }
