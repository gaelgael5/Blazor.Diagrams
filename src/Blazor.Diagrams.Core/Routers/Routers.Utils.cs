using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;

namespace Blazor.Diagrams.Core
{
    public static partial class Routers
    {
        public static GPoint GetPortPositionBasedOnAlignment(PortModel port)
        {
            var pt = port.Position;
            switch (port.Alignment)
            {
                case PortAlignment.Top:
                    return new GPoint(pt.X + port.Size.Width / 2, pt.Y);
                case PortAlignment.TopRight:
                    return new GPoint(pt.X + port.Size.Width, pt.Y);
                case PortAlignment.Right:
                    return new GPoint(pt.X + port.Size.Width, pt.Y + port.Size.Height / 2);
                case PortAlignment.BottomRight:
                    return new GPoint(pt.X + port.Size.Width, pt.Y + port.Size.Height);
                case PortAlignment.Bottom:
                    return new GPoint(pt.X + port.Size.Width / 2, pt.Y + port.Size.Height);
                case PortAlignment.BottomLeft:
                    return new GPoint(pt.X, pt.Y + port.Size.Height);
                case PortAlignment.Left:
                    return new GPoint(pt.X, pt.Y + port.Size.Height / 2);
                default:
                    return pt;
            }
        }
    }
}
