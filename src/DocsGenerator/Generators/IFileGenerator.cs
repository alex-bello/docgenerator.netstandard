using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DocsGenerator.Generators
{
    public interface IFileGenerator
    {
        StringWriter Generate();
    }
}