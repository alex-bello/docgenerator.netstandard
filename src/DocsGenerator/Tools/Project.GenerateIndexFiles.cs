using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DocsGenerator.Internal.Files;
using DocsGenerator.Output;

namespace DocsGenerator.Tools
{
    public static partial class StaticTools
    {
        public static Project GenerateIndexFiles(this Project project)
        {
            // Throw error if no assemblies in Assemblies property.
            if (!project.Assemblies.Any()) throw new ArgumentException("Assemblies property must contain at least one Assembly to document.");

            foreach( var outputFormat in project.Settings.OutputFormats)
            {
                var filename = Path.Combine(project.Settings.OutputFolder, "index.md");
                // var file = new DocsFile(filename, FileType.Index, OutputFormat.Markdown)
                //     .SetTitle(project.Settings.ProjectName)
                //     .UseEngine(new IndexFileGenerator(project.Assemblies, project.Settings));
                //     //.Compile();
                
                // file.Compile();

                //dll.GetAllNamespaces().ToList().ForEach(a => output.WriteLine("[" + a + "](./namespaces/" + a.Replace(".", "-") + ".md)"));
                // File.WriteAllLines(filename, output.ToString().Split(Environment.NewLine, StringSplitOptions.None));
                project.LogVerbose($"Index file created at {filename}");
            }

            return project;
        }
    }
}