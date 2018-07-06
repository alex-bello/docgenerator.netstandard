
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
                var content = x.Attributes().Where(a => a.Name.LocalName == "name").FirstOrDefault()?.Value.Split(':');
                XmlCodeCommentType type = XmlCodeCommentType.Field;
                
                // Get element name and switch on it.
                switch (content[0])
                {
                    case "T":
                        type = XmlCodeCommentType.Type;
                        break;
                    case "F":
                        type = XmlCodeCommentType.Field;
                        break;
                    case "P":
                        type = XmlCodeCommentType.Property;
                        break;
                    case "M":
                        type = XmlCodeCommentType.Method;
                        break;
                    case "E":
                        type = XmlCodeCommentType.Event;
                        break;
                    default:
                        type = XmlCodeCommentType.Unknown;
                        break;
                }

                var comment = new XmlCodeComment(content[1], type, x.Elements().Where(e => e.Name.LocalName == "summary").FirstOrDefault()?.Value.RemoveNewLines().TrimAll());
                project.Settings.XmlCodeComments.Add(comment); 
            }

            foreach (var xmlFile in project.Settings.XmlCodeComments)
            {
                project.LogVerbose($"XML File: {xmlFile.Name}, {xmlFile.CommentType.ToString()}, {xmlFile.Summary ?? "<null>"}");
            }

            return project;
        }
    }
}