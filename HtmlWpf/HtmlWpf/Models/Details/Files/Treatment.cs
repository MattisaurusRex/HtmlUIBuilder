using System;
using HtmlWpf.Models.Entities;

namespace HtmlWpf.Models.Details.Files
{
    public class Treatment : IEntityBase
    {
        public int PK { get; set; }
        public string SignedBy { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public ObjectState State { get; set; }
    }
}
