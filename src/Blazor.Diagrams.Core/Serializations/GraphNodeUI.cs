using Blazor.Diagrams.Core.Models;
using System;

namespace Blazor.Diagrams.Core.Serializations
{

    public class GraphUI
    {


        public GraphUI()
        {
            Ports = new GraphPortUIList();
        }

        public Guid Uuid { get; set; }

        public double X { get; set; }
        public double Y { get; set; }

        public double? Width { get; set; }
        public double? Height { get; set; }

        public GraphPortUIList Ports { get; set; }

        internal virtual void Serialize(NodeModel node)
        {

            this.Uuid = node.Id;
            this.X = node.Position.X;
            this.Y = node.Position.Y;

            if (node.Size != null)
            {
                this.Width = node.Size.Width;
                this.Height = node.Size.Height;
            }

            foreach (PortModel port in node.Ports)
                Ports.Add(GraphPortUI.Serialize(port));

        }

        internal void Initialize(NodeModel node)
        {

            node.SetPosition(this.X, this.Y);
            if (this.Width.HasValue && this.Height.HasValue)
                node.Size = new Geometry.Size(this.Width.Value, this.Height.Value);

            foreach (GraphPortUI port in this.Ports)
            {
                var p = port.Initialize(node);
                node.AddPort(p);
            }

        }

    }

}
