namespace DocsGenerator.Tools
{
    public class GenerateOutputFiles
    {
        // foreach(var outputFormat in project.Settings.OutputFormats)
        // {
        //     project.Settings.FileDefinitions.Add(new IndexFileDefinition());
        //     var filename = Path.Combine(project.Settings.OutputFolder, $"index.{outputFormat.FileExtension}");
        //     // var file = new DocsFile(filename, FileType.Index, OutputFormat.Markdown)
        //     //     .SetTitle(project.Settings.ProjectName)
        //     //     .UseEngine(new IndexFileGenerator(project.AssemblyContext.GetAssemblies(), project.Settings));
        //     //     //.Compile();
            
        //     // file.Compile();

        //     //dll.GetAllNamespaces().ToList().ForEach(a => output.WriteLine("[" + a + "](./namespaces/" + a.Replace(".", "-") + ".md)"));
        //     // File.WriteAllLines(filename, output.ToString().Split(Environment.NewLine, StringSplitOptions.None));
        //     project.LogVerbose($"Index file created at {filename}");
        // }
    }
}