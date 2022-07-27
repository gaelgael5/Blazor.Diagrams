using Blazor.Diagrams.Core.Geometry;
using System;

namespace Blazor.Diagrams.Core
{
    public static partial class PathGenerators
    {
        public static double SourceMarkerAdjustement(GPoint[] route, double markerWidth)
        {
            var angleInRadians = Math.Atan2(route[1].Y - route[0].Y, route[1].X - route[0].X) + Math.PI;
            var xChange = markerWidth * Math.Cos(angleInRadians);
            var yChange = markerWidth * Math.Sin(angleInRadians);
            route[0] = new GPoint(route[0].X - xChange, route[0].Y - yChange);
            return angleInRadians * 180 / Math.PI;
        }

        public static double TargetMarkerAdjustement(GPoint[] route, double markerWidth)
        {
            var angleInRadians = Math.Atan2(route[^1].Y - route[^2].Y, route[^1].X - route[^2].X);
            var xChange = markerWidth * Math.Cos(angleInRadians);
            var yChange = markerWidth * Math.Sin(angleInRadians);
            route[^1] = new GPoint(route[^1].X - xChange, route[^1].Y - yChange);
            return angleInRadians * 180 / Math.PI;
        }

        public static GPoint[] ConcatRouteAndSourceAndTarget(GPoint[] route, GPoint source, GPoint target)
        {
            var result = new GPoint[route.Length + 2];
            result[0] = source;
            route.CopyTo(result, 1);
            result[^1] = target;
            return result;
        }
    }
}
