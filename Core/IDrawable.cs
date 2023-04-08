using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.Core
{
    public interface IDrawable
    {
        public Vector3 Origin { get; set; }
        public Vector3 Position { get; set; }
        public void Draw();
        public void Destroy();

        public void Move(Vector3 direction);
        public void RotateX(float angle);
        public void RotateY(float angle);
        public void RotateZ(float angle);
        public void Scale(Vector3 factor);
    }
}
