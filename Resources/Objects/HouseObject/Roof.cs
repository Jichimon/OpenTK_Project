using OpenTK.Mathematics;
using OpenTK_Project.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.Resources.Objects.HouseObject
{
    class Roof : Part
    {

        //atributos
        private readonly float[] _vertexArray = new float[]
        {
            //posiciones
           -0.5f,  -0.25f,  0.5f, // 0
            0.5f,  -0.25f,  0.5f, // 1 
            0.0f,   0.25f,  0.5f, // 2

           -0.5f,  -0.25f,  -0.5f, // 3
            0.5f,  -0.25f,  -0.5f, // 4 
            0.0f,   0.25f,  -0.5f  // 5

        };

        private readonly uint[] _indexArray = new uint[]
        {
            //cara delantera
            0, 1, 2,
            //cara derecha
            1, 4, 5,
            5, 2, 1,
            //cara de abajo
            1, 4, 3,
            3, 1, 0,
            //cara izquierda
            0, 3, 2,
            2, 3, 5,
            //cara de atras
            5, 3, 4
        };


        private Color4 ColorShape = new(207, 72, 43, 255);



        //constructor

        public Roof(Vector3 relativePosition) : base()
        {
            LoadPartData(_vertexArray, _indexArray, Point.Vector3ToPoint(relativePosition), ColorShape);
        }

    }
}
