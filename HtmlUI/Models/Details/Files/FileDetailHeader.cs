using HtmlUI.Models.Buttons;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HtmlUI.Models.Details.Files
{
    public class FileDetailHeader : IDetailHeader
    {
        public int PK { get; set; }
        public int EntityID { get; set; }
        [DisplayName("Entity Type")]
        public string EntityType { get; set; } = "File"; //gotten from schema name?
        [DisplayName("Detail Tab Items")]
        public IEnumerable<IDetailTabItem> DetailTabItems { get; set; } = new List<IDetailTabItem>() { 
            new FileDetailCustomer(),
            new FileDetailProperties(),
            new FileDetailPatient(),
            new FileDetailSections(),
            new FileDetailMedications(),
            new FileDetailTools(),
            new FileDetailNotes(),
            new FileDetailInfo(),
            new FileDetailAttachments()
        };
        [DisplayName("File Barcode")]
        public string FileBarcode { get; set; } = string.Empty;
        public ButtonRow RelatedFilesBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Related Files","Related Files","","Blue",""),
            },
            ButtonType = "Header"
        };
        //[DisplayName("Related Files (Button)")]
        //public string RelatedFilesButton { get; set; } = string.Empty;
        [DisplayName("Case Reference")]
        public string CaseReference { get; set; } = string.Empty;
        public ButtonRow ViewQuoteBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("View Quote","View Quote","","Blue",""),
            },
            ButtonType = "Header"
        };
        //[DisplayName("View Quote (Button)")]
        //public string ViewQuoteButton { get; set; } = string.Empty;
        public string[] Split { get; set; } = new string[] { "Yes", "No" };
        [DisplayName("File Status")]
        public string[] FileStatus { get; set; } = new string[] { "Hold", "Insufficient", "Invoiced", "Reported", "Complete", "In Progress", "Scheduled" };

        public ButtonRow FileFolderBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("File Folder","File Folder","folder","Blue",""),
            },
            ButtonType = "Header"
        };
        //[DisplayName("File Folder (Button)")]
        //public string FileFolderButton { get; set; } = string.Empty;
        [DisplayName("File Segments")]
        public string FileSegments { get; set; } = string.Empty;

        public ButtonRow PickSegmentsBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Pick Segments","Pick Segments","","orange",""),
            },
            ButtonType = "Header",
            AssociatedInput = "Segments"
        };

        public string[][] headerView { get; set; } = new string[][] { ["", "EntityID"], ["", "FileBarcode"], ["", "RelatedFilesBtnRow"],  ["", "ViewQuoteBtnRow"],
        ["", "CaseReference"], ["", "Split"], ["", "FileStatus"], ["", "FileFolderBtnRow"], ["", "FileSegments"], ["", "PickSegmentsBtnRow"]};
    }
}
