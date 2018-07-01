using System.Reflection;

namespace DocsGenerator
{
    public class DocsAssembly
    {
        public Assembly Assembly { get; set; }

        public bool IsEntryAssembly { get; set; } = false;
    }
}