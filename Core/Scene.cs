using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.Core
{
    public class Scene : IDrawable
    {
        Dictionary<string, GraphicObject> Objects;

        //guarda la posicion inicial del centro del objeto
        private Vector3 _origin = Vector3.Zero;
        private Vector3 _position = Vector3.Zero;
        public Vector3 Origin { get => _origin; set => _origin = value; }
        public Vector3 Position { get => _position; set => _position = value; }


        public Scene(Point position)
        {
            Origin = position.ParseToVector3();
            Position = Origin;
            Objects = new();
        }

        public Scene()
        {
            Objects = new();
        }


        public virtual void OnLoad()
        {
            Objects = new();
        }

        public void AddObject(string name, GraphicObject @object)
        {
            @object.SetInitialPosition(Point.Vector3ToPoint(Origin));
            Objects.Add(name, @object);
        }

        public void AddObject(Point position, string name, GraphicObject @object)
        {
            Vector3 vPos = Origin + position.ParseToVector3();
            Point objectPosition = Point.Vector3ToPoint(vPos);
            @object.SetInitialPosition(objectPosition);
            Objects.Add(name, @object);
        }


        public void Draw()
        {
            foreach (var item in Objects)
            {
                item.Value.Draw();
            }
        }

        public void Destroy()
        {
            foreach (var item in Objects)
            {
                item.Value.Destroy();
            }
        }
    }
}
