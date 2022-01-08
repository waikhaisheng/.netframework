using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Utils
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20220106
    /// UpdatedBy: Wai Khai Sheng
    /// Updated: 20220108
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FileSystemWatcherUtil<T>
    {
        public event FileSystemEventHandler FileSystemEventHandlerEventOnChanged;
        public event FileSystemEventHandler FileSystemEventHandlerEventOnCreated;
        public event FileSystemEventHandler FileSystemEventHandlerEventOnDeleted;
        public event RenamedEventHandler FileSystemEventHandlerEventOnRenamed;
        public event ErrorEventHandler FileSystemEventHandlerEventOnError;
        public T ObjectData { get; set; }
        private string _path;
        public FileSystemWatcherUtil()
        {
        }
        public void Initialization(string path)
        {
            _path = path;
            var filepath = Path.GetDirectoryName(path);
            var filename = Path.GetFileName(path);
            var watcher = new FileSystemWatcher(filepath);
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
            watcher.Changed += FileSystemEventHandlerEventOnChanged;
            watcher.Created += FileSystemEventHandlerEventOnCreated;
            watcher.Deleted += FileSystemEventHandlerEventOnDeleted;
            watcher.Renamed += FileSystemEventHandlerEventOnRenamed;
            watcher.Error += FileSystemEventHandlerEventOnError;
            watcher.Filter = filename;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }
    }
}
