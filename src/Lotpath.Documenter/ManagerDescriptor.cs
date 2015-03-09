using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lotpath.Documenter
{
    public class ManagerDescriptor
    {
        private readonly Type _managerType;

        public ManagerDescriptor(Type managerType)
        {
            _managerType = managerType;

            Name = _managerType.Name;
            Methods = new List<ManagerMethodDescriptor>();

            var methods = _managerType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                      .Where(x => x.DeclaringType == managerType);

            foreach (var methodInfo in methods)
            {
                Methods.Add(new ManagerMethodDescriptor(methodInfo));
            }
        }

        public string Name { get; private set; }

        public IList<ManagerMethodDescriptor> Methods { get; private set; }
    }
}