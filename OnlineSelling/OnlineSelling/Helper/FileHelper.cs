using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
namespace OnlineSelling.Helper
{
    class FileHelper
    {
        public static T ReadFile<T>(string fullpath)
        {
            string responseData = string.Empty;
            using (StreamReader sr = File.OpenText(fullpath))
            {
                responseData = sr.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public static void WriteFile<T>(string fullpath, T model)
        {
            using (StreamWriter sw = File.CreateText(Path.Combine(fullpath)))
            {
                var jsonData = JsonConvert.SerializeObject(model, Formatting.Indented);
                sw.Write(jsonData);
            }
        }
    }
}
