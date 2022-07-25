using System;
using System.Text;

namespace Blazor.Diagrams.Core.Serializations
{


    public class DiagramDocument
    {


        public DiagramDocument()
        {
            Groups = new DiagramGroupList();
            Nodes = new DiagramNodeList();
            Relationships = new DiagramRelationshipList();
        }

        public static DiagramDocument CreateFrom(Diagram diagram)
        {

            var result = new DiagramDocument()
            {
                Zoom = diagram.Zoom,
                PanX = diagram.Pan.X,
                PanY = diagram.Pan.Y,
            };

            result.Groups.CreateFrom(diagram.Groups);
            result.Nodes.CreateFrom(diagram.Nodes);
            result.Nodes.CreateFrom(diagram.Groups);

            result.Relationships.CreateFrom(diagram.Links);

            return result;

        }

        public Diagram GenerateDiagram()
        {
            var diagram = new Diagram();
            GenerateDiagram(diagram);
            return diagram;
        }

        public void GenerateDiagram(Diagram diagram)
        {        

            diagram.SetZoom(this.Zoom);
            diagram.UpdatePan(this.PanX, this.PanY);
            this.Groups.GenerateTo(diagram);
            this.Nodes.GenerateTo(diagram);
            this.Relationships.GenerateTo(diagram);

        }

        public Guid Uuid { get; set; }

        public double Zoom { get; set; } = 1;

        public double PanX { get; set; }

        public double PanY { get; set; }


        public DiagramGroupList Groups { get; set; }

        public DiagramNodeList Nodes { get; set; }

        public DiagramRelationshipList Relationships { get; set; }

    }

}
