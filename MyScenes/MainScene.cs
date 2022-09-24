using OpenTK_Project.Core;
using OpenTK_Project.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.MyScenes
{
    class MainScene : Scene
    {
        public MainScene() : base()
        {

        }


        public override void OnLoad()
        {
            //definiendo los objetos de mi escenario

            string object1 = "shape1";
            Point positionShape = new(0.5f, 0.5f, 0.0f);
            string jsonFile = "../../../Resources/Objects/Object1.json";
            GraphicObject shape = ObjectBuilder.BuildFromJson(jsonFile);
            AddObject(positionShape, object1, shape);

            object1 = "shape2";
            positionShape = new(-0.5f, -0.5f, 0.0f);
            jsonFile = "../../../Resources/Objects/Object2.json";
            shape = ObjectBuilder.BuildFromJson(jsonFile);
            AddObject(positionShape, object1, shape);

        }
    }
}
