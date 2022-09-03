using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.Figures
{
    class Square
    {

        //atributos
        readonly float[] Vertices = new float[]
        {
            //posiciones
            0.5f, -0.5f,  0.0f, // 0
            0.5f,  0.5f,  0.0f, // 1 
           -0.5f,  0.5f,  0.0f, // 2
           -0.5f, -0.5f,  0.0f, // 3

        };

        readonly uint[] Indices = new uint[]
        {
            //triangulos
            1, 0, 3,
            3, 2, 1
            
        };



        //constructor
        public Square()
        {
        }

        //getters
        public float[] GetVertices()
        {
            return Vertices;
        }

        public int VerticesCount()
        {
            return Vertices.Length;
        }

        public uint[] GetIndices()
        {
            return Indices;
        }

        public int IndexCount()
        {
            return Indices.Length;
        }
    }
}
