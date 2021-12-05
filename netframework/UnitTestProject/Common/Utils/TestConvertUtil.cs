using Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Common.Utils
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211205
    /// Updated: 
    /// </summary>
    [TestClass]
    public class TestConvertUtil
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestOunceToGram()
        {
            double t = 1;
            var ret = ConvertUtil.OunceToGram(t);
            Assert.AreEqual(ConvertUtil.OunceUnit, ret);
            var ret2 = t.OunceToGram();
            Assert.AreEqual(ConvertUtil.OunceUnit, ret2);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestOunceToGramSignificantDigits()
        {
            double t = 1;
            ushort r = 2; 
            var ret = ConvertUtil.OunceToGram(t, r);
            Assert.AreEqual(Math.Round(ConvertUtil.OunceUnit, 2), ret);
            var ret2 = t.OunceToGram(r);
            Assert.AreEqual(Math.Round(ConvertUtil.OunceUnit, 2), ret2);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGramToOunce()
        {
            double t = 1;
            var ret = ConvertUtil.GramToOunce(t);
            Assert.AreEqual(1/ConvertUtil.OunceUnit, ret);
            var ret2 = t.GramToOunce();
            Assert.AreEqual(1/ConvertUtil.OunceUnit, ret2);
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211205
        /// UpdatedBy:
        /// Updated: 
        /// </summary>
        [TestMethod]
        public void TestGramToOunceSignificantDigits()
        {
            double t = 1;
            ushort r = 2; 
            var ret = ConvertUtil.GramToOunce(t, r);
            Assert.AreEqual(Math.Round(1/ConvertUtil.OunceUnit, 2), ret);
            var ret2 = t.GramToOunce(r);
            Assert.AreEqual(Math.Round(1/ConvertUtil.OunceUnit, 2), ret2);
        }
    }
}
