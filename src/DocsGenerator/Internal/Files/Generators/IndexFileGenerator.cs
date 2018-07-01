using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DocsGenerator.Extensions;

namespace DocsGenerator.Internal.Files.Generators
{
    public class IndexFileGenerator : IFileGenerator
    {
        public IndexFileGenerator(IEnumerable<Assembly> assemblies, ProjectSettings settings)
        {
            Assemblies = assemblies;
            Settings = settings;
        }

        public IEnumerable<Assembly> Assemblies { get; set; }

        public ProjectSettings Settings { get; set; }

        public StringWriter Generate()
        {
            var output = new StringWriter();

            output.WriteLine("# {0}", Settings.ProjectName);
            output.WriteLine();

            output.WriteLine("## Assemblies in Project");
            output.WriteLine();

            output.WriteLine("| Name | Description |");
            output.WriteLine("| --- | --- |");

            Assemblies.ToList().ForEach(a => {
                output.WriteLine("| [{0} Assembly]({1}) | Description |", a.GetSimpleName(), Path.Combine(Settings.TempFolder, Settings.AssembliesFolder, a.ToFileName() + ".md"));
            });

            return output;
        }
    }
}