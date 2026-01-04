using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HtmlUI.Models.Search
{
    public class FilesSearchModel : SearchBase
    {

        public override string Type { get; set; } = "Files";

        public string ID { get; set; }
        public string Barcode { get; set; } 
        public string Client { get; set; }
        [DisplayName("Section Number")]
        public string SectionNo { get; set; }
        [DisplayName("Section Status")]
        public string SectionStatus { get; set; }
        [DisplayName("Issue Number")]
        public string IssueNo { get; set; }
        [DisplayName("Case Reference")]
        public string CaseRef { get; set; }
        [DisplayName("Client Status")]
        public string[] ClientStatus { get; set; } = new string[] { "Active", "Ceased trading", "Created in error", "Changed name", "Moved address" };
        [DisplayName("File Result")]
        public string FileResult { get; set; }
        [DisplayName("Business Class")]
        public string BusinessClass { get; set; }
        public string Territory { get; set; }
        [DisplayName("Invoice ID")]
        public string InvoiceID { get; set; }
        [DisplayName("Without Invoice")]
        public bool WithoutInvoice { get; set; }
        [DisplayName("File From")]
        public DateTime FileFrom { get; set; }
        [DisplayName("File To")]
        public DateTime FileTo { get; set; }
        [DisplayName("Released From")]
        public DateTime ReleasedFrom { get; set; }
        [DisplayName("Released To")]
        public DateTime ReleasedTo { get; set; }
        [DisplayName("Received From")]
        public DateTime ReceivedFrom { get; set; }
        [DisplayName("Received To")]
        public DateTime ReceivedTo { get; set; }
        [DisplayName("Approved From")]
        public DateTime ApprovedFrom { get; set; }
        [DisplayName("Approved To")]
        public DateTime ApprovedTo { get; set; }
        [DisplayName("Reported From")]
        public DateTime ReportedFrom { get; set; }
        [DisplayName("Reported To")]
        public DateTime ReportedTo { get; set; }
        [DisplayName("Invoiced From")]
        public DateTime InvoicedFrom { get; set; }
        [DisplayName("Invoiced To")]
        public DateTime InvoicedTo { get; set; }
        [DisplayName("Patient Forename")]
        public string PatientForename { get; set; }
        [DisplayName("Patient Surname")]
        public string PatientSurname { get; set; }
        [DisplayName("Patient Gender")]
        public string PatientGender { get; set; }
        [DisplayName("Patient DOB")]
        public DateTime PatientDOB { get; set; }
        [DisplayName("Patient NI Number")]
        public string PatientNINumber { get; set; }
        [DisplayName("Patient Passport Number")]
        public string PatientPassportNumber { get; set; }
        [DisplayName("File Type")]
        public string FileType { get; set; }
        public string Collector { get; set; }
        [DisplayName("Test Purpose")]
        public string TestPurpose { get; set; }
        [DisplayName("File Colour")]
        public string FileColour { get; set; }
        public string Documentation { get; set; }
        public string Identification { get; set; }
        [DisplayName("Collection Status")]
        public string CollectionStatus { get; set; }
        public string Workflow { get; set; }
        [DisplayName("ID Type")]
        public string IDType { get; set; }
        public string SBC { get; set; }
        public bool Print { get; set; }

        //hardcoded list of headings with their prop names
        //store in sql as a view?
        //        SELECT *
        //        FROM INFORMATION_SCHEMA.COLUMNS
        //        WHERE TABLE_NAME = N'Collections'

        
        public override string[][] Headings { get; set; } = new string[][] { [ "Client", "ID" ], [ "Client", "Barcode" ], [ "Client", "Client" ], [ "Client", "SectionNo" ], [ "Client", "SectionStatus" ], [ "Client", "IssueNo" ], [ "Client", "CaseRef" ], [ "Client", "ClientStatus" ], [ "Client", "FileResult" ], [ "Client", "BusinessClass" ], [ "Client", "Territory" ], [ "Client", "InvoiceID" ], [ "Client", "WithoutInvoice" ],
  [ "Dates", "FileFrom" ], [ "Dates", "FileTo" ], [ "Dates", "ReceivedFrom" ], [ "Dates", "ReceivedTo" ], [ "Dates", "ReleasedFrom" ], [ "Dates", "ReleasedTo" ], [ "Dates", "ApprovedFrom" ], [ "Dates", "ApprovedTo" ], [ "Dates", "ReportedFrom" ], [ "Dates", "ReportedTo" ], [ "Dates", "InvoicedFrom" ], [ "Dates", "InvoicedTo" ],
  [ "Patient", "PatientForename" ], [ "Patient", "PatientSurname" ], [ "Patient", "PatientGender" ], [ "Patient", "PatientDOB" ], [ "Patient", "PatientNINumber" ], [ "Patient", "PatientPassportNumber" ],
  [ "Office", "FileType" ], [ "Office", "Collector" ], [ "Office", "TestPurpose" ], [ "Office", "FileColour" ], [ "Office", "Documentation" ], [ "Office", "Identification" ], [ "Office", "Status" ], [ "Office", "Print" ], [ "Office", "Workflow" ], [ "Office", "SBC" ], [ "Office", "IDType" ] };

        
    }
}
