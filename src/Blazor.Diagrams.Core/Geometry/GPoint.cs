using System;

namespace Blazor.Diagrams.Core.Geometry
{
    public class GPoint
    {
        public static GPoint Zero { get; } = new GPoint(0, 0);

        public GPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public double Dot(GPoint other) => X * other.X + Y * other.Y;
        public GPoint Lerp(GPoint other, double t)
            => new GPoint(X * (1.0 - t) + other.X * t, Y * (1.0 - t) + other.Y * t);

        // Maybe just make Points mutable?
        public GPoint Add(double value) => new GPoint(X + value, Y + value);
        public GPoint Add(double x, double y) => new GPoint(X + x, Y + y);

        public GPoint Substract(double value) => new GPoint(X - value, Y - value);
        public GPoint Substract(double x, double y) => new GPoint(X - x, Y - y);

        public double DistanceTo(GPoint other)
            => Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));

        public override string ToString() => $"Point(x={X}, y={Y})";

        public static GPoint operator -(GPoint a, GPoint b) => new GPoint(a.X - b.X, a.Y - b.Y);
        public static GPoint operator +(GPoint a, GPoint b) => new GPoint(a.X + b.X, a.Y + b.Y);

        public void Deconstruct(out double x, out double y)
        {
            x = X;
            y = Y;
        }
    }
}
