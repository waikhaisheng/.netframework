using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public static class FileUtil
    {
        public static List<string> GetDirectoryByFolderName(string dirName, string findName)
        {
            var ret = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(dirName);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {dirName}");
            }
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (var item in dirs)
            {
                if (item.FullName.Contains(findName))
                {
                    GetDirectoryByFolderName(item.FullName, findName);
                    ret.Add(item.FullName);
                }
            }
            return ret;
        }
        
        public static List<string> GetDirectoryByFileName(string dirName, string findName)
        {
            var ret = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(dirName);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {dirName}");
            }
            FileInfo[] files = dir.GetFiles();
            foreach (var item in files)
            {
                if (item.FullName.Contains(findName))
                {
                    ret.Add(item.FullName);
                }
            }
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (var item in dirs)
            {
                GetDirectoryByFileName(item.FullName, findName);
            }
            return ret;
        }
    }
}
