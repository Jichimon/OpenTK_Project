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
            AllocConsole();

            Console.WriteLine("Running my first OpenTK App");
            Console.WriteLine("Please select a scenery file to show.");
            Console.WriteLine("Press a ENTER to continue...");
            Console.ReadLine();


            string fileName = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                }
            }
            //Console.WriteLine(fileName);
            LoadOpenTK(fileName);

        }
        public static void LoadOpenTK(string fileName)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 600),
                Title = "LearnOpenTK - Graphic Programming Presentation",
                // Necesario para correr en MacOS
                Flags = ContextFlags.ForwardCompatible,
            };

            using (var window = new Window(fileName, GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
    }
}
