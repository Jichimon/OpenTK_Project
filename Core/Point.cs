using Newtonsoft.Json;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.Core
{
    public class Point
    {
        public float X;
        public float Y;
        public float Z;

        [JsonConstructor]
        public Point(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }


        public Vector3 ParseToVector3()
        {
            return new Vector3(X, Y, Z);
        }


        public static Point Vector3ToPoint(Vector3 vector3)
        {
            return new Point(vector3.X, vector3.Y, vector3.Z);
        }
    }
}
