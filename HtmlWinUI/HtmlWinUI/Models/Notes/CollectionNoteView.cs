using System;
using HtmlWinUI.Models.Entities;

namespace HtmlWinUI.Models.Notes
{
    public class CollectionNoteView : IEntityNote
    {
        public int PK { get; set; }

        public string AddedBy { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; }
        public string CollectionNum { get; set; } = string.Empty;
        public string Quote { get; set; } = string.Empty;
        public string File { get; set; } = string.Empty;
        public string CIDNum { get; set; } = string.Empty;
        public string Prospect { get; set; } = string.Empty;
        public bool Alert { get; set; } = false;
        public string Text { get; set; } = string.Empty;

        public ObjectState State { get; set; }
    }
}
