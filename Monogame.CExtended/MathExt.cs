using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace MonoGame.CExtended
{
    public static class MathExt
    {

        public const float PI = 3.14159265358979323f;
        public const float TWOPI = 2.0f * PI;

        public static float Sign(this float x)
        {
            return x/Abs(x);
        }

        public static float Abs(this float x)
        {
            return x > 0 ? x : -x;
        }
        public static int Abs(this int x)
        {
            return x > 0 ? x : -x;
        }


        public static float Min(float a, float b)
        {
            return a < b ? a : b;
        }
        public static int Min(int a, int b)
        {
            return a < b ? a : b;
        }

        public static float Max(float a, float b)
        {
            return a > b ? a : b;
        }
        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public static float Clamp(this float x, float min, float max)
        {
            return Min(Max(x, min), max);
        }
        public static int Clamp(this int x, int min, int max)
        {
            return Min(Max(x, min), max);
        }

        public static float ToRadians(this float x)
        {
            return (float)(Math.PI * x / 180.0);
        }
        public static bool InTolerance(this float val, float target, float error)
        {
            float difference = Abs(val - target);
            return difference < error;
        }

        public static float ModBounds(this float x, float min, float max)
        {
            if(min == max)
            {
                throw new ArgumentException("Max and min cannot be equal");
            }
            if(x == min || x==max || x == 0)
            {
                return x;
            }
            float dif = max - min;
            while(x > max)
            {
                x -= dif;
            }
            while (x < 0)
            {
                x += dif;
            }
            return x;
        }

        public static float AngleTo(this Vector2 a, Vector2 b)
        {
            return (float)Math.Acos(Vector2.Dot(a,b) / (a.Length() * b.Length()));

        }
        public static Vector2 Normalized(this Vector2 a)
        {
            return a / a.Length();

        }


    }
}
