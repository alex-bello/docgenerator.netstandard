﻿using System;
using System.Runtime.InteropServices;
using McMaster.Extensions.CommandLineUtils;
using DocsGenerator.Tools;

namespace DocsGenerator
{
    class Program
    {
        public static int Main(string[] args)
        {
            CommandOption debug = null;

            // Console.WriteLine($"Runtime FrameworkDescription: {RuntimeInformation.FrameworkDescription}");
            // Console.WriteLine($"Runtime OSArchitecture: {RuntimeInformation.OSArchitecture}");
            // Console.WriteLine($"Runtime OSDescription: {RuntimeInformation.OSDescription}");
            // Console.WriteLine($"Runtime ProcessArchitecture: {RuntimeInformation.ProcessArchitecture}");

            try
            {
                var app = new CommandLineApplication();

                app.HelpOption(inherited: true);
                var sourcePath = app.Argument("[source]", "The path of the source folder containing dlls to generate documentation for");
                var outputPath = app.Argument("[output]", "The path of the output folder where files will be generated.");
                
                debug = app.Option("-d|--debug", "Flag to enable debug session, which does not delete temporary files.", CommandOptionType.NoValue);
                var outputFormatOptions = app.Option("-o|--output-format <FORMAT>", "Adds an output format for generating output.", CommandOptionType.MultipleValue);
                var projectName = app.Option<string>("-n|--name <NAME>", "The name of the project.", CommandOptionType.SingleValue);
                var verbose = app.Option("-v|--verbose", "Flag to enable verbose logging.", CommandOptionType.NoValue);
            
                app.OnExecute(() =>
                {
                    var formats = outputFormatOptions.Values;

                    var settings = new ProjectSettings()
                        .WithProjectName(projectName.Value())
                        .HasSource(sourcePath.Value)
                        .HasOutputFolder(outputPath.Value)
                        .UseVerboseLogging(verbose.HasValue());       

                    if (formats.Contains("markdown")) settings.UseMarkdown();
                    if (formats.Contains("html")) settings.UseHtml();

                    Console.WriteLine("Verbose Logging is {0}", verbose.HasValue());

                    var builder = new ProjectBuilder(settings)
                        .GenerateProject()
                        .Compile();

                    return 0;
                });

                return app.Execute(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 99;
            }
            finally
            {   
                if (!debug.HasValue())Console.WriteLine("Directory.Delete(settings.TempFolder, true);");
                //Directory.Delete(settings.TempFolder, true);
            }
        }

        internal static int HandleError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
            return 1;
        }
    }
}
