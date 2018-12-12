using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TesteProgrammers
{
    public static class FilesBackup
    {
        public static bool CheckPath(string path)
        {
            return Directory.Exists(path);
        }

        public static List<string> CheckDuplicateFilesByContent(string path)
        {          
            List<FolderFile> files = GetDirectoryFiles(path);

            List<string> duplicateFiles = files.Select(f =>
            {
                using (var fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read))
                {
                    return new
                    {
                        FileName = f.FileName,
                        FullName = f.FullName,
                        FileHash = BitConverter.ToString(SHA1.Create().ComputeHash(fs))
                    };
                }
            }).GroupBy(f => new { f.FileName, f.FileHash })
            .Select(g => new { Hash = g.Key, Files = g.Select(x => x.FullName).ToList() })
            .Where(f=> f.Files.Count > 1)
            .SelectMany(f => f.Files).ToList();

            return duplicateFiles;
        }

        private static List<FolderFile> GetDirectoryFiles(string path)
        {
            List<FolderFile> files = new List<FolderFile>();
            files.AddRange(Directory.GetFiles(path).Select(f=> new FolderFile { FileName = f.Split('\\').Last(), FullName = f }).ToList());
            var directories = Directory.GetDirectories(path);
            if (directories.Any())
            {
                foreach (string dir in directories)
                {                    
                    files.AddRange(GetDirectoryFiles(dir));
                }
            }
            return files;
        }

    }
}
