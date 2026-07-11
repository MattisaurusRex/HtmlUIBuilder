using System;
using System.ComponentModel;
using HtmlWinUI.Models.Entities;

namespace HtmlWinUI.Models.Details.Files
{
    public class SectionView : IEntityBase
    {
        public int PK { get; set; }

        public string SectionID { get; set; } = string.Empty;
        public string WF { get; set; } = string.Empty;
        [DisplayName("Filing Instruction")]
        public string FilingInstruction { get; set; } = string.Empty;
        [DisplayName("Length From")]
        public string LengthFrom { get; set; } = string.Empty;
        [DisplayName("Length To")]
        public string LengthTo { get; set; } = string.Empty;
        [DisplayName("Date From")]
        public string DateFrom { get; set; } = string.Empty;
        [DisplayName("Date To")]
        public string DateTo { get; set; } = string.Empty;
        [DisplayName("Folder Weight")]
        public int FolderWeight { get; set; }
        [DisplayName("Net Size")]
        public int NetSize { get; set; }
        [DisplayName("Exact Size")]
        public int ExactSize { get; set; }
        [DisplayName("WI Num")]
        public int WINum { get; set; }
        public DateTime WICompleted { get; set; }
        public int Position { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Deleted { get; set; } = string.Empty;
        public DateTime FilingDate { get; set; }
        public int VolumeNum { get; set; }
        public int VolID { get; set; }
        public int CF { get; set; }
        public int BalanceID { get; set; }
        public string ApprovedBy { get; set; } = string.Empty;
        public int Issue { get; set; }
        public DateTime ApprovedDate { get; set; }
        public DateTime DateReleased { get; set; }
        public int SBC { get; set; }
        public DateTime DateReported { get; set; }
        public string ReportedBy { get; set; } = string.Empty;
        public int Invoice { get; set; }
        public string CofFType { get; set; } = string.Empty;
        public string Parent { get; set; } = string.Empty;
        public string IsPrinting { get; set; } = string.Empty;
        public string IncludeInWI { get; set; } = string.Empty;
        public bool AutoApproved { get; set; } = false;
        public bool NeedsVersionIncrement { get; set; } = false;
        public ObjectState State { get; set; }
    }
}
