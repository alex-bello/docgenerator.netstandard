using System.Collections.Generic;
using DocsGenerator.Internal.Files;

namespace DocsGenerator.Internal.XmlCodeComments
{
    public interface IXmlCodeComment
    {
         string Name { get; set; }

         XmlCodeCommentType CommentType { get; set; }

         string Summary { get; set; }

         Dictionary<string, string> Parameters { get; set; }
         
         string Returns { get; set; }
    }
}