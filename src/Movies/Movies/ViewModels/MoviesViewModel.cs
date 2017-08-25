using System.Threading.Tasks;
using Movies.ViewModels.Base;
using Movies.Services.Movies;
using System.Collections.ObjectModel;
using Movies.Models.Movie;
using Xamarin.Forms;

namespace Movies.ViewModels
{
    public class MoviesViewModel : ViewModelBase
    {
        private ObservableCollection<Movie> _movies;

        private IMoviesService _moviesService;

        public MoviesViewModel(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set
            {
                _movies = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

           var movies = await _moviesService.GetPopularAsync();
            Movies = new ObservableCollection<Movie>(movies.Results);
            MessagingCenter.Send(this, AppSettings.MoviesMessage, Movies as object);

            IsBusy = false;
        }
    }
}