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

            foreach (var file in Directory.EnumerateFiles(project.Settings.TempFolder, "*.dll"))
            {
                try
                {
                    project.LogVerbose($"Loading Assembly at {file}");
                    var assembly = project.LoadAssemblyFromFile(file);
                    //project.Assemblies.Add(assembly);
                    Console.WriteLine($"{assembly.GetSimpleName()} Loaded from file {file}.");
                }
                catch  // This error is thrown for assemblies from nuget and so we load the dll directly.
                {
                    project.LogVerbose($"Assembly not loaded.");
                }
            }
                
            project.LogVerbose("Loading referenced assemblies complete...");
            project.LogVerbose($"{project.Assemblies.Count()} assemblies loaded.");

            return project;
        }
    }
}