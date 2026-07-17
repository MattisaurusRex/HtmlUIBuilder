using System.Collections.Generic;
using System.ComponentModel;
using HtmlWpf.Models.Buttons;

namespace HtmlWpf.Models.Details.Files
{
    public class FileDetailAttachments : IDetailTabItem
    {
        public int PK { get; set; }
        public int HeaderPK { get; set; }

        public string PageHeading { get; set; } = "Attachments";
        public int FormColumnsPerHeading { get; set; } = 1;
        public int HeadingsColumnsNo { get; set; } = 1;
        public string Type { get; set; } = "File";
        public string IconType { get; set; } = "paperclip";
        public IEnumerable<AttachmentsView> Attachments { get; set; } = new List<AttachmentsView>() { new AttachmentsView() };
        public ButtonRow SampleAttachmentsBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Attach", "Attach", "paperclip", "brown", ""),
                new Button("Open", "Open", "notes", "green", ""),
                new Button("Deliver", "Deliver", "email", "orange", ""),
                new Button("Popout", "Popout", "arrow-up", "purple", "")
            },
            ButtonType = "Detail"
        };

        [DisplayName("Email Log")]
        public IEnumerable<AttachmentsView> EmailLogSub { get; set; } = new List<AttachmentsView>() { new AttachmentsView() };

        public string[][] Headings { get; set; } = new string[][] { ["", "Attachments"], ["", "SampleAttachmentsBtnRow"], ["", "EmailLogSub"] };
    }
}
