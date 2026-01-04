using Microsoft.Web.Administration;
using System.ComponentModel;

namespace HtmlUI.Models.Entities
{
    public class FileEntity : IEntityBase
    {
        public ObjectState State { get; set; }
        public int PK { get; set; }

        [DisplayName("Instruction Text")]
        public string InstructionText {get; set;}

        [DisplayName("File Type")]
        public string  FileTypeId {get; set;}
        
        public string Required {get; set;}

        [DisplayName("File Collected")]
        public string FileCollected {get; set;}

        [DisplayName("File Collection Status")]
        public string  FileCollectionStatusId {get; set;}

        [DisplayName("Photo Status")]
        public string PhotoStatusId {get; set;}

        [DisplayName("Status Reason")]
        public string StatusReason {get; set;}

        [DisplayName("File Source")]
        public string FileSource {get; set;} 
        public string FileColour {get; set;} 
        public string FilePackId {get; set;} 
        public string FileTestType {get; set;} 
        public string FileLengthInCm {get; set;} 
        public string FileQty { get; set; }
    }
}
