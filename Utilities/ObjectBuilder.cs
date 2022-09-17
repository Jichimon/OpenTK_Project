using Newtonsoft.Json;
using OpenTK_Project.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.Utilities
{
    class ObjectBuilder
    {
        public static Figure BuildFromJson(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            Figure objeto = JsonConvert.DeserializeObject<Figure>(jsonString);
            Console.WriteLine(objeto);
            return objeto;
        }


        public static void ToJson(string fileName, object shape)
        {
            string jsonFile = JsonConvert.SerializeObject(shape);
            File.Create(fileName);
            File.WriteAllText(fileName, jsonFile);
        }
    }
}
