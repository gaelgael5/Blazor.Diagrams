﻿using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Models;
using Microsoft.AspNetCore.Components;
using Blazor.Diagrams.Core.Geometry;

namespace SharedDemo.Demos
{
    public class PerformanceCompoent : ComponentBase
    {
        protected readonly Diagram diagram = new Diagram();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c += 2)
                {
                    var node1 = new NodeModel(new GPoint(10 + c * 10 + c * 120, 10 + r * 100));
                    var node2 = new NodeModel(new GPoint(10 + (c + 1) * 130, 10 + r * 100));

                    var sourcePort = node1.AddPort(PortAlignment.Right);
                    var targetPort = node2.AddPort(PortAlignment.Left);

                    diagram.Nodes.Add(new[] { node1, node2 });
                    diagram.Links.Add(new LinkModel(sourcePort, targetPort));
                }
            }
        }
    }
}
