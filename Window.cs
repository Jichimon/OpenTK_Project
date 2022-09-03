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

namespace OpenTK_Project
{
    class Window : GameWindow
    {

        //atributos
        int VertexBufferObject;
        int VertexArrayObject;
        int IndexBufferObject;
        Square Shape = new Square();
        Shader Shader;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            Init();
        }


        private void Init()
        {
            VertexArrayObject = GL.GenVertexArray(); //generamos el VAO
            VertexBufferObject = GL.GenBuffer(); //generamos el VBO
            IndexBufferObject = GL.GenBuffer(); //generamos el IBO

            GL.BindVertexArray(VertexArrayObject); //habilitamos el VAO 

            //enlazamos el VBO con un buffer de openGL y lo inicializamos
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, Shape.VerticesCount() * sizeof(float), Shape.GetVertices(), BufferUsageHint.StaticDraw);

            //enlazamos el IBO con un buffer de openGL y lo inicializamos
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, Shape.IndexCount() * sizeof(uint), Shape.GetIndices(), BufferUsageHint.StaticDraw);

            //creamos y usamos el program shader
            string vertexPath = "Resources/Shaders/VertexShader.glsl";
            string fragmentPath = "Resources/Shaders/FragmentShader.glsl";

            Shader = new Shader(vertexPath, fragmentPath);
        }


        //para la primera vez que corremos el programa
        protected override void OnLoad()
        {
            GL.ClearColor(0.12f, 0.32f, 0.2f, 1.0f);


            //configuramos los atributos del vertexbuffer y lo habilitamos
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, sizeof(float) * 3, 0);
            GL.EnableVertexAttribArray(0);

            Shader.Use();

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Shader.Use();
            GL.BindVertexArray(VertexArrayObject);
            //Dibuja mi casa
            GL.DrawElements(PrimitiveType.Triangles, Shape.IndexCount(), DrawElementsType.UnsignedInt, 0);

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
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0); //anulamos el ArrayBuffer
            GL.DeleteBuffer(VertexBufferObject); //y borramos el VBO
            Shader.Dispose(); //eliminamos el shader
            base.OnUnload();
        }

    }
}
