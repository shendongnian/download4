      using (var ms = new MemoryStream())
      {
          if (fs.CanSeek) 
          {
              fs.Seek(5, SeekOrigin.Begin);
              fs.CopyTo(ms, 5);
              //byte[] b = ms.ToArray();
              // create a StreamContent object
              var sc = new StreamContent(ms);
          }
      }
