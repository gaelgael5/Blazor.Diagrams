using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Blazor.Diagrams.Core.Serializations
{
    internal class StorageHelper
    {

        internal static HashSet<string> GetProperties(params Type[] nodes)
        {

            HashSet<string> result = new HashSet<string>();

            foreach (Type node in nodes)
            {
                var properties = TypeDescriptor.GetProperties(node);
                foreach (PropertyDescriptor property in properties)
                    if (property.ComponentType == node)
                        result.Add(property.Name);
            }

            return result;

        }


        internal static List<PropertyValue> CreateExtendedPropertiesFrom(object node, HashSet<Type> excludes, HashSet<string> propertiesManaged)
        {

            var dic = new Dictionary<string, PropertyValue>();
            var extendedProperties = new List<PropertyValue>();

            var properties = TypeDescriptor.GetProperties(node.GetType());
            foreach (PropertyDescriptor property in properties)
                if (IsAccepted(property, excludes, propertiesManaged))
                    SerializeExtendedProperties(dic, property, node);

            foreach (var item in dic)
                extendedProperties.Add(item.Value);

            return extendedProperties;

        }

        internal static void SerializeExtendedProperties(Dictionary<string, PropertyValue> dic, PropertyDescriptor property, object component)
        {

            if (!dic.TryGetValue(property.Name, out var value))
            {
                value = new PropertyValue() { Name = property.Name };
                value.Serialize(property, component);
                dic.Add(property.Name, value);
            }
            else
            {

            }

        }

        internal static bool IsAccepted(PropertyDescriptor property, HashSet<Type> excludes, HashSet<string> propertiesManaged)
        {

            if (property.IsReadOnly)
                return false;

            Type componentType = property.ComponentType;

            if (propertiesManaged.Contains(property.Name))
                return false;

            if (excludes.Contains(componentType))
                return false;

            var a = property.Attributes.OfType<SerializableAttribute>().FirstOrDefault();
            if (a == null)
                return false;

            return true;

        }

    }

}
