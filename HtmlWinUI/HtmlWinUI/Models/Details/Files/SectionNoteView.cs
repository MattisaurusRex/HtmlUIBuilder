using System;
using HtmlWinUI.Models.Entities;

namespace HtmlWinUI.Models.Details.Files
{
    public class SectionNoteView : IEntityBase
    {
        public int PK { get; set; }

        public string Note { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public ObjectState State { get; set; }
    }
}
