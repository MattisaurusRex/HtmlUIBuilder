using HtmlWpf.Models.Entities;

namespace HtmlWpf.Models.Details.Files
{
    public class Customer : IEntityBase
    {
        public int PK { get; set; }
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool COfA { get; set; } = false;
        public ObjectState State { get; set; }
    }
}
