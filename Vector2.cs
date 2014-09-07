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
    public struct Vector2
    {
        public static Vector2 One
        {
            get
            {
                return new Vector2(1, 1);
            }
        }

        public static Vector2 Zero
        {
            get
            {
                return new Vector2();
            }
        }

        public float X;
        public float Y;

        public Vector2(float x)
        {
            this.X = x;
            this.Y = 0;
        }

        public Vector2(float y)
        {
            this.X = 0;
            this.Y = y;
        }

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public float Length()
        {
            return (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }

        public float SquaredLength()
        {
            return (float)(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2 operator *(Vector2 v1, float f)
        {
            return new Vector2(v1.X * f, v1.Y * f);
        }

        public static Vector2 operator /(Vector2 v1, float f)
        {
            return new Vector2(v1.X / f, v1.Y / f);
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return v1.X != v2.X || v1.Y != v2.Y;
        }

        public static float Distance(Vector2 v1, Vector2 v2)
        {
            return (v1 - v2).Length();
        }

    }
}
