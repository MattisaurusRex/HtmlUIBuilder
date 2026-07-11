using System;
using System.Collections.Generic;
using System.ComponentModel;
using HtmlWinUI.Models.Buttons;

namespace HtmlWinUI.Models.Details.Files
{
    public class FileDetailPatient : IDetailTabItem
    {
        public int PK { get; set; }
        public int HeaderPK { get; set; }

        public string PageHeading { get; set; } = "Patient";
        public int FormColumnsPerHeading { get; set; } = 2;
        public int HeadingsColumnsNo { get; set; } = 1;
        public string Type { get; set; } = "File";
        public string IconType { get; set; } = "man";
        public string PatientID { get; set; } = string.Empty;
        public ButtonRow FilePatientIDBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Search Patient", "", "telescope-look", "purple", ""),
                new Button("Auto Select Anon", "", "smile", "purple", ""),
                new Button("Use Barcode As Patient Name", "", "barcode-search", "purple", "")
            },
            ButtonType = "Detail",
            AssociatedInput = "PatientID"
        };

        public string Forename { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string NI { get; set; } = string.Empty;
        public string Passport { get; set; } = string.Empty;
        [DisplayName("Driving Licence")]
        public string DrivingLicence { get; set; } = string.Empty;
        public string ID4 { get; set; } = string.Empty;
        [DisplayName("Difficult Patient")]
        public bool DifficultPatient { get; set; } = false;

        public string[][] Headings { get; set; } = new string[][] { ["", "PatientID"], ["", "Forename"], ["", "Surname"], ["", "Gender"], ["", "DOB"], ["", "NI"],
        ["", "Passport"], ["", "DrivingLicence"], ["", "ID4"], ["", "DifficultPatient"] };
    }
}
