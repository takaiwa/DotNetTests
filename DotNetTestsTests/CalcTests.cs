namespace DotNetTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DotNetTests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Calcクラステスト用のクラス.
    /// </summary>
    [TestClass]
    public class CalcTests
    {
        /// <summary>
        /// Get/Set the TestContext. 
        /// This property is set automatically from the unit testing framework.
        /// </summary>
        private TestContext _TestInstance;
        public TestContext TestContext
        {
            get { return _TestInstance; }
            set { _TestInstance = value; }
        }

        /// <summary>
        /// 足し算メソッドの検証.
        /// </summary>
        /// <param name="x">第一引数.</param>
        /// <param name="y">第二引数.</param>
        /// <param name="expected">第一引数と第二引数を足した合計の予測.</param>
        [TestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(10, 22, 32)]
        public void SumTest(int x, int y, int expected)
        {
            Calc cal = new Calc();

            // 出力による確認 ※テストエクスプローラーに出力される
            Console.WriteLine("x:" + x + ", y:" + y + ", expected:" + expected);

            int actual = cal.Sum(x, y);
            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> TestData
        {
            get
            {
                return new[]
                {
                    new object[] { 1, 2, 3 },
                    new object[] { 10, 22, 32 },
                };
            }
        }

        /// <summary>
        /// DataRowに配列を使ってテスト.
        /// </summary>
        /// <param name="a">入力の配列.</param>
        /// <param name="expected">期待値.</param>
        [TestMethod]
        [DataRow(new[] { 1, 2 }, 3)]
        [DataRow(new[] { 10, 22 }, 32)]
        public void ArraySumTest(int [] a, int expected)
        {
            Calc cal = new Calc();
            int actual = cal.Sum(a[0], a[1]);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TestDataを使ってテスト.
        /// </summary>
        /// <param name="x">第一引数.</param>
        /// <param name="y">第二引数.</param>
        /// <param name="expected">第一引数と第二引数を足した合計の予測.</param>
        [TestMethod]
        [DynamicData("TestData")]
        public void DynamicDataSumTest(int x, int y, int expected)
        {
            Calc cal = new Calc();
            int actual = cal.Sum(x, y);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// DataSourceのXMLを使ってテストを実行.
        /// ※TestContext.DataRowがエラーの場合、right click your test project, Add->Reference...->Assemblies->Framework->System.Data, check it.
        ///   テストデータとして使うXMLファイルの相対パスは、exeからの相対パス.
        /// </summary>
        [TestMethod]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            @"..\..\testdata\TestData.xml",
            "Row",
            DataAccessMethod.Sequential)]
        public void DataSourceXMLSumTest()
        {
            int x = Convert.ToInt32(this.TestContext.DataRow["x"]);
            int y = Convert.ToInt32(this.TestContext.DataRow["y"]);
            int expected = Convert.ToInt32(this.TestContext.DataRow["expected"]);

            Calc cal = new Calc();
            int actual = cal.Sum(x, y);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// DataSourceのCSVを使ってテストを実行.
        /// ※CSVファイル、SJISでないと失敗した.
        /// </summary>
        [TestMethod]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"..\..\testdata\TestData.csv",
            "TestData#csv",
            DataAccessMethod.Sequential)]
        public void DataSourceCSVSumTest()
        {
            int x = Convert.ToInt32(this.TestContext.DataRow["x"]);
            int y = Convert.ToInt32(this.TestContext.DataRow["y"]);
            int expected = Convert.ToInt32(this.TestContext.DataRow["expected"]);

            Calc cal = new Calc();
            int actual = cal.Sum(x, y);
            Assert.AreEqual(expected, actual);
        }
    }
}