using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using DocsGenerator.Extensions;

namespace DocsGenerator.Tools
{
    public static partial class StaticTools
    {
        public static Project LoadReferencedAssemblies(this Project project)
        {
            project.LogVerbose("Loading referenced assemblies...");
            // project.EntryAssembly.GetReferencedAssemblies().ToList().ForEach(ra => {
            foreach (var file in Directory.EnumerateFiles(project.Settings.TempFolder, "*.dll"))
            {
                try
                {
                    project.LogVerbose($"Loading Assembly at {file}");
                    var assembly = Assembly.LoadFrom(file);
                    project.Assemblies.Add(assembly);
                    Console.WriteLine($"{assembly.GetSimpleName()} Loaded from file {file}.");
                }

                // Try loading all assemblies from project folder since we compiled self-contained version of application.
                // var filename = Path.Combine(project.Settings.TempFolder, ra.FullName.Split(',').First() + ".dll");
                // Assembly.LoadFrom(filename);
                // Console.WriteLine($"{ra.GetSimpleName()} Loaded from file {filename}.");
                // Assembly.Load(ra.FullName);
                // Console.WriteLine($"{ra.FullName} Loaded.");
                catch (Exception ex) // This error is thrown for assemblies from nuget and so we load the dll directly.
                {
                    project.LogVerbose($"Assembly not loaded.");
                }
            }
                
            // });
            project.LogVerbose("Loading referenced assemblies complete...");
            project.LogVerbose($"{project.Assemblies.Count()} assemblies loaded.");

            return project;
        }
    }
}