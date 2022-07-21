using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;
using System;

namespace CustomNodesLinks.Models
{
  public sealed class DiagramLinkLabel : LinkLabelModel
  {
    public DiagramLinkLabel(BaseLinkModel parent, Guid id, string content, double? distance = null, Point? offset = null) : 
      base(parent, id, content, distance, offset)
    {
    }

    public DiagramLinkLabel(BaseLinkModel parent, string content, double? distance = null, Point? offset = null) : 
      base(parent, content, distance, offset)
    {
    }

    public bool ShowLabel { get; set; } = true;
  }
}
