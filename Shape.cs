using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK_Project.Core;
using OpenTK_Project.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project
{
    abstract class Shape
    {

        Vector3[] Vertices = Array.Empty<Vector3>();
        uint[] Indices;
        Color4 Color;

        int VertexBufferObject;
        int VertexArrayObject;
        int IndexBufferObject;
        ShaderEngine Shader;

        //guarda la posicion inicial del centro del objeto
        protected Vector3 Origin;


        /// <summary>
        /// Constructor básico que crea un objeto en el centro de la ventana
        /// </summary>
        public Shape()
        {
            SetInitialPosition(Vector3.Zero);
        }

        /// <summary>
        /// Crea una figura cuyo origen, es su posición pasada por parámetro.
        /// </summary>
        /// <param name="relativePosition"> posicion de la figura en la ventana </param>
        public Shape(Vector3 relativePosition)
        {
            SetInitialPosition(relativePosition);
        }

        /// <summary>
        /// Crea una figura cuyo origen, es su posición pasada por parámetro y se le puede asignar un color.
        /// </summary>
        /// <param name="relativePosition"> posicion de la figura en la ventana </param>
        /// <param name="color"> color de la figura </param>
        public Shape(Vector3 relativePosition, Color4 color)
        {
            SetInitialPosition(relativePosition);
            Color = color;
        }


        private void SetInitialPosition(Vector3 initialPosition)
        {
            Origin = initialPosition;
        }


        private void SetVerticesInitialPosition(Vector3[] vertices)
        {
            List<Vector3> vertexlist = new();
            foreach (Vector3 vertex in vertices)
            {
                Vector3 newPosition = vertex + Origin;
                vertexlist.Add(newPosition);
            }
            Vertices = vertexlist.ToArray();
        }


        protected void Init(float[] vertexArray, uint[] indices, Color4 color)
        {
            Vector3[] vertices = Converter.ParseToVector3Array(vertexArray);
            SetVerticesInitialPosition(vertices);
            Indices = indices;
            Color = color;
            VertexArrayObject = GL.GenVertexArray(); //generamos el VAO
            VertexBufferObject = GL.GenBuffer(); //generamos el VBO
            IndexBufferObject = GL.GenBuffer(); //generamos el IBO

            GL.BindVertexArray(VertexArrayObject); //habilitamos el VAO 

            //enlazamos el VBO con un buffer de openGL y lo inicializamos
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, GetLength(Vertices) * sizeof(float), Vertices, BufferUsageHint.StaticDraw);

            //enlazamos el IBO con un buffer de openGL y lo inicializamos
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, Indices.Length * sizeof(uint), Indices, BufferUsageHint.StaticDraw);

            //configuramos los atributos del vertexbuffer y lo habilitamos (el primer 0 indica el location en el vertexShader)
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, sizeof(float) * 3, 0);

            SetShaders();
        }


        //metodos estáticos
        private static int GetLength(Vector3[] array)
        {
            return array.Length * 3;
        }


        //metodos principales

        public void SetShaders()
        {
            BuildShader();
            Shader.SetUniformColor4("u_Color", Color);
        }


        public void Draw()
        {
            //habilitamos todo
            Shader.Use();
            GL.BindVertexArray(VertexArrayObject);

            //Dibujamos
            GL.DrawElements(PrimitiveType.Triangles, Indices.Length, DrawElementsType.UnsignedInt, 0);
        }


        public void Destroy()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0); //anulamos el ArrayBuffer
            GL.DeleteBuffer(VertexBufferObject); //y borramos el VBO
            Shader.Dispose(); //eliminamos el shader
        }




        private void BuildShader()
        {
            //creamos y usamos el program shader
            Shader = new ShaderEngine();
            Shader.Use();
        }

    }
}
