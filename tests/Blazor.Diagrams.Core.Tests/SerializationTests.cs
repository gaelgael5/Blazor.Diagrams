//using Bb.WebClient.UIComponents;
//using Bb.WebClient.UIComponents.Glyphs;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Serializations;
using System;
using System.Text;
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


        //[Fact]
        //public void Test2()
        //{

        //    Type[] types = new Type[] { typeof(GlyphFileFormats), typeof(GlyphFilled), typeof(GlyphOutlined), typeof(GlyphRounded), typeof(GlyphsBrands), typeof(GlyphSharp), typeof(GlyphTwoTone), typeof(GlyphUncategorized) };

        //    foreach (var type in types)
        //    {

        //        var fields = type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

        //        foreach (var field in fields)
        //        {

        //            var name = field.Name;

        //            StringBuilder sb = new StringBuilder($"<svg id=\"{Guid.NewGuid()}\" data-name=\"Layer 1\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 24 24\">");
        //            sb.Append(((Glyph)field.GetValue(null)).Value);
        //            sb.Append("</svg>");
        //            Bb.ContentHelperFiles.Save($"C:\\Users\\g.beard\\Desktop\\Nouveau dossier\\svg\\{type.Name}_{name}.svg", sb.ToString());
        //        }

        //    }

        //}


    

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
