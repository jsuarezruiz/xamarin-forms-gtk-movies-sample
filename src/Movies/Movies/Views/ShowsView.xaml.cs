using Movies.Models.TVShow;
using Movies.ViewModels;
using Movies.Views.Templates;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Movies.Views
{
    public partial class ShowsView : ContentPage
    {
        public ShowsView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<ShowsViewModel, object>(this, AppSettings.ShowsMessage, (sender, arg) =>
            {
                var shows = arg as ObservableCollection<TVShow>;
                foreach (var show in shows)
                {
                    var showItemTemplate = new ShowBannerItemTemplate();
                    showItemTemplate.BindingContext = show;

                    WrapLayout.Children.Add(showItemTemplate);
                }
            });

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<ShowsViewModel, object>(this, AppSettings.ShowsMessage);

            base.OnDisappearing();
        }
    }
}