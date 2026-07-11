using System;
using HtmlWinUI.Models.Entities;

namespace HtmlWinUI.Models.Details.Files
{
    public class Treatment : IEntityBase
    {
        public int PK { get; set; }
        public string SignedBy { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public ObjectState State { get; set; }
    }
}
