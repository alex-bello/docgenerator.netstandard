namespace DocsGenerator.Internal.Files
{
    public abstract class FileDefinition : IFileDefinition
    {
        public FileDefinition(string fullName, string baseFileName, FileType fileType)
        {
            FullName = fullName;
            BaseFileName = baseFileName;
            FileType = fileType;
        }

        public string BaseFileName { get; set; }

        public string FullName { get; set; }

        public FileType FileType { get; set; }

        public string Title { get; set; }
    }
}