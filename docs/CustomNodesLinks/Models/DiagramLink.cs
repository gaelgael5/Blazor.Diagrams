using Blazor.Diagrams.Core.Models;
using System;

namespace CustomNodesLinks.Models
{
  public sealed class DiagramLink : LinkModel
  {
    public DiagramLink(Guid id, string name, NodeModel sourceNode, NodeModel? targetNode) :
      base(id, sourceNode, targetNode)
    {
      Name = name;
      Labels.Add(new DiagramLinkLabel(this, Name));
    }

    public string Name { get; set; }

  }
}
