using System;
using System.Collections.Generic;

namespace DocsGenerator.Internal.Files
{
    public interface IFileDefinition
    {
        string BaseFileName { get; set; }
        
        string FullName { get; set; }

        FileType FileType { get; set; }

        string Title { get; set; }
    }
}