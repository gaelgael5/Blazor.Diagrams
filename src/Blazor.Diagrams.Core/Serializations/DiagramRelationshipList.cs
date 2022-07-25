using Blazor.Diagrams.Core.Layers;
using Blazor.Diagrams.Core.Models.Base;
using System;
using System.Collections.Generic;

namespace Blazor.Diagrams.Core.Serializations
{

    public class DiagramRelationshipList : List<DiagramRelationship>
    {

        internal void CreateFrom(LinkLayer links)
        {

            foreach (BaseLinkModel link in links)
            {

                var l = new DiagramRelationship();
                l.CreateFrom(link);
                this.Add(l);
            }
        
        }

        internal void GenerateTo(Diagram diagram)
        {

            foreach (var relationship in this)
                relationship.GenerateTo(diagram);

        }
    }


}
