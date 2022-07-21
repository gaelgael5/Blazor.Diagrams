using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Blazor.Diagrams.Core.Serializations
{


    public class GraphNode
    {

        static GraphNode()
        {
            GraphNode._propertiesManaged = StorageHelper.GetProperties(typeof(GraphNode));
        }

        public GraphNode()
        {
            this.ExtendedProperties = new List<PropertyValue>();
        }

        public string Type { get; set; } = typeof(NodeModel).AssemblyQualifiedName;

        public Guid Uuid { get; set; }

        public string Title { get; set; }

        public bool Locked { get; set; }

        public RenderLayer Layer { get; set; }

        public Guid? ParentGroupId { get; set; }

        internal void GenerateTo(Diagram diagram)
        {

            var type = System.Type.GetType(this.Type);
            if (type != null)
            {

                var node = (NodeModel)Activator.CreateInstance(type, new object[] { this.Uuid, null, this.Layer, null });
                node.Title = this.Title;
                node.Locked = this.Locked;

                this.Design.Initialize(node);

                diagram.Nodes.Add(node);
            }
            else
            {

            }


        }

        public GraphUI Design { get; set; }

        public List<PropertyValue> ExtendedProperties { get; }

        #region Serialize

        internal virtual void CreateFrom(NodeModel node)
        {

            this.Type = node
                .GetType()
                .AssemblyQualifiedName;
            this.Uuid = node.Id;
            this.Title = node.Title;
            this.Locked = node.Locked;
            this.Layer = node.Layer;

            ParentGroupId = node.Group?.Id;

            CreateUIFrom(node);
            ExtendedProperties.AddRange(StorageHelper.CreateExtendedPropertiesFrom(node, _excludes, _propertiesManaged));

        }


        protected virtual void CreateUIFrom(NodeModel node)
        {
            this.Design = new GraphUI();
            this.Design.Serialize(node);
        }

        #endregion Serialize

        private HashSet<Type> _excludes = new HashSet<Type>() { typeof(NodeModel), typeof(GroupModel) };
        protected static HashSet<string> _propertiesManaged;

    }

}
