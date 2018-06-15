using System;
using System.IO;

namespace DocsGenerator
{
    public class DocsProjectSettings
    {

    #region Properties

        public string AssembliesFolder { get; set; }
        
        public string NamespacesFolder { get; set; }
        
        public string ProjectName { get; set; }

        public DocsProjectOutputFormat Format { get; set; }
        
        public string SourcePath { get; set; }

        public string OutputFolder { get; set; }

        public string TempFolder { get; set; }

        public bool Verbose { get; set; } = false;
    
    #endregion

    #region Methods

        public DocsProjectSettings HasSource(string sourcePath)
        {
            // Set SourcePath to value provided
            SourcePath = sourcePath;
            return this;
        }

        public DocsProjectSettings HasOutputFolder(string outputFolder)
        {
             // Set OutputFolder to value provided
            OutputFolder = Path.GetFullPath(outputFolder);
            TempFolder = Path.GetFullPath(OutputFolder + string.Format("/~{0}".ToString(), Guid.NewGuid().ToString().ToLower().Replace("-", "")));
            AssembliesFolder = this.AssembliesFolder ?? Path.Combine(OutputFolder, @"_assemblies");
            NamespacesFolder = this.NamespacesFolder ?? Path.Combine(OutputFolder, @"_namespaces");

            return this;
        }

        public DocsProjectSettings UseVerboseLogging(bool isVerbose)
        {
            Verbose = isVerbose;
            //settings.LogVerbose(string.Format("Verbose logging enabled"));
            return this;
        }

        /// <summary>
        /// Fluent API Method to set the name of the DocsProject.
        /// </summary>
        /// <param name="projectName">The name of the project</param>
        /// <returns>The </returns>
        public DocsProjectSettings WithProjectName(string projectName)
        {
            ProjectName = projectName;
            return this;
        }

        public DocsProjectSettings SetOutputFormat(DocsProjectOutputFormat format)
        {
            Format = format;
            return this;
        }

    #endregion
    }
}