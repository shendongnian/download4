    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    namespace Recurser
    {
        public class Recurser
        {
            public readonly List<DirectoryInfo> Folders;
            public readonly List<FileInfo> Files;
            public string RootFolder
            public Recurser(string RootFolder) : this(RootFolder, "*.*")
            {
            }
            public Recurser(string RootFolder, string SearchPattern)
            {
                this.Folders = new List<DirectoryInfo>();
                this.Files = new List<FileInfo>();
                this.RootFolder = RootFolder;
            }
            public void Start()
            {
                this.Folders.Clear();
                this.Files.Clear();
                int iCount = 0;
                if (Directory.Exists(this.RootFolder))
                {
                    this.Folders.Add(new DirectoryInfo(this.RootFolder));
                    while (iCount < this.Folders.Count)
                    {
                        Directory.GetDirectories(this.Folders[iCount].FullName).ToList<string>().ForEach((string Folder) => this.Folders.Add(new DirectoryInfo(Folder)));
                        Directory.GetFiles(this.Folders[iCount].FullName).ToList<string>().ForEach((string File) => this.Files.Add(new FileInfo(File)));
                        iCount = checked(iCount + 1);
                    }
                }
            }
        }
    }
