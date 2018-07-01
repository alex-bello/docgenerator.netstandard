using System.IO;

namespace DocsGenerator.Tools
{
    public static partial class StaticTools
    {
        public static Project PrepareOutputFolder(this Project project)
        {
            // Wipe existing output folder
            project.LogVerbose("Removing output folder if exists...");
            if (Directory.Exists(project.Settings.OutputFolder)) Directory.Delete(project.Settings.OutputFolder, true);
            project.LogVerbose("Removing output folder complete.");

            // Create, validate, and log new output folder
            project.LogVerbose("Creating new output folder...");
            Directory.CreateDirectory(project.Settings.OutputFolder);
            project.ValidateFolder(project.Settings.OutputFolder);
            project.LogVerbose("Creating new output folder complete.");

            return project;
        }
    }
}