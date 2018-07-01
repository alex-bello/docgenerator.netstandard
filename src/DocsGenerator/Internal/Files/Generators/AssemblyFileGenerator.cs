using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DocsGenerator.Extensions;
using DocsGenerator.Output.Generators;

namespace DocsGenerator.Internal.Files.Generators
{
    public class AssemblyFileGenerator : IFileGenerator
    {
        public AssemblyFileGenerator(Assembly assembly, ProjectSettings settings, string title)
        {
            Assembly = assembly;
            Settings = settings;
            Title = title;
        }

        public Assembly Assembly { get; set; }

        public ProjectSettings Settings { get; set; }

        public IEnumerable<IOutputGenerator> OutputGenerators { get; set; }

        public string Title { get; set; }

        public StringWriter Generate()
        {
            var output = new StringWriter();

            Assembly.GetReferencedAssemblies().ToList().ForEach(ra => {
                try
                {
                    Assembly.Load(ra.FullName);
                    Console.WriteLine($"{ra.FullName} Loaded.");
                }
                catch (FileNotFoundException ex) // This error is thrown for assemblies from nuget and so we load the dll directly.
                {
                    var filename = Path.Combine(Settings.TempFolder, ra.FullName.Split(',').First() + ".dll");
                    Assembly.LoadFrom(filename);
                    Console.WriteLine($"{ex.FileName} Loaded from file {filename}.");
                }
            });

            output.WriteLine("# {0}", Title);
            output.WriteLine();
            output.WriteLine("## Namespaces in Assembly");
            output.WriteLine();

            output.WriteLine("| Name | Description |");
            output.WriteLine("| --- | --- |");
            Assembly.GetAllNamespaces().OrderBy(p => p).ToList().ForEach(n => {
                output.WriteLine("| [{0} Assembly]({1}) | Description |", n, Path.Combine(Settings.OutputFolder, Settings.NamespacesFolder, n.Replace(".", "-").ToLower() + ".md"));
            });

            return output;
        }
    }
}
            // switch (FileType)
            // {
            //     case DocsFileType.Assembly:
            //         output.WriteLine("## Namespaces in Assembly");
            //         output.WriteLine();
            //         break;
            // }

            // output.WriteLine("| Name | Description |");
            // output.WriteLine("| --- | --- |");
            // Assemblies.ToList().ForEach(a => {
            //     output.WriteLine("| [{0} Assembly]({1}) | Description |", a.FullName.Split(',').First(), a.FullName.Split(',').First().Replace(".", "-").ToLower() + ".md");
            // });

            // output.WriteLine();
            // //dll.GetAllNamespaces().ToList().ForEach(a => output.WriteLine("[" + a + "](./namespaces/" + a.Replace(".", "-") + ".md)"));