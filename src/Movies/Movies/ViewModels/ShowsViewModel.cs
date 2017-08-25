using System.Threading.Tasks;
using Movies.ViewModels.Base;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Movies.Models.TVShow;
using Movies.Services.TVShow;

namespace Movies.ViewModels
{
    public class ShowsViewModel : ViewModelBase
    {
        private ObservableCollection<TVShow> _shows;

        private ITVShowService _showsService;

        public ShowsViewModel(ITVShowService showsService)
        {
            _showsService = showsService;
        }

        public ObservableCollection<TVShow> Shows
        {
            get { return _shows; }
            set
            {
                _shows = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

           var shows = await _showsService.GetPopularAsync();
            Shows = new ObservableCollection<TVShow>(shows.Results);
            MessagingCenter.Send(this, AppSettings.ShowsMessage, Shows as object);

            IsBusy = false;
        }
    }
}