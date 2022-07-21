using System;

namespace Blazor.Diagrams.Core.Models.Base
{
    public abstract class Model
    {

        public Model() : this(Guid.NewGuid()) { }

        public Model(Guid id)
        {
            Id = id;
        }

        public event Action? Changed;

        public Guid Id { get; private set; }

        public void SetId (Guid id)
        {
            this.Id = id;
        }

        public bool Locked { get; set; }

        public virtual void Refresh() => Changed?.Invoke();
    }
}
