using Newtonsoft.Json;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.Core
{
    public class GraphicObject : IDrawable
    {

        Dictionary<string, Face> Parts;

        //guarda la posicion inicial del centro del objeto
        private Vector3 _origin = Vector3.Zero;
        private Vector3 _position = Vector3.Zero;
        public Vector3 Origin { get => _origin; set => _origin = value; }
        public Vector3 Position { get => _position; set => _position = value; }


        
        public GraphicObject(Point position, Dictionary<string, Face> parts)
        {
            Origin = position.ParseToVector3();
            Position = Origin;
            Parts = parts;
        }



        public GraphicObject() { Parts = new(); }


        public void SetInitialPosition(Point position)
        {
            Origin = position.ParseToVector3();
            Position = Origin;
            LoadParts();
        }


        public void LoadParts()
        {
            foreach (var item in Parts)
            {
                item.Value.Init(Origin);
            }
        }


        public void SetNewPart(string partName, Face part)
        {
            Parts.Add(partName, part);
        }

        public void SetViewProjectionMatrix(Matrix4 ViewProjectionMatrix)
        {
            foreach (Face item in Parts.Values)
            {
                item.SetViewProjectionMatrix(ViewProjectionMatrix);
            }
        }

        public void Draw()
        {
            foreach (var item in Parts)
            {
                item.Value.Draw();
            }
        }

        public void Destroy()
        {
            foreach (var item in Parts)
            {
                item.Value.Destroy();
            }
        }

    }
}
