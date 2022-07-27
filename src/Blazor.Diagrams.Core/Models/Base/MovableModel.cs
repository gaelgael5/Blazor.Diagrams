using Blazor.Diagrams.Core.Geometry;
using System;

namespace Blazor.Diagrams.Core.Models.Base
{
    // I'm assuming that all movable models (nodes & groups for now) are also selectable,
    // I believe it makes sense since if you click to move something then you're also selecting
    public abstract class MovableModel : SelectableModel
    {

        public MovableModel(GPoint? position = null)
        {
            Position = position ?? GPoint.Zero;
        }

        public MovableModel(Guid id, GPoint? position = null) : base(id)
        {
            Position = position ?? GPoint.Zero;
        }

        public GPoint Position { get; set; }

        public virtual void SetPosition(double x, double y) => Position = new GPoint(x, y);
    }
}
