using System.Collections.Generic;
using System.ComponentModel;
using HtmlWpf.Models.Buttons;
using HtmlWpf.Models.Notes;

namespace HtmlWpf.Models.Details.Files
{
    public class FileDetailNotes : IDetailTabItem
    {
        public int PK { get; set; }
        public int HeaderPK { get; set; }

        public string PageHeading { get; set; } = "Notes";
        public int FormColumnsPerHeading { get; set; } = 1;
        public int HeadingsColumnsNo { get; set; } = 1;
        public string Type { get; set; } = "File";
        public string IconType { get; set; } = "notes";
        [DisplayName("File Notes")]
        public IEnumerable<FileNoteView> FileNotes { get; set; } = new List<FileNoteView>() { new FileNoteView() };

        public ButtonRow FileNotesBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Add File Note", "Add File Note", "sticky-notes", "white", "")
            },
            ButtonType = "Detail"
        };
        [DisplayName("Quotation Notes")]
        public IEnumerable<QuotationNoteView> QuotationNotes { get; set; } = new List<QuotationNoteView>() { new QuotationNoteView() };
        [DisplayName("Collection Notes")]
        public IEnumerable<CollectionNoteView> CollectionNotes { get; set; } = new List<CollectionNoteView>() { new CollectionNoteView() };
        public ButtonRow FileNotesReportBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Notes Report", "Notes Report", "email", "blue", "")
            },
            ButtonType = "Detail"
        };

        public string[][] Headings { get; set; } = new string[][] { ["File notes", "FileNotes"], ["File notes", "FileNotesBtnRow"],
        ["Quotation notes", "QuotationNotes"], ["Collection notes", "CollectionNotes"], ["Collection notes", "FileNotesReportBtnRow"] };
    }
}
