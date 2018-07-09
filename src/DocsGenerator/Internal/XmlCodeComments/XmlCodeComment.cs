using System.Collections.Generic;

namespace DocsGenerator.Internal.XmlCodeComments
{
    public class XmlCodeComment : IXmlCodeComment
    {
        public XmlCodeComment()
        {

        }

        public XmlCodeComment(string name, XmlCodeCommentType commentType, string summary = null, string returns = null)
        {
            FullName = name;
            CommentType = commentType;
            Summary = summary;
            Returns = returns;
        }

        public string FullName { get; set; }
        
        public XmlCodeCommentType CommentType { get; set; }
        
        public string Remarks { get; set; }

        public string Returns { get; set; }

        public string Summary { get; set; }        
        
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, string> TypeParameters { get; set; } = new Dictionary<string, string>();
    }
}