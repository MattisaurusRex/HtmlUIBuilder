using System.Collections.Generic;
using System.ComponentModel;
using HtmlWinUI.Models.Buttons;

namespace HtmlWinUI.Models.Details.Files
{
    public class FileDetailSections : IDetailTabItem
    {
        public int PK { get; set; }
        public int HeaderPK { get; set; }

        public string PageHeading { get; set; } = "Sections";
        public int FormColumnsPerHeading { get; set; } = 1;
        public int HeadingsColumnsNo { get; set; } = 1;
        public string Type { get; set; } = "File";
        public string IconType { get; set; } = "ruler";

        public IEnumerable<SectionView> Sections { get; set; } = new List<SectionView>() { new SectionView() };
        [DisplayName("Section Notes")]
        public IEnumerable<SectionNoteView> SectionNotes { get; set; } = new List<SectionNoteView>() { new SectionNoteView() };

        public ButtonRow SectionsFileBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Add", "Add", "", "purple", ""),
                new Button("Copy", "Copy", "", "purple", ""),
                new Button("Copy C of F", "Copy C of F", "", "purple", ""),
                new Button("Add Type", "Add Type", "", "purple", ""),
                new Button("Versions", "Versions", "", "purple", ""),
                new Button("Audit trail", "Audit trail", "", "purple", ""),
                new Button("Up-Issue", "Up-Issue", "", "purple", ""),
                new Button("Down-Issue", "Down-", "", "purple", "")
            },
            ButtonType = "Detail"
        };

        [DisplayName("C of F Notes")]
        public string[] COfFNotes { get; set; } = new string[] { string.Empty };

        public ButtonRow SectionsNotesFileBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Spell Check", "", "tick-abc", "blue", ""),
                new Button("Add Note", "Add Note", "", "purple", "")
            },
            ButtonType = "Detail",
            AssociatedInput = "COfFNotes"
        };

        public IEnumerable<TestsView> Tests { get; set; } = new List<TestsView>() { new TestsView() };

        public ButtonRow SectionsTestsFileBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Add Tests", "Add tests", "", "purple", ""),
                new Button("Audit Trail", "Audit trail", "", "purple", "")
            },
            ButtonType = "Detail"
        };

        public string[][] Headings { get; set; } = new string[][] { ["Sections", "Sections"], ["Sections", "SectionNotes"], ["Sections", "SectionsFileBtnRow"],
        ["Sections", "COfFNotes"], ["Sections", "SectionsNotesFileBtnRow"], ["Tests", "Tests"],
        ["Tests", "SectionsTestsFileBtnRow"] };
    }
}
