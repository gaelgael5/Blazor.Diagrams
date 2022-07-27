using System;
using System.Collections.Generic;
using System.Text;
using Blazor.Diagrams.Core.ExtendedModels;
using Microsoft.AspNetCore.Components;

namespace Blazor.Diagrams.Components
{

    public partial class TableNode
    {
        [Parameter]
        public Table Node { get; set; }
    }

}
