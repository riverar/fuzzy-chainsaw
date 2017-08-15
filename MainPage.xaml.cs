using System.ComponentModel;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;

namespace fuzzy_chainsaw
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Rect ViewSize
        {
            get
            {
                return ApplicationView.GetForCurrentView().VisibleBounds;
            }
        }

        public MainPage()
        {
            this.DataContext = this;
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().VisibleBoundsChanged += (_, __) =>
            {
                RaisePropertyChanged("ViewSize");
            };
        }

        public void RaisePropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
