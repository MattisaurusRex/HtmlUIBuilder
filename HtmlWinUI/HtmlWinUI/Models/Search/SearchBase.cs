namespace HtmlWinUI.Models.Search
{
    public abstract class SearchBase : IFormBase
    {
        public abstract string Type { get; set; }
        public abstract string[][] Headings { get; set; }
        public int FormColumnsPerHeading { get; set; } = 3;
        public int HeadingsColumnsNo { get; set; } = 3;
    }
}
