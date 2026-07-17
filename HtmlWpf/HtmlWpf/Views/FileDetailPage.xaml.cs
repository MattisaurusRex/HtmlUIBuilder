using System.Linq;
using System.Windows.Controls;
using HtmlWpf.Models.Details;
using HtmlWpf.Models.Details.Files;
using HtmlWpf.Services;

namespace HtmlWpf.Views
{
    /// <summary>
    /// File detail screen (ported from Views/Files/Details.cshtml): header panel
    /// plus one tab per detail tab item, all laid out in FileDetailPage.xaml.
    /// Navigation parameter: the file id.
    /// </summary>
    public partial class FileDetailPage : Page, INavigable
    {
        public FileDetailHeader Detail { get; private set; } = new();
        public FileDetailCustomer CustomerTab { get; private set; } = new();
        public FileDetailProperties PropertiesTab { get; private set; } = new();
        public FileDetailPatient PatientTab { get; private set; } = new();
        public FileDetailSections SectionsTab { get; private set; } = new();
        public FileDetailNotes NotesTab { get; private set; } = new();
        public FileDetailInfo InfoTab { get; private set; } = new();
        public FileDetailAttachments AttachmentsTab { get; private set; } = new();

        public string EntityIdText => Detail.EntityID.ToString();
        public string ReceivedPagesText => PropertiesTab.ReceivedPages.ToString();

        public FileDetailPage()
        {
            InitializeComponent();
        }

        public void OnNavigatedTo(object? parameter)
        {
            Detail = SampleDataService.GetFileDetail((int)parameter!);
            CustomerTab = Tab<FileDetailCustomer>();
            PropertiesTab = Tab<FileDetailProperties>();
            PatientTab = Tab<FileDetailPatient>();
            SectionsTab = Tab<FileDetailSections>();
            NotesTab = Tab<FileDetailNotes>();
            InfoTab = Tab<FileDetailInfo>();
            AttachmentsTab = Tab<FileDetailAttachments>();
            // Set last so every Binding sees the loaded data (the WinUI page
            // called Bindings.Update() here instead).
            DataContext = this;
            DetailTabs.SelectedIndex = 0;
        }

        private T Tab<T>() where T : class, IDetailTabItem, new()
        {
            return Detail.DetailTabItems.OfType<T>().FirstOrDefault() ?? new T();
        }
    }
}
