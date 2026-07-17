using System;
using HtmlWpf.Models.Entities;

namespace HtmlWpf.Models.Details.Files
{
    public class ReportingMethods : IEntityBase
    {
        public int PK { get; set; }
        public string ReportingMethod { get; set; } = string.Empty;
        public DateTime DateReported { get; set; } = DateTime.Now;
        public ObjectState State { get; set; }
    }
}
