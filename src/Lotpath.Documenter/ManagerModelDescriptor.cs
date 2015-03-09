using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lotpath.Documenter
{
    public class ManagerModelDescriptor
    {
        public ManagerModelDescriptor(Type modelType)
        {
            Properties = new Dictionary<string, string>();
            NestedModels = new Dictionary<string, ManagerModelDescriptor>();

            Type = modelType.ToGenericTypeString();

            if (modelType.Namespace.StartsWith("System"))
            {
                return;
            }

            var properties = modelType.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();

            foreach (var property in properties)
            {
                Properties.Add(property.Name, property.PropertyType.ToGenericTypeString());
            }

            foreach (var nested in modelType.GetNestedTypes(BindingFlags.Instance | BindingFlags.Public))
            {
                NestedModels.Add(nested.Name, new ManagerModelDescriptor(nested));
            }
        }

        public string Type { get; private set; }

        public IDictionary<string, string> Properties { get; private set; }

        public IDictionary<string, ManagerModelDescriptor> NestedModels { get; private set; }

        public bool ShouldSerializeProperties()
        {
            return Properties.Any();
        }

        public bool ShouldSerializeNestedModels()
        {
            return NestedModels.Any();
        }
    }
}