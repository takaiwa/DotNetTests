namespace DotNetTests.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DotNetTests;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class UtilTests
    {
        /// <summary>
        /// ログオンしているユーザー名を取得するテスト.
        /// </summary>
        [TestMethod]
        public void GetCurrentNameTest()
        {
            string actual = Util.GetCurrentName();

            Console.WriteLine(string.Format("actual:{0}", actual));

            Assert.AreNotEqual(actual.Length, 0);
        }
    }
}