using OpenTK.Mathematics;
using OpenTK_Project.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.Resources.Objects.HouseObject
{
    class Door : Face
    {

        //atributos
        private readonly float[] _vertexArray = new float[]
        {
            //posiciones
            0.0f,  -0.2f,   0f,  // 0
            0.2f,  -0.2f,   0f,  // 1 
            0.2f,   0.2f,   0f,  // 2
            0.0f,   0.2f,   0f,  // 3

        };

        private readonly uint[] _indexArray = new uint[]
        {
            //líneas
            0, 1, 2,
            2, 3, 0
        };


        private Color4 ColorShape = new(119, 7, 9, 255);



        //constructor

        public Door(Vector3 relativePosition) : base()
        {
            LoadPartData(_vertexArray, _indexArray, Point.Vector3ToPoint(relativePosition), ColorShape);
        }

    }
}
