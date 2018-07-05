
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using DocsGenerator.Extensions;
using DocsGenerator.Internal.XmlCodeComments;

namespace DocsGenerator.Tools
{
    public static partial class StaticTools
    {
        public static Project LoadXmlComments(this Project project)
        {
            project.LogVerbose("Loading compiled project xml comments...");
            var path = Path.Combine(project.Settings.TempFolder, project.EntryAssembly.GetSimpleName() + ".xml");
            project.LogVerbose($"Loading xml fie from: {path}");

            using (XmlReader reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        project.LogVerbose(reader.Name);

                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "member":
                                reader.MoveToFirstAttribute();
                                var content = reader.ReadContentAsString().Split(':');             
                                XmlCodeCommentType type = XmlCodeCommentType.Field;

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
                                } 

                                var comment = new XmlCodeComment(content[1], type);
                                project.Settings.XmlCodeComments.Add(comment);
                                
                                break;
                            case "article":
                                // Detect this article element.
                                Console.WriteLine("Start <article> element.");
                                // Search for the attribute name on this current node.
                                string attribute = reader["name"];
                                if (attribute != null)
                                {
                                    Console.WriteLine("  Has attribute name: " + attribute);
                                }
                                // Next read will contain text.
                                if (reader.Read())
                                {
                                    Console.WriteLine("  Text node: " + reader.Value.Trim());
                                }
                                break;
                        }
                    }
                }
            }

            // foreach (var file in Directory.EnumerateFiles(project.Settings.TempFolder, "*.dll"))
            // {
            //     try
            //     {
            //         project.LogVerbose($"Loading Assembly at {file}");
            //         var assembly = Assembly.LoadFrom(file);
            //         project.Assemblies.Add(assembly);
            //         Console.WriteLine($"{assembly.GetSimpleName()} Loaded from file {file}.");
            //     }
            //     catch (Exception ex) // This error is thrown for assemblies from nuget and so we load the dll directly.
            //     {
            //         project.LogVerbose($"Assembly not loaded.");
            //     }
            // }

            project.LogVerbose($"EntryAssembly SimpleName: {project.EntryAssembly.GetSimpleName()}");

            return project;
        }
    }
}