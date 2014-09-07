//----------------------------------------------------------------
//
//  Copyright (c) 2014 All Rights Reserved
//  Valter Costa
//
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericAI
{
    public class Rectangle
    {
        public float X;
        public float Y;
        public float Width;
        public float Height;

        public float Left
        {
            get
            {
                return X;
            }
        }

        public float Right
        {
            get
            {
                return X + Width;
            }
        }

        public float Top
        {
            get
            {
                return Y;
            }
        }

        public float Bottom
        {
            get
            {
                return Y + Height;
            }
        }


        public Rectangle()
        {

        }

        public Rectangle(float x, float y, float width, float height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

    }
}
