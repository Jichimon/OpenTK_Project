using OpenTK.Windowing.Desktop;
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

namespace OpenTK_Project
{
    class Window : GameWindow
    {

        //atributos
        Stage Stage1;

        public Window(string sceneryFileName, GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            Console.WriteLine(sceneryFileName);
            Stage1 = Stage.LoadScene(sceneryFileName);
        }



        public Matrix4 CreateViewProjectionMatrix()
        {
            //Inicializar Matriz de Proyeccion
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / Size.Y, 1.0f, 100.0f);

            //posicion de la camara
            Vector3 cameraPosition = new(0.0f, 1.5f, 15.0f);
            Vector3 target = new(0.0f, 0.0f, 0.0f);
            Vector3 up = new(0.0f, 1.0f, 0.0f);

            Matrix4 view = Matrix4.LookAt(cameraPosition, target, up);

            return view * projection;
        }



        //para la primera vez que corremos el programa
        protected override void OnLoad()
        {
            GL.ClearColor(0.12f, 0.32f, 0.2f, 1.0f);

            Stage1.OnLoad();
            Stage1.SetViewProjectionMatrix(CreateViewProjectionMatrix());

            base.OnLoad();
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);

            Stage1.Draw();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }


        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }



        //-----

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            KeyboardState inputKey = KeyboardState.GetSnapshot();

            if (this.IsFocused)
            {

                if (inputKey.IsKeyDown(Keys.S))
                {
                    //hacia atrás
                    Stage1.Move(new Vector3(0.0f, 0.0f, 0.05f));
                }

                if (inputKey.IsKeyDown(Keys.W))
                {
                    //hacia adelante
                    Stage1.Move(new Vector3(0.0f, 0.0f, -0.05f));
                }

                if (inputKey.IsKeyDown(Keys.D))
                {
                    //hacia derecha
                    Stage1.Move(new Vector3(0.05f, 0.0f, 0.0f));
                }

                if (inputKey.IsKeyDown(Keys.A))
                {
                    //hacia izquierda
                    Stage1.Move(new Vector3(-0.05f, 0.0f, 0.0f));
                }

                if (inputKey.IsKeyDown(Keys.Space))
                {
                    //hacia arriba
                    Stage1.Move(new Vector3(0.0f, 0.05f, 0.0f));
                }

                if (inputKey.IsKeyDown(Keys.LeftControl))
                {
                    //hacia abajo
                    Stage1.Move(new Vector3(0.0f, -0.05f, 0.0f));
                }

                if (inputKey.IsKeyDown(Keys.Q))
                {
                    //mas grande
                    Stage1.Scale(new Vector3(1.01f, 1.01f, 1.01f));
                }

                if (inputKey.IsKeyDown(Keys.E))
                {
                    //mas pequeño
                    Stage1.Scale(new Vector3(0.99f, 0.99f, 0.99f));
                }

                if (inputKey.IsKeyDown(Keys.R))
                {
                    Stage1.RotateY(0.02f);
                }

                if (inputKey.IsKeyDown(Keys.T))
                {
                    Stage1.RotateX(0.02f);
                }

                if (inputKey.IsKeyDown(Keys.Y))
                {
                    Stage1.RotateZ(0.02f);
                }

            }
            base.OnKeyDown(e);
        }






        //para cerrar el programa
        protected override void OnUnload()
        {
            Stage1.Destroy();
            base.OnUnload();
        }

    }
}
