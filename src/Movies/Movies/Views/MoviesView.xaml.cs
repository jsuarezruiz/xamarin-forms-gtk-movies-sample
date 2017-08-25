using Movies.Models.Movie;
using Movies.ViewModels;
using Movies.Views.Templates;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Movies.Views
{
    public partial class MoviesView : ContentPage
    {
        public MoviesView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<MoviesViewModel, object>(this, AppSettings.MoviesMessage, (sender, arg) =>
            {
                var movies = arg as ObservableCollection<Movie>;
                foreach (var movie in movies)
                {
                    var movieItemTemplate = new MovieBannerItemTemplate();
                    movieItemTemplate.BindingContext = movie;

                    WrapLayout.Children.Add(movieItemTemplate);
                }
            });

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<MoviesViewModel, object>(this, AppSettings.MoviesMessage);

            base.OnDisappearing();
        }
    }
}