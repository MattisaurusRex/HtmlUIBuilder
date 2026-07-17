using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HtmlWpf.Models.Details.Files
{
    public class FileDetailProperties : IDetailTabItem
    {
        public int PK { get; set; }
        public int HeaderPK { get; set; }

        public string PageHeading { get; set; } = "Properties";
        public string Type { get; set; } = "File";
        public string IconType { get; set; } = "folder";
        public int FormColumnsPerHeading { get; set; } = 1;
        public int HeadingsColumnsNo { get; set; } = 3;
        [DisplayName("Date Of Collection")]
        public DateTime DateOfCollection { get; set; }

        public string[] Collector { get; set; } = new string[] { };
        [DisplayName("Collected By Us")]
        public bool CollectedByUs { get; set; } = false;
        [DisplayName("Reporting Methods")]
        public IEnumerable<ReportingMethods> ReportingMethods { get; set; } = new List<ReportingMethods> { new ReportingMethods() };
        public IEnumerable<Treatment> Treatments { get; set; } = new List<Treatment> { new Treatment() };
        [DisplayName("Signed By Collector")]
        public bool SignedByCollector { get; set; } = false;
        [DisplayName("Signed By Patient")]
        public bool SignedByPatient { get; set; } = false;
        [DisplayName("Seal Intact")]
        public bool SealIntact { get; set; } = false;
        public string[] Identification { get; set; } = new string[] { "" };
        [DisplayName("ID Type")]
        public string[] IDType { get; set; } = new string[] { "" };
        [DisplayName("Effective Type")]
        public string[] EffectiveType { get; set; } = new string[] { "" };
        [DisplayName("Folder Colour")]
        public string[] FolderColour { get; set; } = new string[] { "" };
        [DisplayName("Document Type")]
        public string[] DocumentType { get; set; } = new string[] { "" };
        [DisplayName("AB File")]
        public string[] ABFile { get; set; } = new string[] { "" };
        [DisplayName("Received Date")]
        public DateTime ReceivedDate { get; set; }
        [DisplayName("Testing Purpose")]
        public string[] TestingPurpose { get; set; } = new string[] { "" };
        [DisplayName("Received Pages")]
        public int ReceivedPages { get; set; }
        [DisplayName("Destruction Due")]
        public string DestructionDue { get; set; } = string.Empty;
        [DisplayName("Destruction Done")]
        public string DestructionDone { get; set; } = string.Empty;
        [DisplayName("Destroyed By")]
        public string[] DestroyedBy { get; set; } = new string[] { "" };
        [DisplayName("Destruction List ID")]
        public string DestructionListID { get; set; } = string.Empty;
        [DisplayName("Customer OS #")]
        public string CustomerOSNum { get; set; } = string.Empty;
        [DisplayName("Sub-Section")]
        public string[] SubSection { get; set; } = new string[] { "" };
        [DisplayName("Identification Method")]
        public string[] IdentificationMethod { get; set; } = new string[] { "" };

        public string[][] Headings { get; set; } = new string[][] { ["Collection", "DateOfCollection"], ["Collection", "Collector"], ["Collection", "CollectedByUs"],
        ["Reporting Methods", "ReportingMethods"],
        ["Treatments", "Treatments"],
        ["Checks", "SignedByCollector"], ["Checks", "SignedByPatient"], ["Checks", "SealIntact"],
        ["File Type", "Identification"], ["File Type", "IDType"], ["File Type", "EffectiveType"], ["File Type", "FolderColour"], ["File Type", "DocumentType"], ["File Type", "ABFile"],
        ["Other ", "ReceivedDate"], ["Other ", "TestingPurpose"], ["Other ", "ReceivedPages"], ["Other ", "DestructionDue"], ["Other ", "DestroyedBy"], ["Other ", "DestructionListID"],
        ["Customer OS # ", "CustomerOSNum"],
        ["Sub-Section ", "SubSection"],
        ["Identification Method ", "IdentificationMethod"]
        };
    }
}
