using System;
using HtmlWpf.Models.Entities;

namespace HtmlWpf.Models.Notes
{
    public interface IEntityNote : IEntityBase
    {
        string AddedBy { get; set; }
        DateTime TimeStamp { get; set; }
        string CollectionNum { get; set; }
        string Quote { get; set; }
        string File { get; set; }
        string CIDNum { get; set; }
        string Prospect { get; set; }
        bool Alert { get; set; }
        string Text { get; set; }
    }
}
