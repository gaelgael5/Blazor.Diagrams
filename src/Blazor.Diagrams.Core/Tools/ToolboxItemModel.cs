using Blazor.Diagrams.Core.Models;
using System;

namespace Blazor.Diagrams.Core.Tools
{
    public class ToolboxItemModel
    {

        public Type Type { get; set; } = typeof(NodeModel);

        public PortAlignment Ports { get; set; } = PortAlignment.Left | PortAlignment.Right | PortAlignment.Top | PortAlignment.Bottom;

        public string Label { get; set; }

    }

}
