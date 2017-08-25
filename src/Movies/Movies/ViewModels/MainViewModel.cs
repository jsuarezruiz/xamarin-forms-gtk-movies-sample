using Movies.Services.Navigation;
using Movies.ViewModels.Base;
using System.Threading.Tasks;

namespace Movies.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private MenuViewModel _menuViewModel;
        private HomeViewModel _homeViewModel;

        private INavigationService _navigationService;

        public MainViewModel(
            INavigationService navigationService, 
            MenuViewModel menuViewModel,
            HomeViewModel homeViewModel)
        {
            _navigationService = navigationService;
            _menuViewModel = menuViewModel;
            _homeViewModel = homeViewModel;
        }

        public MenuViewModel MenuViewModel
        {
            get
            {
                return _menuViewModel;
            }

            set
            {
                _menuViewModel = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel HomeViewModel
        {
            get
            {
                return _homeViewModel;
            }

            set
            {
                _homeViewModel = value;
                OnPropertyChanged();
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAll
                (
                    _menuViewModel.InitializeAsync(navigationData),
                    _navigationService.NavigateToAsync<HomeViewModel>()
                );
        }
    }
}