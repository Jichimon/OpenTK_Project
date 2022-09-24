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
        public static Part BuildPartFromJson(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            Part objeto = JsonConvert.DeserializeObject<Part>(jsonString);
            Console.WriteLine(objeto);
            return objeto;
        }


        public static void ToJson(string fileName, object shape)
        {
            string jsonFile = JsonConvert.SerializeObject(shape);
            File.Create(fileName);
            File.WriteAllText(fileName, jsonFile);
        }


        public static GraphicObject BuildFromJson(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            GraphicObject objeto = JsonConvert.DeserializeObject<GraphicObject>(jsonString);
            Console.WriteLine(objeto);
            return objeto;
        }

    }
}
