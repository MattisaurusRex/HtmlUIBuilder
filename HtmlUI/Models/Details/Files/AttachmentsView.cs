using Microsoft.Web.Administration;
using Mono.TextTemplating;
using HtmlUI.Models.Entities;
using System.ComponentModel;

namespace HtmlUI.Models.Details.Files
{
    public class AttachmentsView : IEntityBase
    {
        public int PK { get; set; }
        public ObjectState State { get; set; }
        [DisplayName("Attached By")]
        public string AttachedBy { get; set; } = string.Empty;
        [DisplayName("Date Attached")]
        public DateTime DateAttached { get; set; }
        public string Description { get; set; } = string.Empty;
        [DisplayName("Original File Name")]
        public string OriginalFileName { get; set; } = string.Empty;
        [DisplayName("Doc Ref")]
        public string DocRef { get; set; } = string.Empty;
        [DisplayName("Document Type")]
        public string[] DocumentType { get; set; } = new string[] { "" };
        [DisplayName("Num Pages")]
        public int NumPages { get; set; }
        [DisplayName("Qualitative Resut")]
        public string[] QualitativeResult { get; set; } = new string[] { "" };
        [DisplayName("Attach To WS")]
        public bool AttachToWS { get; set; } = false;
        [DisplayName("Order In WS")]
        public int OrderInWS { get; set; } = 0;
        public string Panel { get; set; } = string.Empty;
        public string Test { get; set; } = string.Empty;
        public string Analyte { get; set; } = string.Empty;
        public string Invoice { get; set; } = string.Empty;
        [DisplayName("Deliver Date")]
        public DateTime DelDate { get; set; }
        [DisplayName("Deliver By")]
        public string[] DelBy { get; set; } = new string[] { "" };

    }
}
