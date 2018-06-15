using System;
using System.IO;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils;
using DocsGenerator.Markdown;
using System.Linq;
using DocsGenerator.Utils;
using DocsGenerator.Extensions;

namespace DocsGenerator
{
    class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                var app = new CommandLineApplication();

                app.HelpOption(inherited: true);
                var sourcePath = app.Argument("[source]", "The path of the source folder containing dlls to generate documentation for");
                var outputPath = app.Argument("[output]", "The path of the output folder where files will be generated.");
                var verbose = app.Option("-v|--verbose", "Flag to enable verbose logging.", CommandOptionType.NoValue);
                var projectName = app.Option<string>("-n|--name <NAME>", "The name of the project.", CommandOptionType.SingleValue);
            
                app.OnExecute(() =>
                {
                    var settings = new DocsProjectSettings()
                        .WithProjectName(projectName.Value())
                        .HasSource(sourcePath.Value)
                        .HasOutputFolder(outputPath.Value)
                        .UseMarkdown()
                        .UseVerboseLogging(verbose.HasValue());       

                    Console.WriteLine("Verbose Logging is {0}", verbose.HasValue());                 

                    var builder = new DocsProjectBuilder(settings)
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
                Console.WriteLine("Directory.Delete(settings.TempFolder, true);");
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
