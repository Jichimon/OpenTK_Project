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
            try
            {
                string jsonString = File.ReadAllText(fileName);
                Part? objeto = JsonConvert.DeserializeObject<Part>(jsonString);
                Console.WriteLine(objeto);
                if (objeto is null) throw new Exception("error alcargar el objeto,no puede ser nulo");
                return objeto;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }


        public static void ToJson(string fileName, object shape)
        {
            try
            {
                string jsonFile = JsonConvert.SerializeObject(shape);
                File.Create(fileName);
                File.WriteAllText(fileName, jsonFile);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public static GraphicObject BuildFromJson(string fileName)
        {
            try
            {
                string jsonString = File.ReadAllText(fileName);
                GraphicObject? objeto = JsonConvert.DeserializeObject<GraphicObject>(jsonString);
                Console.WriteLine(objeto);
                if (objeto is null) throw new Exception("error alcargar el objeto,no puede ser nulo");
                return objeto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public static Stage BuildSceneFromJson(string fileName)
        {
            try
            {
                string jsonString = File.ReadAllText(fileName);
                Stage? objeto = JsonConvert.DeserializeObject<Stage>(jsonString);
                Console.WriteLine(objeto);
                if (objeto is null) throw new Exception("error alcargar el objeto,no puede ser nulo");
                return objeto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
