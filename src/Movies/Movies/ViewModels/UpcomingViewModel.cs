using System.Threading.Tasks;
using Movies.ViewModels.Base;
using Movies.Services.Movies;
using System.Collections.ObjectModel;
using Movies.Models.Movie;
using System.Linq;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Movies.Services.Navigation;

namespace Movies.ViewModels
{
    public class UpcomingViewModel : ViewModelBase
    {
        private ObservableCollection<Movie> _upcoming;

        private IMoviesService _moviesService;
        private INavigationService _navigationService;

        public UpcomingViewModel(
            IMoviesService moviesService,
            INavigationService navigationService)
        {
            _moviesService = moviesService;
            _navigationService = navigationService;
        }

        public ObservableCollection<Movie> Upcoming
        {
            get { return _upcoming; }
            set
            {
                _upcoming = value;
                OnPropertyChanged();
            }
        }

        public ICommand MovieDetailCommand => new Command<Movie>(MovieDetailAsync);

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            var upcoming = await _moviesService.GetUpcomingAsync(2);
            Upcoming = new ObservableCollection<Movie>(
                upcoming.Results
                .Where(d => d.ReleaseDate > DateTime.Today)
                .OrderBy(m => m.ReleaseDate));

            IsBusy = false;
        }

        private async void MovieDetailAsync(object obj)
        {
            var movie = obj as Movie;

            if (movie != null)
            {
                await _navigationService.NavigateToAsync<DetailViewModel>(movie);
            }
        }
    }
}