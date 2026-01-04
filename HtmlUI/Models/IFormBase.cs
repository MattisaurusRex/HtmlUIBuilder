namespace HtmlUI.Models
{
    public interface IFormBase
    {
        int HeadingsColumnsNo { get; set; }
        int FormColumnsPerHeading { get; set; }
        string[][] Headings { get; set; }
        string Type { get; set; }
    }
}
