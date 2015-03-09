using System.IO;
using System.Linq;

namespace Lotpath.Documenter
{
    public class DocumentationSummaryWriter
    {
        private readonly ManagerDocumentation _documentation;

        public DocumentationSummaryWriter(ManagerDocumentation documentation)
        {
            _documentation = documentation;
        }

        public void WriteTo(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                foreach (var d in _documentation.Managers)
                {
                    writer.WriteLine("{0}", d.Name);

                    foreach (var m in d.Methods)
                    {
                        writer.Write("\t");

                        writer.Write("{0} : ", m.Name);

                        writer.Write("(");
                        var parameters = m.ModelsIn.Select(p => string.Format("{0} {1}", p.Value.Type, p.Key)).ToList();
                        writer.Write(string.Join(", ", parameters));
                        writer.Write(")");
                        writer.WriteLine(" => {0}", m.ModelOut.Type);

                    }

                    writer.WriteLine();
                }
            }
        }
    }
}