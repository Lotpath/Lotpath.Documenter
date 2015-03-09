using System.Collections.Generic;
using System.Reflection;

namespace Lotpath.Documenter
{
    public class ManagerMethodDescriptor
    {
        public ManagerMethodDescriptor(MethodInfo methodInfo)
        {
            ModelsIn = new Dictionary<string, ManagerModelDescriptor>();

            Name = methodInfo.Name;

            ModelOut = new ManagerModelDescriptor(methodInfo.ReturnType);

            foreach (var p in methodInfo.GetParameters())
            {
                ModelsIn.Add(p.Name, new ManagerModelDescriptor(p.ParameterType));
            }
        }

        public string Name { get; private set; }

        public IDictionary<string, ManagerModelDescriptor> ModelsIn { get; private set; }

        public ManagerModelDescriptor ModelOut { get; private set; }
    }
}