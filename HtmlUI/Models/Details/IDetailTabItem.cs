namespace HtmlUI.Models.Details
{
    public interface IDetailTabItem : IFormBase
    {
        int PK { get; set; }
        int HeaderPK { get; set; }
        string PageHeading { get; set; }
        string Type { get; set; } //gotten from schema name?
        string iconType { get; set; }
    }
}
