namespace HtmlWinUI.Models.Entities
{
    public interface IEntityBase
    {
        ObjectState State { get; set; }
        int PK { get; set; }
    }
}
