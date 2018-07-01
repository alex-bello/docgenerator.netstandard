using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DocsGenerator.Internal.Files.Generators
{
    public interface IFileGenerator
    {
        StringWriter Generate();
    }
}