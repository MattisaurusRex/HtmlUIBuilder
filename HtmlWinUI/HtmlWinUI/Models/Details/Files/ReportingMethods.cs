using System;
using HtmlWinUI.Models.Entities;

namespace HtmlWinUI.Models.Details.Files
{
    public class ReportingMethods : IEntityBase
    {
        public int PK { get; set; }
        public string ReportingMethod { get; set; } = string.Empty;
        public DateTime DateReported { get; set; } = DateTime.Now;
        public ObjectState State { get; set; }
    }
}
