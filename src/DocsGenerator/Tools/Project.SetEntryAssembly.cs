using System.IO;
using System.Reflection;

namespace DocsGenerator.Tools
{
    public static partial class StaticTools
    {
        public static Project SetEntryAssembly(this Project project)
        {
            // Load dlls from TempFolder and log if verbose enabled
            project.LogVerbose("Setting project entry assembly...");
            project.EntryAssembly = project.LoadFromAssemblyPath(Path.Combine(project.Settings.TempFolder, Path.GetFileNameWithoutExtension(project.Settings.SourcePath) + ".dll"));
            project.LogVerbose("Setting project entry assembly complete.");

            return project;
        }
    }
}