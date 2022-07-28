using Blazor.Diagrams.Components;
using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.ExtendedModels;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Tools;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Linq;

namespace Cartography.Components
{

    public partial class ToolboxComponent
    {

        [Parameter]
        public Toolbox Toolbox { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        private void OnDragStart(string uuid)
        {
            Toolbox.DragStart(uuid);
        }            


    }

}
