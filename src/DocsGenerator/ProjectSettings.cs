using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DocsGenerator.Internal.Files;
using DocsGenerator.Output;
using DocsGenerator.Output.Generators;

namespace DocsGenerator
{
    public class ProjectSettings
    {

    #region Properties

        public string AssembliesFolder { get; set; }
        
        public string NamespacesFolder { get; set; }

        public ICollection<IFileDefinition> FileDefinitions { get; set; } = new List<IFileDefinition>();
        
        public string ProjectName { get; set; }

        public ICollection<IOutputGenerator> OutputFormats { get; set; } = new List<IOutputGenerator>();
        
        public string SourcePath { get; set; }

        public string OutputFolder { get; set; }

        public string TempFolder { get; set; }

        public bool Verbose { get; set; } = false;
    
    #endregion

    #region Methods

        public ProjectSettings HasSource(string sourcePath)
        {
            // Set SourcePath to value provided
            SourcePath = sourcePath;
            return this;
        }

        public ProjectSettings HasOutputFolder(string outputFolder)
        {
             // Set OutputFolder to value provided
            OutputFolder = Path.GetFullPath(outputFolder);
            TempFolder = Path.GetFullPath(OutputFolder + string.Format("/~{0}".ToString(), Guid.NewGuid().ToString().ToLower().Replace("-", "")));
            AssembliesFolder = this.AssembliesFolder ?? Path.Combine(OutputFolder, @"_assemblies");
            NamespacesFolder = this.NamespacesFolder ?? Path.Combine(OutputFolder, @"_namespaces");

            return this;
        }

        public ProjectSettings UseVerboseLogging(bool isVerbose)
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
        public ProjectSettings WithProjectName(string projectName)
        {
            ProjectName = projectName;
            return this;
        }

    #endregion

    }
}