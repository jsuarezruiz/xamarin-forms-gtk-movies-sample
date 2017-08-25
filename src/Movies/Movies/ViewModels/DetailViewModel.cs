using Movies.ViewModels.Base;
using System.Threading.Tasks;
using Movies.Models.Movie;
using Movies.Services.Movies;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Movies.Services.Navigation;
using System;

namespace Movies.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        private Movie _movie;
        private ObservableCollection<MovieCastMember> _casting;
        private string _video;

        private INavigationService _navigationService;
        private IMoviesService _moviesService;

        public DetailViewModel(
            INavigationService navigationService,
            IMoviesService moviesService)
        {
            _navigationService = navigationService;
            _moviesService = moviesService;
        }

        public Movie Movie
        {
            get { return _movie; }
            set
            {
                _movie = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MovieCastMember> Casting
        {
            get { return _casting; }
            set
            {
                _casting = value;
                OnPropertyChanged();
            }
        }

        public string Video
        {
            get { return _video; }
            set
            {
                _video = value;
                OnPropertyChanged();
            }
        }

        public ICommand PlayCommand => new Command(Play);
        public ICommand HomepageCommand => new Command(HomepageAsync);
        public ICommand PeopleDetailCommand => new Command<MovieCastMember>(PeopleDetailAsync);

        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData is Movie)
            {
                IsBusy = true;

                var movie = (Movie)navigationData;
                Movie = await _moviesService.FindByIdAsync(movie.Id);
                var credits = await _moviesService.GetCreditsAsync(movie.Id);
                Casting = new ObservableCollection<MovieCastMember>(credits.CastMembers.Take(10));
                var videos = await _moviesService.GetVideosAsync(movie.Id);

                if (videos.Videos.Any())
                {
                    var video = videos.Videos.First();
                    Video = string.Format("{0}{1}", AppSettings.YouTubeUrl, video.Key);
                }

                IsBusy = false;
            }
        }

        private void Play()
        {
            if (string.IsNullOrEmpty(Video))
                return;

            Device.OpenUri(new Uri(Video));
        }

        private async void HomepageAsync()
        {
            if (string.IsNullOrEmpty(Movie.Homepage))
            {
                MessagingCenter.Send(this, AppSettings.DialogMessage, "This movie has no active homepage.");

                return;
            }

            await _navigationService.NavigateToAsync<HomepageViewModel>(Movie.Homepage);
        }

        private async void PeopleDetailAsync(object obj)
        {
            var people = obj as MovieCastMember;

            if (people != null)
            {
                await _navigationService.NavigateToAsync<PeopleViewModel>(people);
            }
        }
    }
}