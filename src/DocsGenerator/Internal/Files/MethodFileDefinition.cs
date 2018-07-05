namespace DocsGenerator.Internal.Files
{
    public class MethodFileDefinition : FileDefinition
    {
        public MethodFileDefinition(string fullName, string baseFileName, FileType fileType, string parentName) : base(fullName, baseFileName, fileType)
        {
            ParentName = parentName;
        }

        public string ParentName { get; set; }
    }
}