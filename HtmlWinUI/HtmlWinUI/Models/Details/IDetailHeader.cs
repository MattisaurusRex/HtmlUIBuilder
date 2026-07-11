using System.Collections.Generic;

namespace HtmlWinUI.Models.Details
{
    public interface IDetailHeader
    {
        public int PK { get; set; }
        public int EntityID { get; set; }
        public IEnumerable<IDetailTabItem> DetailTabItems { get; set; }
        public string EntityType { get; set; }
        /// <summary>Pairs [group, property name] describing the header panel cells, in order.</summary>
        public string[][] HeaderView { get; set; }
    }
}
