using Microsoft.Web.Administration;
using HtmlUI.Models.Entities;
using System.ComponentModel;

namespace HtmlUI.Models.Details.Files
{
    public class InfoOtherView : IEntityBase
    {
        public int PK { get; set; }
        [DisplayName("BarCode")]
        public string BarCode { get; set; } = string.Empty;
        [DisplayName("File ID")]
        public string FileId { get; set; } = string.Empty;
        [DisplayName("Patients Solicitor")]
        public string PatientsSolicitor { get; set; } = string.Empty;
        public string Venue { get; set; } = string.Empty;
        public ObjectState State { get; set; }

    }
}
