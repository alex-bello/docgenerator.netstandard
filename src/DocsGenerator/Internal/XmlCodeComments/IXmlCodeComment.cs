using System.Collections.Generic;
using DocsGenerator.Internal.Files;

namespace DocsGenerator.Internal.XmlCodeComments
{
    public interface IXmlCodeComment
    {
        string FullName { get; set; }

        XmlCodeCommentType CommentType { get; set; }

        string Remarks { get; set; }

        string Returns { get; set; }

        string Summary { get; set; }

        Dictionary<string, string> Parameters { get; set; }

        Dictionary<string, string> TypeParameters { get; set; }
    }
}