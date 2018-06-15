namespace DocsGenerator.Extensions
{
    public static class DocsProjectSettingsExtensions
    {
        public static DocsProjectSettings UseMarkdown(this DocsProjectSettings settings)
        {
            return settings.SetOutputFormat(DocsProjectOutputFormat.Markdown);
        }

    }
}