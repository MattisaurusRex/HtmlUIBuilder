using HtmlUI.Models.Buttons;
using System.ComponentModel;

namespace HtmlUI.Models.Details.Files
{
    public class FileDetailMedications : IDetailTabItem
    {
        public int PK { get; set; }
        public int HeaderPK { get; set; }

        public string PageHeading { get; set; } = "Medications";

        public int FormColumnsPerHeading { get; set; } = 1;
        public int HeadingsColumnsNo { get; set; } = 1;
        public string Type { get; set; } = "File"; //gotten from schema name?
        public string iconType { get; set; } = "drugs";


        public ButtonRow MedicationFileBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Medication","Medication","","purple","")
            },
            ButtonType = "Detail"
        };
        public string[][] Headings { get; set; } = new string[][] { ["", "MedicationFileBtnRow"] };

    }
   
}
