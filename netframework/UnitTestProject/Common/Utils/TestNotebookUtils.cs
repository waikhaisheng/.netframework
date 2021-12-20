using Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject.Common.Utils
{
    [TestClass]
    public class TestNotebookUtils
    {
        [TestMethod]
        public void TestMethod1()
        {
            System.Diagnostics.Debug.WriteLine("");
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestTask()
        {
            string ret = "";
            try
            {
                using (var cts = new CancellationTokenSource())
                {
                    var t1 = Task.Run(() =>
                    {
                        while (true)
                        {
                            if (cts.Token.IsCancellationRequested)
                            {
                                //throw new TaskCanceledException();
                                //throw new OperationCanceledException();
                                cts.Token.ThrowIfCancellationRequested();
                            }
                        }
                    }, cts.Token);
                    cts.Cancel();
                    t1.Wait();
                }
            }
            catch (TaskCanceledException ex)
            {
                ret = ex?.InnerException?.Message;
            }
            catch (OperationCanceledException ex)
            {
                ret = ex?.InnerException?.Message;
            }
            catch (Exception ex)
            {
                ret = ex?.InnerException?.Message;
            }
            Assert.AreEqual("A task was canceled.", ret);
        }
        [TestMethod]
        public async Task TestAsyncTask()
        {
            SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);
            try
            {
                await _semaphoreSlim.WaitAsync();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }
        [TestMethod]
        public void TestMoveFile()
        {
            var path = @"..\..\Common\TestLocalFiles\TestWriteBytes.txt";
            var toPath = @"..\..\Common\TestLocalFiles\TestWriteBytes.bat";
            using (StreamReader sr = new StreamReader
                    (File.Open(path, FileMode.Open)))
            {
                Console.WriteLine(sr.ReadLine());
            }
            File.Move(path, toPath);
            File.Move(toPath, path);
        }
        [TestMethod]
        public void TestStream()
        {
            var sb = new StringBuilder();
            var path = @"..\..\Common\TestLocalFiles\TestWriteBytes.txt";
            using (var fs = File.OpenRead(path))
            {
                var b = new byte[1024];
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    sb.Append(Encoding.ASCII.GetString(b));
                }
            }
            var ret = sb.ToString();
            Assert.IsNotNull(ret);
        }
        [TestMethod]
        public void TestYield()
        {
            var _listA = new List<int> { 1, 2, 3, 4, 5 };
            foreach (var item in TestYieldListAMoreThan3(_listA))
            {
                System.Diagnostics.Debug.WriteLine(item);
                Assert.IsTrue(item > 3);
            }
        }
        private IEnumerable<int> TestYieldListAMoreThan3(List<int> _listA)
        {
            foreach (var item in _listA)
            {
                if (item > 3)
                {
                    yield return item;
                }
            }
        }
    }
}
