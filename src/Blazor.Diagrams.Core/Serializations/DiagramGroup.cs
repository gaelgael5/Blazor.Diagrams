using Blazor.Diagrams.Core.Models;
using System;
using System.Reflection;

namespace Blazor.Diagrams.Core.Serializations
{
    public class DiagramGroup : DiagramNodeModel
    {

        public DiagramGroup()
        {
            DiagramNodeModel._propertiesManaged = StorageHelper.GetProperties(typeof(DiagramNodeModel), typeof(DiagramGroup));
        }

        public byte Padding { get; set; } = 30;

        protected override void CreateUIFrom(NodeModel group)
        {
            this.Design = new DiagramGrouphUI();
            this.Design.Serialize(group);
        }

        internal override void CreateFrom(NodeModel node)
        {
            var o = node as GroupModel;
            this.Padding = o.Padding;
            base.CreateFrom(node);
        
        }

        internal GroupModel Generate()
        {

            var type = System.Type.GetType(this.Type);
            if (type != null)
            {
                var group = (GroupModel)Activator.CreateInstance(type, new object[] { Array.Empty<NodeModel>(), this.Padding });

                group.SetId(this.Uuid);
                group.Title = this.Title;
                group.Locked = this.Locked;

                this.Design.Initialize(group);

                return group;
            }

            throw new InvalidOperationException($"the type {this.Type} can't be created");

        }
    
    }


}
