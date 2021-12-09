using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211130
    /// Updated: 
    /// </summary>
    public static class FileUtil
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211130
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="findName"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211130
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="findName"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211206
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bytes"></param>
        public static void WriteAllBytes(string path, byte[] bytes)
        {
            File.WriteAllBytes(path, bytes);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211206
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static byte[] ReadAllBytes(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(path);
            return File.ReadAllBytes(path);
        }
    }
}
