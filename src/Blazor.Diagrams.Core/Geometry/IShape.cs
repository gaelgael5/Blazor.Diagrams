using System.Collections.Generic;

namespace Blazor.Diagrams.Core.Geometry
{
    public interface IShape
    {
        public IEnumerable<GPoint> GetIntersectionsWithLine(Line line);
    }
}
