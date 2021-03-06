    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    
    namespace OctaneDownloadEngine
    {
        class Program
        {
            static void Main()
            {
                try
                {
                    // have to use this because you can't have async entrypoint
                    Task.WaitAll(SplitDownload("http://www.hdwallpapers.in/walls/tree_snake_hd-wide.jpg", @"c:\temp\output.jpg"));
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                    throw;
                }
    
                Console.ReadLine();
            }
    
            public static async Task<string> SplitDownload(string URL, string OUT)
            {
                var responseLength = WebRequest.Create(URL).GetResponse().ContentLength;
                var partSize = (long)Math.Floor(responseLength / 4.00);
    
                Console.WriteLine(responseLength.ToString(CultureInfo.InvariantCulture) + " TOTAL SIZE");
                Console.WriteLine(partSize.ToString(CultureInfo.InvariantCulture) + " PART SIZE" + "\n");
                var previous = 0;
                
                var fs = new FileStream(OUT, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, (int)partSize);
                try
                {
                    fs.SetLength(responseLength);
    
                    List<Tuple<Task<byte[]>, int, int>> asyncTasks = new List<Tuple<Task<byte[]>, int, int>>();
    
                    for (var i = (int)partSize; i <= responseLength + partSize; i = (i + (int)partSize) + 1)
                    {
                        var previous2 = previous;
                        var i2 = i;
    
                        // GetResponseAsync deadlocks for some reason so switched to HttpClient instead
                        HttpClient client =  new HttpClient() { MaxResponseContentBufferSize = 1000000 };
                        client.DefaultRequestHeaders.Range = new RangeHeaderValue(previous2, i2);
                        byte[] urlContents = await client.GetByteArrayAsync(URL);
    
                        // start each download task and keep track of them for later
                        Console.WriteLine("start {0},{1}", previous2, i2);
    
                        var downloadTask = client.GetByteArrayAsync(URL);
                        asyncTasks.Add(new Tuple<Task<byte[]>, int, int>(downloadTask, previous2, i2));
    
                        previous = i2;
                    }
    
                    // now that all the downloads are started, we can await the results
                    // loop through looking for a completed task in case they complete out of order
                    while (asyncTasks.Count > 0)
                    {
                        Tuple<Task<byte[]>, int, int> completedTask = null;
                        foreach (var task in asyncTasks)
                        {
                            // as each task completes write the data to the file
                            if (task.Item1.IsCompleted)
                            {
                                Console.WriteLine("await {0},{1}", task.Item2, task.Item3);
                                var array = await task.Item1;
    
                                Console.WriteLine("write to file {0},{1}", task.Item2, task.Item3);
                                fs.Position = task.Item2;
    
                                foreach (byte x in array)
                                {
                                    if (fs.Position != task.Item3)
                                    {
                                        fs.WriteByte(x);
                                    }
                                }
                                completedTask = task;
                                break;
                            }
                        }
                        asyncTasks.Remove(completedTask);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("close file");
                    fs.Close();
                }
                return OUT;
            }
        }
    }
