using System.Threading.Tasks;
using Movies.ViewModels.Base;
using Movies.Services.Navigation;

namespace Movies.ViewModels
{
    public class SplashViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public SplashViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await _navigationService.NavigateToAsync<MainViewModel>();
        }
    }
}