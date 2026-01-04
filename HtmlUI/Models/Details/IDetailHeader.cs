namespace HtmlUI.Models.Details
{
    public interface IDetailHeader
    {
        public int PK { get; set; }
        public int EntityID { get; set; }
        public IEnumerable<IDetailTabItem> DetailTabItems { get; set; }
        public string EntityType { get; set; }
        public string[][] headerView { get; set; }
    }
}
