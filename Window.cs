﻿using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK_Project.Core;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK_Project.Resources.Objects.CarObject;
using OpenTK_Project.Resources.Objects.HouseObject;

namespace OpenTK_Project
{
    class Window : GameWindow
    {

        //atributos
        Car Car1;
        House House1;

        private readonly Vector3 _carInitialPosition = new(0.0f, 0.0f, -20.0f);

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            Car1 = new Car(_carInitialPosition);
            House1 = new();
        }


        //para la primera vez que corremos el programa
        protected override void OnLoad()
        {
            GL.ClearColor(0.12f, 0.32f, 0.2f, 1.0f);

            //Inicializar Matriz de Proyeccion
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / Size.Y, 1.0f, 100.0f);

            //posicion de la camara
            Vector3 cameraPosition = new(0.0f, 1.5f, 10.0f);
            Vector3 target = new(0.0f, 0.0f, 0.0f);
            Vector3 up = new(0.0f, 1.0f, 0.0f);

            Matrix4 view = Matrix4.LookAt(cameraPosition, target, up);


            Car1.SetViewProjectionMatrix(view * projection);

            House1.SetViewProjectionMatrix(view * projection);

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);

            Car1.Draw();
            House1.Draw();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }


        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }

        //para cerrar el programa
        protected override void OnUnload()
        {
            Car1.Destroy();
            House1.Destroy();
            base.OnUnload();
        }

    }
}
