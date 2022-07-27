using Blazor.Diagrams.Core.Geometry;

namespace Blazor.Diagrams.Core
{
    public class PathGeneratorResult
    {
        public PathGeneratorResult(string[] paths, double? sourceMarkerAngle = null, GPoint? sourceMarkerPosition = null,
            double? targetMarkerAngle = null, GPoint? targetMarkerPosition = null)
        {
            Paths = paths;
            SourceMarkerAngle = sourceMarkerAngle;
            SourceMarkerPosition = sourceMarkerPosition;
            TargetMarkerAngle = targetMarkerAngle;
            TargetMarkerPosition = targetMarkerPosition;
        }

        public string[] Paths { get; }
        public double? SourceMarkerAngle { get; }
        public GPoint? SourceMarkerPosition { get; }
        public double? TargetMarkerAngle { get; }
        public GPoint? TargetMarkerPosition { get; }
    }
}
