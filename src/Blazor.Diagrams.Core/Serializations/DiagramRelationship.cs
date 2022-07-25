using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;
using System;
using System.Collections.Generic;

namespace Blazor.Diagrams.Core.Serializations
{
    public class DiagramRelationship
    {

        static DiagramRelationship()
        {
            _propertiesManaged = new HashSet<string>();
            DiagramRelationship._propertiesManaged = StorageHelper.GetProperties(typeof(BaseLinkModel), typeof(LinkModel));
        }

        public DiagramRelationship()
        {
            this.Labels = new List<DiagramLinkLabelModel>();
            this.ExtendedProperties = new List<DiagramPropertyValue>();
        }

        public string Type { get; set; } = typeof(LinkModel).AssemblyQualifiedName;

        public Guid Uuid { get; set; }

        public bool IsAttached { get; set; }

        public bool Segmentable { get; set; }

        public DiagramEndpoint Source { get; set; }

        public DiagramEndpoint Target { get; set; }

        public List<DiagramLinkLabelModel> Labels { get; set; }

        public string? Color { get; set; }

        public string? SelectedColor { get; set; }

        public double Width { get; set; } = 2;


        public List<DiagramPropertyValue> ExtendedProperties { get; }


        internal void CreateFrom(BaseLinkModel link)
        {

            this.Type = link
                .GetType()
                .AssemblyQualifiedName;

            Uuid = link.Id;

            this.IsAttached = link.IsAttached;
            this.Segmentable = link.Segmentable;


            foreach (var label in link.Labels)
            {
                var la = new DiagramLinkLabelModel();
                la.Serialize(label);
                Labels.Add(la);
            }

            this.Source = new DiagramEndpoint()
            {
                MarkerPath = link?.SourceMarker?.Path,
                MarkerWidth = link?.SourceMarker?.Width,
                PortId = link?.SourcePort.Id,
                NodeId = link?.SourceNode.Id
            };

            this.Target = new DiagramEndpoint()
            {
                MarkerPath = link?.TargetMarker?.Path,
                MarkerWidth = link?.TargetMarker?.Width,
                PortId = link?.TargetPort.Id,
                NodeId = link?.TargetNode.Id
            };

            if (link is LinkModel l)
            {
                this.Color = l.Color;
                this.SelectedColor = l.SelectedColor;
                this.Width = l.Width;
            }

            ExtendedProperties.AddRange(StorageHelper.CreateExtendedPropertiesFrom(link, _excludes, _propertiesManaged));

        }

        internal void GenerateTo(Diagram diagram)
        {

            var type = System.Type.GetType(this.Type);
            if (type != null)
            {

                object source = null;
                object target = null;

                if (this.Source.NodeId != null)
                {
                    source = diagram.ResolveNode(this.Source.NodeId.Value);
                }

                if (this.Target.NodeId != null)
                {
                    target = diagram.ResolveNode(this.Target.NodeId.Value);
                }


                if (this.Source.PortId != null)
                {
                    source = diagram.ResolvePort(this.Source.PortId.Value, this.Source.NodeId.Value);
                }

                if (this.Target.PortId != null)
                {
                    target = diagram.ResolvePort(this.Target.PortId.Value, this.Target.NodeId.Value);
                }

                BaseLinkModel link;
                if (source != null && target != null)
                {

                    if (source is PortModel)
                        link = (BaseLinkModel)Activator.CreateInstance(type, new object[] { this.Uuid, (PortModel)source, (PortModel)target });
    
                    else 
                        link = (BaseLinkModel)Activator.CreateInstance(type, new object[] { this.Uuid, (NodeModel)source, (NodeModel)target });

                    if (link is LinkModel l)
                    {
                        l.Color = this.Color;
                        l.SelectedColor = this.SelectedColor;
                        l.Width = this.Width;
                    }

                    //this.Design.Initialize(node);

                    diagram.Links.Add(link);

                }




            }
            else
            {

            }


        }

        private HashSet<Type> _excludes = new HashSet<Type>() { typeof(BaseLinkModel), typeof(LinkModel) };
        private static HashSet<string> _propertiesManaged;

    }

}
