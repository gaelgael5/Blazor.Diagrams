using Blazor.Diagrams.Core.Layers;
using Blazor.Diagrams.Core.Models;
using System;
using System.Collections.Generic;

namespace Blazor.Diagrams.Core.Serializations
{
    public class GraphNodeList : List<GraphNode>
    {

        internal void CreateFrom(NodeLayer nodes)
        {

            foreach (NodeModel node in nodes)
            {
                var n = new GraphNode();
                n.CreateFrom(node);
                this.Add(n);
            }

        }

        internal void CreateFrom(IReadOnlyList<GroupModel> groups)
        {

            foreach (var n in groups)
            {

                if (n is GroupModel group)
                    CreateFrom(group.Children);
                
                else
                {
                    var n2 = new GraphNode();
                    n2.CreateFrom(n);
                    this.Add(n2);
                }

            }

        }

        private void CreateFrom(IReadOnlyList<NodeModel> children)
        {

            foreach (NodeModel n in children)
            {
                
                if (n is GroupModel group)
                    CreateFrom(group.Children);
                
                else
                {
                    var n2 = new GraphNode();
                    n2.CreateFrom(n);
                    this.Add(n2);
                }
            }

        }


        internal void GenerateTo(Diagram diagram)
        {

            foreach (GraphNode node in this)
                node.GenerateTo(diagram);

        }

    }


}
