using Newtonsoft.Json;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK_Project.Core;
using OpenTK_Project.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.Core
{
    public class Part : IDrawable
    {

        Vector3[] Vertices = Array.Empty<Vector3>();
        uint[] Indices;
        Color4 Color;

        protected Matrix4 ModelMatrix;
        protected Matrix4 MVPMatrix;
        protected Matrix4 ViewProjectionMatrix;

        protected Matrix4 Rotations;
        protected Matrix4 Translations;
        protected Matrix4 Scales;

        int VertexBufferObject;
        int VertexArrayObject;
        int IndexBufferObject;
        ShaderEngine Shader;

        //guarda la posicion inicial del centro del objeto
        private Vector3 _origin = Vector3.Zero;
        private Vector3 _position = Vector3.Zero;
        public Vector3 Origin { get => _origin; set => _origin = value; }
        public Vector3 Position { get => _position; set => _position = value; }

        //constantes
        readonly Color4 DefaultColor = new Color4(142, 138, 125, 255);

        [JsonConstructor]
        public Part(float[] vertices, uint[] indices, Point origin, Color4? color)
        {
            ModelMatrix = Matrix4.Identity;
            ViewProjectionMatrix = Matrix4.Identity;
            MVPMatrix = ModelMatrix;
            SetOrigin(origin);
            Load(vertices, indices, color ?? DefaultColor);
        }



        private void SetOrigin(Point origin)
        {
            if (origin != null) Origin = origin.ParseToVector3();
            else Origin = Vector3.Zero;

        }


        public void SetInitialPosition(Vector3 initialPosition)
        {
            Position = initialPosition;

        }

        private void SetVerticesInitialPosition(Vector3 position)
        {
            List<Vector3> vertexlist = new();
            foreach (Vector3 vertex in Vertices)
            {
                Vector3 newPosition = vertex + position;
                vertexlist.Add(newPosition);
            }
            Vertices = vertexlist.ToArray();
        }


        private void Load(float[] vertexArray, uint[] indices, Color4 color)
        {
            Vertices = Converter.ParseToVector3Array(vertexArray);
            Indices = indices;
            Color = color;
        }

        internal void Init(Vector3 initialPosition)
        {
            SetInitialPosition(initialPosition);
            SetVerticesInitialPosition(Origin + Position);
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

        // TODO:
        // remove ViewProjection Matrxi from this class to window
        public void SetViewProjectionMatrix(Matrix4 viewProjectionMatrix)
        {
            ViewProjectionMatrix = viewProjectionMatrix;
            CalculateMvpMatrix();
        }

        protected void CalculateMvpMatrix()
        {
            MVPMatrix = ModelMatrix * ViewProjectionMatrix;
        }

        private void BindMatrix()
        {
            Shader.SetUniformMatrix4("mvp", MVPMatrix);
        }


        public void Draw()
        {
            CalculateMvpMatrix();
            //habilitamos todo
            Shader.Use();
            BindMatrix();
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
