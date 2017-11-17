using Movies.Models.People;
using Movies.ViewModels;
using Movies.Views.Templates;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Movies.Views
{
    public partial class PeopleView : ContentPage
    {
        public PeopleView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<PeopleViewModel, object>(this, AppSettings.ImagesMessage, (sender, arg) =>
            {
                var profiles = arg as ObservableCollection<Profile>;
                foreach (var profile in profiles)
                {
                    var movieItemTemplate = new ImageItemTemplate
                    {
                        BindingContext = profile
                    };

                    var tapGestureRecognizer = new TapGestureRecognizer();

                    tapGestureRecognizer.Tapped += async (s, a) =>
                    {
                        await ((PeopleViewModel)BindingContext).GalleryAsync(profile);
                    };

                    movieItemTemplate.GestureRecognizers.Add(tapGestureRecognizer);

                    WrapLayout.Children.Add(movieItemTemplate);
                }
            });

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<PeopleViewModel, object>(this, AppSettings.ImagesMessage);

            base.OnDisappearing();
        }
    }
}