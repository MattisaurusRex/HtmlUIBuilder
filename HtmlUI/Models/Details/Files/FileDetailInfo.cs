using System.ComponentModel;

namespace HtmlUI.Models.Details.Files
{
    public class FileDetailInfo : IDetailTabItem
    {
        public int PK { get; set; }
        public int HeaderPK { get; set; }

        public string PageHeading { get; set; } = "Info";

        public string Type { get; set; } = "File"; //gotten from schema name?
        public string iconType { get; set; } = "information";
        public int FormColumnsPerHeading { get; set; } = 1;
        public int HeadingsColumnsNo { get; set; } = 1;
        [DisplayName("Info Other")]
        public IEnumerable<InfoOtherView> InfoOther { get; set; } = new List<InfoOtherView>() { new InfoOtherView() };        
        [DisplayName("Overall Qualitative Result")]
        public string[] OverallQualitativeResult { get; set; } = new string[] { "" };
        [DisplayName("File Name Prefix")]
        public string[] FileNamePrefix { get; set; } = new string[] { "" };

        public string[][] Headings { get; set; } =
        new string[][] { ["", "InfoOther"], ["", "OverallQualitativeResult"], ["", "FileNamePrefix"] };


}
   
}
