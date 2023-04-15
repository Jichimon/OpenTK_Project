using OpenTK.Mathematics;
using OpenTK_Project.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.Resources.Objects.HouseObject
{
    class House : GraphicObject
    {

        private readonly Vector3 _initialPosition = new(2.0f, 0.0f, 1.0f);

        //atributos
        Door Door;
        Roof Roof;
        Wall Wall;

        Vector3 DoorInitialPosition = new Vector3(-0.1f, -0.4f,  0.51f);
        Vector3 RoofInitialPosition = new Vector3( 0.0f,  0.45f,  0.0f);
        Vector3 WallInitialPosition = new Vector3( 0.0f, -0.2f,  0.0f);



        //constructor
        public House() : base()
        {
            Init();
            SetInitialPosition(Point.Vector3ToPoint(_initialPosition));
        }


        public House(Vector3 position) : base()
        {
            Init();
            SetInitialPosition(Point.Vector3ToPoint(position));
        }


        private void Init()
        {
            Wall = new Wall(WallInitialPosition + Origin);

            Roof = new Roof(RoofInitialPosition + Origin);

            Door = new Door(DoorInitialPosition + Origin);

            SetNewPart("wall", Wall);
            SetNewPart("roof", Roof);
            SetNewPart("door", Door);
        }

    }
}
