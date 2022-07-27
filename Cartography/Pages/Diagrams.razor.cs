using Blazor.Diagrams.Components;
using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.ExtendedModels;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Tools;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Linq;

namespace Cartography.Pages
{

    public partial class Diagrams
    {

        private Diagram Diagram { get; set; }

        protected override void OnInitialized()
        {

            base.OnInitialized();

            this.toolbox = new Toolbox()
                .Add(
                    new ToolboxCategory() { Name = "Default", Icon = "line_weight", Label = "Misc" }
                )
                .Add(
                    new ToolboxItem()
                    {
                        CategoryName = "Default",
                        Label = "tool1",
                        Icon = "account_circle",
                        Model = new ToolboxItemModel()
                        {
                            Label = "tool",
                            Ports = PortAlignment.Top | PortAlignment.Bottom,
                            Type = typeof(Table)
                        }
                    }
                 );

            var options = new DiagramOptions
            {
                DeleteKey = "Delete", // What key deletes the selected nodes/links
                DefaultNodeComponent = null, // Default component for nodes
                AllowMultiSelection = true, // Whether to allow multi selection using CTRL
                Links = new DiagramLinkOptions
                {
                },
                Zoom = new DiagramZoomOptions
                {
                    Minimum = 0.5, // Minimum zoom value
                    Inverse = false, // Whether to inverse the direction of the zoom when using the wheel
                }
            };
            Diagram = new Diagram(options);

            Diagram.RegisterModelComponent<Table, TableNode>();

            Setup();

        }

        private void Setup()
        {
            var node1 = NewNode(50, 50);
            var node2 = NewNode(300, 300);
            var node3 = NewNode(300, 50);
            Diagram.Nodes.Add(new[] { node1, node2, node3 });

            Diagram.Links.Add(new LinkModel(node1.GetPort(PortAlignment.Right), node2.GetPort(PortAlignment.Left)));
        }

        private static NodeModel NewNode(double x, double y)
        {
            var node = new NodeModel(new GPoint(x, y));
            node.AddPort(PortAlignment.Bottom);
            node.AddPort(PortAlignment.Top);
            node.AddPort(PortAlignment.Left);
            node.AddPort(PortAlignment.Right);
            return node;
        }


        private void OnDragStart(string uuid)
        {
            _draggedType = toolbox.GetByUuid(uuid);
        }

        private void OnDrop(DragEventArgs e)
        {

            if (_draggedType == null) // Unkown item
                return;

            var position = Diagram.GetRelativeMousePoint(e.ClientX, e.ClientY);
            var newModel = _draggedType.Create(position.X, position.Y);

            if (Diagram.Nodes.Any(c => c.Title == newModel.Title))
            {
                int c = 2;
                var n = newModel.Title + c.ToString();

                while (Diagram.Nodes.Any(c => c.Title == n))
                {
                    c++;
                    n = newModel.Title + c.ToString();
                }
                newModel.Title = n;
            }

            Diagram.Nodes.Add(newModel);
            _draggedType = null;

        }

        void Change(object value, string name, string action)
        {
            //console.Log($"{name} item with index {value} {action}");
        }

        private ToolboxItem _draggedType;
        private Toolbox toolbox;


    }

}
