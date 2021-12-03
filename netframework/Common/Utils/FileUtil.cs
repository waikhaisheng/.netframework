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
    }
}
