using System;

namespace Blazor.Diagrams.Core.ExtendedModels
{
    public class Column
    {
        public event Action Changed;

        public string Name { get; set; }
        public ColumnType Type { get; set; }
        public bool Primary { get; set; }

        public void Refresh() => Changed?.Invoke();
    }

}
