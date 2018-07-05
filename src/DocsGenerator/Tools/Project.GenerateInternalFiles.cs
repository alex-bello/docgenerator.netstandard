using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DocsGenerator.Extensions;
using DocsGenerator.Internal.Files;

namespace DocsGenerator.Tools
{
    public static partial class StaticTools
    {
        public static Project GenerateInternalFiles(this Project project)
        {
            // Throw error if no assemblies in Assemblies property.
            if (!project.Assemblies.Any()) throw new ArgumentException("Assemblies property must contain at least one Assembly to document.");

            foreach (var a in project.Assemblies)
            {
                project.Settings.FileDefinitions.Add(new AssemblyFileDefinition( a.FullName, a.GetSimpleName(), FileType.Assembly));
            }

            foreach( var x in project.EntryAssembly.GetUserTypes())
            {
                project.Settings.FileDefinitions.Add(new TypeFileDefinition( x.FullName, x.FullName.GetSimpleName(), FileType.Type));

                foreach (var y in x.GetProperties())
                {
                    project.Settings.FileDefinitions.Add(new PropertyFileDefinition( y.Name, y.Name, FileType.Property, x.FullName.GetSimpleName()));
                }

                foreach (var m in x.GetMethods().Where(m => !m.IsSpecialName))
                {
                    project.Settings.FileDefinitions.Add(new MethodFileDefinition( m.Name, m.Name, FileType.Method, x.FullName.GetSimpleName()));
                }
            }

            foreach (var b in project.Settings.FileDefinitions)
            {
                Console.WriteLine($"{b.FullName}, {b.BaseFileName}, {b.FileType.ToString()}");
            }
            // foreach(var outputFormat in project.Settings.OutputFormats)
            // {
            //     project.Settings.FileDefinitions.Add(new IndexFileDefinition());
            //     var filename = Path.Combine(project.Settings.OutputFolder, $"index.{outputFormat.FileExtension}");
            //     // var file = new DocsFile(filename, FileType.Index, OutputFormat.Markdown)
            //     //     .SetTitle(project.Settings.ProjectName)
            //     //     .UseEngine(new IndexFileGenerator(project.Assemblies, project.Settings));
            //     //     //.Compile();
                
            //     // file.Compile();

            //     //dll.GetAllNamespaces().ToList().ForEach(a => output.WriteLine("[" + a + "](./namespaces/" + a.Replace(".", "-") + ".md)"));
            //     // File.WriteAllLines(filename, output.ToString().Split(Environment.NewLine, StringSplitOptions.None));
            //     project.LogVerbose($"Index file created at {filename}");
            // }

            return project;
        }
    }
}