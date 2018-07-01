// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Reflection;
// using DocsGenerator.Utils;

// namespace DocsGenerator.Markdown
// {
//     public class MarkdownDocumentProject
//     {
//         public IEnumerable<Assembly> Assemblies { get; set; } = new List<Assembly>();

//         public string ProjectName { get; set; }

//         public string OutputFolder { get; }

//         public MarkdownDocumentProject(string outputFolder, string projectName = null)
//         {
//             OutputFolder = outputFolder;
//             ProjectName = projectName;

//             // // Ensure that the output folders exists, create if it doesn't.
//             // var directory = Directory.CreateDirectory(OutputFolder);

//             // // Log successful directory creation
//             // Console.WriteLine("Directory Created successfully at {0}", directory.FullName.ToLower());            
//         }
        
//         public int Compile() 
//         {
//             // Generate the project's index file
//             GenerateIndexFile();
//             GenerateAssemblyFiles();
            
//             return 0;
//         }
        
//         internal void GenerateIndexFile()
//         {
//             // Throw error if no assemblies in Assemblies property.
//             if (!Assemblies.Any()) throw new ArgumentException("Assemblies property must contain at least one Assembly to document.");

//             var filename = Path.Combine(OutputFolder, "index.md");
//             var output = new StringWriter();
            
//             output.WriteLine("# {0}", ProjectName);
//             output.WriteLine();
//             output.WriteLine("## Assemblies in Project");
//             output.WriteLine();

//             output.WriteLine("| Name | Description |");
//             output.WriteLine("| --- | --- |");
//             Assemblies.ToList().ForEach(a => {
//                 var assemblyName = a.FullName.Split(',').First();
//                 output.WriteLine("| [{0} Assembly]({1}) | Description |", assemblyName, Path.Combine("./assemblies/", assemblyName.Replace(".", "-").ToLower() + ".md"));
//             });

//             output.WriteLine();
//             //dll.GetAllNamespaces().ToList().ForEach(a => output.WriteLine("[" + a + "](./namespaces/" + a.Replace(".", "-") + ".md)"));

//             File.WriteAllLines(filename, output.ToString().Split(Environment.NewLine, StringSplitOptions.None));
//             Console.WriteLine("Index file created at {0}", filename);
//         }

//         internal void GenerateAssemblyFiles()
//         {
//             if (!Assemblies.Any()) throw new ArgumentException("Assemblies property must contain at least one Assembly to document.");

//             new AssemblyUtils(Assemblies, OutputFolder).Compile();

//             // var output = new StringWriter();

//             // output.WriteLine("# {0}", ProjectName);
//             // output.WriteLine();
//             // output.WriteLine("## Assemblies in Project");
//             // output.WriteLine();

//             // output.WriteLine("| Name | Description |");
//             // output.WriteLine("| --- | --- |");
//             // Assemblies.ToList().ForEach(a => {
//             //     output.WriteLine("| [{0} Assembly]({1}) | Description |", a.FullName.Split(',').First(), a.FullName.Split(',').First().Replace(".", "-").ToLower() + ".md");
//             // });

//             // output.WriteLine();
//             // //dll.GetAllNamespaces().ToList().ForEach(a => output.WriteLine("[" + a + "](./namespaces/" + a.Replace(".", "-") + ".md)"));

//             // File.WriteAllLines(filename, output.ToString().Split(Environment.NewLine, StringSplitOptions.None));
//             // Console.WriteLine("Index file created at {0}", filename);
//         }
//     }
// }