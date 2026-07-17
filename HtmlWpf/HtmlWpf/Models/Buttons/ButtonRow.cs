using System.Collections.Generic;

namespace HtmlWpf.Models.Buttons
{
    public class ButtonRow
    {
        public List<Button> Buttons { get; set; } = new();
        public string ButtonType { get; set; } = string.Empty; // e.g. Header, Detail
        /// <summary>Name of the input property this row is rendered next to ("" = standalone row).</summary>
        public string AssociatedInput { get; set; } = string.Empty;
    }
}
