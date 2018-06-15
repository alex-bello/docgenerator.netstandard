using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using DocsGenerator.Extensions;
using DocsGenerator.Generators;

namespace DocsGenerator
{
    public class DocsProject
    {

    #region Constructors
    
        public DocsProject(DocsProjectSettings settings)
        {
            Settings = settings;
            LogVerbose("Project Created...");
            typeof(DocsProjectSettings).GetProperties().ToList().ForEach( x => Console.WriteLine($"{x.Name}: {x.GetValue(this.Settings)}"));
        }

    #endregion

    #region Properties

        public IFileGenerator Engine { get; set; }

        protected internal ICollection<Assembly> Assemblies { get; set; } = new List<Assembly>();

        public DocsProjectSettings Settings { get; }

    #endregion

    #region Methods

        protected internal void LogVerbose(string message)
        {
            if (Settings.Verbose) Console.WriteLine(message);
        }

        protected internal void ValidateFolder(string path)
        {
            if (!Directory.Exists(path)) throw new DirectoryNotFoundException();
        }

        public int Compile() 
        {
            this
            .PrepareOutputFolder()
            .CompileProject()
            .LoadAssemblies()            
            .GenerateIndexFile() // Generate the project's index file
            .GenerateAssemblyFiles();

            return 0;
        }

        public DocsProject PrepareOutputFolder()
        {            
            // Wipe existing output folder
            LogVerbose("Removing output folder if exists...");
            Directory.Delete(Settings.OutputFolder, true);
            LogVerbose("Removing output folder complete.");

            // Create, validate, and log new output folder
            LogVerbose("Creating new output folder...");
            Directory.CreateDirectory(Settings.OutputFolder);
            ValidateFolder(Settings.OutputFolder);
            LogVerbose("Creating new output folder complete.");

            // // Create, validate, and log temp folder
            // LogVerbose("Creating temporary folder...");
            // Directory.CreateDirectory(Settings.TempFolder);
            // ValidateFolder(Settings.TempFolder);
            // LogVerbose("Creating temporary folder complete.");

            return this;
        }

        public DocsProject CompileProject()
        {
            var command = $"dotnet publish {Settings.SourcePath} -o \"{Settings.TempFolder}\" --self-contained --force";
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(command);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

            return this;
        }

        public DocsProject LoadAssemblies()
        {
            // Load dlls from TempFolder and log if verbose enabled
            LogVerbose("Loading Assemblies...");

            Assemblies.Add(Assembly.LoadFile(Path.Combine(Settings.TempFolder, Path.GetFileNameWithoutExtension(Settings.SourcePath) + ".dll")));

            // Directory.EnumerateFiles(Settings.TempFolder, "*.dll").ToList().ForEach(f => {
            //     Assemblies.Add(Assembly.LoadFile(Path.GetFullPath(f)));
            //     LogVerbose($"File {Path.GetFullPath(f)} added to assemblies enumerable.");
            // });

            LogVerbose($"{Assemblies.Count()} assemblies in enumerable");
            LogVerbose("Loading source dlls complete.");

            return this;
        }
        
        internal DocsProject GenerateIndexFile()
        {
            // Throw error if no assemblies in Assemblies property.
            if (!Assemblies.Any()) throw new ArgumentException("Assemblies property must contain at least one Assembly to document.");

            var filename = Path.Combine(Settings.OutputFolder, "index.md");
            var file = new DocsFile(filename, DocsFileType.Index, DocsProjectOutputFormat.Markdown)
                .SetTitle(Settings.ProjectName)
                .UseEngine(new IndexFileGenerator(Assemblies, Settings));
                //.Compile();
            
            file.Compile();

            //dll.GetAllNamespaces().ToList().ForEach(a => output.WriteLine("[" + a + "](./namespaces/" + a.Replace(".", "-") + ".md)"));
            // File.WriteAllLines(filename, output.ToString().Split(Environment.NewLine, StringSplitOptions.None));
            LogVerbose($"Index file created at {filename}");

            return this;
        }

        internal DocsProject GenerateAssemblyFiles()
        {
            if (!Assemblies.Any()) throw new ArgumentException("Assemblies property must contain at least one Assembly to document.");

            // Create, validate, and log assemblies folder
            LogVerbose($"Creating {Settings.AssembliesFolder} folder...");
            Directory.CreateDirectory(Settings.AssembliesFolder);
            ValidateFolder(Settings.TempFolder);
            LogVerbose($"Creating {Settings.AssembliesFolder} folder complete.");

            Assemblies.ToList().ForEach(a => {
                    var outfile = Path.Combine(Settings.AssembliesFolder, a.ToFileName() + ".md");
                    var file = new DocsFile(outfile, DocsFileType.Assembly, DocsProjectOutputFormat.Markdown)
                        .SetTitle(a.GetSimpleName())
                        .UseEngine(new AssemblyFileGenerator(a, Settings, a.GetSimpleName()));
                        //.Compile();
                    
                    file.Compile();
                    Console.WriteLine($"Assembly file created for {a.GetSimpleName()} at {outfile}");
                });

            return this;
        }

    #endregion

    }
}