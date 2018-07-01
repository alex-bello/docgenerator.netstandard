using System.IO;

namespace DocsGenerator.Output.Generators
{
    public class MarkdownOutputGenerator : IOutputGenerator
    {
        public string FileExtension { get; set; } = "md";

        public string OutputFolder { get { return "/md"; } }

        public OutputFormat OutputFormat { get { return OutputFormat.Markdown; } }

        public StringWriter Generate()
        {
            throw new System.NotImplementedException();
        }

        public string PrintTitle(string title)
        {
            return $"# {title}";
        }
    }
}