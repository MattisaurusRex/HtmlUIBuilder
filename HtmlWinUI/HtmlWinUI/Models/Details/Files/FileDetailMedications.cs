using System.Collections.Generic;
using HtmlWinUI.Models.Buttons;

namespace HtmlWinUI.Models.Details.Files
{
    public class FileDetailMedications : IDetailTabItem
    {
        public int PK { get; set; }
        public int HeaderPK { get; set; }

        public string PageHeading { get; set; } = "Medications";

        public int FormColumnsPerHeading { get; set; } = 1;
        public int HeadingsColumnsNo { get; set; } = 1;
        public string Type { get; set; } = "File";
        public string IconType { get; set; } = "drugs";

        public ButtonRow MedicationFileBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Medication", "Medication", "", "purple", "")
            },
            ButtonType = "Detail"
        };
        public string[][] Headings { get; set; } = new string[][] { ["", "MedicationFileBtnRow"] };
    }
}
