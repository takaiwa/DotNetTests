namespace DotNetTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;

    // System.Text.Json;はnugetで取得
    public class SettingSample
    {
        public static void JsonSerialize<T>(T data, string jsonFilePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            using (var stream = new FileStream(jsonFilePath, FileMode.Create, FileAccess.Write))
            {
                JsonSerializer.SerializeAsync(stream, data, options);
            }
        }

        public static T JsonDeserialize<T>(string jsonFilePath)
        {
            var jsonString = File.ReadAllText(jsonFilePath);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }

    public class SettingsData
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
