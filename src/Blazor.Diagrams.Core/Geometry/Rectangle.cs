﻿using System;
using System.Collections.Generic;

namespace Blazor.Diagrams.Core.Geometry
{
    public class Rectangle : IShape
    {
        public static Rectangle Zero { get; } = new Rectangle(0, 0, 0, 0);

        public double Width { get; set; }
        public double Height { get; set; }
        public double Top { get; set; }
        public double Right { get; set; }
        public double Bottom { get; set; }
        public double Left { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(double left, double top, double right, double bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
            Width = Math.Abs(Left - Right);
            Height = Math.Abs(Top - Bottom);
        }

        public Rectangle(GPoint position, Size size)
        {
            Left = position.X;
            Top = position.Y;
            Right = Left + size.Width;
            Bottom = Top + size.Height;
            Width = size.Width;
            Height = size.Height;
        }

        public bool Overlap(Rectangle r)
            => Left < r.Right && Right > r.Left && Top < r.Bottom && Bottom > r.Top;

        public bool Intersects(Rectangle r)
        {
            var thisX = Left;
            var thisY = Top;
            var thisW = Width;
            var thisH = Height;
            var rectX = r.Left;
            var rectY = r.Top;
            var rectW = r.Width;
            var rectH = r.Height;
            return rectX < thisX + thisW && thisX < rectX + rectW && rectY < thisY + thisH && thisY < rectY + rectH;
        }

        public Rectangle Inflate(double horizontal, double vertical)
            => new Rectangle(Left - horizontal, Top - vertical, Right + horizontal, Bottom + vertical);

        public Rectangle Union(Rectangle r)
        {
            var x1 = Math.Min(Left, r.Left);
            var x2 = Math.Max(Left + Width, r.Left + r.Width);
            var y1 = Math.Min(Top, r.Top);
            var y2 = Math.Max(Top + Height, r.Top + r.Height);
            return new Rectangle(x1, y1, x2, y2);
        }

        public bool ContainsPoint(GPoint point) => ContainsPoint(point.X, point.Y);

        public bool ContainsPoint(double x, double y)
            => x >= Left && x <= Right && y >= Top && y <= Bottom;

        public IEnumerable<GPoint> GetIntersectionsWithLine(Line line)
        {
            var borders = new[] {
                new Line(NorthWest, NorthEast),
                new Line(NorthEast, SouthEast),
                new Line(SouthWest, SouthEast),
                new Line(NorthWest, SouthWest)
            };

            for (var i = 0; i < borders.Length; i++)
            {
                var intersectionPt = borders[i].GetIntersection(line);
                if (intersectionPt != null)
                    yield return intersectionPt;
            }
        }

        public GPoint Center => new GPoint(Left + Width / 2, Top + Height / 2);
        public GPoint NorthEast => new GPoint(Right, Top);
        public GPoint SouthEast => new GPoint(Right, Bottom);
        public GPoint SouthWest => new GPoint(Left, Bottom);
        public GPoint NorthWest => new GPoint(Left, Top);
        public GPoint East => new GPoint(Right, Top + Height / 2);
        public GPoint North => new GPoint(Left + Width / 2, Top);
        public GPoint South => new GPoint(Left + Width / 2, Bottom);
        public GPoint West => new GPoint(Left, Top + Height / 2);

        public bool Equals(Rectangle? other)
        {
            return other != null && Left == other.Left && Right == other.Right && Top == other.Top &&
                Bottom == other.Bottom && Width == other.Width && Height == other.Height;
        }

        public override string ToString()
                    => $"Rectangle(width={Width}, height={Height}, top={Top}, right={Right}, bottom={Bottom}, left={Left})";
    }
}
