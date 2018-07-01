using System.IO;

namespace DocsGenerator.Output.Generators
{
    public interface IOutputGenerator
    {
        string FileExtension { get; }

        string OutputFolder { get; }

        OutputFormat OutputFormat { get; }
        
        string PrintTitle(string title);

        StringWriter Generate();
    }
}