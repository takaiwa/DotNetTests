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
    public class ExcelSampleTests
    {
        [TestMethod]
        public void CreateNewBookTest()
        {
            ExcelSample es = new ExcelSample();
            es.CreateNewBook("foobar.xlsx", "hoge");


        }
    }
}