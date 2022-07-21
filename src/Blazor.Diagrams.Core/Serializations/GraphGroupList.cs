using Blazor.Diagrams.Core.Models;
using System;
using System.Collections.Generic;

namespace Blazor.Diagrams.Core.Serializations
{
    public class GraphGroupList : List<GraphGroup>
    {


        internal void CreateFrom(IReadOnlyList<GroupModel> groups)
        {

            foreach (var group in groups)
            {
                var g = new GraphGroup();
                g.CreateFrom(group);
                this.Add(g);

                CreateFrom(group.Children);

            }

        }

        private void CreateFrom(IReadOnlyList<NodeModel> children)
        {

            foreach (NodeModel n in children)
            {
                if (n is GroupModel group)
                {
                    var g = new GraphGroup();
                    g.CreateFrom(group);
                    this.Add(g);

                    CreateFrom(group.Children);
                }
            }

        }

        internal void GenerateTo(Diagram diagram)
        {

            HashSet<Guid> created = new HashSet<Guid>(this.Count);

            while (this.Count > created.Count)
            {
                foreach (var group in this)
                {
                    if (group.ParentGroupId == null || !created.Contains(group.ParentGroupId.Value))
                    {
                        var g = group.Generate();
                        diagram.AddGroup(g);
                        created.Add(group.Uuid);
                    }
                }
            }

        }
    }


}
