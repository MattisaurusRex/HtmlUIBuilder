using System.Collections.Generic;
using HtmlWinUI.Models.Buttons;

namespace HtmlWinUI.Models.Details.Files
{
    public class FileDetailTools : IDetailTabItem
    {
        public int PK { get; set; }
        public int HeaderPK { get; set; }
        public string PageHeading { get; set; } = "Tools";
        public int FormColumnsPerHeading { get; set; } = 1;
        public int HeadingsColumnsNo { get; set; } = 2;
        public string Type { get; set; } = "File";
        public string IconType { get; set; } = "tool-box";
        public ButtonRow FileToolsBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Release File", "Release File", "play", "purple", ""),
                new Button("Copy File", "Copy File", "copy", "purple", ""),
                new Button("Clone File", "Clone File", "copy", "purple", "")
            },
            ButtonType = "Detail"
        };
        public ButtonRow FileToolsAuditBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("View Audit Trail", "View Audit Trail", "clipboard", "purple", ""),
                new Button("C of F Versions", "C of F Versions", "version", "purple", ""),
                new Button("File Actions Report", "File Actions Report", "report", "purple", "")
            },
            ButtonType = "Detail"
        };
        public ButtonRow FileToolsResultsBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Send Results", "(Re)Send Results", "send-email", "orange", "")
            },
            ButtonType = "Detail"
        };
        public ButtonRow FileToolsPapersBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Positive Papers", "Positive Papers", "notes", "blue", "")
            },
            ButtonType = "Detail"
        };
        public ButtonRow FileToolsWIBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("WI Wizard", "1. WI Wizard", "wizard", "green", ""),
                new Button("Convert to PDF", "2. Convert to PDF", "", "blue", ""),
                new Button("Finalise WI", "3. Finalise WI", "copy-red", "blue", ""),
                new Button("Deliver WI", "4. Deliver", "email", "blue", "")
            },
            ButtonType = "Detail"
        };
        public ButtonRow FileToolsIDsBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Update IDs", "Update IDs", "bar-chart", "purple", "")
            },
            ButtonType = "Detail"
        };
        public ButtonRow FileToolsSectionsBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Deleted Sections", "Deleted Sections", "recycle-bin", "blue", "")
            },
            ButtonType = "Detail"
        };
        public ButtonRow FileToolsDeleteBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Delete File", "", "x-button", "blue", "")
            },
            ButtonType = "Detail"
        };

        public string[][] Headings { get; set; } = new string[][] { ["", "FileToolsBtnRow"], ["", "FileToolsAuditBtnRow"], ["", "FileToolsResultsBtnRow"], ["", "FileToolsPapersBtnRow"],
         ["WI Tools", "FileToolsWIBtnRow"],
         ["Update IDs", "FileToolsIDsBtnRow"], ["Sections", "FileToolsSectionsBtnRow"], ["DELETE File", "FileToolsDeleteBtnRow"] };
    }
}
