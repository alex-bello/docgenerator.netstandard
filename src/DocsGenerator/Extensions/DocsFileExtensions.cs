using DocsGenerator.Generators;

namespace DocsGenerator.Extensions
{
    public static class DocsFileExtensions
    {
        public static DocsFile UseEngine(this DocsFile file, IFileGenerator generator)
        {
            file.FileGenerator = generator;
            return file;
        }
    }
}