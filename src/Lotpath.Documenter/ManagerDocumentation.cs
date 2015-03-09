using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lotpath.Documenter
{
    public class ManagerDocumentation
    {
        private readonly IList<Type> _managerTypes;

        public ManagerDocumentation(Assembly assembly)
        {
            _managerTypes = assembly
                .GetExportedTypes()
                .Where(x => x.Name.Contains("Manager"))
                .ToList();

            Managers = _managerTypes.Select(x => new ManagerDescriptor(x)).ToList();
        }

        public IList<ManagerDescriptor> Managers { get; private set; } 
    }
}