     class ResourceHelper
        {
               public static void MakeFileOutOfAStream(string stream, string filePath)
                {
                    using(var fs = new FileStream(filePath,FileMode.Create,FileAccess.ReadWrite))
                    {
                        CopyStream(GetStream(stream), fs);
                    }
                }
        
                static void CopyStream(Stream input, Stream output)
                {
                    byte[] buffer = new byte[32768];
                    int read;
                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, read);
                    }
                }
     static String GetStream(string stream)
            {
                string s = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(stream)).ReadToEnd();
    
                return s;
            }
        }
