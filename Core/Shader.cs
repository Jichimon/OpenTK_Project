using System;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace OpenTK_Project.Core
{
    class Shader
    {
        //atributos
        int Id;
        private bool DisposedFlag = false;

        //constructor
        public Shader(string vertexPath, string fragmentPath)
        {
            int vertexShader, fragmentShader; //el id de cada shader

            //extraemos el codigo fuente de cada shader respectivamente
            string vertexShaderSource;
            using (StreamReader reader = new StreamReader(vertexPath))
            {
                vertexShaderSource = reader.ReadToEnd();
            }

            string fragmentShaderSource;
            using (StreamReader reader = new StreamReader(fragmentPath))
            {
                fragmentShaderSource = reader.ReadToEnd();
            }

            //compilamos cada shader
            vertexShader = CompileShader(ShaderType.VertexShader, vertexShaderSource);
            fragmentShader = CompileShader(ShaderType.FragmentShader, fragmentShaderSource);

            //creamos el programa y unimos los dos shaders
            Id = GL.CreateProgram();

            GL.AttachShader(Id, vertexShader);
            GL.AttachShader(Id, fragmentShader);
            GL.LinkProgram(Id);

            //limpiamos
            GL.DetachShader(Id, vertexShader);
            GL.DetachShader(Id, fragmentShader);
            GL.DeleteShader(fragmentShader);
            GL.DeleteShader(vertexShader);
        }

        private int CompileShader(ShaderType type, string source)
        {
            int shader = GL.CreateShader(type);  //generamos 
            GL.ShaderSource(shader, source); //unimos el shader generado al codigo fuente
            GL.CompileShader(shader); //compilamos

            //si hay algun error se verá en consola para debugging
            string infoLogVert = GL.GetShaderInfoLog(shader);
            if (infoLogVert != System.String.Empty)
                System.Console.WriteLine(infoLogVert);

            return shader;
        }


        public void Use()
        {
            GL.UseProgram(Id);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!DisposedFlag)
            {
                GL.DeleteProgram(Id);

                DisposedFlag = true;
            }
        }

        ~Shader()
        {
            GL.DeleteProgram(Id);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
