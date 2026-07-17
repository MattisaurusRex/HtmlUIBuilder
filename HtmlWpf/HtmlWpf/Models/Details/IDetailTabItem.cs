namespace HtmlWpf.Models.Details
{
    public interface IDetailTabItem : IFormBase
    {
        int PK { get; set; }
        int HeaderPK { get; set; }
        string PageHeading { get; set; }
        string IconType { get; set; }
    }
}
