using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using DocsGenerator.Internal.XmlCodeComments;

namespace DocsGenerator.Utils
{
    /// <summary>
    /// Removes all newline characters from string.
    /// </summary>
    public static partial class XElementExtensions 
    {
        public static XmlCodeComment ToXmlCodeComment(this XElement element)
        {
            var codeComment = new XmlCodeComment();

            var name = element.Attributes().Where(a => a.Name.LocalName == "name").FirstOrDefault()?.Value.Split(':');
            codeComment.Name = name[1];
                
                // Get element name and switch on it.
            switch (name[0])
            {
                case "T":
                    codeComment.CommentType = XmlCodeCommentType.Type;
                    break;
                case "F":
                    codeComment.CommentType = XmlCodeCommentType.Field;
                    break;
                case "P":
                    codeComment.CommentType = XmlCodeCommentType.Property;
                    break;
                case "M":
                    codeComment.CommentType = XmlCodeCommentType.Method;
                    break;
                case "E":
                    codeComment.CommentType = XmlCodeCommentType.Event;
                    break;
                default:
                    codeComment.CommentType = XmlCodeCommentType.Unknown;
                    break;
            }

            codeComment.Remarks = element.Elements().Where(e => e.Name.LocalName == "remarks").FirstOrDefault()?.Value.RemoveNewLines().TrimAll();
            codeComment.Returns = element.Elements().Where(e => e.Name.LocalName == "returns").FirstOrDefault()?.Value.RemoveNewLines().TrimAll();
            codeComment.Summary = element.Elements().Where(e => e.Name.LocalName == "summary").FirstOrDefault()?.Value.RemoveNewLines().TrimAll();

            // TODO: Create list from linq extension methods
            // Use a foreach loop to add parameters
            element.Elements().Where(e => e.Name.LocalName == "param").ToList().ForEach(x => codeComment.Parameters.Add(x.FirstAttribute.Value, x.Value));

            // TODO: Create list from linq extension methods
            // Use a foreach loop to add parameters
            element.Elements().Where(e => e.Name.LocalName == "typeparam").ToList().ForEach(x => codeComment.TypeParameters.Add(x.FirstAttribute.Value, x.Value));

            return codeComment;
        }
    }
}