namespace HtmlUI.Models.Buttons
{
    public class ButtonRow
    {
        public List<Button> Buttons { get; set; }
        public string ButtonType { get; set; } //lookup table? submit, view, detail, detailHeader
        public string AssociatedInput { get; set; } = string.Empty;
    }
}
