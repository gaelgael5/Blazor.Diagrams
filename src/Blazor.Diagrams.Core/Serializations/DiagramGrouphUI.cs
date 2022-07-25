using Blazor.Diagrams.Core.Models;

namespace Blazor.Diagrams.Core.Serializations
{
    public class DiagramGrouphUI : GraphUI
    {

        internal override void Serialize(NodeModel n)
        {

            var node = n as GroupModel;

            this.X = node.Position.X;
            this.Y = node.Position.Y;

            this.Width = node.Size?.Width ?? 0;
            this.Height = node.Size?.Height ?? 0;

            foreach (PortModel port in node.Ports)
            {

                Ports.Add(new DiagramPortUI()
                {
                    Uuid = port.Id,
                    Alignment = port.Alignment,
                    X = port.Position.X,
                    Y = port.Position.Y
                });

            }


        }

    }

}
