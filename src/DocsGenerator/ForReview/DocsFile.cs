// using System;
// using System.IO;
// using DocsGenerator.Output.Generators;

// namespace DocsGenerator
// {
//     public class DocsFile
//     {
//         public IFileGenerator FileGenerator { get; set; }

//         public string FilePath { get; set; }
        
//         public FileType FileType { get; set; }

//         protected string Title { get; set; }

//         public DocsFile(string filePath, FileType fileType = FileType.Class, OutputFormat format = OutputFormat.Markdown)
//         {
//             FilePath = filePath;
//             FileType = fileType;
//         } 

//         public DocsFile SetTitle(string title)
//         {
//             Title = title;
//             return this;
//         }

//         protected internal virtual void Compile()
//         {
//             File.WriteAllLines(FilePath, FileGenerator.Generate().ToString().Split(Environment.NewLine, StringSplitOptions.None));          
//         }
//     }
// }