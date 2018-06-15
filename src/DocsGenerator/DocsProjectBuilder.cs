using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DocsGenerator.Extensions;

namespace DocsGenerator
{
    public class DocsProjectBuilder
    {
    
    #region Constructors

        public DocsProjectBuilder(DocsProjectSettings settings)
        {
            Settings = settings;
        }

    #endregion

    #region Properties

        public DocsProjectSettings Settings { get; }

        public DocsProject Project { get; set; }

    #endregion

    #region Methods

        public DocsProject GenerateProject()
        {
            return new DocsProject(Settings);
        }

    #endregion
    }
}