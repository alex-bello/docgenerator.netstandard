using System.IO;

namespace DocsGenerator.Output.Generators
{
    public class HtmlOutputGenerator : IOutputGenerator
    {
        public string FileExtension { get; set; } = "html";

        public string OutputFolder { get { return "/html"; } }

        public OutputFormat OutputFormat { get { return OutputFormat.Html; } }

        public StringWriter Generate()
        {
            throw new System.NotImplementedException();
        }

        public string PrintTitle(string title)
        {
            return $"<h1>{title}</h1>";
        }

    }
}