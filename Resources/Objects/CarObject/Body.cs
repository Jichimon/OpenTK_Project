using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK_Project.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.Resources.Objects.CarObject
{
    internal class Body : Face
    {
        //atributos
        private readonly Point _origin = new Point(0.0f, 0.0f, 0.0f);

        private readonly float[] _vertexArray = new float[]
        {
            -2.0f,
            1.00f,
            1.50f,
            3.00f,
            1.00f,
            1.50f,
            3.00f,
            1.00f,
            -1.5f,
            -2.0f,
            1.00f,
            -1.5f,

            -2.0f,
            0.00f,
            1.50f,
            3.00f,
            0.00f,
            1.50f,
            3.00f,
            0.00f,
            -1.5f,
            -2.0f,
            0.00f,
            -1.5f

        };

        private readonly uint[] _indexArray = new uint[]
        {
            0,
            1,
            2,
            2,
            3,
            0,
            0,
            1,
            4,
            4,
            5,
            1,
            1,
            2,
            6,
            6,
            1,
            5,
            5,
            6,
            7,
            7,
            4,
            6,
            6,
            2,
            7,
            7,
            2,
            3,
            3,
            0,
            7,
            7,
            4,
            0
        };


        private Color4 ColorShape = new(0.81961f, 0.16078f, 0.11373f, 1);



        //constructor
        public Body() : base()
        {
            LoadPartData(_vertexArray, _indexArray, _origin, ColorShape);
        }

        public Body(Vector3 relativePosition) : base()
        {
            LoadPartData(_vertexArray, _indexArray, Point.Vector3ToPoint(relativePosition), ColorShape);
        }

    }
}
