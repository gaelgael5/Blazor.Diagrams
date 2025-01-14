﻿using System;
using System.Collections.Generic;

namespace Blazor.Diagrams.Core.Geometry
{
    public class Ellipse : IShape
    {
        public Ellipse(double cx, double cy, double rx, double ry)
        {
            Cx = cx;
            Cy = cy;
            Rx = rx;
            Ry = ry;
        }

        public double Cx { get; }
        public double Cy { get; }
        public double Rx { get; }
        public double Ry { get; }

        public IEnumerable<GPoint> GetIntersectionsWithLine(Line line)
        {
            var a1 = line.Start;
            var a2 = line.End;
            var dir = new GPoint(line.End.X - line.Start.X, line.End.Y - line.Start.Y);
            var diff = a1.Substract(Cx, Cy);
            var mDir = new GPoint(dir.X / (Rx * Rx), dir.Y / (Ry * Ry));
            var mDiff = new GPoint(diff.X / (Rx * Rx), diff.Y / (Ry * Ry));

            var a = dir.Dot(mDir);
            var b = dir.Dot(mDiff);
            var c = diff.Dot(mDiff) - 1.0;
            var d = b * b - a * c;

            if (d > 0)
            {
                var root = Math.Sqrt(d);
                var ta = (-b - root) / a;
                var tb = (-b + root) / a;

                if (ta >= 0 && 1 >= ta || tb >= 0 && 1 >= tb)
                {
                    if (0 <= ta && ta <= 1)
                        yield return a1.Lerp(a2, ta);

                    if (0 <= tb && tb <= 1)
                        yield return a1.Lerp(a2, tb);
                }
            }
            else
            {
                var t = -b / a;
                if (0 <= t && t <= 1)
                {
                    yield return a1.Lerp(a2, t);
                }
            }
        }
    }
}
