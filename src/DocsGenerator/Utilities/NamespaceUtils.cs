// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Reflection;
// using DocsGenerator.Extensions;

// namespace DocsGenerator.Utils
// {
//     public class NamespaceUtils
//     {
//         internal IEnumerable<Assembly> Assemblies { get; }

//         internal IEnumerable<string> Namespaces { get; } 

//         internal string OutputFolder { get; }

//         public NamespaceUtils(IEnumerable<Assembly> assemblies, string outputFolder)
//         {
//             Assemblies = assemblies;
//             OutputFolder = outputFolder;

//             var namespaceList = new List<string>();
//             Assemblies.ToList().ForEach(a => { namespaceList.AddRange(a.GetAllNamespaces()); });

//             Namespaces = namespaceList;
//         }

//         public void Compile()
//         {
//             // Exit method if the Namespaces property is empty.
//             if (!Namespaces.Any()) return;

//             Namespaces.ToList().ForEach(n => {
//                 var md = new MarkdownDocumentFile(Path.Combine(OutputFolder, n.Replace(".", "-") + ".md"), MarkdownDocumentFileType.Assembly)
//                     .SetTitle(string.Format("{0} Assembly", n));
//             });


//             // var props = type.GetProperties();

//             // if (props.Length == 0) 
//             // {
//             //     output.WriteLine("No Properties Exist.");
                
//             // }
//             // else
//             // {
//             //     props.ToList().ForEach(p => output.WriteLine("- {0} Property", p.Name));
//             // }
//         }
//     }
// }