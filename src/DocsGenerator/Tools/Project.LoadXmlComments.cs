
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using DocsGenerator.Extensions;
using DocsGenerator.Internal.XmlCodeComments;
using DocsGenerator.Utils;

namespace DocsGenerator.Tools
{
    public static partial class StaticTools
    {
        public static Project LoadXmlComments(this Project project)
        {
            project.LogVerbose("Loading compiled project xml comments...");
            var path = Path.Combine(project.Settings.TempFolder, project.EntryAssembly.GetSimpleName() + ".xml");
            project.LogVerbose($"Loading xml file from: {path}");
            XDocument doc = XDocument.Load(path);

            foreach( var x  in doc.Descendants().Where(d => d.Name.LocalName == "member"))
            {              
                project.Settings.XmlCodeComments.Add(x.ToXmlCodeComment()); 
            }

            foreach (var xmlFile in project.Settings.XmlCodeComments)
            {
                project.LogVerbose($"XML File: {xmlFile.FullName}, {xmlFile.CommentType.ToString()}, {xmlFile.Summary ?? "<null>"}, {xmlFile.Remarks ?? "<null>"}");
            }

            return project;
        }
    }
}