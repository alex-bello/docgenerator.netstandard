using DocsGenerator.Output;
using DocsGenerator.Output.Generators;

namespace DocsGenerator.Tools
{
    public static partial class ProjectSettingsTools
    {
        public static ProjectSettings UseMarkdown(this ProjectSettings settings)
        {
            settings.OutputFormats.Add(new MarkdownOutputGenerator());
            return settings;
        }

    }
}