using Blazor.Diagrams.Core.Models;
using System;

namespace Blazor.Diagrams.Core.Serializations
{
    public class GraphPortUI
    {

        public PortAlignment Alignment { get; set; }

        public Guid Uuid { get; set; }
        
        public double Y { get; set; }
        
        public double X { get; set; }

        internal static GraphPortUI Serialize(PortModel port)
        {

            return new GraphPortUI()
            {
                Uuid = port.Id,
                Alignment = port.Alignment,
                X = port.Position.X,
                Y = port.Position.Y
            };

        }

        internal PortModel Initialize(NodeModel group)
        {
            var p = new PortModel(group, Alignment, new Geometry.Point(this.X, this.Y));
            p.SetId(this.Uuid);
            return p;
        }

    }

}
