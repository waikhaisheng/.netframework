using Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
    }
}
