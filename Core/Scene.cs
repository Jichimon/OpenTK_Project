using OpenTK.Mathematics;
using OpenTK_Project.Resources.Objects.CarObject;
using OpenTK_Project.Resources.Objects.HouseObject;
using OpenTK_Project.Utilities;
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

        public Scene(Dictionary<string, GraphicObject> objects)
        {
            Objects = objects;
        }

        public Scene()
        {
            Objects = new();
            InitScene();
        }


        public void InitScene()
        {
            Car car;
            House house;

            Vector3 _carInitialPosition = new(0.0f, 0.0f, -20.0f);

            car = new Car(_carInitialPosition);
            house = new();


            Objects.Add("car", car);
            Objects.Add("house", house);
        }


        public void OnLoad()
        {
            foreach (var item in Objects)
            {
                item.Value.LoadParts();
            }
        }


        public void SetViewProjectionMatrix(Matrix4 ViewProjectionMatrix)
        {
            foreach (GraphicObject item in Objects.Values)
            {
                item.SetViewProjectionMatrix(ViewProjectionMatrix);
            }
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
