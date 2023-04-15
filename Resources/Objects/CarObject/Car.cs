
using OpenTK.Mathematics;
using OpenTK_Project.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenTK_Project.Resources.Objects.CarObject
{
    public class Car : GraphicObject
    {
        //atributos
        private readonly Vector3 _initialPosition = new (0.0f, 0.0f, -15.0f);

        Body Body;
        Roof Roof;
        CarWindows CarWindows;
        Tire BackLeftTire;
        Tire BackRightTire;
        Tire FrontLeftTire;
        Tire FrontRightTire;

        Vector3 BodyInitialPosition = new Vector3(0f, 0f, 0f);
        Vector3 CarWindowsInitialPosition = new Vector3(0.00f, 1.45f, 0.00f);
        Vector3 RoofInitialPosition = new Vector3(0.0f, 1.9f, 0.0f);
        Vector3 BackLeftTireInitialPosition = new Vector3(-1.00f, -0.5f, 1.25f);
        Vector3 BackRightTireInitialPosition = new Vector3(-1.00f, -0.5f, -1.25f);
        Vector3 FrontLeftTireInitialPosition = new Vector3(1.50f, -0.5f, 1.25f);
        Vector3 FrontRightTireInitialPosition = new Vector3(1.50f, -0.5f, -1.25f);


        //constructor
        public Car() : base()
        {
            Init();
            SetInitialPosition(Point.Vector3ToPoint(_initialPosition));
        }


        public Car(Vector3 position) : base()
        {
            Init();
            SetInitialPosition(Point.Vector3ToPoint(position));
        }


        private void Init()
        {
            BackLeftTire = new Tire(BackLeftTireInitialPosition + Origin);
            BackRightTire = new Tire(BackRightTireInitialPosition + Origin);         
            FrontLeftTire = new Tire(FrontLeftTireInitialPosition + Origin);
            FrontRightTire = new Tire(FrontRightTireInitialPosition + Origin);
            Roof = new Roof(RoofInitialPosition + Origin);            
            CarWindows = new CarWindows(CarWindowsInitialPosition + Origin);
            Body = new Body(BodyInitialPosition + Origin);


            SetNewPart("back-left-tire", BackLeftTire);
            SetNewPart("back-right-tire", BackRightTire);
            SetNewPart("front-left-tire", FrontLeftTire);
            SetNewPart("front-right-tire", FrontRightTire);
            SetNewPart("body", Body);
            SetNewPart("windows", CarWindows);
            SetNewPart("ceeling", Roof);

        }

    }
}
