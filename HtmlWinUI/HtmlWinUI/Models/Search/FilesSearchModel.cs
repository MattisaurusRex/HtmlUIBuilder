using System;
using System.ComponentModel;

namespace HtmlWinUI.Models.Search
{
    public class FilesSearchModel : SearchBase
    {
        public override string Type { get; set; } = "Files";

        public string ID { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public string Client { get; set; } = string.Empty;
        [DisplayName("Section Number")]
        public string SectionNo { get; set; } = string.Empty;
        [DisplayName("Section Status")]
        public string SectionStatus { get; set; } = string.Empty;
        [DisplayName("Issue Number")]
        public string IssueNo { get; set; } = string.Empty;
        [DisplayName("Case Reference")]
        public string CaseRef { get; set; } = string.Empty;
        [DisplayName("Client Status")]
        public string[] ClientStatus { get; set; } = new string[] { "Active", "Ceased trading", "Created in error", "Changed name", "Moved address" };
        [DisplayName("File Result")]
        public string FileResult { get; set; } = string.Empty;
        [DisplayName("Business Class")]
        public string BusinessClass { get; set; } = string.Empty;
        public string Territory { get; set; } = string.Empty;
        [DisplayName("Invoice ID")]
        public string InvoiceID { get; set; } = string.Empty;
        [DisplayName("Without Invoice")]
        public bool WithoutInvoice { get; set; }
        [DisplayName("File From")]
        public DateTime? FileFrom { get; set; }
        [DisplayName("File To")]
        public DateTime? FileTo { get; set; }
        [DisplayName("Released From")]
        public DateTime? ReleasedFrom { get; set; }
        [DisplayName("Released To")]
        public DateTime? ReleasedTo { get; set; }
        [DisplayName("Received From")]
        public DateTime? ReceivedFrom { get; set; }
        [DisplayName("Received To")]
        public DateTime? ReceivedTo { get; set; }
        [DisplayName("Approved From")]
        public DateTime? ApprovedFrom { get; set; }
        [DisplayName("Approved To")]
        public DateTime? ApprovedTo { get; set; }
        [DisplayName("Reported From")]
        public DateTime? ReportedFrom { get; set; }
        [DisplayName("Reported To")]
        public DateTime? ReportedTo { get; set; }
        [DisplayName("Invoiced From")]
        public DateTime? InvoicedFrom { get; set; }
        [DisplayName("Invoiced To")]
        public DateTime? InvoicedTo { get; set; }
        [DisplayName("Patient Forename")]
        public string PatientForename { get; set; } = string.Empty;
        [DisplayName("Patient Surname")]
        public string PatientSurname { get; set; } = string.Empty;
        [DisplayName("Patient Gender")]
        public string PatientGender { get; set; } = string.Empty;
        [DisplayName("Patient DOB")]
        public DateTime? PatientDOB { get; set; }
        [DisplayName("Patient NI Number")]
        public string PatientNINumber { get; set; } = string.Empty;
        [DisplayName("Patient Passport Number")]
        public string PatientPassportNumber { get; set; } = string.Empty;
        [DisplayName("File Type")]
        public string FileType { get; set; } = string.Empty;
        public string Collector { get; set; } = string.Empty;
        [DisplayName("Test Purpose")]
        public string TestPurpose { get; set; } = string.Empty;
        [DisplayName("File Colour")]
        public string FileColour { get; set; } = string.Empty;
        public string Documentation { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        [DisplayName("Collection Status")]
        public string CollectionStatus { get; set; } = string.Empty;
        public string Workflow { get; set; } = string.Empty;
        [DisplayName("ID Type")]
        public string IDType { get; set; } = string.Empty;
        public string SBC { get; set; } = string.Empty;
        public bool Print { get; set; }

        public override string[][] Headings { get; set; } = new string[][] { ["Client", "ID"], ["Client", "Barcode"], ["Client", "Client"], ["Client", "SectionNo"], ["Client", "SectionStatus"], ["Client", "IssueNo"], ["Client", "CaseRef"], ["Client", "ClientStatus"], ["Client", "FileResult"], ["Client", "BusinessClass"], ["Client", "Territory"], ["Client", "InvoiceID"], ["Client", "WithoutInvoice"],
          ["Dates", "FileFrom"], ["Dates", "FileTo"], ["Dates", "ReceivedFrom"], ["Dates", "ReceivedTo"], ["Dates", "ReleasedFrom"], ["Dates", "ReleasedTo"], ["Dates", "ApprovedFrom"], ["Dates", "ApprovedTo"], ["Dates", "ReportedFrom"], ["Dates", "ReportedTo"], ["Dates", "InvoicedFrom"], ["Dates", "InvoicedTo"],
          ["Patient", "PatientForename"], ["Patient", "PatientSurname"], ["Patient", "PatientGender"], ["Patient", "PatientDOB"], ["Patient", "PatientNINumber"], ["Patient", "PatientPassportNumber"],
          ["Office", "FileType"], ["Office", "Collector"], ["Office", "TestPurpose"], ["Office", "FileColour"], ["Office", "Documentation"], ["Office", "Identification"], ["Office", "CollectionStatus"], ["Office", "Print"], ["Office", "Workflow"], ["Office", "SBC"], ["Office", "IDType"] };
    }
}
