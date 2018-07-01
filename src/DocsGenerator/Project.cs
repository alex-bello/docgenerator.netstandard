using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using DocsGenerator.Extensions;
using DocsGenerator.Internal.Files;
using DocsGenerator.Output;
using DocsGenerator.Tools;

namespace DocsGenerator
{
    public class Project
    {

    #region Constructors
    
        public Project(ProjectSettings settings)
        {
            Settings = settings;
            LogVerbose("Project Created...");
            typeof(ProjectSettings).GetProperties().ToList().ForEach( x => LogVerbose($"{x.Name}: {x.GetValue(this.Settings)}"));
        }

    #endregion

    #region Properties

        protected internal ICollection<Assembly> Assemblies { get; set; } = new List<Assembly>();

        protected internal Assembly EntryAssembly { get; set; }

        //protected internal ICollection<AssemblyDocsFileInfo> AssemblyDocsFileInfos { get; set; } = new List<AssemblyDocsFileInfo>();

        public ProjectSettings Settings { get; }

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
            .CompileSourceProject()
            .SetEntryAssembly()
            .LoadReferencedAssemblies();
            // .GenerateIndexFiles(); // Generate the project's index file
            //.GenerateAssemblyFiles();

            return 0;
        }

        internal Project PopulateFileData()
        {
            if (!Assemblies.Any()) throw new ArgumentException("Assemblies property must contain at least one Assembly to document.");

            var assembly = Assembly.LoadFile(Path.Combine(Settings.TempFolder, Path.GetFileNameWithoutExtension(Settings.SourcePath) + ".dll"));
            
            // Assemblies.ToList().ForEach(a => {
            //     //var outfile = Path.Combine(Settings.AssembliesFolder, a.ToFileName() + ".md");
            //     AssemblyDocsFileInfos.Add(new AssemblyDocsFileInfo { 
            //         FullName = a.FullName,
            //         ExportedTypes = a.GetUserTypes()
            //     });
                // var file = new AssemblyDocsFileInfo(outfile, DocsFileType.Assembly, OutputFormat.Markdown)
                //     .SetTitle(a.GetSimpleName())
                //     .UseEngine(new AssemblyFileGenerator(a, Settings, a.GetSimpleName()));
                    //.Compile();
                
                // file.Compile();
                // Console.WriteLine($"Assembly file created for {a.GetSimpleName()} at {outfile}");
            // });

            assembly.GetReferencedAssemblies().ToList().ForEach(ra => {
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

            // AssemblyDocsFileInfos.Add(Mapper.Map<AssemblyDocsFileInfo>(assembly));

            return this;
        }
        
        // internal Project GenerateAssemblyFiles()
        // {
        //     if (!Assemblies.Any()) throw new ArgumentException("Assemblies property must contain at least one Assembly to document.");

        //     // Create, validate, and log assemblies folder
        //     LogVerbose($"Creating {Settings.AssembliesFolder} folder...");
        //     Directory.CreateDirectory(Settings.AssembliesFolder);
        //     ValidateFolder(Settings.TempFolder);
        //     LogVerbose($"Creating {Settings.AssembliesFolder} folder complete.");

        //     Assemblies.ToList().ForEach(a => {
        //             var outfile = Path.Combine(Settings.AssembliesFolder, a.ToFileName() + ".md");
        //             var file = new DocsFile(outfile, FileType.Assembly, OutputFormat.Markdown)
        //                 .SetTitle(a.GetSimpleName())
        //                 .UseEngine(new AssemblyFileGenerator(a, Settings, a.GetSimpleName()));
        //                 //.Compile();
                    
        //             file.Compile();
        //             Console.WriteLine($"Assembly file created for {a.GetSimpleName()} at {outfile}");
        //         });

        //     return this;
        // }

    #endregion

    }
}