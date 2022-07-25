using System;

namespace Blazor.Diagrams.Core.Serializations
{
    public class DiagramEndpoint
    {

        public Guid? PortId { get; set; }

        public Guid? NodeId { get; set; }

        public string MarkerPath { get; set; }

        public double? MarkerWidth { get; set; }

    }
}
