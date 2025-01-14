﻿using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;

namespace SharedDemo.Demos
{
    public class BotAnswerNode : NodeModel
    {
        public BotAnswerNode(GPoint position = null) : base(position) { }

        public string Answer { get; set; }
    }
}
