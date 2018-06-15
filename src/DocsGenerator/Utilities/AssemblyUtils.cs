// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Reflection;
// using DocsGenerator.Markdown;
// using DocsGenerator.Extensions;

// namespace DocsGenerator.Utils
// {
//     public class AssemblyUtils
//     {
//         internal IEnumerable<Assembly> Assemblies { get; }

//         internal string OutputFolder { get; }

//         public AssemblyUtils(IEnumerable<Assembly> assemblies, string outputFolder)
//         {
//             Assemblies = assemblies;
//             OutputFolder = Path.Combine(outputFolder,"assemblies/");
            
//             var namespaceList = new List<string>();
//             Assemblies.ToList().ForEach(a => { namespaceList.AddRange(a.GetAllNamespaces()); });
//         }

//         public void Compile()
//         {
//             // Exit method if the Assemblies property is empty.
//             if (!Assemblies.Any()) return;

//             // Make sure output directory exists.
//             Directory.CreateDirectory(OutputFolder);

//             Assemblies.ToList().ForEach(n => {

//                 var assemblyName = n.FullName.Split(',');
//                 var path = Path.Combine(OutputFolder, assemblyName.First().Replace(".", "-").ToLower() + ".md");
//                 Console.WriteLine("File Path is {0}", path);
//                 var x = new MarkdownDocumentFile(path, MarkdownDocumentFileType.Assembly);
//                 x.SetTitle(string.Format("{0} Assembly", assemblyName));
//                 x.Compile();
//             });

//         }
//     }
// }