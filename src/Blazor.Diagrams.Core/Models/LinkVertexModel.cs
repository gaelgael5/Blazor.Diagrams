using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models.Base;
using System;

namespace Blazor.Diagrams.Core.Models
{
    public class LinkVertexModel : MovableModel
    {
        public LinkVertexModel(BaseLinkModel parent, Guid id, Point? position = null) : base(id, position)
        {
            Parent = parent;
        }

        public LinkVertexModel(BaseLinkModel parent, Point? position = null) : base(position)
        {
            Parent = parent;
        }

        public BaseLinkModel Parent { get; }

        public override void SetPosition(double x, double y)
        {
            base.SetPosition(x, y);
            Refresh();
            Parent.Refresh();
        }
    }
}
