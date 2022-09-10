using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.Figures
{
    class Square : Shape
    {

        //atributos
        readonly float[] VertexArray = new float[]
        {
            //posiciones
            0.25f, -0.25f,  0.0f, // 0
            0.25f,  0.25f,  0.0f, // 1 
           -0.25f,  0.25f,  0.0f, // 2
           -0.25f, -0.25f,  0.0f, // 3

        };

        readonly uint[] Indices = new uint[]
        {
            //triangulos
            1, 0, 3,
            3, 2, 1
            
        };

        readonly Color4 DefaultColor = new Color4(142, 138, 125, 255);


        //constructores
        public Square() : base()
        {
            Init(VertexArray, Indices, DefaultColor);
        }

        public Square(Vector3 position) : base(position)
        {
            Init(VertexArray, Indices, DefaultColor);
        }

        public Square(Vector3 position, Color4 color) : base(position, color)
        {
            Init(VertexArray, Indices, color);
        }
    }
}
