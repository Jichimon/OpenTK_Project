﻿using OpenTK.Mathematics;
using OpenTK_Project.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK_Project.Resources.Objects.HouseObject
{
    class Wall : Part
    {

        //atributos
        private readonly float[] _vertexArray = new float[]
        {
             //posiciones
           -0.4f, -0.4f,  0.5f, // 0
            0.4f, -0.4f,  0.5f, // 1 
            0.4f,  0.4f,  0.5f, // 2
           -0.4f,  0.4f,  0.5f, // 3

           -0.4f, -0.4f,  -0.5f, // 4 
            0.4f, -0.4f,  -0.5f, // 5
            0.4f,  0.4f,  -0.5f, // 6 
           -0.4f,  0.4f,  -0.5f  // 7

        };

        private readonly uint[] _indexArray = new uint[]
        {
            //cara delantera
            0, 1, 2,
            2, 3, 0,
            //cara de abajo
            0, 4, 1,
            1, 5, 4,
            //cara izquierda
            4, 7, 0,
            0, 3, 7,
            //cara de arriba
            7, 3, 2,
            2, 6, 7,
            //cara de atras
            7, 6, 4,
            4, 5, 6,
            //cara derecha
            6, 2, 1,
            1, 5, 6
        };


        private Color4 ColorShape = new(22, 112, 139, 255);



        //constructor

        public Wall(Vector3 relativePosition) : base()
        {
            LoadPartData(_vertexArray, _indexArray, Point.Vector3ToPoint(relativePosition), ColorShape);
        }

    }
}