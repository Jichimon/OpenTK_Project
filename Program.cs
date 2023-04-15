using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace OpenTK_Project
{
    public class Program
    {

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();


    [STAThread]
        public static void Main(string[] args)
        {
            LoadOpenTK();

        }
        public static void LoadOpenTK()
        {
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
