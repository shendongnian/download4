        static bool Compare2(string filePath1, string filePath2)
        {
            bool success = true;
            var info = new FileInfo(filePath1);
            var info2 = new FileInfo(filePath2);
            if (info.Length != info2.Length)
            {
                return false;
            }
            long fileLength = info.Length;
            const int size = 0x1000000;
            Parallel.For(0, fileLength / size, x =>
            {
                var start = (int)x * size;
                if (start >= fileLength)
                {
                    return;
                }
                using (FileStream file = File.OpenRead(filePath1))
                {
                    using (FileStream file2 = File.OpenRead(filePath2))
                    {
                        var buffer = new byte[size];
                        var buffer2 = new byte[size];
                        file.Position = start;
                        file2.Position = start;
                        int count = file.Read(buffer, 0, size);
                        file2.Read(buffer2, 0, size);
                        for (int i = 0; i < count; i++)
                        {
                            if (buffer[i] != buffer2[i])
                            {
                                success = false;
                                return;
                            }
                        }
                    }
                }
            });
            return success;
        }
