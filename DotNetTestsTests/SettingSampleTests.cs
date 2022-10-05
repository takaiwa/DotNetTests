namespace DotNetTests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DotNetTests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SettingSampleTests
    {
        [TestMethod]
        public void JsonSerializeTest()
        {
            string filePath = @"c:\work\settings.json";

            // 設定ファイル用のデータ作成
            SettingsData sd1 = new SettingsData();
            sd1.ID = 123;
            sd1.Name = "foobar";
            sd1.list = new List<string>();

            sd1.list.Add("hoge1");
            sd1.list.Add("hoge2");
            sd1.list.Add("hoge3");

            // 設定ファイル書き込み
            SettingSample.JsonSerialize<SettingsData>(sd1, filePath);

            // 設定ファイル読み込み
            SettingsData sd2 = SettingSample.JsonDeserialize<SettingsData>(filePath);

            Console.WriteLine("ID:" + sd2.ID + ", Name:" + sd2.Name + ", list[0]:" + sd2.list[0]);
        }
    }
}