namespace DocsGenerator.Internal.Files
{
    public class PropertyFileDefinition : FileDefinition
    {
        public PropertyFileDefinition(string fullName, string baseFileName, FileType fileType, string parentName) : base(fullName, baseFileName, fileType)
        {
            ParentName = parentName;
        }

        public string ParentName { get; set; }
    }
}