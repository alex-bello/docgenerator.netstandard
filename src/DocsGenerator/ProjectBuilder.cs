using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DocsGenerator.Extensions;

namespace DocsGenerator
{
    public class ProjectBuilder
    {
    
    #region Constructors

        public ProjectBuilder(ProjectSettings settings)
        {
            Settings = settings;
        }

    #endregion

    #region Properties

        public ProjectSettings Settings { get; }

        public Project Project { get; set; }

    #endregion

    #region Methods

        public Project GenerateProject()
        {
            return new Project(Settings);
        }

    #endregion
    }
}