namespace HtmlWinUI.Models
{
    /// <summary>
    /// Schema for a metadata-driven form: Headings pairs [group heading, property name]
    /// describe which properties appear in which group, in order.
    /// </summary>
    public interface IFormBase
    {
        int HeadingsColumnsNo { get; set; }
        int FormColumnsPerHeading { get; set; }
        string[][] Headings { get; set; }
        string Type { get; set; }
    }
}
