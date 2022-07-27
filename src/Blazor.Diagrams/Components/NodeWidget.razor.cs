using Blazor.Diagrams.Core.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Diagrams.Components
{
    public partial class NodeWidget
    {

        public NodeWidget()
        {

        }

        [Parameter]
        public NodeModel Node { get; set; }



    }

}
