using System;

namespace Blazor.Diagrams.Core.Tools
{
    public class DragStartEventArgs : EventArgs
    {

        public DragStartEventArgs(Toolbox toolbox, string uuid)
        {
        
            this._toolbox = toolbox;
            this._uuid = uuid;

            DragedItem = toolbox.GetByUuid(uuid);
        
        }

        public ToolboxItem DragedItem { get; }

        private Toolbox _toolbox;
        private string _uuid;

    }

}
