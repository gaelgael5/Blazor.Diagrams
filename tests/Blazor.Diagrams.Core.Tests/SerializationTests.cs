using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Serializations;
using Xunit;

namespace Blazor.Diagrams.Core.Tests
{
    public class SerializationTests
    {
        [Fact]
        public void Test1()
        {

            var diagram = new Diagram();

            // Act
            diagram.SetZoom(1.234);
            diagram.UpdatePan(50, 50);

            var node1 = NewNode(50, 50);
            var node2 = NewNode(250, 250);
            var node3 = NewNode(500, 100);
            diagram.Nodes.Add(new[] { node1, node2, node3 });

            diagram.Links.Add(new LinkModel(node1.GetPort(PortAlignment.Right), node2.GetPort(PortAlignment.Left)));


            var document = DiagramDocument.CreateFrom(diagram);


            var diagram2 = document.GenerateDiagram();



        }

        private NodeModel NewNode(double x, double y)
        {
            var node = new NodeModel(new Point(x, y));
            node.AddPort(PortAlignment.Bottom);
            node.AddPort(PortAlignment.Left);
            node.AddPort(PortAlignment.Right);
            return node;
        }

    }
}
