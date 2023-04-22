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


    }
}
