using System.IO;

namespace Lotpath.Documenter
{
    public class DocumentationDetailWriter
    {
        private readonly ManagerDocumentation _documentation;

        public DocumentationDetailWriter(ManagerDocumentation documentation)
        {
            _documentation = documentation;
        }

        public void WriteTo(Stream stream)
        {
            var json = SimpleJson.SimpleJson.SerializeObject(_documentation);

            var formatted = JsonHelper.FormatJson(json);

            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine(formatted);
            }
        }
    }
}