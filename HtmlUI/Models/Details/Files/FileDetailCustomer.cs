using HtmlUI.Models.Buttons;
using HtmlUI.Models.Search;
using System.ComponentModel;

namespace HtmlUI.Models.Details.Files
{
    public class FileDetailCustomer : IDetailTabItem
    {
        public int PK { get; set; }
        public int HeaderPK { get; set; }
        public string Type { get; set; } = "File"; //gotten from schema name?
        public string PageHeading { get; set; } = "Customer";
        public string iconType { get; set; } = "customer";

        [DisplayName("Job Number")]
        public string JobNo { get; set; } = string.Empty;
        
        public ButtonRow SampleCustomerJobBtnRow { get; set; } = new ButtonRow() 
        { 
            Buttons = new List<Button>()
            {
                new Button("Assign To Job","","binoculars","Purple",""),
                new Button("Create Job","","plus-one","Purple","")
            },
            ButtonType = "Detail",
            AssociatedInput = "JobNo"
        };
        
        [DisplayName("Job Date")]
        public DateTime JobDate { get; set; }
        public IEnumerable<Customer> Customer { get; set; } = new List<Customer>() { new Customer() };

        [DisplayName("Delivery Method")]
        public string[] DeliveryMethod { get; set; } = new string[] { "eMail", "Fax", "Post", "Folder" };
        [DisplayName("Report As Job")]
        public bool ReportAsJob { get; set; } = false;
        [DisplayName("Delivery Destination")]
        public string DeliveryDestination { get; set; } = string.Empty;

        public ButtonRow FollowUpEmailBtnRow { get; set; } = new ButtonRow()
        {
            Buttons = new List<Button>()
            {
                new Button("Follow Up Email","Follow Up Email","email","white","")               
            },
            ButtonType = "Detail"
        };
        //[DisplayName("Follow up email (Button)")]
        //public string FollowUpEmailButton { get; set; } = string.Empty;
        [DisplayName("Quote ID")]
        public string QuoteID { get; set; } = string.Empty;
        [DisplayName("Follow Up Sent")]
        public bool FollowUpSent { get; set; } = false;
        public int HeadingsColumnsNo { get; set; } = 1;        
        public int FormColumnsPerHeading { get; set; } = 1;        
        public string[][] Headings { get; set; } = new string[][] { ["", "JobNo"], ["", "SampleCustomerJobBtnRow"], ["", "JobDate"], 
        ["", "Customer"], ["", "DeliveryMethod"], ["", "ReportAsJob"], ["", "DeliveryDestination"], ["", "QuoteID"], ["", "FollowUpEmailBtnRow"], 
        ["", "FollowUpSent"] }; 

    }

}
