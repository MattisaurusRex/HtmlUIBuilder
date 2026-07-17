using System.ComponentModel;

namespace HtmlWpf.Models.Entities
{
    public class FileEntity : IEntityBase
    {
        public ObjectState State { get; set; }
        public int PK { get; set; }

        [DisplayName("Instruction Text")]
        public string InstructionText { get; set; } = string.Empty;

        [DisplayName("File Type")]
        public string FileTypeId { get; set; } = string.Empty;

        public string Required { get; set; } = string.Empty;

        [DisplayName("File Collected")]
        public string FileCollected { get; set; } = string.Empty;

        [DisplayName("File Collection Status")]
        public string FileCollectionStatusId { get; set; } = string.Empty;

        [DisplayName("Photo Status")]
        public string PhotoStatusId { get; set; } = string.Empty;

        [DisplayName("Status Reason")]
        public string StatusReason { get; set; } = string.Empty;

        [DisplayName("File Source")]
        public string FileSource { get; set; } = string.Empty;
        public string FileColour { get; set; } = string.Empty;
        public string FilePackId { get; set; } = string.Empty;
        public string FileTestType { get; set; } = string.Empty;
        public string FileLengthInCm { get; set; } = string.Empty;
        public string FileQty { get; set; } = string.Empty;
    }
}
