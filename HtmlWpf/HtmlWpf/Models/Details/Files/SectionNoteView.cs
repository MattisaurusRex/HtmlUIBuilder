using System;
using HtmlWpf.Models.Entities;

namespace HtmlWpf.Models.Details.Files
{
    public class SectionNoteView : IEntityBase
    {
        public int PK { get; set; }

        public string Note { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public ObjectState State { get; set; }
    }
}
