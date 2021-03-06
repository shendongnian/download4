    private Semaphore _semaphore;
    private delegate void Processor(string fileName);
    [Test]
    public void SetterTest() {
      var queue = new Queue<string>();
      queue.Enqueue("1.mp3");
      queue.Enqueue("2.mp3");
      queue.Enqueue("3.mp3");
      // ..
      queue.Enqueue("10000.mp3");
      _semaphore = new Semaphore(5,5);
      
      while (queue.Count > 0) {
        string fileName;
        lock (queue) fileName = queue.Dequeue();
        new Processor(ProcessFile).BeginInvoke(fileName, null, null);
      }
    }
    private void ProcessFile(string file) {
      _semaphore.WaitOne();
      var p = new Process();
      p.StartInfo.FileName = @"binary.exe";
      p.StartInfo.Arguments = file;
      p.StartInfo.UseShellExecute = false;
      p.StartInfo.CreateNoWindow = true;
      p.StartInfo.RedirectStandardOutput = true;
      p.Start();
      p.WaitForExit();
      _semaphore.Release();
    }
