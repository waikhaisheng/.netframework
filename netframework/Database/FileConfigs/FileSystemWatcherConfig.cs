using Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Database.FileConfigs
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20220106
    /// UpdatedBy: Wai Khai Sheng
    /// Updated: 20220108
    /// </summary>
    public class FileSystemWatcherConfig
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20220106
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        public static FileSystemWatcherUtil<Dictionary<string, string>> DictConfigInstance { get; set; }

        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20220106
        /// UpdatedBy: Wai Khai Sheng
        /// Updated: 20220108
        /// </summary>
        public void SetupFileSystemWatcherConfig()
        {
            var path = ConfigurationManager.AppSettings["DictConfig"];
            DictConfigInstance = new FileSystemWatcherUtil<Dictionary<string, string>>();
            DictConfigInstance.FileSystemEventHandlerEventOnChanged += OnChanged;
            DictConfigInstance.FileSystemEventHandlerEventOnCreated += OnCreated;
            DictConfigInstance.FileSystemEventHandlerEventOnDeleted += OnDeleted;
            DictConfigInstance.FileSystemEventHandlerEventOnRenamed += OnRenamed;
            DictConfigInstance.FileSystemEventHandlerEventOnError += OnError;
            DictConfigInstance.Initialization(path);
            DictConfigInstance.ObjectData = GetObj(path);
        }

        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20220108
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetObj(string path)
        {
            try
            {
                Thread.Sleep(100);
                var jString = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(jString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return null;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20220108
        /// UpdatedBy: 
        /// Updated: 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Thread.Sleep(100);
            DictConfigInstance.ObjectData = GetObj(ConfigurationManager.AppSettings["DictConfig"]);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20220108
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCreated(object sender, FileSystemEventArgs e)
        {
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20220108
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20220108
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20220108
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnError(object sender, ErrorEventArgs e)
        {
            LogException(e.GetException());
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20220108
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="ex"></param>
        private void LogException(Exception ex)
        {
            if (ex != null)
            {
                Debug.WriteLine($"Message: {ex.Message}");
                Debug.WriteLine($"Stacktrace: {ex.StackTrace}");
                LogException(ex.InnerException);
            }
        }
    }
}
