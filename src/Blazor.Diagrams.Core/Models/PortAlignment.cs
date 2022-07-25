using System;

namespace Blazor.Diagrams.Core.Models
{

    [Flags]
    public enum PortAlignment
    {
        Top = 1,
        TopRight = 2,
        Right = 4,
        BottomRight = 8,
        Bottom = 16,
        BottomLeft = 32,
        Left = 128,
        TopLeft = 256
    }
}
