    public static class BlobContainerExtensions 
    {
       public static void Rename(this CloudBlobContainer container, string oldName, string newName)
       {
          //Warning: this Wait() is bad practice and can cause deadlock issues when used from ASP.NET applications
          RenameAsync(container, oldName, newName).Wait();
       }
    
       public static async Task RenameAsync(this CloudBlobContainer container, string oldName, string newName)
       {
          var source = await container.GetBlobReferenceFromServerAsync(oldName);
          var target = container.GetBlockBlobReference(newName);
            
          await target.StartCopyFromBlobAsync(source.Uri);
    
          while (target.CopyState.Status == CopyStatus.Pending)
                await Task.Delay(100);
    
          if (target.CopyState.Status != CopyStatus.Success)
              throw new Exception("Rename failed: " + target.CopyState.Status);
    
          await source.DeleteAsync();
        }
    }
