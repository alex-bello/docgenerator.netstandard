using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace DocsGenerator.Tools
{
    public static partial class StaticTools
    {
        public static Project CompileSourceProject(this Project project)
        {

            project.LogVerbose("Compiling source project...");
            string runtimeVersion = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "win10-x64" : RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "osx-x64" : "linux-x64";

            var command = $"dotnet publish {project.Settings.SourcePath} -o \"{project.Settings.TempFolder}\" -r {runtimeVersion} --self-contained --force";
            project.LogVerbose($"Compile Source Command: {command}");
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
            project.LogVerbose(cmd.StandardOutput.ReadToEnd());

            project.LogVerbose("Compiling source project complete.");

            return project;
        }
    }
}