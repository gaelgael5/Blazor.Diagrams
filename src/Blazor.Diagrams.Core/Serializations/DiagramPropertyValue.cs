using Blazor.Diagrams.Core.Models;
using System.ComponentModel;

namespace Blazor.Diagrams.Core.Serializations
{
    public class DiagramPropertyValue
    {

        public string Type { get; set; } = typeof(NodeModel).AssemblyQualifiedName;

        public string Name { get; set; }

        public string Value { get; set; }

        internal void Serialize(PropertyDescriptor property, object component)
        {
            Type = property.PropertyType.AssemblyQualifiedName;
            var value = property.GetValue(component);
            this.Value = property.Converter.ConvertToString(value);
        }

    }

}
