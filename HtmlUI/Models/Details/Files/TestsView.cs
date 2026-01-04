using Microsoft.Web.Administration;
using HtmlUI.Models.Entities;

namespace HtmlUI.Models.Details.Files
{
    public class TestsView : IEntityBase
    {
        public ObjectState State { get; set; }
        public int PK { get; set; }
        public string Test { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public string Panel { get; set; } = string.Empty;
        public string Analytics { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public string QualityCheck { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Notepad { get; set; } = string.Empty;
        public string ALDT { get; set; } = string.Empty;
        public float Printed { get; set; }
        public string SBC { get; set; } = string.Empty;
        public int Offset { get; set; }
        public string Worksheet { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Reportable { get; set; } = string.Empty;
        public string ApprovedBy { get; set; } = string.Empty;
        public DateTime ApprovedDate { get; set; }
        public string LowLimit { get; set; } = string.Empty;
        public string HighLimit { get; set; } = string.Empty;
        public string BatchID { get; set; } = string.Empty;
        public string ExactResult { get; set; } = string.Empty;
    }
}
