using Newtonsoft.Json;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.Core
{
    class Figure
    {
        public readonly float[] Vertices;
        public readonly uint[] Indices;
        public readonly Color4 Color;
        readonly Color4 DefaultColor = new Color4(142, 138, 125, 255);

        [JsonConstructor]
        public Figure(float[] vertices, uint[] indices, Color4? color)
        {
            Vertices = vertices;
            Indices = indices;
            Color = color ?? DefaultColor;
        }

    }
}
