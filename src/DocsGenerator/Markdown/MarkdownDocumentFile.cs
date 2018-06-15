// using System;
// using System.IO;

// namespace DocsGenerator.Markdown
// {
//     public class MarkdownDocumentFile
//     {
//         public string FilePath { get; set; }
        
//         public MarkdownDocumentFileType FileType { get; set; }

//         protected string Title { get; set; }

//         public MarkdownDocumentFile(string filePath, MarkdownDocumentFileType fileType = MarkdownDocumentFileType.Class)
//         {
//             FilePath = filePath;
//             FileType = fileType;
//         } 

//         protected internal virtual MarkdownDocumentFile SetTitle(string title)
//         {
//             Title = title;
//             // switch (FileType)
//             // {
//             //     case MarkdownDocumentFileType.Assembly:
//             //         Title = string.Format("{0} Assembly");
//             //         break;
//             //     default:
//             //         Title = "Default Title";
//             // }
//             return this;
//         }

//         protected internal virtual void Compile()
//         {
//             var output = new StringWriter();

//             output.WriteLine("# {0}", Title);
//             output.WriteLine();

//             switch (FileType)
//             {
//                 case MarkdownDocumentFileType.Assembly:
//                     output.WriteLine("## Namespaces in Assembly");
//                     output.WriteLine();
//                     break;
//             }

//             // output.WriteLine("| Name | Description |");
//             // output.WriteLine("| --- | --- |");
//             // Assemblies.ToList().ForEach(a => {
//             //     output.WriteLine("| [{0} Assembly]({1}) | Description |", a.FullName.Split(',').First(), a.FullName.Split(',').First().Replace(".", "-").ToLower() + ".md");
//             // });

//             // output.WriteLine();
//             // //dll.GetAllNamespaces().ToList().ForEach(a => output.WriteLine("[" + a + "](./namespaces/" + a.Replace(".", "-") + ".md)"));

//             File.WriteAllLines(FilePath, output.ToString().Split(Environment.NewLine, StringSplitOptions.None));
//             Console.WriteLine("{0} file created at {1}", FileType.ToString(), FilePath);
//         }
//     }
// }