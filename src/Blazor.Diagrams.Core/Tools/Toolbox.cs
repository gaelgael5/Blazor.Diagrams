using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Serializations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blazor.Diagrams.Core.Tools
{

    public class Toolbox : List<ToolboxItem>
    {

        public Guid Uuid { get; set; }


        public IEnumerable<string> Categories() => new HashSet<string>(this.Select(c => c.Category));

        public IEnumerable<ToolboxItem> GetByCategory(string category) => this.Where(c => c.Category == category);


    }


    public class ToolboxItem
    {

        public ToolboxItem()
        {
            Model = new ToolboxItemModel();
        }

        public Guid Uuid { get; set; } = Guid.NewGuid();

        public string Category { get; set; } = "Default";

        public string Label { get; set; }

        public string Icon { get; set; }

        public ToolboxItemModel Model { get; set; } = new ToolboxItemModel();

        public NodeModel Create(double x, double y)
        {
            return Creator_Impl(x, y, this);
        }

        private Func<double, double, ToolboxItem, NodeModel> Creator_Impl { get; set; } = (x, y, model) =>
        {
            Guid uuid = Guid.NewGuid();
            var point = new Point(x, y);
            var node = (NodeModel)Activator.CreateInstance(model.Model.Type, new object[] {uuid, point, RenderLayer.HTML, null });
            node.Title = model.Model.Label;

            #region create Ports

            if ((model.Model.Ports & PortAlignment.Top) == PortAlignment.Top)
                node.AddPort(PortAlignment.Top);

            if ((model.Model.Ports & PortAlignment.TopRight) == PortAlignment.TopRight)
                node.AddPort(PortAlignment.TopRight);

            if ((model.Model.Ports & PortAlignment.Right) == PortAlignment.Right)
                node.AddPort(PortAlignment.Right);

            if ((model.Model.Ports & PortAlignment.BottomRight) == PortAlignment.BottomRight)
                node.AddPort(PortAlignment.BottomRight);

            if ((model.Model.Ports & PortAlignment.Bottom) == PortAlignment.Bottom)
                node.AddPort(PortAlignment.Bottom);

            if ((model.Model.Ports & PortAlignment.BottomLeft) == PortAlignment.BottomLeft)
                node.AddPort(PortAlignment.BottomLeft);

            if ((model.Model.Ports & PortAlignment.Left) == PortAlignment.Left)
                node.AddPort(PortAlignment.Left);

            if ((model.Model.Ports & PortAlignment.TopLeft) == PortAlignment.TopLeft)
                node.AddPort(PortAlignment.TopLeft);

            #endregion create Ports

            return node;

        };

    }

    public class ToolboxItemModel
    {

        public Type Type { get; set; } = typeof(NodeModel);

        public PortAlignment Ports { get; set; } = PortAlignment.Left | PortAlignment.Right | PortAlignment.Top | PortAlignment.Bottom;

        public string Label { get; set; }

    }

}
