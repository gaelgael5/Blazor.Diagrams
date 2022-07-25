using Blazor.Diagrams.Core.Models;
using System;

namespace Blazor.Diagrams.Core.Serializations
{
    public class DiagramLinkLabelModel
    {

        public DiagramLinkLabelModel()
        {

        }

        internal void Serialize(LinkLabelModel label)
        {
            this.Uuid = label.Id;
            this.Content = label.Content;
            this.Distance = label.Distance;
            this.X = label.Offset?.X;
            this.Y = label.Offset?.Y;
        }

        public Guid Uuid { get; set; }

        public string Content { get; set; }

        public double? Distance { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }


    }

}
