using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using System;

namespace CustomNodesLinks.Models
{

    public sealed class DiagramNode : NodeModel
    {

        public DiagramNode(Guid id, string name, GPoint pos) :
          base(id, pos)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

}
