using DocsGenerator.Output;
using DocsGenerator.Output.Generators;

namespace DocsGenerator.Tools
{
    public static partial class ProjectSettingsTools
    {
        public static ProjectSettings UseHtml(this ProjectSettings settings)
        {
            settings.OutputFormats.Add(new HtmlOutputGenerator());
            return settings;
        }

    }
}