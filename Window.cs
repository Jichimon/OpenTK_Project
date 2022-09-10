using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK_Project.Core;
using OpenTK_Project.Figures;
using OpenTK.Mathematics;

namespace OpenTK_Project
{
    class Window : GameWindow
    {

        //atributos
        Shape Shape1, Shape2;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            Vector3 topRight = new Vector3(0.5f, 0.5f, 0.0f);
            Vector3 bottomLeft = new Vector3(-0.5f, -0.5f, 0.0f);

            Color4 color = new Color4(200,0,150,255);
            Shape1 = new Square(bottomLeft);
            Shape2 = new Square(topRight, color);
        }


        //para la primera vez que corremos el programa
        protected override void OnLoad()
        {
            GL.ClearColor(0.12f, 0.32f, 0.2f, 1.0f);

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Shape1.Draw();
            Shape2.Draw();

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
            Shape1.Destroy();
            Shape2.Destroy();
            base.OnUnload();
        }

    }
}
