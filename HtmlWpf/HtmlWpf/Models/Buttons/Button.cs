namespace HtmlWpf.Models.Buttons
{
    public class Button
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public string Action { get; set; }

        public Button(string name, string text, string icon, string color, string action)
        {
            Name = name;
            Text = text;
            Icon = icon;
            Color = color;
            Action = action;
        }
    }
}
