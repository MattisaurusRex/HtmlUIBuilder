using System.Linq;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using HtmlWinUI.Models.Details;
using HtmlWinUI.Models.Details.Files;
using HtmlWinUI.Services;

namespace HtmlWinUI.Views
{
    /// <summary>
    /// File detail screen (ported from Views/Files/Details.cshtml): header panel
    /// plus one tab per detail tab item, all laid out in FileDetailPage.xaml.
    /// Navigation parameter: the file id.
    /// </summary>
    public sealed partial class FileDetailPage : Page
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Detail = SampleDataService.GetFileDetail((int)e.Parameter);
            CustomerTab = Tab<FileDetailCustomer>();
            PropertiesTab = Tab<FileDetailProperties>();
            PatientTab = Tab<FileDetailPatient>();
            SectionsTab = Tab<FileDetailSections>();
            NotesTab = Tab<FileDetailNotes>();
            InfoTab = Tab<FileDetailInfo>();
            AttachmentsTab = Tab<FileDetailAttachments>();
            Bindings.Update();
            DetailTabs.SelectedIndex = 0;
        }

        private T Tab<T>() where T : class, IDetailTabItem, new()
        {
            return Detail.DetailTabItems.OfType<T>().FirstOrDefault() ?? new T();
        }
    }
}
