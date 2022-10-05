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

            SettingsData sd1 = new SettingsData();
            sd1.ID = 123;
            sd1.Name = "foobar";

            SettingSample.JsonSerialize<SettingsData>(sd1, filePath);

            SettingsData sd2 = SettingSample.JsonDeserialize<SettingsData>(filePath);

            Console.WriteLine("ID:" + sd2.ID + ", Name:" + sd2.Name);
        }
    }
}