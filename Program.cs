using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;

namespace OpenTK_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running my first OpenTK App");

            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 600),
                Title = "LearnOpenTK - Graphic Programming Presentation",
                // Necesario para correr en MacOS
                Flags = ContextFlags.ForwardCompatible,
            };



            using (var window = new Window(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
    }
}
