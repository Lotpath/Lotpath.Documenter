using System;
using System.Linq;
using System.Reflection;

namespace Lotpath.Documenter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("");
                Console.WriteLine("Lotpath.Documenter.exe {assembly-path} [options]");
                Console.WriteLine("");
                Console.WriteLine("Options:");
                Console.WriteLine("");
                Console.WriteLine("{0,-15}{1}", "--summary", "write summary to console");
                Console.WriteLine("{0,-15}{1}", "--detail", "write json details to console");
                return;
            }

            var assembly = Assembly.LoadFrom(args[0]);

            var documentation = new ManagerDocumentation(assembly);

            if (args.Length == 1 || args.Contains("--summary"))
            {
                var writer = new DocumentationSummaryWriter(documentation);

                writer.WriteTo(Console.OpenStandardOutput());
            }
            else if (args.Contains("--detail"))
            {
                var writer = new DocumentationDetailWriter(documentation);

                writer.WriteTo(Console.OpenStandardOutput());
            }
        }
    }
}
